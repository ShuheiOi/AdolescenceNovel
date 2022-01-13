using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class DIVIDETest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            //エラー
            //SystemData.instance.command.Add(new Divide(new StringValue("test"), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Divide(new NumericValue(10),new NumericValue(0), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Let(new StringValue("a"), new NumericValue(3)));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new NumericValue(4)));
            SystemData.instance.command.Add(new Divide(new VariableValue("a"), new VariableValue("b"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Divide(new NumericValue(3), new NumericValue(10), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}