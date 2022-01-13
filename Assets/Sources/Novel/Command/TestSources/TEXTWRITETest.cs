using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTWRITETest : MonoBehaviour
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
                new StringValue(TestConst.instance.TESTIMAGEPATH + "textbox"),
                // image coord
                new NumericValue(1), new NumericValue(1.5f),
                // image size
                new NumericValue(700), new NumericValue(580),
                // offset
                new NumericValue(25), new NumericValue(10),
                // text size
                new NumericValue(1000), new NumericValue(400),
                // font size
                new NumericValue(12)
            ));
            // SystemData.instance.command.Add(new Textdef(new StringValue("boxtest2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), /* image coord */ new NumericValue(1), new NumericValue(1.5f), /* image size */ new NumericValue(1000), new NumericValue(1200), /* offset */ new NumericValue(0.1f), new NumericValue(0.1f), /* text size */ new NumericValue(0.9f), new NumericValue(1.2f), /* font size */ new NumericValue(12)));
            // SystemData.instance.command.Add(new Textdef(new StringValue("boxtest3"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(1), new NumericValue(1.5f), new NumericValue(1000), new NumericValue(1200), new NumericValue(0.1f), new NumericValue(0.1f), new NumericValue(0.9f), new NumericValue(1.2f), new NumericValue(12)));
            SystemData.instance.command.Add(new Texton(new StringValue("boxtest11")));
            SystemData.instance.command.Add(new Maintext(new StringValue("濃いめ")));
            SystemData.instance.command.Add(new Textwrite(
                new StringValue("boxtest11"),
                // new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"),
                new StringValue("===================================================================================================="),
                new NumericValue(60),
                // RGBA
                new NumericValue(80),
                new NumericValue(0),
                new NumericValue(120),
                new NumericValue(255)
                , new StringValue(ConstData.instance.text_font)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("薄め")));
            SystemData.instance.command.Add(new Textwrite(
                new StringValue("boxtest11"),
                // new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"),
                new StringValue("===================================================================================================="),
                new NumericValue(60),
                // RGBA
                new NumericValue(80),
                new NumericValue(0),
                new NumericValue(120),
                new NumericValue(25)
                // , new StringValue(ConstData.instance.text_font)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("#RRGGBB指定")));
            SystemData.instance.command.Add(new Textwrite(
                new StringValue("boxtest11"),
                // new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"),
                new StringValue("===================================================================================================="),
                new NumericValue(60),
                // RGBA
                new StringValue("#507078")
                , new StringValue(ConstData.instance.text_font)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("#RRGGBBAA指定")));
            SystemData.instance.command.Add(new Textwrite(
                new StringValue("boxtest11"),
                // new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"),
                new StringValue("===================================================================================================="),
                new NumericValue(60),
                // RGBA
                new StringValue("#5070786f")
                // , new StringValue(ConstData.instance.text_font)
            ));
            
            
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}