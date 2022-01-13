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
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace AdolescenceNovel
{
    public class StaticData
    {
        private const string AesIV = @"!QAZ2WSX#EDC4RFV";
        private const string AesKey = @"5TGB&YHN7UJM(IK<";
        const int ATTR_CHECK = 1;
#if UNITY_EDITOR
        public static bool encryption = false;
#else
        public static bool encryption = true;
#endif
        private static List<string> GlobalDataList = new List<string>();
        public static bool HasData(string name)
        {
            return GlobalDataList.Contains(name);
        }
        public static void AddData(string name)
        {
            GlobalDataList.Add(name);
        }
        public static void Initial()
        {
            GlobalDataList = new List<string>();
            string filename = Application.streamingAssetsPath + "/SaveData/GlobalDataSaveData";
            StreamReader sr;
            try
            {
                sr = new StreamReader(filename);
            }
            catch (FileNotFoundException)
            {
                sr = new StreamReader(File.Create(filename));
                sr.Close();
                return;
            }
            string allStaticData = sr.ReadToEnd();
            if (allStaticData.Length == 0) return;
            if (encryption)
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider
                {
                    BlockSize = 128,
                    KeySize = 128,
                    IV = Encoding.UTF8.GetBytes(AesIV),
                    Key = Encoding.UTF8.GetBytes(AesKey),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform decrypt = aes.CreateDecryptor();
                byte[] src = System.Convert.FromBase64String(allStaticData);
                allStaticData = Encoding.Unicode.GetString(decrypt.TransformFinalBlock(src, 0, src.Length));
            }
            foreach(string staticdata in allStaticData.Split('\n'))
            {
                string data = staticdata;
                Debug.Log(data);
                string[] tmp = data.Split(':');
                if (tmp.Length < 3) continue;
                switch ((IValueType)int.Parse(tmp[1]))
                {
                    case IValueType.Numeric:
                        VariableData.setValue(tmp[0], new NumericValue(float.Parse(tmp[2])));
                        GlobalDataList.Add(tmp[0]);
                        break;
                    case IValueType.Boolean:
                        VariableData.setValue(tmp[0], new BooleanValue(bool.Parse(tmp[2])));
                        GlobalDataList.Add(tmp[0]);
                        break;
                    case IValueType.String:
                        VariableData.setValue(tmp[0], new StringValue(tmp[2]));
                        GlobalDataList.Add(tmp[0]);
                        break;
                    case IValueType.Variable:
                        VariableData.setValue(tmp[0], new VariableValue(tmp[2]));
                        GlobalDataList.Add(tmp[0]);
                        break;
                }
            }
            sr.Close();
        }
        public static void StaticDataLoad(Dictionary<string,IValue> dict)
        {
            string allStaticData = "";
            foreach (string name in GlobalDataList)
            {
                allStaticData += $"{name}:{(int)dict[name].GetValueTypeEnum()}:{dict[name].Value()}\n";
            }
            if (encryption)
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider
                {
                    BlockSize = 128,
                    KeySize = 128,
                    IV = Encoding.UTF8.GetBytes(AesIV),
                    Key = Encoding.UTF8.GetBytes(AesKey),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform encrypt = aes.CreateEncryptor();
                byte[] dest = Encoding.Unicode.GetBytes(allStaticData);
                allStaticData = System.Convert.ToBase64String(encrypt.TransformFinalBlock(dest, 0, dest.Length));
            }
            using (StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/SaveData/GlobalDataSaveData",false))
            {
                sw.WriteLine(allStaticData);
                sw.Flush();
                sw.Close();
            }
        }

    }
}