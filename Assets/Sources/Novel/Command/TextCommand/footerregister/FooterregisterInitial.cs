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
using UnityEngine;
namespace AdolescenceNovel
{
    public class FooterregisterInitial : IFooterregisterState
    {
        private static FooterregisterInitial _singleton = null;
        public static FooterregisterInitial singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new FooterregisterInitial();
                }
                return _singleton;
            }
        }
        
        public bool Execute(Footerregister nowstate, FooterregisterContext context)
        {
            int imageX = 0;
            int imageY = ConstData.original_height - (int)(float)nowstate.imageHeight.Value();
            if(TextData.instance.isFooterRegistered)
            {
                MonoBehaviour.DestroyImmediate(TextData.instance.footer.textbox.gameObject);
            }
            TextData.instance.footer = TextData.MakeProperty(
                // text x, y
                (float)nowstate.offsetX.Value(), (float)nowstate.offsetY.Value(),
                // text width, height: 画面右下隅まで
                ConstData.original_width - (float)nowstate.offsetX.Value(), (float)nowstate.imageHeight.Value() - (float)nowstate.offsetY.Value(),
                // image x, y
                imageX, imageY,
                // image width, height
                ConstData.original_width, (float)nowstate.imageHeight.Value(),
                (string)nowstate.imagePath.Value(), (string)nowstate.fontName.Value(), (int)(float)nowstate.fontSize.Value()
            );
            TextData.instance.footer.text.text = (string)nowstate.content.Value();
            TextData.instance.isFooterRegistered = true;
            return true;
        }
    }
}
