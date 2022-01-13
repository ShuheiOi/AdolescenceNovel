using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class TEXTSPEEDTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Maintext(new StringValue("(竜騎兵/ドラグーン)\n(急速眼球運動睡眠/ラッピッドアイ・ムーブメント・スリープ)\n@(死/タナトス)(電磁波/エレクトロマグネティックウェーブ)\n")));
            SystemData.instance.command.Add(new Maintext(new StringValue("長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト長いテキスト"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Maintext(new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Maintext(new StringValue("あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Textspeed(new NumericValue(100)));
            // 英数字と仮名 各100文字: 10秒くらい
            SystemData.instance.command.Add(new Maintext(new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Maintext(new StringValue("QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890QwertAsdfgZxcvbErtyuDfghjCvbnm12345678901234567890"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Maintext(new StringValue("あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Maintext(new StringValue("あいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねのあいうえおかきくけこさしすせそたちつてとなにぬねの"), new StringValue("長ーいおつきあい")));
            SystemData.instance.command.Add(new Texton());
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}