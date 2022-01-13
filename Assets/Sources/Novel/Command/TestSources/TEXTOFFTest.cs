using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTOFFTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            // SystemData.instance.command.Add(new Maintext(new StringValue("(竜騎兵/ドラグーン)\n(急速眼球運動睡眠/ラッピッドアイ・ムーブメント・スリープ)\n@(死/タナトス)(電磁波/エレクトロマグネティックウェーブ)\n")));
            
            SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(5000)));
            SystemData.instance.command.Add(new Texton());
            SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(7), new NumericValue(5000)));
            SystemData.instance.command.Add(new Maintext(new StringValue("(竜騎兵/ドラグーン)\n(急速眼球運動睡眠/ラッピッドアイ・ムーブメント・スリープ)\n@(死/タナトス)(電磁波/エレクトロマグネティックウェーブ)\n")));
            SystemData.instance.command.Add(new Textoff());
            SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(7), new NumericValue(5000)));
            SystemData.instance.command.Add(new Maintext(new StringValue("長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト"), new StringValue("長ーいおつきあい")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}