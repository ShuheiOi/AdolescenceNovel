using UnityEngine;
namespace AdolescenceNovel
{
    public class LSPTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(0), new NumericValue(0)));
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest2"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test2"), new NumericValue(100), new NumericValue(0), new BooleanValue(true)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}