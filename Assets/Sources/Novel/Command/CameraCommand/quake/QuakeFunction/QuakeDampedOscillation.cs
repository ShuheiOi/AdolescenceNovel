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
using System;
namespace AdolescenceNovel
{
    public abstract class QuakeDampedOscillation : IQuakeFunction
    {
        private double constKperPi;
        private double constExpCoeff;
        private double constAlpha;
        private double constXCoeff;
        
        
        protected QuakeDampedOscillation(int shakeSpeedMilliHz, int paramMilliK)
        {
            // K / pi = (k / 1000) / pi
            constKperPi = paramMilliK / (1000 * Math.PI);
            // sin^2 の倍角による追加係数1/2を込める
            constExpCoeff = (1 + constKperPi * constKperPi / 4) / 2;
            constAlpha = Math.Atan(2 / constKperPi);
            // x = constXCoeff * u = pi * (h/1000) * (u/10^{-3-2}) = pi * H * t
            constXCoeff = Math.PI * shakeSpeedMilliHz / (1_000_000 * ConstData.DelayUnitsPerMs);
        }
        
        public float CalculateR(int timeUnits)
        {
            // x = constXCoeff * u
            double x = constXCoeff * timeUnits;
            double exp = Math.Exp(constKperPi * (constAlpha - x));
            double cos = Math.Cos(2 * x);
            // constXCoeff * Exp( (K/pi) * (alpha - x) ) * (1 - cos(2x))
            return (float)(constExpCoeff * exp * (1 - cos));
        }
    }
}