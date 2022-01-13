using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdolescenceNovel
{
    public class POPPUSHTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Push(new NumericValue(3)));
            SystemData.instance.command.Add(new Push(new BooleanValue(true)));
            SystemData.instance.command.Add(new Push(new StringValue("test3")));
            SystemData.instance.command.Add(new Pop(new StringValue("test")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{test}")));
            SystemData.instance.command.Add(new Pop(new StringValue("test")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{test}")));
            SystemData.instance.command.Add(new Pop(new StringValue("test")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{test}")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}