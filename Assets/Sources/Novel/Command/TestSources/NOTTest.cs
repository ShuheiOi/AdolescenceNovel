using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class NOTTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            //エラー
            //SystemData.instance.command.Add(new Sub(new StringValue("aaa"), new StringValue("bbb"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Let(new StringValue("a"), new BooleanValue(true)));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new BooleanValue(false)));
            SystemData.instance.command.Add(new Not(new VariableValue("a"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
            SystemData.instance.command.Add(new Not(new VariableValue("b"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{tmp}")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}