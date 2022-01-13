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
    public class BgInitial : IBgState
    {
        private static BgInitial _singleton = null;
        public static BgInitial singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new BgInitial();
                }
                return _singleton;
            }
        }
        
        public bool Execute(Bg nowstate, BgContext context)
        {
            string picturePathOrColor = (string)nowstate.picturePathOrColor.Value();
            //色コード
            if(picturePathOrColor[0] == '#')
            {
                //色コードが指定されている場合
                string r = picturePathOrColor.Substring(1, 2);
                string g = picturePathOrColor.Substring(3, 2);
                string b = picturePathOrColor.Substring(5, 2);
                int r_int = System.Convert.ToInt32(r, 16);
                int g_int = System.Convert.ToInt32(g, 16);
                int b_int = System.Convert.ToInt32(b, 16);

                SpriteData.instance.DrawBackGround(new Color((float)r_int/255, (float)g_int /255, (float)b_int /255));                
            }
            else
            {
                //画像パスが指定されている場合
                SpriteData.instance.DrawBackGround(picturePathOrColor);
            }
            int animationNumber = (int)(float)nowstate.animationNumber.Value();
            if (animationNumber == -1) return true;

            BgAnimation animation = new BgAnimation();
            animation.animation = AnimationChecker.ChangeAnimation((int)(float)nowstate.animationNumber.Value());
            context.ChangeState(animation);
            return false;
        }
    }
}
