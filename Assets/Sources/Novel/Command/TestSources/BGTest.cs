using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class BGTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Bg(new StringValue(TestConst.instance.TESTIMAGEPATH + "background"), new NumericValue(1)));
            SystemData.instance.command.Add(new Bg(new StringValue("#FF0000"), new NumericValue(10), new NumericValue(1000)));
            SystemData.instance.command.Add(new Bg(new StringValue("#FF00FF"), new NumericValue(5), new NumericValue(1000)));
            SystemData.instance.command.Add(new Bg(new StringValue(TestConst.instance.TESTIMAGEPATH + "background")));
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(7), new NumericValue(1000)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}