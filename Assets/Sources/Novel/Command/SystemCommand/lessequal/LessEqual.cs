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
    public class LessEqual : SystemCommand
    {
        private readonly IValue a;
        private readonly IValue b;
        private readonly VariableValue variable;

        private ILessEqualCalculate state;

        public LessEqual(IValue a,IValue b,VariableValue variable)
        {
            this.a = a;
            this.b = b;
            this.variable = variable;
        }

        public override bool Execute(ref int now, ref string nowFile, ref bool stop)
        {
            if (a.CheckType(b.GetValueType()))
            {
                if (a.CheckType(typeof(float)))
                {
                    state = new LessEqualNumeric_Numeric();
                }
                if (a.CheckType(typeof(string)))
                {
                    state = new LessEqualString_String();
                }
            }
            state.Calculate(a, b, variable);
            return true;
        }
    }
}