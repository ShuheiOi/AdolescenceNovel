using UnityEngine;

namespace AdolescenceNovel
{
    public class CLTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(2000)));
            SystemData.instance.command.Add(new Cl(new StringValue("c"), new NumericValue(10),new NumericValue(1000)));
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(2000)));
            SystemData.instance.command.Add(new Cl(new StringValue("c"), new NumericValue(10)));
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(2000)));
            SystemData.instance.command.Add(new Cl(new StringValue("c")));
            SystemData.instance.command.Add(new Ld(new StringValue("c"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            SystemData.instance.command.Add(new Ld(new StringValue("r"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1")));
            SystemData.instance.command.Add(new Ld(new StringValue("l"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(10), new NumericValue(2000)));
            SystemData.instance.command.Add(new Cl(new StringValue("a")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}