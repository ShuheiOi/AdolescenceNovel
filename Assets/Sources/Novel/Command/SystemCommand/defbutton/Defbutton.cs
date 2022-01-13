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
    public class Defbutton : SystemCommand
    {
        public IValue buttonValue;
        public IValue pictureName;
        public IValue width;
        public IValue height;
        public IValue overPictureName;
        public IValue fontName;
        public IValue overFontName;

        private IDefbuttonContext state;
        public Defbutton(IValue buttonValue,IValue width,IValue height, IValue pictureName)
        {
            this.buttonValue = buttonValue;
            this.pictureName = pictureName;
            this.width = width;
            this.height = height;
            this.overPictureName = new StringValue("");
            this.fontName = new StringValue("");
            this.overFontName = new StringValue("");
            state = new DefbuttonContext();
        }
        public Defbutton(IValue buttonValue, IValue width, IValue height, IValue pictureName, IValue overPictureName)
        {
            this.buttonValue = buttonValue;
            this.pictureName = pictureName;
            this.width = width;
            this.height = height;
            this.overPictureName = overPictureName;
            this.fontName = new StringValue("");
            this.overFontName = new StringValue("");
            state = new DefbuttonContext();
        }
        public Defbutton(IValue buttonValue, IValue width, IValue height, IValue pictureName, IValue overPictureName, IValue fontName,IValue overFontName)
        {
            this.buttonValue = buttonValue;
            this.pictureName = pictureName;
            this.width = width;
            this.height = height;
            this.overPictureName = overPictureName;
            this.fontName = fontName;
            this.overFontName = overFontName;
            state = new DefbuttonContext();
        }
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}