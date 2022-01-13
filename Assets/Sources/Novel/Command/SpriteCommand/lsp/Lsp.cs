﻿/*
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
    public class Lsp : SpriteCommand
    {
        //スプライトの変数名
        public readonly IValue spriteName;

        //ロードする画像名
        public readonly IValue pictureName;

        //表示する座標
        public readonly IValue x;
        public readonly IValue y;

        //このスプライトが顔用であるかどうか
        public readonly IValue isFace;

        //状態を表す変数
        private ILspContext state;

        //全ての引数が与えられる場合
        public Lsp(IValue spriteName, IValue pictureName, IValue x, IValue y, IValue isFace)
        {
            this.spriteName = spriteName;
            this.pictureName = pictureName;
            this.x = x;
            this.y = y;
            this.isFace = isFace;
            state = new LspContext();
        }

        //isFaceだけ省略された場合
        public Lsp(IValue spriteName, IValue pictureName, IValue x, IValue y)
        {
            this.spriteName = spriteName;
            this.pictureName = pictureName;
            this.x = x;
            this.y = y;
            this.isFace = new BooleanValue(false);
            state = new LspContext();
        }

        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}