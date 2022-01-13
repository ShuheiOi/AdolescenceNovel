using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class LESSEQUALTest : MonoBehaviour
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
            SystemData.instance.command.Add(new LessEqual(new NumericValue(10), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("10 <= 10{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new VariableValue("a"), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a} <= 10{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new VariableValue("a"), new VariableValue("b"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a} <= {b}{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new VariableValue("b"), new VariableValue("a"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{b} <= {a}{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new StringValue("ffffffff"), new StringValue("ffffffff"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("ffffffff <= ffffffff{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new VariableValue("c"), new VariableValue("d"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{c} <= {d}{tmp}")));
            SystemData.instance.command.Add(new LessEqual(new VariableValue("d"), new VariableValue("c"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{d} <= {c}{tmp}")));
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