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
    class LD_Initial : ILdState
    {
        private static LD_Initial _singleton = null;
        public static LD_Initial singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new LD_Initial();
                }
                return _singleton;
            }
        }
        public bool Execute(Ld nowstate, LDContext context)
        {
            string pictureName = "";
            float animationNum = 0;
            pictureName = (string)nowstate.pictureName.Value();
            animationNum = (float)nowstate.animationNum.Value();
            SpriteData.instance.Draw(pictureName, nowstate.place);
            //アニメーション番号が省略された場合次に指定されるアニメーションに従う。
            if (animationNum == -1) return true;

            LD_Animation animation = new LD_Animation
            {
                animation = AnimationChecker.ChangeAnimation((int)animationNum)
            };

            //StateをLD_Animation状態に変更
            context.ChangeStatus(animation);


            return false;
        }
    }
}