/*
MIT License

Copyright (c) 2022 ShuheiOi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */
using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;
using System.IO;
using UnityEngine.UI;
namespace AdolescenceNovel
{
    //Singletonパターンひとつだけ生成
    //使う際は、ConstData.instanceからアクセス
    public class ConstData : MonoBehaviour
    {
        private static ConstData _instance = null;

        //イメージPrefabのパス
        public readonly string IMAGEPATH = "Prefab/Novel/Image";

        //ボタンPrefabのパス
        public readonly string BUTTONPATH = "Prefab/Novel/Button";

        //テキストPrefabのパス
        public readonly string TEXTBOXPATH = "Prefab/Novel/TextBox";

        //メインのCanvasのオブジェクトタグ
        private const string MainCanvasTag = "Novel-Main-Canvas";

        //裏のCanvasのオブジェクト
        private const string BehindCanvasTag = "Novel-Behind-Canvas";

        //UIのCanvasのオブジェクト
        private const string UICanvasTag = "Novel-UI-Canvas";

        //FadeCanvasのInterfaceタグ
        public const string FadeImageTag = "Novel-Fade-Image";

        //Curtaincanvasのオブジェクトタグ
        private const string CurtainCanvasTag = "Novel-Curtain-Canvas";

        //Movieのオブジェクトタグ
        private const string MovieTag = "Novel-Movie";

        //BGMのオブジェクトタグ
        public const string BgmTag = "Novel-BGM";

        //SE(SoundEffect)のオブジェクトタグ
        public const string SeTag = "Novel-SE";

        //テキストのオブジェクトタグ
        public const string TextTag = "Novel-Text";

        //音声のマスターボリュームKey名
        public const string VolumeMaster = "Master";

        //効果音のボリュームKey名
        public const string VolumeSe = "Se";

        //BGMのボリュームKey名
        public const string VolumeBgm = "Bgm";

        //メインのテキストボックスKey名
        public const string TextboxMain = "_MainTextBox";

        //キャラクターのテキストボックスKey名
        public const string NameboxMain = "_NameTextBox";
        
        // RGBA各項目を整数で指定するときの最大値
        public const int RgbaMax = 255;

        //Fade用のルール画像
        public readonly string FadeRulePicture = "Fade/";
        //メインCanvas画像表示GameObject
        public Dictionary<string, GameObject> MainCanvasPicture;

        //メインCanvas画像表示GameObjectのRectTransform
        public Dictionary<string, RectTransform> MainCanvasPictureRectTransform;

        //裏Canvas画像表示GameObject
        public Dictionary<string, GameObject> BehindCanvasPicture;

        //裏Canvas画像表示GameObjectのRectTransform
        public Dictionary<string, RectTransform> BehindCanvasPictureRectTransform;

        //画像表示用(メイン)
        public readonly string MainPicture = "main";

        //画像表示用(バックグラウンド)
        public readonly string BackgroundPicture = "background";

        //画像表示用(顔)
        public readonly string FacePicture = "face";

        //UI用
        public readonly string UIObject = "UI";

        //オリジナルな画面の大きさ
        public static int original_width = 1920;
        public static int original_height = 1080;
        
        // Delay で扱う時間の最小単位: 1msを何分割するか
        public const int DelayUnitsPerMs = 100;
        
        // Quake のデフォルトの揺らし方
        public const string QuakeDefaultFunction = "QuakeConstantVelocity";

        //現在の画面の大きさ
        [System.NonSerialized]
        public int width;
        [System.NonSerialized]
        public int height;

        [System.NonSerialized]
        public float text_x;
        [System.NonSerialized]
        public float text_y;
        [System.NonSerialized]
        public float text_width;
        [System.NonSerialized]
        public float text_height;
        [System.NonSerialized]
        public float text_image_x;
        [System.NonSerialized]
        public float text_image_y;
        [System.NonSerialized]
        public float text_image_width;
        [System.NonSerialized]
        public float text_image_height;
        [System.NonSerialized]
        public string text_font;
        [System.NonSerialized]
        public string text_picture;
        [System.NonSerialized]
        public int text_font_size;
        [System.NonSerialized]
        public int textSpeed;
        [System.NonSerialized]
        public ALIGN text_align;

