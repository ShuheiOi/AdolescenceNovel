using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// References
// https://qiita.com/sango/items/9dd500dde23bb5729340

public class CommandTemplateGenerator : EditorWindow
{
    
    [MenuItem("Custom/Generate Command Template")]
    // [MenuItem("Custom/Generate Command Template", false, 1)]
    private static void ShowWindow()
    {
        // 既存のウィンドウのインスタンスを表示．ない場合は作成．
        // CommandTemplateGenerator window = GetWindow<CommandTemplateGenerator>();
        // window.titleContent = new GUIContent("CommandTemplateGenerator");
        // window.Show();
        // GetWindow<CommandTemplateGenerator>();
        CommandTemplateGenerator window = EditorWindow.GetWindow<CommandTemplateGenerator>();
        window.titleContent = new GUIContent("CmdTemplate");
        window.Show();
    }
    
    Vector2 scrollPosition;
    private void OnGUI()
    {
        using (EditorGUILayout.ScrollViewScope scrollView
            = new EditorGUILayout.ScrollViewScope(scrollPosition))
        {
            scrollPosition = scrollView.scrollPosition;
            SectionBaseSettings();
            SectionExecuteButton();
        }
    }
    
    void SectionTitleLabel(string title)
    {
        GUIStyle sectionTitle = new GUIStyle()
        {
            fontStyle = FontStyle.Bold,
        };
        EditorGUILayout.LabelField(title, sectionTitle);
    }
    void SectionEndSpace()
    {
        GUILayout.Space(15);
    }
    
    // const-like properties
    string[] commandGroups = {
        "MultimediaCommand",
        "SpriteCommand",
        "SystemCommand",
        "TextCommand",
        "CameraCommand",
    };
    
    // setting params
    Dictionary<string, string> predefinedVariables = new Dictionary<string, string>()
    {
        {"Command", ""},
        {"Group", ""},
        {"CommandSnake", ""},
    };
    List<string> pvStateList = new List<string>()
    {
        "Initial",
    };
    
    // 補助params
    string rawCommandName = "";
    int commandGroupIndex = 1;
    int statesNum = 1;
    
    void SectionBaseSettings()
    {
        SectionTitleLabel("Base Settings");
        
        // command name
        rawCommandName = EditorGUILayout.TextField(
            "Command Name", rawCommandName);
        rawCommandName = rawCommandName.ToLower();
        predefinedVariables["CommandSnake"] = rawCommandName;
        predefinedVariables["Command"] = ToUpperInitial(rawCommandName);
        
        
        // command group
        commandGroupIndex = EditorGUILayout.Popup(
            "Command Group", commandGroupIndex, commandGroups);
        predefinedVariables["Group"] = commandGroups[commandGroupIndex];
        
        // states
        int maxStatesNum = 10;
        statesNum = EditorGUILayout.IntSlider(
            "Number of States", statesNum, 1, maxStatesNum);
        for (int i = 0; i < statesNum; i++)
        {
            if (pvStateList.Count < i + 1)
            {
                pvStateList.Add("");
            }
            string label = $"State {i + 1}.";
            if (i == 0)
            {
                label += " (default state)";
            }
            pvStateList[i] = EditorGUILayout.TextField(label, pvStateList[i]);
            pvStateList[i] = ToUpperInitial(pvStateList[i]);
        }
        
        
        SectionEndSpace();
    }
    
