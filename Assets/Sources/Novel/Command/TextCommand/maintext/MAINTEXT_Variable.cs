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
namespace AdolescenceNovel
{
    public class MAINTEXT_Variable : IMaintextState
    {
        private static MAINTEXT_Variable _singleton = null;
        public static MAINTEXT_Variable singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new MAINTEXT_Variable();
                }
                return _singleton;
            }
        }
        public bool Execute(Maintext nowstate, MaintextContext context)
        {
            string var_name = "";
            char tmp;
            while ((tmp = ((string)nowstate.text.Value())[MAINTEXT_Write.singleton.characterNum++]) != '}') {
                if (tmp == ' ') continue;
                var_name += tmp;
            }
            string tmpStr = new string(((string)nowstate.text.Value()).ToCharArray());
            tmpStr = tmpStr.Insert(MAINTEXT_Write.singleton.characterNum, $"{VariableData.getValue(var_name).Value()}");
            nowstate.text = new StringValue(tmpStr);
            TextData.instance.textbox[ConstData.TextboxMain].text.text += tmpStr[MAINTEXT_Write.singleton.characterNum++];
            context.ChangeStatus(new MAINTEXT_Write());
            return false;
        }
    }
}