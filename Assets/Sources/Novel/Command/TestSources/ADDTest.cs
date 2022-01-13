using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class ADDTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Let(new StringValue("a"), new NumericValue(2.4f)));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new NumericValue(4.3f)));
            SystemData.instance.command.Add(new Let(new StringValue("c"), new StringValue("abc")));
            SystemData.instance.command.Add(new Let(new StringValue("d"), new StringValue("def")));
            SystemData.instance.command.Add(new Add(new NumericValue(10), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Add(new VariableValue("a"), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Add(new VariableValue("a"), new VariableValue("b"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Add(new VariableValue("c"), new StringValue("ffffffff"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Add(new VariableValue("c"), new VariableValue("d"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            //エラー string + int
            // SystemData.instance.command.Add(new Add(new VariableValue("c"), new VariableValue("a"), new VariableValue("tmp")));
            //エラー int + string
            // SystemData.instance.command.Add(new Add(new VariableValue("b"), new VariableValue("d"), new VariableValue("tmp")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}