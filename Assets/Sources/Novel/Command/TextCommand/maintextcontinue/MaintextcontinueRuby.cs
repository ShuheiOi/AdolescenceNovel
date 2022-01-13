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
    public class MaintextcontinueRuby :IMaintextcontinueState
    {
        private int nowTime;
        private int nowTimeRuby;
        private int characterNum;
        private string rubyChara;
        private string rubiedChara;
        private string rubyCharaPrint;
        private string rubiedCharaPrint;
        private int rubyCharaPrint_num;
        private int rubiedCharaPrint_num;
        private float space;
        private string printedStr;
        private int rubyTime=0;
        private static MaintextcontinueRuby _singleton = null;
        public static MaintextcontinueRuby singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new MaintextcontinueRuby();
                }
                return _singleton;
            }
        }
        private void RubyInitial(int characterNum,string text)
        {
            rubiedChara = "";
            rubyChara = "";
            int i;
            for (i = characterNum; ; i++)
            {
                if (text[i] == '/') break;
                rubiedChara += text[i];
                rubiedCharaPrint += "  ";
                Debug.Log(rubiedCharaPrint.Length);
            }
            for (i++; ; i++)
            {
                if (text[i] == ')') break;
                rubyChara += text[i];
            }
            this.characterNum = i + 1;
            this.space = TextData.instance.textbox[ConstData.TextboxMain].text.characterSpacing;
            Debug.Log(space);
            printedStr = TextData.instance.textbox[ConstData.TextboxMain].text.text;
            rubyTime = TextData.instance.textSpeed * rubiedChara.Length / rubyChara.Length;
            rubiedCharaPrint = "";
            rubyCharaPrint = "";
            rubiedCharaPrint_num = 0;
            rubyCharaPrint_num = 0;
        }
        public MaintextcontinueRuby(int characterNum,string text)
        {
            RubyInitial(characterNum, text);
        }
        public string CompleteRuby(int characterNum,string text)
        {
            RubyInitial(characterNum, text);
            string ret = rubyTag(rubiedChara, rubyChara, rubiedChara, rubyChara);
            MaintextcontinueWrite.singleton.characterNum = this.characterNum;
            Initial();
            return ret;
        }
        public string rubyTag(string rubied_all,string ruby_all,string rubiedStr,string rubyStr)
        {
            return TextData.SetRubyOffset(rubiedStr,rubied_all,rubyStr,ruby_all);
        }
        public void Initial()
        {
            rubyTime = 0;
            nowTime = 0;
            nowTimeRuby = 0;
            characterNum = 0;
            space = 0;
            rubyChara = "";
            rubiedChara = "";
            printedStr = "";
            rubiedCharaPrint = "";
            rubyCharaPrint = "";
            rubiedCharaPrint_num = 0;
            rubyCharaPrint_num = 0;
        }
        public MaintextcontinueRuby() { }
        public bool Execute(Maintextcontinue nowstate, MaintextcontinueContext context)
        {

            //Submitが入力された場合に入力待ちまで飛ばす
            if (KeyConfig.instance.CheckSubmit())
            {
                TextData.instance.textbox[ConstData.TextboxMain].text.text = printedStr + rubyTag(rubiedChara, rubyChara, rubiedChara, rubyChara);
                context.ChangeState(new MaintextcontinueSkip());
                MaintextcontinueWrite.singleton.characterNum = characterNum;
                Initial();
                return false;
            }
            //ルビ出力終了
            if (rubyCharaPrint_num == rubyChara.Length && rubiedCharaPrint_num == rubiedChara.Length)
            {
                MaintextcontinueWrite.singleton.characterNum = characterNum;
                context.ChangeState(new MaintextcontinueWrite());
                Initial();
                return false;
            }
            //通常テキストの出力
            if (singleton.nowTime > TextData.instance.textSpeed && rubiedCharaPrint_num < rubiedChara.Length)
            {
                rubiedCharaPrint += rubiedChara[rubiedCharaPrint_num++];
                singleton.nowTime = 0;
            }
            //ルビテキストの出力
            if(singleton.nowTimeRuby > rubyTime && rubyCharaPrint_num < rubyChara.Length)
            {
                rubyCharaPrint += rubyChara[rubyCharaPrint_num++];
                singleton.nowTimeRuby = 0;
            }
            TextData.instance.textbox[ConstData.TextboxMain].text.text = printedStr + rubyTag(rubiedChara, rubyChara, rubiedCharaPrint, rubyCharaPrint);
            singleton.nowTime += (int)(Time.deltaTime * 1000);
            singleton.nowTimeRuby += (int)(Time.deltaTime * 1000);
            return false;
        }
    }
}