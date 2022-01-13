using UnityEngine;
namespace AdolescenceNovel
{
    public class TestConst : MonoBehaviour
    {
        private static TestConst _instance = null;

        //テスト用の画像の保存場所
        public readonly string TESTIMAGEPATH = "TestImage/";

        //テスト用の音声の保存場所
        public readonly string TESTSOUNDPATH = "TestSound/";

        //テスト用の動画の保存場所
        public readonly string TESTMOVIEPATH = "TestMovie/";

        public static TestConst instance
        {
            get
            {
                if (!_instance)
                {
                    var go = new GameObject("TestConst");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<TestConst>();
                }
                return _instance;
            }
        }
    }
}