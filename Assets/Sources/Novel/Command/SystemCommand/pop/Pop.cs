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
    public class Pop : SystemCommand
    {
        // TODO: プロパティを宣言
        // コマンド引数以外でも必要なら自由にここに追加して良い
        // （PullInitialなどのExecute()の第1引数Pull nowstateから参照可能）
        
        // // description
        public IValue name;
        
        
        // 状態を表す変数
        private IPopContext state;
        
        
        // TODO: コンストラクタに引数を追加
        // 全ての引数が与えられる場合
        // public Pull(IValue arg)
        public Pop(IValue name)
        {
            this.name = name;
            // arg.Value(ref this.arg);
            state = new PopContext();
        }
        
        // TODO: 必要なら引数を省略したときのコンストラクタを同様に追加
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}