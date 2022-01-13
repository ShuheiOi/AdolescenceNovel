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
    public class LetInitial : ILetState
    {
        private static LetInitial _singleton = null;
        public static LetInitial singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new LetInitial();
                }
                return _singleton;
            }
        }
        
        public bool Execute(Let nowstate, LetContext context)
        {
            // TODO: 実装
            switch (nowstate.value.GetValueTypeEnum())
            {
                case IValueType.Numeric:
                    nowstate.variableName.SetValue(new NumericValue((float)nowstate.value.Value()));
                    break;
                case IValueType.String:
                    nowstate.variableName.SetValue(new StringValue((string)nowstate.value.Value()));
                    break;
                case IValueType.Boolean:
                    nowstate.variableName.SetValue(new BooleanValue((bool)nowstate.value.Value()));
                    break;
            }
            //VariableData.setValue(nowstate.variableName.Value,nowstate.value);
            return true;
        }
    }
}
