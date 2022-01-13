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
    public class Footerregister : TextCommand
    {
        // 表示する画像名
        public IValue imagePath;
        
        // 表示する文字列
        public IValue content;
        
        // 表示する画像の高さ
        public IValue imageHeight;
        
        // フォント名
        public IValue fontName;
        
        // フォントサイズ
        public IValue fontSize;
        
        // オフセットx座標
        public IValue offsetX;
        
        // オフセットy座標
        public IValue offsetY;
        
        
        // 状態を表す変数
        private IFooterregisterContext state;
        
        
        // 全ての引数が与えられる場合
        public Footerregister(IValue imagePath, IValue content, IValue imageHeight, IValue fontName, IValue fontSize, IValue offsetX, IValue offsetY)
        {
            this.imagePath = imagePath;
            this.content = content;
            this.imageHeight = imageHeight;
            this.fontName = fontName;
            this.fontSize = fontSize;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            
            state = new FooterregisterContext();
        }
        
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
