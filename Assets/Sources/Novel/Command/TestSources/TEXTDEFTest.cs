using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTDEFTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest11"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"),
                // image coord
                new NumericValue(1), new NumericValue(1.5f),
                // image size
                new NumericValue(700), new NumericValue(580),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            // SystemData.instance.command.Add(new Textdef(new StringValue("boxtest2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), /* image coord */ new NumericValue(1), new NumericValue(1.5f), /* image size */ new NumericValue(1000), new NumericValue(1200), /* offset */ new NumericValue(0.1f), new NumericValue(0.1f), /* text size */ new NumericValue(0.9f), new NumericValue(1.2f), /* font size */ new NumericValue(12)));
            // SystemData.instance.command.Add(new Textdef(new StringValue("boxtest3"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(1), new NumericValue(1.5f), new NumericValue(1000), new NumericValue(1200), new NumericValue(0.1f), new NumericValue(0.1f), new NumericValue(0.9f), new NumericValue(1.2f), new NumericValue(12)));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest11")));
            
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest12"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"),
                // image coord
                new NumericValue(0), new NumericValue(0),
                // image size
                new NumericValue(1400), new NumericValue(1080),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest12")));
            
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest13"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"),
                // image coord
                new NumericValue(-10), new NumericValue(-20),
                // image size
                new NumericValue(1400), new NumericValue(1080),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest13")));
            
            // 左上角の確認
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest21"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(20), new NumericValue(30),
                // image size
                new NumericValue(300), new NumericValue(250),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest21")));
            
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest22"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(20), new NumericValue(0),
                // image size
                new NumericValue(300), new NumericValue(250),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest22")));
            
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest23"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(0), new NumericValue(0),
                // image size
                new NumericValue(300), new NumericValue(250),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest23")));
            
            SystemData.instance.command.Add(new Textdef(
                new StringValue("boxtest24"),
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(-20), new NumericValue(-30),
                // image size
                new NumericValue(300), new NumericValue(250),
                // offset
                new NumericValue(0.1f), new NumericValue(0.1f),
                // text size
                new NumericValue(0.9f), new NumericValue(1.2f),
                // font size
                new NumericValue(12)
            ));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest24")));
            
            
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}