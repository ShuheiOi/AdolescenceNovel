using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
namespace AdolescenceNovel
{
    public class Compiler : MonoBehaviour
    {
        [SerializeField]
        public static List<string> file_list = new List<string>();
        private List<string> FullPath()
        {
            string[] list = Directory.GetFiles(Application.streamingAssetsPath + "/Source/", "*.txt");
            List<string> ret = new List<string>();
            string[] temp;
            for (int i = 0; i < list.Length; i++)
            {
                temp = list[i].Split('/');
                ret.Add(temp[temp.Length - 1]);
            }
            return ret;
        }
        private void Update()
        {
            file_list = FullPath();
        }
        public void Docompile()
        {
            file_list = FullPath();
            Compile compile = new Compile(file_list);
        }
        public static List<ICommand> DoGame()
        {
            return Compile.DoCompile();
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(Compiler))]
    public class CompilerEditor : Editor
    {
        [SerializeField]
        private bool print_file_name = false;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.TextArea(Application.streamingAssetsPath + "/Source/",GUIStyle.none);
            if (print_file_name = EditorGUILayout.Toggle("ファイル一覧を表示する", print_file_name))
            {
                if (Compiler.file_list.Count > 0)
                {
                    foreach (string name in Compiler.file_list)
                    {
                        EditorGUILayout.LabelField(name);
                    }
                }
            }
            if (GUILayout.Button("コンパイル"))
            {
                Compiler comp = target as Compiler;
                comp.Docompile();
            }
        }
    }
#endif
}