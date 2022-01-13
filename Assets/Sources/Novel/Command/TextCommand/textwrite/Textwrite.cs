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
    public class Textwrite : TextCommand
    {
        // テキストボックス変数名
        public IValue textboxName;
        
        // テキストボックスに表示させる文字列
        public IValue content;
        
        // フォントサイズ
        public IValue fontSize;
        
        // 文字色R
        public IValue colorR;
        
        // 文字色G
        public IValue colorG;
        
        // 文字色B
        public IValue colorB;
        
        // 文字色A
        public IValue colorA;
        
        // フォント名を指定したか
        public bool fontNameSpecified;
        
        // フォント名
        public IValue fontName;
        
        
        // 状態を表す変数
        private ITextwriteContext state;
        
        
        // RGBA 各個指定, フォント指定あり
        public Textwrite(
            IValue textboxName,
            IValue content,
            IValue fontSize,
            IValue colorR,
            IValue colorG,
            IValue colorB,
            IValue colorA,
            IValue fontName)
        {
            this.textboxName = textboxName;
            this.content = content;
            this.fontSize = fontSize;

            this.colorR = colorR;
            this.colorG = colorG;
            this.colorB = colorB;
            this.colorA = colorA;

            this.fontName = fontName;
            
            fontNameSpecified = true;
            
            state = new TextwriteContext();
        }
        
        // RGBA 各個指定, フォント指定なし
        public Textwrite(
            IValue textboxName,
            IValue content,
            IValue fontSize,
            IValue colorR,
            IValue colorG,
            IValue colorB,
            IValue colorA)
        {
            this.textboxName = textboxName;
            this.content = content;
            this.fontSize = fontSize;

            this.colorR = colorR;
            this.colorG = colorG;
            this.colorB = colorB;
            this.colorA = colorA;

            fontNameSpecified = false;
            
            state = new TextwriteContext();
        }
        
        // RGBA 一括指定, フォント指定あり
        public Textwrite(
            IValue textboxName,
            IValue content,
            IValue fontSize,
            IValue colorRgba,
            IValue fontName)
        {
            this.textboxName = textboxName;
            this.content = content;
            this.fontSize = fontSize;

            // colorRgba.Value(out string rgba);
            string rgba = "";
            rgba = (string)colorRgba.Value();
            int r, g, b, a;
            (r,g,b,a) = ConstData.instance.GetIntRgbaFromString(rgba);
            this.colorA = new NumericValue(a);
            this.colorG = new NumericValue(g);
            this.colorR = new NumericValue(r);
            this.colorB = new NumericValue(b);
            fontNameSpecified = true;
            this.fontName = fontName;
            
            state = new TextwriteContext();
        }
        
        // RGBA 一括指定, フォント指定なし
        public Textwrite(
            IValue textboxName,
            IValue content,
            IValue fontSize,
            IValue colorRgba)
        {
            this.textboxName = textboxName;
            this.content = content;
            this.fontSize = fontSize;

            // colorRgba.Value(out string rgba);
            string rgba = (string)colorRgba.Value();
            int r, g, b, a;
            (r, g, b, a) = ConstData.instance.GetIntRgbaFromString(rgba);
            this.colorA = new NumericValue(a);
            this.colorG = new NumericValue(g);
            this.colorR = new NumericValue(r);
            this.colorB = new NumericValue(b);

            fontNameSpecified = false;
            
            state = new TextwriteContext();
        }
        
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
