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
using UnityEngine.UI;
using UnityEngine;
using TMPro;
namespace AdolescenceNovel
{
    [System.Serializable]
    public struct ButtonProperty
    {
        [System.NonSerialized]
        public Button button;
        [System.NonSerialized]
        public Image image;
        [System.NonSerialized]
        public TMP_Text text;
        [SerializeField]
        public string contentsText;
        [System.NonSerialized]
        public RectTransform rect;
        [SerializeField]
        public string valueName;
        [SerializeField]
        public float width;
        [SerializeField]
        public float height;
        [SerializeField]
        public float x;
        [SerializeField]
        public float y;
        [SerializeField]
        public string pictureName;
        [SerializeField]
        public string overPictureName;
        [SerializeField]
        public int next;
        [SerializeField]
        public string fileName;
        [SerializeField]
        public string fontName;
        [SerializeField]
        public string overFontName;
    }
}