using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class BGMVOLTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Bgm(new StringValue(TestConst.instance.TESTSOUNDPATH + "yonhonnorecorder"), new StringValue("Bgm")));
            // volumeは0.17になる
            SystemData.instance.command.Add(new Bgmvol(new NumericValue(17)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}