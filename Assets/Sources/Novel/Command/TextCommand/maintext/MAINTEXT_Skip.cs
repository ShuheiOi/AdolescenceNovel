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
namespace AdolescenceNovel
{
    public class MAINTEXT_Skip : IMaintextState
    {
        private static MAINTEXT_Skip _singleton = null;

        public static MAINTEXT_Skip singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new MAINTEXT_Skip();
                }
                return _singleton;
            }
        }
        public bool Execute(Maintext nowstate, MaintextContext context)
        {
            string tmpStr = (string)nowstate.text.Value();
            int length = tmpStr.Length;
            for (; MAINTEXT_Write.singleton.characterNum < length;)
            {
                bool checkAdd = false;
                bool checkAddChar = false;
                string add_last = "";

                MAINTEXT_Write.singleton.character_now++;
                char nowChar = tmpStr[MAINTEXT_Write.singleton.characterNum++];
                if (!MAINTEXT_Write.singleton.check_return)
                {
                    MAINTEXT_Write.singleton.character_num++;
                    if (TextData.instance.textbox[ConstData.TextboxMain].text.preferredWidth + ConstData.instance.text_font_size / 2 > ConstData.instance.text_width)
                    {
                        MAINTEXT_Write.singleton.check_return = true;
                        if (length - MAINTEXT_Write.singleton.characterNum > 3)
                        {
                            checkAdd = true;
                            if (tmpStr[MAINTEXT_Write.singleton.characterNum] == '、' || tmpStr[MAINTEXT_Write.singleton.characterNum] == '。')
                            {
                                checkAddChar = true;
                                add_last += tmpStr[MAINTEXT_Write.singleton.characterNum];
                            }
                            add_last += '\n';
                            MAINTEXT_Write.singleton.character_now = 0;
                        }
                    }
                }
                else
                {
                    if (MAINTEXT_Write.singleton.character_now > MAINTEXT_Write.singleton.character_num)
                    {
                        if (length - MAINTEXT_Write.singleton.characterNum > 3)
                        {
                            checkAdd = true;
                            if (MAINTEXT_Write.singleton.characterNum != tmpStr.Length)
                            {
                                if (tmpStr[MAINTEXT_Write.singleton.characterNum] == '、' || tmpStr[MAINTEXT_Write.singleton.characterNum] == '。')
                                {
                                    checkAddChar = true;
                                    add_last += tmpStr[MAINTEXT_Write.singleton.characterNum];
                                }
                            }
                            add_last += '\n';
                            MAINTEXT_Write.singleton.character_now = 0;
                        }
                    }
                }
                switch (nowChar)
                {
                    //入力待ち
                    case '@':
                        context.ChangeStatus(new MAINTEXT_Wait());
                        return false;
                    case '(':
                        MAINTEXT_Ruby mr = new MAINTEXT_Ruby(MAINTEXT_Write.singleton.characterNum, tmpStr);
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += mr.CompleteRuby();
                        break;
                    case '{':
                        {
                            char tmp;
                            string var_name = "";
                            while ((tmp = ((string)nowstate.text.Value())[MAINTEXT_Write.singleton.characterNum++]) != '}')
                            {
                                if (tmp == ' ') continue;
                                var_name += tmp;
                            }
                            TextData.instance.textbox[ConstData.TextboxMain].text.text += $"{VariableData.getValue(var_name).Value()}";
                        }
                        break;
                    case '\n':
                        MAINTEXT_Write.singleton.character_now = 0;
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar;
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += TextData.SetRubyOffset_Vertical();
                        break;
                    default:
                        TextData.instance.textbox[ConstData.TextboxMain].text.text += nowChar + TextData.SetRubyOffset_Vertical();
                        break;
                }
                if (checkAdd)
                {
                    TextData.instance.textbox[ConstData.TextboxMain].text.text += add_last;
                    if (checkAddChar)
                    {
                        MAINTEXT_Write.singleton.characterNum++;
                    }
                }
            }
            context.ChangeStatus(new MAINTEXT_Write());
            return false;
        }
    }
}