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
using System;
using UnityEngine;

namespace AdolescenceNovel
{
    [Serializable]
    public class VariableValue : Variables
    {
        [SerializeField]
        private string variable_name;
        public VariableValue(string variable_name)
        {
            this.variable_name = variable_name;
            valueType = IValueType.Numeric;
        }

        public override bool CheckType(Type var)
        {
            return VariableData.getValue(variable_name).CheckType(var);
        }

        public override Type GetValueType()
        {
            return VariableData.getValue(variable_name).GetValueType();
        }

        public override IValueType GetValueTypeEnum()
        {
            return VariableData.getValue(variable_name).GetValueTypeEnum();
        }

        public override void SetValue(IValue var)
        {
            VariableData.setValue(variable_name, var);
        }

        public override object Value()
        {
            return VariableData.getValue(variable_name).Value();
        }
    }
}