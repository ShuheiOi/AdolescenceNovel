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
using System;
namespace AdolescenceNovel
{
    [Serializable]
    public class Ld : SpriteCommand
    {
        //表示位置    
        public readonly string place;

        //画像パス/画像名
        public readonly IValue pictureName;

        //アニメーション番号
        public readonly IValue animationNum;

        //アニメーション時間
        public readonly IValue animationTime;

        //状態を表す変数
        private ILdContext state;

        //全ての引数が与えられる場合
        public Ld(IValue place, IValue pictureName, IValue animationNum, IValue animationTime)
        {
            this.place = (string)place.Value();
            this.pictureName = pictureName;
            this.animationNum = animationNum;
            this.animationTime = animationTime;
            state = new LDContext();
        }

        //時間だけが省略された場合
        public Ld(IValue place, IValue pictureName, IValue animationNum)
        {
            this.place = (string)place.Value();
            this.pictureName = pictureName;
            this.animationNum = animationNum;
            this.animationTime = new NumericValue(0f);
            state = new LDContext();
        }

        //アニメーション番号も省略された場合
        public Ld(IValue place, IValue pictureName)
        {
            this.place = (string)place.Value();
            this.pictureName = pictureName;
            this.animationNum = new NumericValue(-1);
            this.animationTime = new NumericValue(0);
            state = new LDContext();
        }

        //取得データ確認用のテストメソッド
        public string TestExecute()
        {
            return $"{place}:{pictureName}:{animationNum}:{animationTime}";
        }

        //実行用の関数
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}