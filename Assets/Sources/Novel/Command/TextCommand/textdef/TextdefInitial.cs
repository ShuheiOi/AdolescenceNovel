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
    public class TextdefInitial : ITextdefState
    {
        private static TextdefInitial _singleton = null;
        public static TextdefInitial singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new TextdefInitial();
                }
                return _singleton;
            }
        }
        
        public bool Execute(Textdef nowstate, TextdefContext context)
        {
            TextData.instance.textbox.Add(
                (string)nowstate.textboxName.Value(),
                TextData.MakeProperty(
                    (float)nowstate.imageCoordinateX.Value() + (float)nowstate.offsetX.Value(),
                    (float)nowstate.imageCoordinateY.Value() + (float)nowstate.offsetY.Value(),
                    (float)nowstate.textboxWidth.Value(),
                    (float)nowstate.textboxHeight.Value(),
                    (float)nowstate.imageCoordinateX.Value(),
                    (float)nowstate.imageCoordinateY.Value(),
                    (float)nowstate.imageWidth.Value(),
                    (float)nowstate.imageHeight.Value(),
                    (string)nowstate.textboxImagePath.Value(),
                    (string)nowstate.fontName.Value(),
                    (int)(float)nowstate.fontSize.Value()
                )
            );
            return true;
        }
    }
}
