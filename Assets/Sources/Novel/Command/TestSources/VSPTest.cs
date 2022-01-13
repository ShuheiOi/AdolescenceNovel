using UnityEngine;
namespace AdolescenceNovel
{
    public class VSPTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }

        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Lsph(new StringValue("lsphImage"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(0), new NumericValue(0)));
            SystemData.instance.command.Add(new Vsp(new StringValue("lsphImage"), new NumericValue(1)));

            SystemData.instance.command.Add(new Lsp(new StringValue("lspImage"), new StringValue(TestConst.instance.TESTIMAGEPATH + "test1"), new NumericValue(0), new NumericValue(0)));
            SystemData.instance.command.Add(new Vsp(new StringValue("lspImage"), new NumericValue(0)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}