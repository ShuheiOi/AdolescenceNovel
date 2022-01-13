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
    public class MaintextcontinueSkip : IMaintextcontinueState
    {
        private static MaintextcontinueSkip _singleton = null;
        public static MaintextcontinueSkip singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new MaintextcontinueSkip();
                }
                return _singleton;
            }
        }
        public bool Execute(Maintextcontinue nowstate, MaintextcontinueContext context)
        {
            string tmpStr = (string)nowstate.text.Value();
            int length = tmpStr.Length;
            for (; MaintextcontinueWrite.singleton.characterNum < length;)
            {
                if (tmpStr[MaintextcontinueWrite.singleton.characterNum] == '@') break;
                if (tmpStr[MaintextcontinueWrite.singleton.characterNum] == '(')
                {
                    MaintextcontinueWrite.singleton.characterNum++;
                    TextData.instance.textbox[ConstData.TextboxMain].text.text += MaintextcontinueRuby.singleton.CompleteRuby(MaintextcontinueWrite.singleton.characterNum, tmpStr);
                    continue;
                }
                if(tmpStr[MaintextcontinueWrite.singleton.characterNum] == '\n')
                {
                    TextData.instance.textbox[ConstData.TextboxMain].text.text += tmpStr[MaintextcontinueWrite.singleton.characterNum++];
                    TextData.instance.textbox[ConstData.TextboxMain].text.text += TextData.SetRubyOffset_Vertical();
                    continue;
                }
                TextData.instance.textbox[ConstData.TextboxMain].text.text += tmpStr[MaintextcontinueWrite.singleton.characterNum++]+ TextData.SetRubyOffset_Vertical();
            }

            context.ChangeState(new MaintextcontinueWrite());
            return false;
        }
    }
}