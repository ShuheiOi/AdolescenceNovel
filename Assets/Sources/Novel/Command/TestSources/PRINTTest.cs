using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class PRINTTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Bg(new StringValue(TestConst.instance.TESTIMAGEPATH + "background"), new NumericValue(1)));
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(0), new NumericValue(0)));
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test2"), new NumericValue(100), new NumericValue(0), new BooleanValue(true)));
            SystemData.instance.command.Add(new Print(new NumericValue(10)));
            SystemData.instance.command.Add(new Csp(new StringValue("testtest2")));
            SystemData.instance.command.Add(new Print(new NumericValue(5),new NumericValue(1000)));
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test2"), new NumericValue(100), new NumericValue(0), new BooleanValue(true)));

            SystemData.instance.command.Add(new Print(new NumericValue(15), new NumericValue(1000)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}