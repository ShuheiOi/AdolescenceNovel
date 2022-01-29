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
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AdolescenceNovel
{
    public class VariableData : MonoBehaviour,ISerializationCallbackReceiver
    {
        private static VariableData _instance = null;
        [System.NonSerialized]
        private Dictionary<string, IValue> variable;

        [SerializeField]
        public List<string> variableKeys;
        [SerializeField]
        public List<VariableSave> variableValue;

        [SerializeField]
        private Stack<IValue> register;
        [SerializeField]
        private Stack<int> function_register;
        [SerializeField]
        private StaticData staticData;

        public static void Load(VariableSaveData vd)
        {
            _instance.variable = vd.variable;
            _instance.register = vd.register;
            _instance.function_register = vd.function_register;
            _instance.staticData = vd.staticData;
        }

        //グローバルデータ
        public void UpdateStaticData()
        {
            StaticData.StaticDataLoad(instance.variable);
        }
        public static IValue getValue(string name)
        {
            return instance.variable[name];
        }
        public static void setValue(string name,IValue value)
        {
            instance.variable[name] = value;
        }
        public void pushValue(IValue value)
        {
            object tmp = value.Value();
            //型が文字列の場合
            if (tmp.GetType() == typeof(string))
            {
                instance.register.Push(new StringValue((string)tmp));
            }
            //型が数値の場合
            if( tmp.GetType() == typeof(int) || tmp.GetType() == typeof(float))
            {
                instance.register.Push(new NumericValue((float)tmp));
            }
            //型が論理値の場合
            if( tmp.GetType() == typeof(bool))
            {
                instance.register.Push(new BooleanValue((bool)tmp));
            }
            //それ以外の場合はやばいです
        }
        public void popValue(IValue name)
        {
            instance.variable[(string)name.Value()] = instance.register.Pop();
        }

        public void pushFunction(int now)
        {
            instance.function_register.Push(now);
        }

        public int popFunction()
        {
            return instance.function_register.Pop();
        }


        public static VariableData instance
        {
            get
            {
                if(_instance == null)
                {
                    GameObject go = new GameObject("VariableData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<VariableData>();
                    _instance.variable = new Dictionary<string, IValue>();
                    _instance.register = new Stack<IValue>();
                    _instance.function_register = new Stack<int>();
                }
                return _instance;
            }
        }
        
        public void OnBeforeSerialize()
        {
            instance.variableKeys = new List<string>();
            instance.variableValue = new List<VariableSave>();
            foreach (string key in instance.variable.Keys)
            {
                instance.variableKeys.Add(key);
                instance.variableValue.Add(new VariableSave(instance.variable[key]));
            }
            Debug.Log(JsonUtility.ToJson(instance.variableValue));
        }


        public void OnAfterDeserialize()
        {
            int length = instance.variableKeys.Count;
            for(int i = 0; i < length; i++)
            {
                switch (instance.variableValue[i].type)
                {
                    case IValueType.Numeric:
                        instance.variable.Add(instance.variableKeys[i], new NumericValue(instance.variableValue[i].numeric));
                        break;
                    case IValueType.Boolean:
                        instance.variable.Add(instance.variableKeys[i], new BooleanValue(instance.variableValue[i].boolean));
                        break;
                    case IValueType.String:
                        instance.variable.Add(instance.variableKeys[i], new StringValue(instance.variableValue[i].str));
                        break;
                    case IValueType.Variable:
                        instance.variable.Add(instance.variableKeys[i], new VariableValue(instance.variableValue[i].var));
                        break;
                }
            }
        }
    }
    [Serializable]
    public class VariableSave : ISerializationCallbackReceiver
    {
        public IValue saveData;

        [SerializeField]
        public string str;
        [SerializeField]
        public float numeric;
        [SerializeField]
        public bool boolean;
        [SerializeField]
        public string var;
        [SerializeField]
        public IValueType type;
        public VariableSave(IValue data)
        {
            type = data.GetValueTypeEnum();
            switch (type)
            {
                case IValueType.Numeric:
                    numeric = (float)data.Value();
                    break;
                case IValueType.String:
                    str = (string)data.Value();
                    break;
                case IValueType.Boolean:
                    boolean = (bool)data.Value();
                    break;
                case IValueType.Variable:
                    var = (string)data.Value();
                    break;
            }
        }

        public void OnAfterDeserialize()
        {
            switch (type)
            {
                case IValueType.Numeric:
                    saveData = new NumericValue(numeric);
                    break;
                case IValueType.String:
                    saveData = new StringValue(str);
                    break;
                case IValueType.Boolean:
                    saveData = new BooleanValue(boolean);
                    break;
                case IValueType.Variable:
                    saveData = new VariableValue(var);
                    break;
            }

        }

        public void OnBeforeSerialize()
        {
            switch (type)
            {
                case IValueType.Numeric:
                    saveData = new NumericValue(numeric);
                    break;
                case IValueType.String:
                    saveData = new StringValue(str);
                    break;
                case IValueType.Boolean:
                    saveData = new BooleanValue(boolean);
                    break;
                case IValueType.Variable:
                    saveData = new VariableValue(var);
                    break;
            }
        }
    }

    public class VariableSaveData : ISerializationCallbackReceiver
    {
        [System.NonSerialized]
        public Dictionary<string, IValue> variable;

        [SerializeField]
        public List<string> variableKeys;
        [SerializeField]
        public List<VariableSave> variableValue;

        [SerializeField]
        public Stack<IValue> register;
        [SerializeField]
        public Stack<int> function_register;
        [SerializeField]
        public StaticData staticData;

        public void OnAfterDeserialize()
        {
            int length = variableKeys.Count;
            variable = new Dictionary<string, IValue>();
            for (int i = 0; i < length; i++)
            {
                switch (variableValue[i].type)
                {
                    case IValueType.Numeric:
                        variable.Add(variableKeys[i], new NumericValue(variableValue[i].numeric));
                        break;
                    case IValueType.Boolean:
                        variable.Add(variableKeys[i], new BooleanValue(variableValue[i].boolean));
                        break;
                    case IValueType.String:
                        variable.Add(variableKeys[i], new StringValue(variableValue[i].str));
                        break;
                    case IValueType.Variable:
                        variable.Add(variableKeys[i], new VariableValue(variableValue[i].var));
                        break;
                }
            }
        }

        public void OnBeforeSerialize()
        {
            throw new NotImplementedException();
        }
    }
}