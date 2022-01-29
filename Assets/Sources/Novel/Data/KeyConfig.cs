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
using UnityEngine;
namespace AdolescenceNovel
{
    public class KeyConfig : MonoBehaviour
    {
        private static KeyConfig _instance;
        public static KeyConfig instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("KeyConfig");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<KeyConfig>();
                }
                return _instance;
            }
        }
        [System.NonSerialized]
        public string SubmitKey = "Submit";

        [System.NonSerialized]
        public string CancelKey = "Cancel";

        [System.NonSerialized]
        public string NovelSkipKey = "NovelSkip";

        [System.NonSerialized]
        public string UpKey = "Up";

        [System.NonSerialized]
        public string DownKey = "Down";

        //Submitkeyが押された
        public bool CheckSubmit()
        {
            return Input.GetButtonDown(instance.SubmitKey);
        }

        //CancelKeyが押された
        public bool CheckCancel()
        {
            return Input.GetButtonDown(instance.CancelKey);
        }

        public bool CheckNovelSkip()
        {
            return Input.GetButtonDown(instance.NovelSkipKey) | Input.GetButton(instance.NovelSkipKey);
        }

        //↑キーが押された
        public bool CheckUp()
        {
            return Input.GetButtonDown(instance.UpKey);
        }

        //↓キーが押された
        public bool CheckDown()
        {
            return Input.GetButtonDown(instance.DownKey);
        }

        public bool CheckKey(string str)
        {
            return Input.GetButtonDown(str);
        }
    }
}