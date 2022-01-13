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
    public class QuakeSineCurve : IQuakeFunction
    {
        private double constCoeff;
        public QuakeSineCurve(int shakeSpeedMilliHz)
        {
            constCoeff = Math.PI * 2 / 1_000_000 / ConstData.DelayUnitsPerMs * shakeSpeedMilliHz;
        }
        
        public float CalculateR(int timeUnits)
        {
            // coeff = 2 * 10^{-(6+2)} * pi * h
            // ( 1 - cos(coeff * u) )/2
            double cos = Math.Cos(constCoeff * timeUnits);
            return (float)((1 - cos) / 2);
        }
    }
}