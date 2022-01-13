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
    class LD_Animation : ILdState
    {
        private static LD_Animation _singleton = null;
        public IAnimation animation;

        public int time;

        public static LD_Animation singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new LD_Animation();
                    _singleton.time = 0;
                }
                return _singleton;
            }
        }
        public void Initial()
        {
            singleton.time = 0;
        }
        public bool Execute(Ld nowstate, LDContext context)
        {
            float animationTime = 0;
            animationTime = (float)nowstate.animationTime.Value();
            if(animation.Animation(ref singleton.time, (int)animationTime))
            {
                context.ChangeStatus(new LD_Initial());
                Initial();
                return true;
            }
            return false;
        }
    }
}