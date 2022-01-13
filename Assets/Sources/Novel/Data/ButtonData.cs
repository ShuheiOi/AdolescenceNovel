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
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
namespace AdolescenceNovel
{
    //ボタン用のデータを格納するクラス
    public class ButtonData : MonoBehaviour, ISerializationCallbackReceiver
    {
        //Singletonパターン
        private static ButtonData _instance = null;

        public static void Load(ButtonSaveData bd)
        {
            instance.buttonList = new Dictionary<string, ButtonProperty>(bd.buttonList);
            instance.mainButton = bd.mainButton;
            instance.staticButton = bd.staticButton;
            instance.waitButton = bd.waitButton;
            instance.buttonActiveNum = bd.buttonActiveNum;
            instance.next = bd.next;
            instance.nextFile = bd.nextFile;
        }

        //登録されたボタンのテンプレート
        [System.NonSerialized]
        private Dictionary<string, ButtonProperty> buttonList;

        [SerializeField]
        public List<string> buttonListKeys;
        [SerializeField]
        public List<ButtonProperty> buttonListValues;

        //選択肢用のボタンリスト
        [SerializeField]
        private List<ButtonProperty> mainButton;

        //静的(常にゲーム上に残る)ボタンリスト
        [SerializeField]
        private List<ButtonProperty> staticButton;

        //選択肢用のボタンが待ち状態でいる確認
        [SerializeField]
        public bool waitButton;

        //現在アクティブになっているボタン番号
        [SerializeField]
        private int buttonActiveNum = -1;

        //押されていた場合どこへ移動するかのチェック
        [SerializeField]
        public int next;
        [SerializeField]
        public string nextFile;

