using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class FOOTERREGISTERTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Maintext(new StringValue("tetete")));
            SystemData.instance.command.Add(new Footerregister(
                new StringValue(TestConst.instance.TESTIMAGEPATH + "background"),
                new StringValue("||test footer ///test footer ///test footer ///test footer ///"),
                // height
                new NumericValue(100),
                // font
                new StringValue(ConstData.instance.text_font), new NumericValue(40),
                // offset
                new NumericValue(10), new NumericValue(-20)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("teteto")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}