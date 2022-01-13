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
    public class Textdef : TextCommand
    {
        // テキスト変数名
        public IValue textboxName;
        
        // テキストボックスの画像パス
        public IValue textboxImagePath;
        
        // x座標
        public IValue imageCoordinateX;
        
        // y座標
        public IValue imageCoordinateY;
        
        // 幅
        public IValue imageWidth;
        
        // 高さ
        public IValue imageHeight;
        
        // オフセットdx
        public IValue offsetX;
        
        // オフセットdy
        public IValue offsetY;
        
        // テキストボックスの幅
        public IValue textboxWidth;
        
        // テキストボックスの高さ
        public IValue textboxHeight;
        
        // フォントの大きさ
        public IValue fontSize;
        
        // フォント名
        public IValue fontName;
        
        
        // 状態を表す変数
        private ITextdefContext state;
        
        
        // 全ての引数が与えられる場合
        public Textdef(
            IValue textboxName,
            IValue textboxImagePath,
            IValue imageCoordinateX,
            IValue imageCoordinateY,
            IValue imageWidth,
            IValue imageHeight,
            IValue offsetX,
            IValue offsetY,
            IValue textboxWidth,
            IValue textboxHeight,
            IValue fontSize,
            IValue fontName)
        {
            this.textboxName = textboxName;
            this.textboxImagePath = textboxImagePath;
            this.imageCoordinateX = imageCoordinateX;
            this.imageCoordinateY = imageCoordinateY;
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.textboxWidth = textboxWidth;
            this.textboxHeight = textboxHeight;
            this.fontSize = fontSize;
            this.fontName = fontName;
            
            state = new TextdefContext();
        }
        
        // フォント名を省略した場合
        public Textdef(
            IValue textboxName,
            IValue textboxImagePath,
            IValue imageCoordinateX,
            IValue imageCoordinateY,
            IValue imageWidth,
            IValue imageHeight,
            IValue offsetX,
            IValue offsetY,
            IValue textboxWidth,
            IValue textboxHeight,
            IValue fontSize)
        {
            this.textboxName = textboxName;
            this.textboxImagePath = textboxImagePath;
            this.imageCoordinateX = imageCoordinateX;
            this.imageCoordinateY = imageCoordinateY;
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            this.textboxWidth = textboxWidth;
            this.textboxHeight = textboxHeight;
            this.fontSize = fontSize;
            fontName = new StringValue(ConstData.instance.text_font);
            
            state = new TextdefContext();
        }
        
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
