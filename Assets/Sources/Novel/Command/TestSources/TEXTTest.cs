using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Let(new StringValue("a"), new BooleanValue(true)));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a} is answer")));
            SystemData.instance.command.Add(new Maintextcontinue(new StringValue("hello\ncontinue")));
            SystemData.instance.command.Add(new Maintextcontinue(new StringValue("hello @(continue/コンティニュー)")));
            SystemData.instance.command.Add(new Maintextcontinue(new StringValue("hello @(続ける/continue)")));
            SystemData.instance.command.Add(new Maintext(new StringValue("hello\n @(続ける/continue)")));
            SystemData.instance.command.Add(new Maintext(new StringValue("｛a｝is answer")));
            SystemData.instance.command.Add(new Maintextcontinue(new StringValue("hello continue")));
            SystemData.instance.command.Add(new Maintext(new StringValue("aaaa＠@bbb")));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new StringValue("is")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a} {b} answer")));
            SystemData.instance.command.Add(new Let(new StringValue("c"), new NumericValue(100)));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a} {b} answer {c}")));
            SystemData.instance.command.Add(new Maintext(new StringValue("(竜騎兵/ドラグーン)\n(急速眼球運動睡眠/ラッピッドアイ・ムーブメント・スリープ)\n@(死/タナトス)(電磁波/エレクトロマグネティックウェーブ)\n")));
            SystemData.instance.command.Add(new Maintext(new StringValue("長いテ～キスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト"), new StringValue("長ーいおつきあい")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}