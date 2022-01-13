using UnityEngine;
namespace AdolescenceNovel
{
    public class LETTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Let(new StringValue("a"), new StringValue("hello")));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new NumericValue(1)));
            SystemData.instance.command.Add(new Let(new StringValue("c"), new BooleanValue(true)));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
            Debug.Log((string)VariableData.getValue("a").Value());
        }
    }
}