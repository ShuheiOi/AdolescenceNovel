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
    public class Quake : CameraCommand
    {
        // 揺らすx幅
        public IValue shakeDx;
        
        // 揺らすy幅
        public IValue shakeDy;
        
        // 揺らす時間
        public IValue shakeUntilUnits;
        
        // 揺らす速さ
        public IValue shakeSpeedMilliHz;
        
        // 揺らし方の名前
        public IValue shakeFunctionName;

        public IValue shakeTimeMs;

        // 揺らし方の指定
        public IQuakeFunction shakeFunction;
        
        // 状態を表す変数
        private IQuakeContext state;
        
        private void SetShakeFunction()
        {
            string fullClassName = "AdolescenceNovel." + shakeFunctionName;
            Type type = Type.GetType(fullClassName, false, true);
            if (type == null || type.IsAbstract)
            {
                type = Type.GetType("AdolescenceNovel." + ConstData.QuakeDefaultFunction, false, true);
                
                // 万一既定値がおかしい場合
                if (type == null)
                {
                    // TODO: エラーを投げてから終了
                    return;
                }
            }
            
            shakeFunction = (IQuakeFunction)Activator.CreateInstance(type, shakeSpeedMilliHz);
        }
        
        
        // 全ての引数が与えられる場合
        public Quake(IValue shakeDx, IValue shakeDy, IValue shakeTimeMs, IValue shakeSpeedMilliHz, IValue shakeFunctionName)
        {
            this.shakeDx = shakeDx;
            this.shakeDy = shakeDy;
            
            this.shakeTimeMs = shakeTimeMs;

            this.shakeSpeedMilliHz = shakeSpeedMilliHz;
            
            //TODO
            //関数名(string)で指定しない方法がいいと思う

            //shakeFunctionName.Value(ref rawName);
            //this.shakeFunctionName = new StringValue("Quake" + rawName.Replace("_", "").ToLower());
            SetShakeFunction();
            
            state = new QuakeContext();
        }
        
        // 揺らし方の指定を省略した場合
        public Quake(IValue shakeDx, IValue shakeDy, IValue shakeTimeMs, IValue shakeSpeedMilliHz)
        {
            this.shakeDx = shakeDx;
            this.shakeDy = shakeDy;
            
            this.shakeTimeMs = shakeTimeMs;

            this.shakeSpeedMilliHz = shakeSpeedMilliHz;
            
            this.shakeFunctionName = new StringValue(ConstData.QuakeDefaultFunction);
            SetShakeFunction();
            
            state = new QuakeContext();
        }
        
        // 揺らす速さと揺らし方の指定を省略した場合
        public Quake(IValue shakeDx, IValue shakeDy, IValue shakeTimeMs)
        {
            this.shakeDx = shakeDx;
            this.shakeDy = shakeDy;
            
            this.shakeTimeMs = shakeTimeMs;

            this.shakeSpeedMilliHz = new NumericValue(1000);
            shakeFunctionName = new StringValue(ConstData.QuakeDefaultFunction);
            SetShakeFunction();
            
            state = new QuakeContext();
        }
        
        
        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            return state.Execute(this);
        }
    }
}