        public static ButtonData instance
        {
            get
            {
                if (!_instance)
                {
                    var go = new GameObject("ButtonData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ButtonData>();
                    _instance.mainButton = new List<ButtonProperty>();
                    _instance.staticButton = new List<ButtonProperty>();
                    _instance.buttonList = new Dictionary<string, ButtonProperty>();
                    _instance.waitButton = false;
                    _instance.buttonActiveNum = -1;
                }
                return _instance;
            }
        }

        //ボタンプロパティ作成
        private ButtonProperty MakeButtonTemplate(string pictureName,float width,float height,string overpictureName, string fontName,string overFontName)
        {
            ButtonProperty bp = new ButtonProperty
            {
                button = Resources.Load<Button>(ConstData.instance.BUTTONPATH),
                width = width,
                height = height,
                fontName = fontName,
                overFontName = overFontName,
                pictureName = pictureName,
                overPictureName = overpictureName,
            };
            bp.image = bp.button.GetComponent<Image>();
            return bp;
        }
        public void SelectButton(int num)
        {
            this.mainButton[num % mainButton.Count].button.Select();
        }
        private ButtonProperty MakeButton(string valueName, float x, float y, string text, int next, string overPictureName, string pictureName,string fontName,string overFontName,int count)
        {
            ButtonProperty bp = new ButtonProperty
            {
                button = Instantiate<Button>(instance.buttonList[valueName].button, ConstData.instance.UIGameObject.transform),
            };
            bp.image = bp.button.GetComponent<Image>();
            bp.button.name = valueName;
            bp.valueName = valueName;
            bp.image.sprite = Resources.Load<Sprite>(instance.buttonList[valueName].pictureName);
            bp.pictureName = instance.buttonList[valueName].pictureName;
            bp.text = bp.button.GetComponentInChildren<TMP_Text>();
            bp.rect = bp.button.GetComponent<RectTransform>();
            bp.rect.sizeDelta = new Vector2(instance.buttonList[valueName].width, instance.buttonList[valueName].height);
            bp.width = instance.buttonList[valueName].width;
            bp.height = instance.buttonList[valueName].height;
            bp.rect.anchoredPosition = new Vector2(x, -y);
            bp.x = x;
            bp.y = -y;
            bp.next = next;
            bp.text.text = text;
            bp.contentsText = text;
            bp.overPictureName = instance.buttonList[valueName].overPictureName;
            bp.button.onClick.AddListener(() =>
            {
                if (!instance.waitButton) return;
                instance.next = bp.next;
                instance.waitButton = false;
            }
            );
            //マウスオーバーしたときの画像が設定している場合
            if (instance.buttonList[valueName].overPictureName.Length != 0 || instance.buttonList[valueName].overFontName.Length != 0)
            {
                var trigger = bp.button.GetComponent<EventTrigger>();
                
                var entry = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerEnter
                };
                entry.callback.AddListener((data) =>
                {
                    bp.button.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(overPictureName);
                    bp.button.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>(overFontName);
                    instance.buttonActiveNum = count;
                });
                var exit = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerExit
                };
                exit.callback.AddListener((data) =>
                {
                    bp.button.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(pictureName);
                    bp.button.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>(fontName);
                    instance.buttonActiveNum = -1;
                }
                );
                var select = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.Select
                };
                select.callback.AddListener((data) =>
                {
                    bp.button.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(overPictureName);
                    bp.button.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>(overFontName);
                    instance.buttonActiveNum = count;
                }
                );
                var deselect = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.Deselect
                };
                deselect.callback.AddListener((data) =>
                {
                    bp.button.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(pictureName);
                    bp.button.GetComponentInChildren<TMP_Text>().font = Resources.Load<TMP_FontAsset>(fontName);
                    instance.buttonActiveNum = -1;
                });
                trigger.triggers.Add(select);
                trigger.triggers.Add(deselect);
                trigger.triggers.Add(entry);
                trigger.triggers.Add(exit);
            }
            bp.button.gameObject.SetActive(true);
            return bp;
        }

        //ボタンのアクティブ化
        public void ActiveButton()
        {
            instance.buttonActiveNum = -1;
            foreach(ButtonProperty button in instance.mainButton)
            {
                button.button.gameObject.SetActive(true);
            }
        }

        public void DeleteMainButton()
        {
            foreach (ButtonProperty button in instance.mainButton)
            {
                Destroy(button.button.gameObject);
                Destroy(button.button);
            }
            instance.mainButton.Clear();
        }
        public void DeleteButtonList()
        {
            instance.buttonList.Clear();
        }

        //ボタンのテンプレート作成
        //public void RegistButton(string valueName,string pictureName,int width,int height)
        //{
        //    instance.buttonList.Add(valueName, MakeButtonTemplate(pictureName,width,height));
        //}

        public void RegistButton(string valueName,string pictureName,int width,int height,string overPicture,string fontName,string overFontName)
        {
            if (!instance.buttonList.ContainsKey(valueName))
            {
                instance.buttonList.Add(valueName, MakeButtonTemplate(pictureName, width, height, overPicture, fontName, overFontName));
            }
            else
            {
                instance.buttonList.Remove(valueName);
                instance.buttonList[valueName] = MakeButtonTemplate(pictureName, width, height, overPicture, fontName, overFontName);
            }
        }

        //ボタン描画
        public void MainDrawButton(string valueName, int x, int y,string text, int next)
        {
            instance.mainButton.Add(MakeButton(valueName, x, y,text,next,instance.buttonList[valueName].overPictureName,instance.buttonList[valueName].pictureName,instance.buttonList[valueName].fontName,instance.buttonList[valueName].overFontName, instance.mainButton.Count));
        }

        //指定した場所にジャンプする
        public void ButtonJump()
        {
            SystemData.instance.Jump(instance.next);
        }

        public void ButtonSelect()
        {
            int count = instance.mainButton.Count;
            if (KeyConfig.instance.CheckUp())
            {
                if (instance.buttonActiveNum != -1)
                {
                    instance.buttonActiveNum--;
                }
                else
                {
                    instance.buttonActiveNum = 0;
                }
                instance.buttonActiveNum = (instance.buttonActiveNum + count) % count;
            }
            if (KeyConfig.instance.CheckDown())
            {
                if (instance.buttonActiveNum != -1)
                {
                    instance.buttonActiveNum++;
                }
                else
                {
                    instance.buttonActiveNum = 0;
                }
                instance.buttonActiveNum = (instance.buttonActiveNum + count) % count;
            }
            if (instance.buttonActiveNum != -1) instance.mainButton[instance.buttonActiveNum % count].button.Select();
        }
        public int SelectButtonNum()
        {
            if (instance.buttonActiveNum == -1) return -1;
            if (instance.mainButton.Count == 0) return -1;
            return instance.buttonActiveNum % instance.mainButton.Count;
        }

        public void OnBeforeSerialize()
        {
            instance.buttonListKeys = new List<string>();
            instance.buttonListValues = new List<ButtonProperty>();
            foreach(string key in instance.buttonList.Keys)
            {
                instance.buttonListKeys.Add(key);
                instance.buttonListValues.Add(instance.buttonList[key]);
            }

        }

        public void OnAfterDeserialize()
        {
        }
    }
    public class ButtonSaveData : ISerializationCallbackReceiver
    {
        //登録されたボタンのテンプレート
        [System.NonSerialized]
        public Dictionary<string, ButtonProperty> buttonList;

        [SerializeField]
        public List<string> buttonListKeys;
        [SerializeField]
        public List<ButtonProperty> buttonListValues;

        //選択肢用のボタンリスト
        [SerializeField]
        public List<ButtonProperty> mainButton;

        //静的(常にゲーム上に残る)ボタンリスト
        [SerializeField]
        public List<ButtonProperty> staticButton;

        //選択肢用のボタンが待ち状態でいる確認
        [SerializeField]
        public bool waitButton;

        //現在アクティブになっているボタン番号
        [SerializeField]
        public int buttonActiveNum = -1;

        //押されていた場合どこへ移動するかのチェック
        [SerializeField]
        public int next;
        [SerializeField]
        public string nextFile;

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }

        public void OnAfterDeserialize()
        {
            int length = buttonListKeys.Count;
            buttonList = new Dictionary<string, ButtonProperty>();
            ButtonData.instance.DeleteMainButton();
            ButtonData.instance.DeleteButtonList();
            for (int i = 0; i < length; i++)
            {
                ButtonProperty template = buttonListValues[i];
                ButtonData.instance.RegistButton(buttonListKeys[i], template.pictureName, (int)template.width, (int)template.height, template.overPictureName, template.fontName, template.overFontName);
            }
            length = mainButton.Count;
            List<ButtonProperty> mainbutton_temp = new List<ButtonProperty>(mainButton);
            mainButton = new List<ButtonProperty>();
            for (int i = 0; i < length; i++)
            {
                ButtonProperty template = mainbutton_temp[i];
                ButtonData.instance.MainDrawButton(template.valueName, (int)template.x, (int)template.y, template.contentsText, template.next);
            }
        }
    }
}