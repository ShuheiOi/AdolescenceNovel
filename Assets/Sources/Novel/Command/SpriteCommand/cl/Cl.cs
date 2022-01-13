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
    public class Cl : SpriteCommand
    {
        //表示位置
        public IValue place;

        //アニメーション番号
        public IValue animationNum;

        //アニメーション時間
        public IValue animationTime;

        //状態を表す変数
        private IClContext state;
        
        //全ての引数が与えられる場合
        public Cl(IValue place,IValue animationNum,IValue animationTime)
        {
            this.place = place;
            this.animationNum = animationNum;
            this.animationTime = animationTime;
            state = new ClContext();
        }

        //時間だけが省略された場合
        public Cl(IValue place,IValue animationNum)
        {
            this.place = place;
            this.animationNum = animationNum;
            this.animationTime = new NumericValue(0);
            state = new ClContext();
        }

        //アニメーション番号も省略された場合
        public Cl(IValue place)
        {
            this.place = place;
            this.animationNum = new NumericValue(-1);
            this.animationTime = new NumericValue(0);
            state = new ClContext();
        }

        //実行用の関数
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}