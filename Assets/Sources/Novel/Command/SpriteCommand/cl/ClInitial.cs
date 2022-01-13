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
    public class ClInitial : IClState
    {
        private static ClInitial _singleton = null;
        public static ClInitial singleton
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new ClInitial();
                }
                return _singleton;
            }
        }
        public bool Execute(Cl nowstate, ClContext context)
        {
            if((string)nowstate.place.Value() == "a")
            {
                foreach(string key in ConstData.instance.PLACE.Keys)
                {
                    SpriteData.instance.DeleteBack($"__{key}");
                }
            }
            else
            {
                SpriteData.instance.DeleteBack($"__{nowstate.place.Value()}");
            }
            //アニメーション番号が省略された場合次に指定されるアニメーションに従う。
            if ((int)(float)nowstate.animationNum.Value() == -1) return true;

            ClAnimation animation = new ClAnimation();
            animation.animation = AnimationChecker.ChangeAnimation((int)(float)nowstate.animationNum.Value());

            context.ChangeStatus(animation);

            return false;
        }
    }
}