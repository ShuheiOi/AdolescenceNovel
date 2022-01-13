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
    public class Msp : SpriteCommand
    {
        // スプライト名
        public IValue spriteName;
        
        // 移動先X座標
        public IValue destinationX;
        
        // 移動先Y座標
        public IValue destinationY;
        
        
        // 状態を表す変数
        private IMspContext state;
        
        
        // 全ての引数が与えられる場合
        public Msp(IValue spriteName, IValue destinationX, IValue destinationY)
        {
            this.spriteName = spriteName;
            this.destinationX = destinationX;
            this.destinationY = destinationY;
            state = new MspContext();
        }
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