        [System.NonSerialized]
        public float name_x;
        [System.NonSerialized]
        public float name_y;
        [System.NonSerialized]
        public float name_width;
        [System.NonSerialized]
        public float name_height;
        [System.NonSerialized]
        public float name_image_x;
        [System.NonSerialized]
        public float name_image_y;
        [System.NonSerialized]
        public float name_image_width;
        [System.NonSerialized]
        public float name_image_height;
        [System.NonSerialized]
        public string name_font;
        [System.NonSerialized]
        public string name_picture;
        [System.NonSerialized]
        public int name_font_size;


        [System.NonSerialized]
        public Canvas mainCanvas;

        [System.NonSerialized]
        public Canvas behindCanvas;

        [System.NonSerialized]
        public Canvas UICanvas;

        //FadeCanvasのInterface取得
        [System.NonSerialized]
        public FadeUI fade;

        [System.NonSerialized]
        public Canvas CurtainCanvas;

        [System.NonSerialized]
        public VideoPlayer videoPlayer;

        [System.NonSerialized]
        public RawImage videoImage;

        [System.NonSerialized]
        public CanvasGroup mainCanvasGroup;

        [System.NonSerialized]
        public CanvasGroup behindCanvasGroup;

        [System.NonSerialized]
        public AudioSource bgm;

        [System.NonSerialized]
        public AudioSource se;

        [System.NonSerialized]
        public CanvasGroup UICanvasGroup;

        [System.NonSerialized]
        public GameObject UIGameObject;

        [System.NonSerialized]
        public GameObject TextGameObject;

        [NonSerialized]
        public float ruby_percent;
        public float ruby_rate;

        public Hashtable PLACE = new Hashtable();

        public enum ALIGN
        {
            Vertical,
            Horizontal
        };


