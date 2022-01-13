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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace AdolescenceNovel
{
    public class SaveData
    {
        readonly string path = "";
        public SaveData(string path)
        {
            this.path = Application.streamingAssetsPath + "/" + path + ".txt";
        }
        public void Load()
        {
            StreamReader sr = new StreamReader(path,Encoding.UTF8);
            SystemData.Load(JsonUtility.FromJson<SystemSaveData>(sr.ReadLine()));
            TextData.Load(JsonUtility.FromJson<TextSaveData>(sr.ReadLine()));
            VariableData.Load(JsonUtility.FromJson<VariableSaveData>(sr.ReadLine()));
            JsonUtility.FromJson<SpriteSaveData>(sr.ReadLine());
            JsonUtility.FromJson<ButtonSaveData>(sr.ReadLine());
            sr.Close();
            sr.Dispose();
        }
        public void Save()
        {
            string systemdata = JsonUtility.ToJson(SystemData.instance);
            string textdata = JsonUtility.ToJson(TextData.instance);
            string variabledata = JsonUtility.ToJson(VariableData.instance);
            string spritedata = JsonUtility.ToJson(SpriteData.instance);
            string buttondata = JsonUtility.ToJson(ButtonData.instance);
            StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
            sw.WriteLine(systemdata);
            sw.WriteLine(textdata);
            sw.WriteLine(variabledata);
            sw.WriteLine(spritedata);
            sw.WriteLine(buttondata);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}