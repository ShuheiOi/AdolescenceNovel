using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class DELAYTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Maintext(new StringValue("before delay")));
            SystemData.instance.command.Add(new Delay(new NumericValue(12345)));
            SystemData.instance.command.Add(new Maintext(new StringValue("finish")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}
