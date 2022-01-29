/*
MIT License

Copyright (c) 2022 ShuheiOi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Runtime.Serialization;
namespace AdolescenceNovel
{
    public class SystemData : MonoBehaviour
    {
        private static SystemData _instance = null;

        [SerializeField]
        private int now;
        [SerializeField]
        private string nowFile;
        [SerializeField]
        private bool stop;

        [SerializeField]
        private bool usingAnotherScene = false;

        // 後で外部ファイルで設定できるようにする
        [System.NonSerialized]
        public Hashtable Volume = new Hashtable
        {
            ["Master"] = 0.5f,
            ["Se"] = 0.5f,
            ["Bgm"] = 0.5f,
            ["Test"] = 0.1f,
        };

        public void ChangeScene()
        {
            instance.usingAnotherScene = !instance.usingAnotherScene;
        }

        public bool CheckUsingScene()
        {
            return instance.usingAnotherScene;
        }

        public void CheckKey()
        {
            foreach(KeyValuePair<string,string> tmp in ConstData.instance.KeyCheck)
            {
                if (KeyConfig.instance.CheckKey(tmp.Key))
                {
                    ChangeScene();
                    UnityEngine.SceneManagement.SceneManager.LoadScene(tmp.Value, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                }
            }
        }

        [System.NonSerialized]
        public List<ICommand> command = new List<ICommand>();

        public Dictionary<string, FlagData> labels;

        public static SystemData instance
        {
            get
            {
                if (!_instance)
                {
                    var go = new GameObject("SystemData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<SystemData>();
                    _instance.command = new List<ICommand>();
                    _instance.now = 0;
                    _instance.nowFile = "";
                    _instance.stop = true;
                }
                return _instance;
            }
        }

        public static void Load(SystemSaveData sysdata)
        {
            _instance.now = sysdata.now;
            _instance.nowFile = sysdata.nowFile;
            _instance.stop = sysdata.stop;
            _instance.usingAnotherScene = sysdata.usingAnotherScene;
        }

        public void ScreenSizeInit()
        {
            Screen.SetResolution(ConstData.instance.width, ConstData.instance.height, false);
        }

        public void ScreenSizeChange(int width, int height)
        {
            Screen.SetResolution(width, height, false);
        }

        public bool CheckFinish()
        {
            return _instance.now >= _instance.command.Count;
        }
        public void Execute()
        {
            Debug.Log(instance.now);
            if (instance.CheckFinish()) return;
            if (instance.command[instance.now].Execute(ref instance.now, ref instance.nowFile, ref instance.stop)) instance.now++;
        }

        public void Jump(int now)
        {
            if (now > instance.command.Count) return;
            this.now = now - 1;
        }

        public int GetNowLine()
        {
            return instance.now;
        }

        private void ChangeVolumeTable(string itemName, float newVolume)
        {
            // clampは，この前にやるべきAudioSource.volumeのsetterに任せる
            if (instance.Volume.ContainsKey(itemName))
            {
                instance.Volume[itemName] = newVolume;
            }
        }

        public void ChangeBgmVolume(float newVolume)
        {
            ConstData.instance.bgm.volume = newVolume;
            SystemData.instance.ChangeVolumeTable(ConstData.VolumeBgm, ConstData.instance.bgm.volume);
        }
        public void ChangeSeVolume(float newVolume)
        {
            ConstData.instance.se.volume = newVolume;
            SystemData.instance.ChangeVolumeTable(ConstData.VolumeSe, ConstData.instance.se.volume);
        }
        
    }
    public class SystemSaveData
    {

        [SerializeField]
        public int now;
        [SerializeField]
        public string nowFile;
        [SerializeField]
        public bool stop;

        [SerializeField]
        public bool usingAnotherScene = false;

        // 後で外部ファイルで設定できるようにする
        [System.NonSerialized]
        public Hashtable Volume = new Hashtable
        {
            ["Master"] = 0.5f,
            ["Se"] = 0.5f,
            ["Bgm"] = 0.5f,
            ["Test"] = 0.1f,
        };

        [System.NonSerialized]
        public List<ICommand> command = new List<ICommand>();

        [System.NonSerialized]
        public Dictionary<string, FlagData> labels;

    }
}