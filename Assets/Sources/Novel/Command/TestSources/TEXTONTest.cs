using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTONTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest1"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(20), new NumericValue(40),
                // image size
                new NumericValue(300), new NumericValue(250),
                // offset
                new NumericValue(10), new NumericValue(30),
                // text size
                new NumericValue(500), new NumericValue(300),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("text on")));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest1")));
            SystemData.instance.command.Add(new Maintext(new StringValue("text off")));
            SystemData.instance.command.Add(new Textoff(new StringValue("boxtest1")));
            // Error: Not found
            SystemData.instance.command.Add(new Texton(new StringValue("lag")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}