using UnityEngine;
namespace AdolescenceNovel
{
    public class MOVIETest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            SystemData.instance.command.Add(new Movie(new StringValue(TestConst.instance.TESTMOVIEPATH + "Kaiki1stPV_master")));
            SystemData.instance.command.Add(new Movie(new StringValue(TestConst.instance.TESTMOVIEPATH + "Coffee-45358")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}