/*
 * MIT License

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
    public class QuakeShaking : IQuakeState
    {
        private static QuakeShaking _singleton = null;
        public static QuakeShaking singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new QuakeShaking();
                    _singleton.elapsedTimeUnits = 0;
                }
                return _singleton;
            }
        }
        
        public int elapsedTimeUnits;
        
        
        public void MoveCamera(float newX, float newY)
        {
            newY *= -1;
            // Debug.LogWarning($"['abebe5', {elapsedTimeUnits}, {newX}, {newY}],");
            ConstData.instance.MainCanvasPictureRectTransform[ConstData.instance.MainPicture].anchoredPosition = new Vector2(newX, newY);
            ConstData.instance.MainCanvasPictureRectTransform[ConstData.instance.BackgroundPicture].anchoredPosition = new Vector2(newX, newY);
        }
        
        public void Initial()
        {
            MoveCamera(0, 0);
            singleton.elapsedTimeUnits = 0;
        }
        
        public bool Execute(Quake nowstate, QuakeContext context)
        {
            int shakeUntilUnits = (int)(float)nowstate.shakeTimeMs.Value() * ConstData.DelayUnitsPerMs;
            int deltaUnits = (int)(Time.deltaTime * 1000 * ConstData.DelayUnitsPerMs);
            elapsedTimeUnits += deltaUnits;
            
            if (elapsedTimeUnits >= shakeUntilUnits
                || KeyConfig.instance.CheckSubmit()
                || KeyConfig.instance.CheckNovelSkip())
            {
                context.ChangeState(new QuakeInitial());
                Initial();
                return true;
            }
            
            float rateRt = nowstate.shakeFunction.CalculateR(elapsedTimeUnits);
            MoveCamera(rateRt * (float)nowstate.shakeDx.Value(), rateRt * (float)nowstate.shakeDy.Value());
            
            return false;
        }
    }
}
