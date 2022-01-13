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
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
namespace AdolescenceNovel
{
    public class TextData : MonoBehaviour, ISerializationCallbackReceiver
    {
        private static TextData _instance = null;
        [System.NonSerialized]
        public Dictionary<string, TextProperty> textbox;

        [SerializeField]
        public List<string> textboxKeys;
        [SerializeField]
        public List<TextProperty> textboxValues;


        [SerializeField]
        public bool isFooterRegistered = false;
        [SerializeField]
        public TextProperty footer;
        [System.NonSerialized]
        private TMP_Text originalText;
        [SerializeField]
        public int textSpeed;

        public static void Load(TextSaveData td)
        {
            _instance.textbox = td.textbox;
            _instance.isFooterRegistered = td.isFooterRegistered;
            _instance.footer = td.footer;
            _instance.textSpeed = td.textSpeed;
        }

        public static TextData instance
        {
            get
            {
                if(_instance == null)
                {
                    var go = new GameObject("TextData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<TextData>();
                    _instance.textbox = new Dictionary<string, TextProperty>();
                    _instance.originalText = Resources.Load<TMP_Text>(ConstData.instance.TEXTBOXPATH);
                    _instance.isFooterRegistered = false;
                }
                return _instance;
            }
        }
        public static TextProperty MakeProperty(float text_x,float text_y,float text_width,float text_height,float image_x,float image_y,float image_width,float image_height,string picturename,string fontname,int fontsize,ConstData.ALIGN align = ConstData.ALIGN.Horizontal)
        {
            TextProperty textProperty = new TextProperty();
            
            textProperty.textbox = Instantiate<Image>(Resources.Load<Image>(ConstData.instance.IMAGEPATH));
            textProperty.text = Instantiate<TMP_Text>(Resources.Load<TMP_Text>(ConstData.instance.TEXTBOXPATH));

            textProperty.textbox.rectTransform.anchorMax = new Vector2(0, 1);
            textProperty.textbox.rectTransform.anchorMin = new Vector2(0, 1);
            textProperty.textbox.rectTransform.pivot = new Vector2(0, 1);

            textProperty.textbox.transform.SetParent(ConstData.instance.TextGameObject.transform);
            textProperty.text.transform.SetParent(textProperty.textbox.transform);


            textProperty.textbox.rectTransform.localPosition = new Vector2(image_x, -image_y);
            textProperty.textbox.rectTransform.sizeDelta = new Vector2(image_width, image_height);
            textProperty.textbox.transform.localScale = new Vector2(1, 1);

            textProperty.text.rectTransform.localPosition = new Vector2(text_x, -text_y);
            textProperty.text.rectTransform.sizeDelta = new Vector2(text_width, text_height);

            if (picturename.Length > 0)
            {
                textProperty.textbox.sprite = Resources.Load<Sprite>(picturename);
            }
            else
            {
                textProperty.textbox.color = new Color(0, 0, 0, 0);
            }

            textProperty.text.font = Resources.Load<TMP_FontAsset>(fontname);
            textProperty.textbox.gameObject.SetActive(false);
            textProperty.text.text = "";
            textProperty.text.fontSize = fontsize;
            return textProperty;
        }
        public void MakeBox()
        {
            //メインのテキストボックス
            instance.textbox.Add(
                ConstData.TextboxMain, MakeProperty(
                    ConstData.instance.text_x,
                    ConstData.instance.text_y,
                    ConstData.instance.text_width,
                    ConstData.instance.text_height,
                    ConstData.instance.text_image_x,
                    ConstData.instance.text_image_y,
                    ConstData.instance.text_image_width,
                    ConstData.instance.text_image_height,
                    ConstData.instance.text_picture,
                    ConstData.instance.text_font,
                    ConstData.instance.text_font_size));
            //メインのネームボックス
            instance.textbox.Add(
                ConstData.NameboxMain, MakeProperty(
                    ConstData.instance.name_x,
                    ConstData.instance.name_y,
                    ConstData.instance.name_width,
                    ConstData.instance.name_height,
                    ConstData.instance.name_image_x,
                    ConstData.instance.name_image_y,
                    ConstData.instance.name_image_width,
                    ConstData.instance.name_image_height,
                    ConstData.instance.name_picture,
                    ConstData.instance.name_font,
                    ConstData.instance.name_font_size
                    ));
        }
        public void DrawTextbox(string name)
        {
            instance.textbox[name].textbox.gameObject.SetActive(true);
        }
        public void DisdrawTextbox(string name)
        {
            instance.textbox[name].textbox.gameObject.SetActive(false);
        }
        public void SetTextboxVisibility(string name, bool visible)
        {
            if (!instance.textbox.ContainsKey(name))
            {
                // TODO: エラーを投げてから終了
                return;
            }
            instance.textbox[name].textbox.gameObject.SetActive(visible);
        }
        public void SetNameboxVisibility(bool visible)
        {
            // ConstData.NameboxMainキーは必ず存在
            instance.textbox[ConstData.NameboxMain].textbox.gameObject.SetActive(visible);
        }
        
        public void SetTextboxContent(string name, string content, int fontSize, float colorR, float colorG, float colorB, float colorA)
        {
            if (!instance.textbox.ContainsKey(name))
            {
                // TODO: エラーを投げてから終了
                return;
            }
            
            instance.textbox[name].text.text = content;
            instance.textbox[name].text.fontSize = fontSize;
            instance.textbox[name].text.color = new Color(colorR, colorG, colorB, colorA);
        }
        public void SetTextboxContent(string name, string content, int fontSize, float colorR, float colorG, float colorB, float colorA, string fontName)
        {
            if (!instance.textbox.ContainsKey(name))
            {
                // TODO: エラーを投げてから終了
                return;
            }
            
            instance.textbox[name].text.font = Resources.Load<TMP_FontAsset>(fontName);
            SetTextboxContent(name, content, fontSize, colorR, colorG, colorB, colorA);
        }
        
        public void SetFooterVisibility(bool visible)
        {
            if (!instance.isFooterRegistered)
            {
                // TODO: エラーを投げてから終了
                return;
            }
            instance.footer.textbox.gameObject.SetActive(visible);
        }

        public static string SetRubyOffset_Vertical()
        {
            string blank = " ";
            return $"<voffset={1+ConstData.instance.ruby_percent/100}em><mspace=1em><size={ConstData.instance.ruby_percent}%>{blank}</size></mspace></voffset><space=-1em>";
        }

        public static string SetRubyOffset(string rubiedStr,string rubied_all,string rubyStr,string ruby_all)
        {
            //ルビがつけられる文章の幅
            float rubied_all_x = instance.textbox[ConstData.TextboxMain].text.GetPreferredValues(rubied_all).x;
            //ルビ文章の幅
            float ruby_all_x = instance.textbox[ConstData.TextboxMain].text.GetPreferredValues(ruby_all).x;
            //ルビが付けられる文章の現在の幅
            float rubied_x = instance.textbox[ConstData.TextboxMain].text.GetPreferredValues(rubiedStr).x;

            float space = (rubied_all_x - ruby_all_x * ConstData.instance.ruby_rate)/2f;
            float offset = rubied_all_x / 2f - ruby_all_x * (ConstData.instance.ruby_rate / 2.0f);
            if (offset < 0)
            {
                offset = 0;
            }
            if (space > 0)
            {
                space = 0;
            }
            else
            {
                space *= -1;
            }
            return $"<space={space}>" + rubiedStr + $"<space={rubied_all_x - rubied_x}><space=-{rubied_all_x / 2f + ruby_all_x * (ConstData.instance.ruby_rate / 2)}><voffset={1}em><size={ConstData.instance.ruby_percent}%><mspace=0em>" + rubyStr + $"</mspace></size></voffset> <space={offset}>";
        }

        public void OnBeforeSerialize()
        {
            instance.textboxKeys = new List<string>();
            instance.textboxValues = new List<TextProperty>();
            foreach(string key in instance.textbox.Keys)
            {
                instance.textboxKeys.Add(key);
                instance.textboxValues.Add(instance.textbox[key]);
            }
        }

        public void OnAfterDeserialize()
        {
            instance.textbox = new Dictionary<string, TextProperty>();
            int length = instance.textboxKeys.Count;
            for(int i = 0; i < length; i++)
            {
                instance.textbox.Add(instance.textboxKeys[i], instance.textboxValues[i]);
            }
        }
    }
    public class TextSaveData : ISerializationCallbackReceiver
    {
        [System.NonSerialized]
        public Dictionary<string, TextProperty> textbox;

        [SerializeField]
        public List<string> textboxKeys;
        [SerializeField]
        public List<TextProperty> textboxValues;


        [SerializeField]
        public bool isFooterRegistered = false;
        [SerializeField]
        public TextProperty footer;
        [System.NonSerialized]
        public TMP_Text originalText;
        [SerializeField]
        public int textSpeed;

        public void OnAfterDeserialize()
        {
            textbox = new Dictionary<string, TextProperty>();
            int length = textboxKeys.Count;
            for (int i = 0; i < length; i++)
            {
                textbox.Add(textboxKeys[i], textboxValues[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }
    }
}