        public Vector2 Scale()
        {
            return new Vector2((float)Screen.width / original_width, (float)Screen.height / original_height);
        }
        public void Initial()
        {
            //クリアデータ
            StaticData.Initial();
            StreamReader sr;
#if UNITY_STANDALONE_WIN
            sr = new StreamReader(Application.streamingAssetsPath + "/ini/maintext.ini");
            
#elif UNITY_STANDALONE_OSX
            sr = new StreamReader(Application.streamingAssetsPath + "/ini/maintext.ini");
#endif
            string all_line = sr.ReadToEnd();
            all_line = all_line.Replace(" ", "");
            all_line = all_line.Replace("\t", "");
            all_line = all_line.Replace("\r", "");
            string[] lists = all_line.Split('\n');
            foreach(string str in lists)
            {
                if (str.Length == 0) continue;
                if (str[0] == '#') continue;
                string[] data = str.Split(':');
                switch (data[0])
                {
                    case "width":
                        instance.width = int.Parse(data[1]);
                        break;
                    case "height":
                        instance.height = int.Parse(data[1]);
                        break;

                    case "text_speed":
                        instance.textSpeed = int.Parse(data[1]);
                        break;
                    case "text_x":
                        instance.text_x = int.Parse(data[1]);
                        break;
                    case "text_y":
                        instance.text_y = int.Parse(data[1]);
                        break;
                    case "text_width":
                        instance.text_width = int.Parse(data[1]);
                        break;
                    case "text_height":
                        instance.text_height = int.Parse(data[1]);
                        break;
                    case "text_image_x":
                        instance.text_image_x = int.Parse(data[1]);
                        break;
                    case "text_image_y":
                        instance.text_image_y = int.Parse(data[1]);
                        break;
                    case "text_image_width":
                        instance.text_image_width = int.Parse(data[1]);
                        break;
                    case "text_image_height":
                        instance.text_image_height = int.Parse(data[1]);
                        break;
                    case "text_font":
                        instance.text_font = data[1];
                        break;
                    case "text_picture":
                        instance.text_picture = data[1];
                        break;
                    case "text_font_size":
                        instance.text_font_size = int.Parse(data[1]);
                        break;
                    case "text_align":
                        instance.text_align = (data[1][0] == 'H' ? ALIGN.Horizontal : ALIGN.Vertical);
                        break;

                    case "name_x":
                        instance.name_x = int.Parse(data[1]);
                        break;
                    case "name_y":
                        instance.name_y = int.Parse(data[1]);
                        break;
                    case "name_width":
                        instance.name_width = int.Parse(data[1]);
                        break;
                    case "name_height":
                        instance.name_height = int.Parse(data[1]);
                        break;
                    case "name_image_x":
                        instance.name_image_x = int.Parse(data[1]);
                        break;
                    case "name_image_y":
                        instance.name_image_y = int.Parse(data[1]);
                        break;
                    case "name_image_width":
                        instance.name_image_width = int.Parse(data[1]);
                        break;
                    case "name_image_height":
                        instance.name_image_height = int.Parse(data[1]);
                        break;
                    case "name_font":
                        instance.name_font = data[1];
                        break;
                    case "name_picture":
                        instance.name_picture = data[1];
                        break;
                    case "name_font_size":
                        instance.name_font_size = int.Parse(data[1]);
                        break;
                    case "preset_position":
                        {
                            string[] inner_data = data[1].Split('(');
                            string command = inner_data[0];
                            inner_data[1] = inner_data[1].Replace(")", "");
                            string[] position = inner_data[1].Split(',');
                            instance.PLACE[command] = new Vector2(float.Parse(position[0]), -float.Parse(position[1]));
                        }
                        break;
                    case "ruby_percent":
                        instance.ruby_percent = float.Parse(data[1]);
                        instance.ruby_rate = instance.ruby_percent / 100;
                        break;
                    case "global":
                        {
                            string varName = data[1];
                            string type = data[2];
                            string val = data[3];
                            if (!StaticData.HasData(varName))
                            {
                                switch (type)
                                {
                                    case "Numeric":
                                        VariableData.setValue(varName, new NumericValue(float.Parse(val)));
                                        StaticData.AddData(varName);
                                        break;
                                    case "String":
                                        VariableData.setValue(varName, new StringValue(val));
                                        StaticData.AddData(varName);
                                        break;
                                    case "Boolean":
                                        VariableData.setValue(varName, new BooleanValue(bool.Parse(val)));
                                        StaticData.AddData(varName);
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            sr.Close();
        }
        
        public (int colorR, int colorG, int colorB, int colorA) GetIntRgbaFromString(string rawRgba)
        {
            // 接頭辞 '#' を除く
            string rgba = rawRgba.Substring(1);
            
            // rgba.Length == 6, 8 に対応
            int blockLength = 2;
            // 16進 to 10進
            int colorR = Convert.ToInt32(rgba.Substring(blockLength * 0, blockLength), 16);
            int colorG = Convert.ToInt32(rgba.Substring(blockLength * 1, blockLength), 16);
            int colorB = Convert.ToInt32(rgba.Substring(blockLength * 2, blockLength), 16);
            int colorA = RgbaMax;
            if (rgba.Length == blockLength * 4)
            {
                colorA = Convert.ToInt32(rgba.Substring(blockLength * 3, blockLength), 16);
            }
            
            return (colorR, colorG, colorB, colorA);
        }
        
        public float IntRgbaToFloat(int ri) => ri / (float)RgbaMax;
        
        public static ConstData instance
        {
            get
            {
                if (!_instance)
                {
                    var go = new GameObject("ConstData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ConstData>();
                    _instance.mainCanvas = GameObject.FindGameObjectWithTag(MainCanvasTag).GetComponent<Canvas>();
                    _instance.behindCanvas = GameObject.FindGameObjectWithTag(BehindCanvasTag).GetComponent<Canvas>();
                    _instance.UICanvas = GameObject.FindGameObjectWithTag(UICanvasTag).GetComponent<Canvas>();
                    _instance.bgm = GameObject.FindGameObjectWithTag(BgmTag).GetComponent<AudioSource>();
                    _instance.se = GameObject.FindGameObjectWithTag(SeTag).GetComponent<AudioSource>();
                    _instance.mainCanvasGroup = _instance.mainCanvas.GetComponent<CanvasGroup>();
                    _instance.behindCanvasGroup = _instance.behindCanvas.GetComponent<CanvasGroup>();
                    _instance.CurtainCanvas = GameObject.FindGameObjectWithTag(CurtainCanvasTag).GetComponent<Canvas>();
                    _instance.videoPlayer = GameObject.FindGameObjectWithTag(MovieTag).GetComponent<VideoPlayer>();
                    _instance.videoImage = GameObject.FindGameObjectWithTag(MovieTag).GetComponent<RawImage>();
                    _instance.TextGameObject = GameObject.FindGameObjectWithTag(TextTag).gameObject;
                    _instance.videoPlayer.gameObject.SetActive(false);
                    //メインキャンバス
                    _instance.MainCanvasPicture = new Dictionary<string, GameObject>
                    {
                        [_instance.MainPicture] = _instance.mainCanvas.transform.Find(_instance.MainPicture).gameObject,
                        [_instance.FacePicture] = _instance.mainCanvas.transform.Find(_instance.FacePicture).gameObject,
                        [_instance.BackgroundPicture] = _instance.mainCanvas.transform.Find(_instance.BackgroundPicture).gameObject
                    };
                    _instance.MainCanvasPictureRectTransform = new Dictionary<string, RectTransform>
                    {
                        [_instance.MainPicture] = _instance.MainCanvasPicture[_instance.MainPicture].GetComponent<RectTransform>(),
                        [_instance.FacePicture] = _instance.MainCanvasPicture[_instance.FacePicture].GetComponent<RectTransform>(),
                        [_instance.BackgroundPicture] = _instance.MainCanvasPicture[_instance.BackgroundPicture].GetComponent<RectTransform>(),
                    };

                    //裏キャンバス
                    _instance.BehindCanvasPicture = new Dictionary<string, GameObject>
                    {
                        [_instance.MainPicture] = _instance.behindCanvas.transform.Find(_instance.MainPicture).gameObject,
                        [_instance.FacePicture] = _instance.behindCanvas.transform.Find(_instance.FacePicture).gameObject,
                        [_instance.BackgroundPicture] = _instance.behindCanvas.transform.Find(_instance.BackgroundPicture).gameObject
                    };

                    _instance.BehindCanvasPictureRectTransform = new Dictionary<string, RectTransform>
                    {
                        [_instance.MainPicture] = _instance.BehindCanvasPicture[_instance.MainPicture].GetComponent<RectTransform>(),
                        [_instance.FacePicture] = _instance.BehindCanvasPicture[_instance.FacePicture].GetComponent<RectTransform>(),
                        [_instance.BackgroundPicture] = _instance.BehindCanvasPicture[_instance.BackgroundPicture].GetComponent<RectTransform>(),
                    };

                    _instance.UIGameObject = _instance.UICanvas.transform.Find(_instance.UIObject).gameObject;
                    _instance.UICanvasGroup = _instance.UIGameObject.GetComponent<CanvasGroup>();
                    _instance.fade = _instance.mainCanvas.GetComponent<FadeUI>();
                    _instance.Initial();
                    TextData.instance.MakeBox();
                    TextData.instance.textSpeed = _instance.textSpeed;
                }
                return _instance;
            }
        }
    }
}