using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdolescenceNovel
{
    public class MULTIPLYTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            //エラー
            //SystemData.instance.command.Add(new Multiply(new NumericValue(3), new StringValue("abc"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Let(new StringValue("a"), new NumericValue(3)));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new StringValue("abc")));
            SystemData.instance.command.Add(new Multiply(new NumericValue(3), new NumericValue(5),new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Multiply(new VariableValue("a"), new NumericValue(5),new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Multiply(new VariableValue("b"), new NumericValue(5),new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}