    bool isFoldoutOpen = true;
    void SectionExecuteButton()
    {
        SectionTitleLabel("Execute");
        
        string pvCommand = predefinedVariables["Command"];
        
        List<string> tasks = new List<string>()
        {
            $"下のボタンを押す",
            $"{pvCommand}.cs: コマンド引数のプロパティ宣言を追加(コメントアウト部参照)",
            $"{pvCommand}.cs: コンストラクタに引数を追加，プロパティに代入(コメントアウト部参照)",
            $"{pvCommand}.cs: (仕様書参照:必要なら)引数を省略したときのコンストラクタを追加",
        };
        for (int i = 0; i < statesNum; i++)
        {
            tasks.Add($"{pvCommand}{pvStateList[i]}.cs: 実装する");
        }
        
        isFoldoutOpen = EditorGUILayout.Foldout(isFoldoutOpen, "< ここからの流れ >");
        if (isFoldoutOpen)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                EditorGUILayout.LabelField($"{i + 1}. {tasks[i]}");
            }
        }
        
        
        string parentDirPath = GetParentDirPath();
        string newDirName = GetNewDirName();
        
        string buttomMessage = "Generate Templates";
        bool isValidInput = true;
        
        if (pvCommand == "")
        {
            // コマンド名 未設定
            buttomMessage = "Empty Command Name";
            isValidInput = false;
        }
        else if (Directory.Exists($"{parentDirPath}/{newDirName}"))
        {
            // 既に同名フォルダが存在
            buttomMessage = "Command Name Duplicated";
            isValidInput = false;
        }
        else if (pvStateList.GetRange(0, statesNum).Any((state) => state.Length == 0))
        {
            // ステート名 未指定
            buttomMessage = "Empty State Name";
            isValidInput = false;
        }
        
        
        using (new EditorGUI.DisabledScope(disabled: !isValidInput))
        {
            if (GUILayout.Button(buttomMessage))
            {
                ExecuteCreation();
            }
        }
        
        SectionEndSpace();
    }
    
    
    // templates
    (string fileName, string content) CsCommand()
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        string pvGroup = predefinedVariables["Group"];
        
        
        // file name
        string fileName = $"{pvCommand}.cs";
        
        
        // content
        string content = "";
        content +=  "namespace AdolescenceNovel\n";
        content +=  "{\n";
        content += $"    public class {pvCommand} : {pvGroup}\n";
        content +=  "    {\n";
        content +=  "        // TODO: プロパティを宣言\n";
        content += $"        // コマンド引数以外でも必要なら自由にここに追加して良い\n";
        content += $"        // （{pvCommand}{pvStateList[0]}などのExecute()の第1引数{pvCommand} nowstateから参照可能）\n";
        content +=  "        \n";
        content +=  "        // // description\n";
        content +=  "        // public string arg;\n";
        content +=  "        \n";
        content +=  "        \n";
        content +=  "        // 状態を表す変数\n";
        content += $"        private I{pvCommand}Context state;\n";
        content +=  "        \n";
        content +=  "        \n";
        content +=  "        // TODO: コンストラクタに引数を追加\n";
        content +=  "        // 全ての引数が与えられる場合\n";
        content += $"        // public {pvCommand}(IValue arg)\n";
        content += $"        public {pvCommand}()\n";
        content +=  "        {\n";
        content +=  "            // arg.Value(ref this.arg);\n";
        content += $"            state = new {pvCommand}Context();\n";
        content +=  "        }\n";
        content +=  "        \n";
        content +=  "        // TODO: 必要なら引数を省略したときのコンストラクタを同様に追加\n";
        content +=  "        \n";
        content +=  "        public override bool Execute(ref int now, ref string nowFile, ref bool stop)\n";
        content +=  "        {\n";
        content +=  "            return state.Execute(this);\n";
        content +=  "        }\n";
        content +=  "    }\n";
        content +=  "}\n";
        
        return (fileName, content);
    }
    (string fileName, string content) CsICommandContext()
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        
        
        // file name
        string fileName = $"I{pvCommand}Context.cs";
        
        
        // content
        string content = "";
        content +=  "namespace AdolescenceNovel\n";
        content +=  "{\n";
        content += $"    public interface I{pvCommand}Context\n";
        content +=  "    {\n";
        content += $"        bool Execute({pvCommand} nowstate);\n";
        content += $"        void ChangeState(I{pvCommand}State state);\n";
        content +=  "    }\n";
        content +=  "}\n";
        
        return (fileName, content);
    }
    (string fileName, string content) CsCommandContext()
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        
        
        // file name
        string fileName = $"{pvCommand}Context.cs";
        
        
        // content
        string content = "";
        content +=  "namespace AdolescenceNovel\n";
        content +=  "{\n";
        content += $"    public class {pvCommand}Context : I{pvCommand}Context\n";
        content +=  "    {\n";
        content += $"        private I{pvCommand}State state;\n";
        content +=  "        \n";
        content += $"        public {pvCommand}Context()\n";
        content +=  "        {\n";
        content += $"            state = new {pvCommand}Initial();\n";
        content +=  "        }\n";
        content +=  "        \n";
        content += $"        public void ChangeState(I{pvCommand}State state)\n";
        content +=  "        {\n";
        content +=  "            this.state = state;\n";
        content +=  "        }\n";
        content +=  "        \n";
        content += $"        public bool Execute({pvCommand} nowstate)\n";
        content +=  "        {\n";
        content +=  "            return state.Execute(nowstate, this);\n";
        content +=  "        }\n";
        content +=  "    }\n";
        content +=  "}\n";
        
        return (fileName, content);
    }
    (string fileName, string content) CsICommandState()
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        
        
        // file name
        string fileName = $"I{pvCommand}State.cs";
        
        
        // content
        string content = "";
        content +=  "namespace AdolescenceNovel\n";
        content +=  "{\n";
        content += $"    public interface I{pvCommand}State\n";
        content +=  "    {\n";
        content += $"        bool Execute({pvCommand} nowstate, {pvCommand}Context context);\n";
        content +=  "    }\n";
        content +=  "}\n";
        
        return (fileName, content);
    }
    List<(string fileName, string content)> CsCommandStates(List<string> pvStates)
    {
        return pvStates.Select(pvState => CsCommandState(pvState)).ToList();
    }
    (string fileName, string content) CsCommandState(string pvState)
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        
        
        // file name
        string fileName = $"{pvCommand}{pvState}.cs";
        
        
        // content
        string content = "";
        content +=  "namespace AdolescenceNovel\n";
        content +=  "{\n";
        content += $"    public class {pvCommand}{pvState} : I{pvCommand}State\n";
        content +=  "    {\n";
        content += $"        private static {pvCommand}{pvState} _singleton = null;\n";
        content += $"        public static {pvCommand}{pvState} singleton\n";
        content +=  "        {\n";
        content +=  "            get\n";
        content +=  "            {\n";
        content +=  "                if (_singleton == null)\n";
        content +=  "                {\n";
        content += $"                    _singleton = new {pvCommand}{pvState}();\n";
        content +=  "                }\n";
        content +=  "                return _singleton;\n";
        content +=  "            }\n";
        content +=  "        }\n";
        content +=  "        \n";
        content += $"        public bool Execute({pvCommand} nowstate, {pvCommand}Context context)\n";
        content +=  "        {\n";
        content +=  "            // TODO: 実装\n";
        content +=  "            \n";
        if (statesNum == 1)
        {
            content += "            return true;\n";
        }
        else
        {
            content += "            // 処理終了ならtrue\n";
            content += "            return false;\n";
        }
        content +=  "        }\n";
        content +=  "    }\n";
        content +=  "}\n";
        
        return (fileName, content);
    }
    
    
    string GetParentDirPath()
    {
        string pvGroup = predefinedVariables["Group"];
        return $"Assets/Sources/Novel/Command/{pvGroup}";
    }
    
    string GetNewDirName()
    {
        string pvCommandSnake = predefinedVariables["CommandSnake"];
        return $"{pvCommandSnake}";
    }
    
    
    // 生成実行
    void ExecuteCreation()
    {
        // predefinedVariables
        string pvCommand = predefinedVariables["Command"];
        string pvGroup = predefinedVariables["Group"];
        
        // mkdir
        string parentDirPath = GetParentDirPath();
        string newDirName = GetNewDirName();
        AssetDatabase.CreateFolder(parentDirPath, newDirName);
        string newDirPath = $"{parentDirPath}/{newDirName}";
        
        
        List<(string, string)> targets = new List<(string, string)>();
        targets.Add(CsCommand());
        targets.Add(CsICommandContext());
        targets.Add(CsCommandContext());
        targets.Add(CsICommandState());
        targets.AddRange(CsCommandStates(pvStateList.GetRange(0, statesNum)));
        
        foreach ((string fileName, string content) in targets)
        {
            string path = $"{newDirPath}/{fileName}";
            
            if (File.Exists(path))
            {
                Debug.Log($"{path} already exists; skipped generating.");
                continue;
            }
            
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(content);
            }
        }
        
        AssetDatabase.Refresh();
    }
    
    
    string ToUpperInitial(string s)
    {
        if (s.Length == 0)
        {
            return s;
        }
        return Char.ToUpper(s[0]) + s.Substring(1).ToLower();
    }
    
    
    
}


