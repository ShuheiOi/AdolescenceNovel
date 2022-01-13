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
    public class Print : SpriteCommand
    {
        // TODO: プロパティを宣言
        // コマンド引数以外でも必要なら自由にここに追加して良い
        // （PrintInitialなどのExecute()の第1引数Print nowstateから参照可能）
        public IValue animationNum;
        public IValue animationTime;
        // // description
        // public string arg;
        
        
        // 状態を表す変数
        private IPrintContext state;


        // TODO: コンストラクタに引数を追加
        // 全ての引数が与えられる場合
        // public Print(IValue arg)
        public Print(IValue animationNum,IValue animationTime)
        {
            // arg.Value(ref this.arg);
            this.animationNum = animationNum;
            this.animationTime = animationTime;
            state = new PrintContext();
        }
        public Print(IValue animationNum)
        {
            // arg.Value(ref this.arg);
            this.animationNum = animationNum;
            this.animationTime = new NumericValue(0);
            state = new PrintContext();
        }

        // TODO: 必要なら引数を省略したときのコンストラクタを同様に追加

        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
