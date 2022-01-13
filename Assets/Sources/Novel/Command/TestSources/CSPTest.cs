using UnityEngine;
namespace AdolescenceNovel
{
    public class CSPTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Lsp(new StringValue("testtest"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(0), new NumericValue(0)));
            SystemData.instance.command.Add(new Csp(new StringValue("testtest")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}