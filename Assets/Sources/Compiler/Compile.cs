/*
 * MIT License

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
using System.IO;
using UnityEngine;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
namespace AdolescenceNovel
{
    public class Compile
    {
        private const string AesIV = @"!QAZ2WSX#EDC4RFV";
        private const string AesKey = @"5TGB&YHN7UJM(IK<";
        const int ATTR_CHECK = 1;
        public static bool encryption = true;
        public Compile(List<string> filename)
        {
            StreamReader sr;
            if (!filename.Contains("00.txt"))
            {
                return;
            }
            int num = filename.BinarySearch("00.txt");
            string script_path = $"{Application.streamingAssetsPath}/Source/Script/script.txt";
            //初期コード
            sr = new StreamReader($"{Application.streamingAssetsPath}/Source/{filename[num]}");
            string contents = sr.ReadToEnd();
            //それ以外のコード
            filename.RemoveAt(num);
            foreach (string name in filename)
            {
                sr = new StreamReader($"{Application.streamingAssetsPath}/Source/{name}");
                contents += sr.ReadToEnd() + "\r\n";
                sr.Close();
            }
            string tmp_file_path = $"{Application.streamingAssetsPath}/Source/tmp/tmpinput.txt";
            StreamWriter tmpsw = new StreamWriter(tmp_file_path);
            tmpsw.Write(contents);
            tmpsw.Flush();
            tmpsw.Close();
            string Start_path = "Assets\\StreamingAssets";
            string command_path = $"./Compiler/CompilerExe/execute.exe";
            Process com = Process.Start("cmd.exe", $"/c {Start_path}\\Compiler\\CompilerExe\\execute.exe < {tmp_file_path}");
            while (!com.HasExited) ;
            UnityEngine.Debug.Log("コンソール終了");
            UnityEngine.Debug.Log($"{Start_path}\\Compiler\\CompilerExe\\execute.exe < {tmp_file_path}");
            sr = new StreamReader($"{Application.streamingAssetsPath}/Source/Script/script.txt");
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
            string ret = "";
            while (!sr.EndOfStream)
            {
                ret += sr.ReadLine() + '\n';
            }
            sr.Close();
            byte[] dest = Encoding.Unicode.GetBytes(ret);
            StreamWriter sw = new StreamWriter(script_path);
            string enc = "";
            if (encryption)
            {
                enc = System.Convert.ToBase64String(encrypt.TransformFinalBlock(dest, 0, dest.Length));
            }
            else
            {
                enc = ret;
            }
            sw.WriteLine(enc);
            sw.Flush();
            sw.Close();
            UnityEngine.Debug.Log("コンパイル終了");
        }
        public static List<ICommand> DoCompile()
        {
            string output_name = $"{Application.streamingAssetsPath}/Source/Script/script.txt";
            StreamReader sr = new StreamReader(output_name);

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 128,
                IV = Encoding.UTF8.GetBytes(AesIV),
                Key = Encoding.UTF8.GetBytes(AesKey),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
            string raw = "";
            if (encryption)
            {
                raw = sr.ReadLine();
                byte[] src = System.Convert.FromBase64String(raw);
                ICryptoTransform decrypt = aes.CreateDecryptor();
                raw = Encoding.Unicode.GetString(decrypt.TransformFinalBlock(src, 0, src.Length));
            }
            else
            {
                raw = sr.ReadToEnd();
            }
            List<string> contents = new List<string>();
            foreach(string tmp in raw.Split('\n'))
            {
                contents.Add(tmp);
            }
            sr.Close();
            List<ICommand> ret = new List<ICommand>();
            string[] commandAttr;
            foreach(string content in contents){
                commandAttr = SplitCommandAttr(content);
                switch (commandAttr[0])
                {
                    case "LD":
                        ret.Add(CompiledLD(commandAttr));
                        break;
                    case "CL":
                        ret.Add(CompiledCL(commandAttr));
                        break;
                    case "BG":
                        ret.Add(CompiledBG(commandAttr));
                        break;
                    case "LSP":
                        ret.Add(CompiledLSP(commandAttr));
                        break;
                    case "LSPH":
                        ret.Add(CompiledLSPH(commandAttr));
                        break;
                    case "CHANGESCENE":
                        ret.Add(CompiledSCENECHANGE(commandAttr));
                        break;
                    case "LT":
                        ret.Add(CompiledLT(commandAttr));
                        break;
                    case "LET":
                        ret.Add(CompiledLET(commandAttr));
                        break;
                    case "BGM":
                        ret.Add(CompiledBGM(commandAttr));
                        break;
                    case "BGMSTOP":
                        ret.Add(CompiledBGMSTOP(commandAttr));
                        break;
                    case "SE":
                        ret.Add(CompiledSE(commandAttr));
                        break;
                    case "TEXTOFF":
                        ret.Add(CompiledTEXTOFF(commandAttr));
                        break;
                    case "TEXTON":
                        ret.Add(CompiledTEXTON(commandAttr));
                        break;
                    case "MAINTEXT":
                        ret.Add(CompiledMAINTEXT(commandAttr));
                        break;
                    case "MOVIE":
                        ret.Add(CompiledMOVIE(commandAttr));
                        break;
                    case "BUTTON":
                        ret.Add(CompiledBUTTON(commandAttr));
                        break;
                    case "DEFBUTTON":
                        ret.Add(CompiledDEFBUTTON(commandAttr));
                        break;
                    case "SELECT":
                        ret.Add(CompiledSELECT(commandAttr));
                        break;
                    case "ADD":
                        ret.Add(CompiledADD(commandAttr));
                        break;
                    case "SUB":
                        ret.Add(CompiledSUB(commandAttr));
                        break;
                    case "MUL":
                        ret.Add(CompiledMUL(commandAttr));
                        break;
                    case "DIV":
                        ret.Add(CompiledDIV(commandAttr));
                        break;
                    case "GT":
                        ret.Add(CompiledGT(commandAttr));
                        break;
                    case "COMPARE":
                        ret.Add(CompiledCOMPARE(commandAttr));
                        break;
                    case "NOTCOMPARE":
                        ret.Add(CompiledNOTCOMPARE(commandAttr));
                        break;
                    case "FUNCTION":
                        ret.Add(CompiledFUNCTION(commandAttr));
                        break;
                    case "RETURN":
                        ret.Add(CompiledRETURN(commandAttr));
                        break;
                    case "POP":
                        ret.Add(CompiledPOP(commandAttr));
                        break;
                    case "PUSH":
                        ret.Add(CompiledPUSH(commandAttr));
                        break;
                    case "GOTO":
                        ret.Add(CompiledGOTO(commandAttr));
                        break;
                    case "VSP":
                        ret.Add(CompiledVSP(commandAttr));
                        break;
                    case "CSP":
                        ret.Add(CompiledCSP(commandAttr));
                        break;
                    case "MSP":
                        ret.Add(CompiledMSP(commandAttr));
                        break;
                    case "BGMVOL":
                        ret.Add(CompiledBGMVOL(commandAttr));
                        break;
                    case "QUAKE":
                        ret.Add(CompiledQUAKE(commandAttr));
                        break;
                    case "TEXTDEF":
                        ret.Add(CompiledTEXTDEF(commandAttr));
                        break;
                    case "TEXTSPEED":
                        ret.Add(CompiledTEXTSPEED(commandAttr));
                        break;
                    case "FOOTERON":
                        ret.Add(CompiledFOOTERON(commandAttr));
                        break;
                    case "FOOTEROFF":
                        ret.Add(CompiledFOOTEROFF(commandAttr));
                        break;
                    case "FOOTERREGIST":
                        ret.Add(CompiledFOOTERREGIST(commandAttr));
                        break;
                    case "DELAY":
                        ret.Add(CompiledDELAY(commandAttr));
                        break;
                    case "TEXTWRITE":
                        ret.Add(CompiledTEXTWRITE(commandAttr));
                        break;
                    case "EQ":
                        ret.Add(CompiledEQ(commandAttr));
                        break;
                    case "MOD":
                        ret.Add(CompiledMOD(commandAttr));
                        break;
                    case "SAVE":
                        ret.Add(CompiledSAVE(commandAttr));
                        break;
                    case "LOAD":
                        ret.Add(CompiledLOAD(commandAttr));
                        break;
                    case "RELEASE":
                        ret.Add(CompiledRELEASE(commandAttr));
                        break;
                    case "PRINT":
                        ret.Add(CompiledPRINT(commandAttr));
                        break;
                    case "END":
                        ret.Add(CompiledEND(commandAttr));
                        break;
                }
            }
            return ret;
        }
        static string[] SplitCommandAttr(string content)
        {
            for(int i = 0; i < content.Length; i++)
            {
                if (content[i] != ' ') break;
                content = content.Remove(0, 1);
            }
            List<string> ret = new List<string>();
            string tmp = "";
            for(int i = 0; i < content.Length; i++)
            {
                if(content[i] == '\\')
                {
                    i++;
                    tmp += content[i];
                }
                else if(content[i] == ' ')
                {
                    ret.Add(tmp);
                    tmp = "";
                }
                else
                {
                    tmp += content[i];
                }
            }
            ret.Add(tmp);
            return ret.ToArray();
        }
        static ICommand CompiledLET(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vn":
                    return new Let(new VariableValue(contents[ATTR_CHECK + 1]), new NumericValue(float.Parse(contents[ATTR_CHECK + 2])));
                case "vs":
                    return new Let(new VariableValue(contents[ATTR_CHECK + 1]), new StringValue(contents[ATTR_CHECK + 2]));
                case "vv":
                    return new Let(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
            }
            return null;
        }
        //LDコマンド
        static ICommand CompiledLD(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "psnn":
                    return new Ld(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]),new VariableValue(contents[ATTR_CHECK + 4]));
                case "psn":
                    return new Ld(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
                case "ps":
                    return new Ld(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
            }
            return null;
        }
        //CLコマンド
        static ICommand CompiledCL(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "p":
                    return new Cl(new StringValue(contents[ATTR_CHECK + 1]));
                case "pn":
                    return new Cl(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
                case "pnn":
                    return new Cl(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        //BGコマンド
        static ICommand CompiledBG(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "snn":
                    return new Bg(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
                case "sn":
                    return new Bg(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
                case "s":
                    return new Bg(new VariableValue(contents[ATTR_CHECK + 1]));
                case "cnn":
                    return new Bg(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
                case "cn":
                    return new Bg(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
                case "c":
                    return new Bg(new StringValue(contents[ATTR_CHECK + 1]));

            }
            return null;
        }
        //LSPコマンド
        static ICommand CompiledLSP(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "ssnn":
                    return new Lsp(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]));
                case "ssnnb":
                    return new Lsp(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]));
            }
            return null;
        }
        //LSPHコマンド
        static ICommand CompiledLSPH(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "ssnn":
                    return new Lsph(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]));
                case "ssnnb":
                    return new Lsph(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]));
            }
            return null;
        }
        //SCENECHANGEコマンド
        static ICommand CompiledSCENECHANGE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Changescene(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledEQ(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Equal(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledMOD(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Mod(new VariableValue(contents[ATTR_CHECK+1]), new VariableValue(contents[ATTR_CHECK+2]), new VariableValue(contents[ATTR_CHECK+3]));
            }
            return null;
        }
        static ICommand CompiledLT(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Less(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledBGM(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Bgm(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledBGMSTOP(string[] contents)
        {
            return new Bgmstop();
        }
        static ICommand CompiledSE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Se(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledTEXTOFF(string[] contents)
        {
            if (contents.Length == 1)
            {
                return new Textoff();
            }
            switch (contents[ATTR_CHECK])
            {
                case "p":
                    return new Textoff(new StringValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledTEXTON(string[] contents)
        {
            if (contents.Length == 1)
            {
                return new Texton();
            }
            switch (contents[ATTR_CHECK])
            {
                case "p":
                    return new Texton(new StringValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledMAINTEXT(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Maintext(new StringValue(contents[ATTR_CHECK + 1]));
                case "ss":
                    return new Maintext(new StringValue(contents[ATTR_CHECK + 2]), new StringValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledMOVIE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Movie(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledBUTTON(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "pnnsn":
                    return new ButtonCommand(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new NumericValue(float.Parse(contents[ATTR_CHECK + 5])));
            }
            return null;
        }
        static ICommand CompiledDEFBUTTON(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "snns":
                    return new Defbutton(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK+2]) ,new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]));
                case "snnss":
                    return new Defbutton(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]));
                case "snnssss":
                    return new Defbutton(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]), new VariableValue(contents[ATTR_CHECK + 6]), new VariableValue(contents[ATTR_CHECK + 7]));
            }
            return null;
        }
        static ICommand CompiledSELECT(string[] contents)
        {
            if (contents.Length == 1)
            {
                return new Select();
            }
            List<IValue> args = new List<IValue>();
            switch (contents[ATTR_CHECK])
            {
                case "vs":
                    for(int i= ATTR_CHECK + 2; i<contents.Length; i++)
                    {
                        args.Add(new VariableValue(contents[i]));
                    }
                    return new Select(new StringValue(contents[ATTR_CHECK + 1]),args);
            }
            return null;
        }
        static ICommand CompiledADD(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Add(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledGT(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Greater(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledCOMPARE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vn":
                    return new Compare(new VariableValue(contents[ATTR_CHECK + 1]), new NumericValue(float.Parse(contents[ATTR_CHECK + 2])));
            }
            return null;
        }
        static ICommand CompiledNOTCOMPARE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vn":
                    return new Notcompare(new VariableValue(contents[ATTR_CHECK + 1]), new NumericValue(float.Parse(contents[ATTR_CHECK + 2])));
            }
            return null;
        }
        static ICommand CompiledFUNCTION(string[] contents)
        {
            return new Function();
        }
        static ICommand CompiledRETURN(string[] contents)
        {
            return new Return();
        }
        static ICommand CompiledPUSH(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "v":
                    return new Push(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledPOP(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "v":
                    return new Pop(new StringValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledGOTO(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "n":
                    return new Goto(new StringValue(""), new NumericValue(float.Parse(contents[ATTR_CHECK + 1])));
            }
            return null;
        }
        static ICommand CompiledVSP(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "sn":
                    return new Vsp(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
            }
            return null;
        }
        static ICommand CompiledCSP(string[] contents)
        {
            if(contents.Length == 1)
            {
                return new Csp();
            }
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Csp(new StringValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledMSP(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "snn":
                    return new Msp(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledBGMVOL(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "n":
                    return new Bgmvol(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledQUAKE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "nnn":
                    return new Quake(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
                case "nnnn":
                    return new Quake(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]));
                case "nnnnn":
                    return new Quake(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]));
            }
            return null;
        }
        static ICommand CompiledTEXTDEF(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "ssnnnnnnnnns":
                    return new Textdef(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]), new VariableValue(contents[ATTR_CHECK + 6]), new VariableValue(contents[ATTR_CHECK + 7]), new VariableValue(contents[ATTR_CHECK + 8]), new VariableValue(contents[ATTR_CHECK + 9]), new VariableValue(contents[ATTR_CHECK + 10]), new VariableValue(contents[ATTR_CHECK + 11]), new VariableValue(contents[ATTR_CHECK + 12]));
                case "ssnnnnnnnnn":
                    return new Textdef(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]), new VariableValue(contents[ATTR_CHECK + 6]), new VariableValue(contents[ATTR_CHECK + 7]), new VariableValue(contents[ATTR_CHECK + 8]), new VariableValue(contents[ATTR_CHECK + 9]), new VariableValue(contents[ATTR_CHECK + 10]), new VariableValue(contents[ATTR_CHECK + 11]));
            }
            return null;
        }
        static ICommand CompiledTEXTSPEED(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "n":
                    return new Textspeed(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledFOOTERON(string[] contents)
        {
            return new Footeron();
        }
        static ICommand CompiledFOOTEROFF(string[] contents)
        {
            return new Footeroff();
        }
        static ICommand CompiledFOOTERREGIST(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "ssnsnnn":
                    return new Footerregister(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new VariableValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]), new VariableValue(contents[ATTR_CHECK + 6]), new VariableValue(contents[ATTR_CHECK + 7]));
            }
            return null;
        }
        static ICommand CompiledDELAY(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "n":
                    return new Delay(new VariableValue(contents[ATTR_CHECK + 1]));
            }
            return null;
        }
        static ICommand CompiledTEXTWRITE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vsnss":
                    return new Textwrite(new StringValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]), new StringValue(contents[ATTR_CHECK + 4]), new VariableValue(contents[ATTR_CHECK + 5]));
            }
            return null;
        }
        static ICommand CompiledSAVE(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Save(new VariableValue(contents[ATTR_CHECK+1]));
            }
            return null;
        }
        static ICommand CompiledLOAD(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "s":
                    return new Load(new VariableValue(contents[ATTR_CHECK+1]));
            }
            return null;
        }
        static ICommand CompiledRELEASE(string[] contents)
        {
            return new Release();
        }
        static ICommand CompiledPRINT(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "n":
                    return new Print(new VariableValue(contents[ATTR_CHECK + 1]));
                case "nn":
                    return new Print(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]));
            }
            return null;
        }
        static ICommand CompiledMUL(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Multiply(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledSUB(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Sub(new VariableValue(contents[ATTR_CHECK + 1]), new VariableValue(contents[ATTR_CHECK + 2]), new VariableValue(contents[ATTR_CHECK + 3]));
            }
            return null;
        }
        static ICommand CompiledDIV(string[] contents)
        {
            switch (contents[ATTR_CHECK])
            {
                case "vvv":
                    return new Divide(new VariableValue(contents[ATTR_CHECK+1]), new VariableValue(contents[ATTR_CHECK+2]),new VariableValue(contents[ATTR_CHECK+3]));
            }
            return null;
        }
        static ICommand CompiledEND(string[] contents)
        {
            return new End();
        }
    }
}