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
    public class MAINTEXT_Write : IMaintextState
    {
        private static MAINTEXT_Write _singleton = null;
        public int characterNum;
        private int nowTime;
        public bool check_return = false;
        public int character_num = -1;
        public int character_now = -1;
        public static MAINTEXT_Write singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new MAINTEXT_Write
                    {
                        characterNum = 0,
                        nowTime = 0,
                    };
                }
                return _singleton;
            }
        }
        public static void Initial()
        {
            singleton.characterNum = 0;
            singleton.character_num = -1;
            singleton.character_now = -1;
            singleton.check_return = false;
        }
        public bool Execute(Maintext nowstate, MaintextContext context)
        {
            string tmpStr = (string)nowstate.text.Value();
            int length = tmpStr.Length;
            bool rubyCheck = false;
            //Submitが入力された場合に入力待ちまで飛ばす
            if (KeyConfig.instance.CheckSubmit() || KeyConfig.instance.CheckNovelSkip())
            {
                context.ChangeStatus(new MAINTEXT_Skip());
            }
            if (singleton.characterNum == length)
            {
                Initial();
                context.ChangeStatus(new MAINTEXT_WaitFinish());
                return false;
            }
            if (singleton.nowTime > TextData.instance.textSpeed)
            {
                bool checkAdd = false;
                bool checkAddChar = false;
                string add_last ="";
                singleton.nowTime = 0;
                Debug.Log(TextData.instance.textbox[ConstData.TextboxMain].text.preferredWidth);
                singleton.character_now++;
                char nowChar = tmpStr[singleton.characterNum++];
                if (!singleton.check_return)
                {
                    singleton.character_num++;
                    if (TextData.instance.textbox[ConstData.TextboxMain].text.preferredWidth + ConstData.instance.text_font_size / 2 > ConstData.instance.text_width)
                    {
                        singleton.check_return = true;
                        if (length - singleton.characterNum > 3)
                        {
                            checkAdd = true;
                            if (ConstData.instance.ContainProhibit(tmpStr[singleton.characterNum]))
                            {
                                checkAddChar = true;
                                add_last += tmpStr[singleton.characterNum];
                            }
                            add_last += '\n';
                        }
                    }
                }
                else
                {
                    if(singleton.character_now > singleton.character_num)
                    {
                        if (length - singleton.characterNum > 3)
                        {
                            checkAdd = true;
                            if (singleton.characterNum != tmpStr.Length)
                            {
                                if (ConstData.instance.ContainProhibit(tmpStr[singleton.characterNum]))
                                {
                                    checkAddChar = true;
                                    add_last += tmpStr[singleton.characterNum];
                                }
                            }
                            add_last += '\n';
                        }
                    }
                }
                switch (nowChar)
                {
                    //入力待ち
                    case '@':
                        context.ChangeStatus(new MAINTEXT_Wait());
                        break;
                    case '(':
                        rubyCheck = true;
                        break;
                    case '{':
                        context.ChangeStatus(new MAINTEXT_Variable());
                        break;
                    case '\n':
                        character_now = 0;
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar;
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += TextData.SetRubyOffset_Vertical();
                        break;
                    default:
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar+ TextData.SetRubyOffset_Vertical();
                        break;
                }
                if (checkAdd)
                {
                    singleton.character_now = 0;
                    TextData.instance.textbox[ConstData.TextboxMain].text.text += add_last;
                    if (checkAddChar)
                    {
                        singleton.characterNum++;
                    }
                }
                if (rubyCheck)
                {
                    context.ChangeStatus(new MAINTEXT_Ruby(singleton.characterNum, tmpStr));
                }
            }
            singleton.nowTime += (int)(Time.deltaTime * 1000);
            return false;
        }
    }
}