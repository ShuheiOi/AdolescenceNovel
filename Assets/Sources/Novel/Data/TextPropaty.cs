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
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.Serialization;
namespace AdolescenceNovel
{
    [System.Serializable]
    public struct TextProperty
    {
        [SerializeField]
        public TMP_Text text;
        [SerializeField]
        public Image textbox;

        [SerializeField]
        public float text_x;
        [SerializeField]
        public float text_y;
        [SerializeField]
        public float text_width;
        [SerializeField]
        public float text_height;

        [SerializeField]
        public float image_x;
        [SerializeField]
        public float image_y;
        [SerializeField]
        public float image_width;
        [SerializeField]
        public float image_height;

        [SerializeField]
        public string textboxImage;
        [SerializeField]
        public string font;
    }
}