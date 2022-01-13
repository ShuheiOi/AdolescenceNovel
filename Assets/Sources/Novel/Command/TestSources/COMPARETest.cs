using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class COMPARETest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            /*1*/SystemData.instance.command.Add(new Less(new NumericValue(6), new NumericValue(5), new VariableValue("_1")));
            /*2*/SystemData.instance.command.Add(new Compare(new VariableValue("_1"), new NumericValue(3)));
            /*3*/SystemData.instance.command.Add(new Notcompare(new VariableValue("_1"), new NumericValue(5)));
            /*4*/SystemData.instance.command.Add(new Maintext(new StringValue("trueの値")));
            /*5*/SystemData.instance.command.Add(new Goto(new StringValue(""), new NumericValue(6)));
            /*6*/SystemData.instance.command.Add(new Maintext(new StringValue("falseの値")));
            /*7*/SystemData.instance.command.Add(new Maintext(new StringValue("hello")));

        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}
