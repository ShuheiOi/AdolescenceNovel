using UnityEngine;
namespace AdolescenceNovel {
    public class DEFBUTTON_BUTTONTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            /*0*/SystemData.instance.command.Add(new Defbutton(new StringValue("test1"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(300), new NumericValue(200)));
            /*1*/SystemData.instance.command.Add(new Defbutton(new StringValue("test2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test2"), new NumericValue(300), new NumericValue(200)));
            /*2*/SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            /*3*/SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(200)));
            /*4*/SystemData.instance.command.Add(new Ld(new StringValue("r"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            /*5*/SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(7), new NumericValue(100)));
            /*6*/SystemData.instance.command.Add(new ButtonCommand(new StringValue("test1"), new NumericValue(0), new NumericValue(0), new StringValue("Hello"), new NumericValue(9)));
            /*7*/SystemData.instance.command.Add(new ButtonCommand(new StringValue("test2"), new NumericValue(0), new NumericValue(250), new StringValue("How are you"), new NumericValue(2)));
            /*8*/SystemData.instance.command.Add(new Select());
            /*9*/SystemData.instance.command.Add(new Movie(new StringValue(TestConst.instance.TESTMOVIEPATH + "Kaiki1stPV_master")));
            /*10*/SystemData.instance.command.Add(new Movie(new StringValue(TestConst.instance.TESTMOVIEPATH + "Coffee-45358")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}