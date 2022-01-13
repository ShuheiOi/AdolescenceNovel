using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class FOOTERONOFFTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Maintext(new StringValue("next: footer register")));
            SystemData.instance.command.Add(new Footerregister(
                new StringValue(TestConst.instance.TESTIMAGEPATH + "background"),
                new StringValue("||test footer ///test footer ///test footer ///test footer /// 隠れてしまえ〜"),
                // height
                new NumericValue(150),
                // font
                new StringValue(ConstData.instance.text_font), new NumericValue(40),
                // offset
                new NumericValue(10), new NumericValue(-20)
            ));
            SystemData.instance.command.Add(new Maintext(new StringValue("regist\nered?")));
            SystemData.instance.command.Add(new Maintext(new StringValue("next: footer on")));
            SystemData.instance.command.Add(new Footeron());
            SystemData.instance.command.Add(new Maintext(new StringValue("now on?\n長いテキストでフッター隠れないかテストします: あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの")));
            SystemData.instance.command.Add(new Maintext(new StringValue("隠れた．\nnext: footer off")));
            SystemData.instance.command.Add(new Footeroff());
            SystemData.instance.command.Add(new Maintext(new StringValue("now off?")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}