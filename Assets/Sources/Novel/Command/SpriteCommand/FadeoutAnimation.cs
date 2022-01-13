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
    public class FadeoutAnimation : IAnimation
    {
        public bool Animation(ref int nowtime, int animationtime)
        {
            if (nowtime < animationtime)
            {
                if (KeyConfig.instance.CheckSubmit() || KeyConfig.instance.CheckNovelSkip())
                {
                    SpriteData.instance.Flip();
                    ConstData.instance.fade.Range = 0;
                    ConstData.instance.mainCanvasGroup.alpha = 1;
                    ConstData.instance.behindCanvasGroup.alpha = 0;
                    return true;
                }
                ConstData.instance.mainCanvasGroup.alpha = 1.0f - nowtime / (float)animationtime;
                ConstData.instance.behindCanvasGroup.alpha = 1;
                nowtime += (int)(Time.deltaTime * 1000);
                return false;
            }
            else
            {
                SpriteData.instance.Flip();
                ConstData.instance.fade.Range = 0;
                ConstData.instance.mainCanvasGroup.alpha = 1;
                ConstData.instance.behindCanvasGroup.alpha = 0;
            }
            return true;
        }
    }
}