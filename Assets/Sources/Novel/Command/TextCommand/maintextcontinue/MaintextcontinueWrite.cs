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
    public class MaintextcontinueWrite : IMaintextcontinueState
    {
        private static MaintextcontinueWrite _singleton = null;
        public int characterNum;
        private int nowTime;
        public static MaintextcontinueWrite singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new MaintextcontinueWrite
                    {
                        characterNum = 0,
                        nowTime = 0,
                    };
                }
                return _singleton;
            }
        }
        private static void Initial()
        {
            singleton.characterNum = 0;
        }
        public bool Execute(Maintextcontinue nowstate, MaintextcontinueContext context)
        {
            string tmpStr = (string)nowstate.text.Value();
            //Submitが入力された場合に入力待ちまで飛ばす
            if (KeyConfig.instance.CheckSubmit() || KeyConfig.instance.CheckSubmit())
            {
                context.ChangeState(new MaintextcontinueSkip());
            }
            if (singleton.characterNum == tmpStr.Length)
            {
                Initial();
                context.ChangeState(new MaintextcontinueWaitFinish());
                return false;
            }
            if (singleton.nowTime > TextData.instance.textSpeed)
            {
                singleton.nowTime = 0;
                char nowChar = tmpStr[singleton.characterNum++];
                switch (nowChar)
                {
                    //入力待ち
                    case '@':
                        context.ChangeState(new MaintextcontinueWait());
                        break;
                    case '(':
                        context.ChangeState(new MaintextcontinueRuby(singleton.characterNum, tmpStr));
                        break;
                    case '\n':
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar;
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += TextData.SetRubyOffset_Vertical();
                        break;
                    default:
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar+ TextData.SetRubyOffset_Vertical();
                        break;
                }
            }
            singleton.nowTime += (int)(Time.deltaTime * 1000);
            return false;
        }
    }
}