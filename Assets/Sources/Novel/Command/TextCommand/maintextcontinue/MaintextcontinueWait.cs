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
    public class MaintextcontinueWait : IMaintextcontinueState
    {
        private static MaintextcontinueWait _singleton = null;
        public static MaintextcontinueWait singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new MaintextcontinueWait();
                }
                return _singleton;
            }
        }
        public bool Execute(Maintextcontinue nowstate, MaintextcontinueContext context)
        {
            if (KeyConfig.instance.CheckSubmit())
            {
                context.ChangeState(new MaintextcontinueWrite());
            }
            return false;
        }
    }
    public class MaintextcontinueWaitFinish : IMaintextcontinueState
    {
        public bool Execute(Maintextcontinue nowstate, MaintextcontinueContext context)
        {
            if (KeyConfig.instance.CheckSubmit() || KeyConfig.instance.CheckNovelSkip())
            {
                context.ChangeState(new MaintextcontinueInitial());
                return true;
            }
            return false;
        }
    }
}