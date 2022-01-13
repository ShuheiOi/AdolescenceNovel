using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdolescenceNovel
{
    public class LESSTest : MonoBehaviour
    {
        private void Awake()
        {
            SystemData.instance.ScreenSizeInit();
        }
        // Start is called before the first frame update
        void Start()
        {
            //エラー
            //SystemData.instance.command.Add(new Sub(new StringValue("aaa"), new StringValue("bbb"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Let(new StringValue("a"), new NumericValue(3)));
            SystemData.instance.command.Add(new Let(new StringValue("b"), new NumericValue(4)));
            SystemData.instance.command.Add(new Less(new VariableValue("b"), new VariableValue("a"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{b}＜{a}ー＞{tmp}")));
            SystemData.instance.command.Add(new Less(new VariableValue("a"), new NumericValue(1145141), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("{a}＜1145141ー＞{tmp}")));
            SystemData.instance.command.Add(new Less(new StringValue("b"), new StringValue("a"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("b＜aー＞{tmp}")));
            SystemData.instance.command.Add(new Less(new StringValue("a"), new StringValue("b"), new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("a＜bー＞{tmp}")));
            SystemData.instance.command.Add(new Less(new StringValue("dogs"), new StringValue("dog"),new VariableValue("tmp")));
            SystemData.instance.command.Add(new Maintext(new StringValue("dogs < dog ー＞{tmp}")));
        }

        // Update is called once per frame
        void Update()
        {
            SystemData.instance.Execute();
        }
    }
}