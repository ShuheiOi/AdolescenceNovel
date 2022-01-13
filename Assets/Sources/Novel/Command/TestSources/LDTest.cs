using UnityEngine;
namespace AdolescenceNovel
{
    public class LDTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(200)));
            SystemData.instance.command.Add(new Ld(new StringValue("r"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(7), new NumericValue(100)));
            Debug.Log(JsonUtility.ToJson(SystemData.instance.command[0]));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}