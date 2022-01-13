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
    public class SeInitial : ISeState
    {
        private static SeInitial _singleton = null;
        public static SeInitial singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new SeInitial();
                }
                return _singleton;
            }
        }
        public bool Execute(Se nowstate, SeContext context)
        {
            string name = (string)nowstate.soundName.Value();
            try
            {
                ConstData.instance.se.clip = Resources.Load<AudioClip>(name);
                ConstData.instance.se.clip.name = name;
            }
            catch (System.NullReferenceException e)
            {
                string[] check = name.Split('.');
                string last = check[check.Length - 1];
                if (last == "mp3" || last == "wav" || last == "ogg")
                {
                    Debug.LogAssertion("拡張子が原因かもしれません\n拡張子は必要ありません");
                }
                Debug.LogAssertion($"{name}という音声ファイルがない可能性があります");
                Debug.Break();
            }
            ConstData.instance.se.volume = (float)SystemData.instance.Volume[(string)nowstate.volumeTag.Value()];
            ConstData.instance.se.loop = false; // Loopをしない
            ConstData.instance.se.Play();
            return true;
        }
    }
}