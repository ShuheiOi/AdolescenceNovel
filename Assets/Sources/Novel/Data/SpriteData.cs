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
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;
namespace AdolescenceNovel
{
    //スプライトデータの保存を行う
    public class SpriteData : MonoBehaviour, ISerializationCallbackReceiver
    {
        private static SpriteData _instance = null;
        public static SpriteData instance
        {
            get
            {
                if (!_instance)
                {
                    var go = new GameObject("SpriteData");
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<SpriteData>();
                    _instance.backGameObject = new Dictionary<string, Image>();
                    _instance.frontGameObject = new Dictionary<string, Image>();
                }
                return _instance;
            }
        }
        [System.NonSerialized]
        private Dictionary<string, Image> backGameObject;

        [SerializeField]
        private List<string> backGameObjectKeys;
        [SerializeField]
        private List<ImageSaveData> backGameObjectValues;

        [System.NonSerialized]
        private Dictionary<string, Image> frontGameObject;
        [SerializeField]
        List<string> frontGameObjectKeys;
        [SerializeField]
        List<ImageSaveData> frongGameObjectValues;

        [System.NonSerialized]
        private Image backBackGroundGameObject;

        [SerializeField]
        ImageSaveData backBackGroundGameObjectSaveData;

        [System.NonSerialized]
        private Image frontBackGroundGameObject;

        [SerializeField]
        ImageSaveData frontBackGroundGameObjectSaveData;

        public static void Load(SpriteSaveData sd)
        {
            _instance.backGameObject = sd.backGameObject;
            _instance.frontGameObject = sd.frontGameObject;
        }

        //データを新規に追加する際に実行
        public void Append(string key, Image data)
        {
            //すでにデータが入っている場合削除を行う
            if (instance.backGameObject.ContainsKey(key))
            {
                Destroy(instance.backGameObject[key].gameObject);
            }
            instance.backGameObject[key] = data;
        }

        //バックグラウンド画像変更
        public void DrawBackGround(string path)
        {
            //ImagePrefab取得
            Image data = Resources.Load<Image>(ConstData.instance.IMAGEPATH);
            data.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            data.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            data.rectTransform.pivot = new Vector2(0.5f, 0.5f);

            //裏キャンバスに表示
            Image image = MonoBehaviour.Instantiate(data, ConstData.instance.BehindCanvasPicture[ConstData.instance.BackgroundPicture].transform);

            try
            {
                //画像の変更
                image.sprite = Resources.Load<Sprite>(path);
                image.sprite.name = path;
            }
            catch (UnassignedReferenceException e)
            {
                string[] check = path.Split('.');
                string last = check[check.Length - 1];
                if(last == "png" || last == "bmp")
                {
                    Debug.LogAssertion("拡張子が原因かもしれません\n拡張子は必要ありません");
                }
                Debug.LogAssertion($"{path}という画像がない可能性があります");
                Debug.Break();

            }
            //位置の移動
            image.rectTransform.anchoredPosition = new Vector2(0, 0);

            image.SetNativeSize();

            image.rectTransform.localScale = ConstData.instance.Scale();
            DeleteBackBackGround();
            backBackGroundGameObject = image;
            backBackGroundGameObject.name = path;

        }

        public void DrawBackGround(Color color)
        {
            //ImagePrefab取得
            Image data = Resources.Load<Image>(ConstData.instance.IMAGEPATH);

            //裏キャンバスに表示
            Image image = MonoBehaviour.Instantiate(data, ConstData.instance.BehindCanvasPicture[ConstData.instance.BackgroundPicture].transform);

            //位置の移動
            image.rectTransform.anchoredPosition = new Vector2(0, 0);
            
            image.rectTransform.localScale = new Vector2(ConstData.instance.width,ConstData.instance.height);
            image.color = color;
            DeleteBackBackGround();
            backBackGroundGameObject = image;
            backBackGroundGameObject.name = $"#{color.r},{color.g},{color.b}";
        }

        public void DeleteBackBackGround()
        {
            if (instance.backBackGroundGameObject == null) return;
            Destroy(instance.backBackGroundGameObject.gameObject);
            Destroy(instance.backBackGroundGameObject);
            instance.backBackGroundGameObject = null;
        }
        public void DeleteFrontBackGround()
        {
            if (instance.frontBackGroundGameObject == null) return;
            Destroy(instance.frontBackGroundGameObject.gameObject);
            Destroy(instance.frontBackGroundGameObject);
            instance.frontBackGroundGameObject = null;
        }

        //指定したデータを削除する
        public void DeleteBack(string key)
        {
            //データがなかった場合即終了
            if (!instance.backGameObject.ContainsKey(key)) return;

            Destroy(instance.backGameObject[key].gameObject);
            Destroy(instance.backGameObject[key]);
            instance.backGameObject.Remove(key);
        }

        public void DeleteFront(string key)
        {
            //データがなかった場合即終了
            if (!instance.frontGameObject.ContainsKey(key)) return;

            Destroy(instance.frontGameObject[key].gameObject);
            Destroy(instance.frontGameObject[key]);
            instance.frontGameObject.Remove(key);
        }
        
        public void DeleteAllBack()
        {
            List<string> keys = new List<string>(instance.backGameObject.Keys);
            foreach (string key in keys)
            {
                instance.DeleteBack(key);
            }
        }
        public void DeleteAllFront()
        {
            List<string> keys = new List<string>(instance.frontGameObject.Keys);
            foreach (string key in keys)
            {
                instance.DeleteFront(key);
            }
        }

        //指定したKeyのデータを取得する
        public Image Get(string key)
        {
            if (!instance.backGameObject.ContainsKey(key)) return null;
            return instance.backGameObject[key];
        }

        //指定したKeyのデータを更新する
        public bool Change(string key, Image image)
        {
            if (!instance.backGameObject.ContainsKey(key)) return false;
            instance.backGameObject[key] = image;
            return true;
        }

        //裏画面の画像を表に持ってくる
        public void Flip()
        {
            List<string> keys = new List<string>(instance.frontGameObject.Keys);
            foreach (string key in keys)
            {
                instance.DeleteFront(key);
            }
            instance.DeleteFrontBackGround();
            keys = new List<string>(instance.backGameObject.Keys);
            int childCount = ConstData.instance.BehindCanvasPicture[ConstData.instance.MainPicture].transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = ConstData.instance.BehindCanvasPicture[ConstData.instance.MainPicture].transform.GetChild(i);
                string key = child.name;
                Image tmp = instance.Get(key);
                Image flipImage = Instantiate(tmp, ConstData.instance.MainCanvasPicture[ConstData.instance.MainPicture].transform);
                flipImage.name = tmp.name;
                instance.frontGameObject[key] = flipImage;
            }
            //顔表示に対する処理
            int facechildCount = ConstData.instance.BehindCanvasPicture[ConstData.instance.FacePicture].transform.childCount;
            for (int i = 0; i < facechildCount; i++)
            {
                Transform child = ConstData.instance.BehindCanvasPicture[ConstData.instance.FacePicture].transform.GetChild(i);
                string key = child.name;
                Image tmp = instance.Get(key);
                Image flipImage = Instantiate(tmp, ConstData.instance.MainCanvasPicture[ConstData.instance.FacePicture].transform);
                flipImage.name = tmp.name;
                instance.frontGameObject[key] = flipImage;
            }
            if (instance.backBackGroundGameObject != null)
            {
                Image background = Instantiate(instance.backBackGroundGameObject, ConstData.instance.MainCanvasPicture[ConstData.instance.BackgroundPicture].transform);
                background.name = instance.backBackGroundGameObject.name;
                frontBackGroundGameObject = background;
            }
        }

        //特定の裏画面の画像を表に持ってくる
        public void Flip(string key)
        {
            Image tmp = instance.Get(key);
            Image flipImage = Instantiate(tmp, ConstData.instance.MainCanvasPicture[ConstData.instance.MainPicture].transform);
            flipImage.name = tmp.name;
            instance.DeleteFront(key);
            instance.frontGameObject[key] = flipImage;
        }

        //ld/cl用
        public void Draw(string pictureName,string place)
        {
            //ImagePrefab取得        
            Image data = Resources.Load<Image>(ConstData.instance.IMAGEPATH);

            //裏キャンバスに表示
            Image image = MonoBehaviour.Instantiate(data, ConstData.instance.BehindCanvasPicture[ConstData.instance.MainPicture].transform);
            
            try
            {
                //画像の変更
                image.sprite = Resources.Load<Sprite>(pictureName);
                image.sprite.name = pictureName;
            }
            catch (UnassignedReferenceException e)
            {
                string[] check = pictureName.Split('.');
                string last = check[check.Length - 1];
                if (last == "png" || last == "bmp")
                {
                    Debug.LogAssertion("拡張子が原因かもしれません\n拡張子は必要ありません");
                }
                Debug.LogAssertion($"{pictureName}という画像がない可能性があります");
                Debug.Break();
            }

            image.SetNativeSize();

            image.rectTransform.localScale = ConstData.instance.Scale();

            //位置の移動
            image.rectTransform.anchorMin = new Vector2(0, 1);
            image.rectTransform.anchorMax = new Vector2(0, 1);
            image.rectTransform.pivot = new Vector2(0, 1);
            image.rectTransform.anchoredPosition = (Vector2)ConstData.instance.PLACE[place];

            image.name = $"__{place}";

            //データの保存
            instance.Append($"__{place}", image);
        }

        //lsp/lsph用
        public void Draw(string pictureName,string spriteName,int x,int y,bool isFace, bool isActive = true)
        {
            string spriteNameFace = "";

            //ImagePrefab取得        
            Image data = Resources.Load<Image>(ConstData.instance.IMAGEPATH);

            //裏キャンバスに表示
            Image image;
            if (isFace)
            {
                spriteNameFace = "_Face_";
                image = MonoBehaviour.Instantiate(data, ConstData.instance.BehindCanvasPicture[ConstData.instance.FacePicture].transform);
            }
            else
            {
                image = MonoBehaviour.Instantiate(data, ConstData.instance.BehindCanvasPicture[ConstData.instance.MainPicture].transform);
            }

            image.rectTransform.anchorMin = new Vector2(0, 1.0f);
            image.rectTransform.anchorMax = new Vector2(0, 1.0f);
            image.rectTransform.pivot = new Vector2(0, 1f);

            //画像の変更
            try
            {
                //画像の変更
                image.sprite = Resources.Load<Sprite>(pictureName);
                image.sprite.name = pictureName;
            }
            catch (UnassignedReferenceException e)
            {
                string[] check = pictureName.Split('.');
                string last = check[check.Length - 1];
                if (last == "png" || last == "bmp")
                {
                    Debug.LogAssertion("拡張子が原因かもしれません\n拡張子は必要ありません");
                }
                Debug.LogAssertion($"{pictureName}という画像がない可能性があります");
                Debug.Break();
            }

            image.SetNativeSize();

            image.rectTransform.localScale = ConstData.instance.Scale();

            //位置の移動
            image.rectTransform.anchoredPosition = new Vector2(x,-y);

            image.name = spriteNameFace + spriteName;

            // 画像を表示するかを設定
            image.gameObject.SetActive(isActive);
            
            //データの保存
            instance.Append(spriteName, image);
        }

        //表示モードを切り替える
        public void ChangeVisibleState(string spriteName, int visibleState)
        {
            //フラグを設定する
            bool visible = (visibleState == 0) ? false : true;

            //フラグを更新する
            if (instance.backGameObject.ContainsKey(spriteName)) 
                instance.backGameObject[spriteName].gameObject.SetActive(visible);
        }

        //バックグラウンドの表示モードを切り替える
        public void ChangeVisibleStateBackGround(bool visible)
        {
            instance.frontBackGroundGameObject.gameObject.SetActive(visible);
        }
        
        // スプライトの表示位置を変更する
        public void MoveBack(string spriteName, float destinationX, float destinationY)
        {
            // 無ければ終了
            if (!instance.backGameObject.ContainsKey(spriteName)) return;

            instance.backGameObject[spriteName].rectTransform.anchoredPosition = new Vector2(destinationX, -destinationY);
        }
        
        public void OnBeforeSerialize()
        {
            instance.backGameObjectKeys = new List<string>();
            instance.backGameObjectValues = new List<ImageSaveData>();
            foreach(string key in instance.backGameObject.Keys)
            {
                instance.backGameObjectKeys.Add(key);
                instance.backGameObjectValues.Add(new ImageSaveData(instance.backGameObject[key]));
            }

            instance.frontGameObjectKeys = new List<string>();
            instance.frongGameObjectValues = new List<ImageSaveData>();
            foreach(string key in instance.frontGameObject.Keys)
            {
                instance.frontGameObjectKeys.Add(key);
                instance.frongGameObjectValues.Add(new ImageSaveData(instance.frontGameObject[key]));
            }
            frontBackGroundGameObjectSaveData = new ImageSaveData(instance.frontBackGroundGameObject);
            backBackGroundGameObjectSaveData = new ImageSaveData(instance.backBackGroundGameObject);
        }

        public void OnAfterDeserialize()
        {
            throw new System.NotImplementedException();
        }
    }
    [System.Serializable]
    public struct ImageSaveData
    {
        [SerializeField]
        public string pictureName;
        [SerializeField]
        public float x;
        [SerializeField]
        public float y;
        [SerializeField]
        public string spriteName;
        [SerializeField]
        public bool isFace;
        [SerializeField]
        public bool isActive;
        [SerializeField]
        public string place;
        public ImageSaveData(Image data)
        {
            spriteName = data.name;
            pictureName = "";
            if(spriteName[0]!='#')pictureName = data.sprite.name;
            place = "";
            //ld関係->__{場所名}
            if (data.name.Length > 1)
            {
                if (data.name[0] == '_' && data.name[1] == '_')
                {
                    place = data.name.Split('_')[2];
                }
            }
            isFace = false;
            //isFace
            if (data.name.Length > 5)
            {
                if (data.name[0] == '_' && data.name[1] == 'F' && data.name[2] == 'A' && data.name[3] == 'C' && data.name[4] == 'E' && data.name[5] == '_')
                {
                    isFace = true;
                }
            }
            x = data.rectTransform.anchoredPosition.x;
            y = data.rectTransform.anchoredPosition.y;
            isActive = data.gameObject.activeSelf;
        }
    }
    public class SpriteSaveData : ISerializationCallbackReceiver
    {
        public Dictionary<string, Image> backGameObject;

        [SerializeField]
        private List<string> backGameObjectKeys;
        [SerializeField]
        private List<ImageSaveData> backGameObjectValues;

        public Dictionary<string, Image> frontGameObject;
        [SerializeField]
        public List<string> frontGameObjectKeys;
        [SerializeField]
        public List<ImageSaveData> frontGameObjectValues;

        [System.NonSerialized]
        private Image backBackGroundGameObject;

        [SerializeField]
        ImageSaveData backBackGroundGameObjectSaveData;

        [System.NonSerialized]
        private Image frontBackGroundGameObject;

        [SerializeField]
        ImageSaveData frontBackGroundGameObjectSaveData;

        public void OnBeforeSerialize()
        {
            throw new System.NotImplementedException();
        }

        public void OnAfterDeserialize()
        {
            int length = frontGameObjectKeys.Count;
            SpriteData.instance.DeleteAllBack();
            SpriteData.instance.DeleteAllFront();
            SpriteData.instance.DeleteBackBackGround();
            SpriteData.instance.DeleteFrontBackGround();
            for (int i = 0; i < length; i++)
            {
                if(frontGameObjectValues[i].place != "")
                {
                    SpriteData.instance.Draw(frontGameObjectValues[i].pictureName, frontGameObjectValues[i].place);
                }
                else
                {
                    SpriteData.instance.Draw(frontGameObjectValues[i].pictureName, frontGameObjectValues[i].spriteName, (int)frontGameObjectValues[i].x, (int)frontGameObjectValues[i].y, frontGameObjectValues[i].isFace, frontGameObjectValues[i].isActive);
                }
            }
            string color_tmp = frontBackGroundGameObjectSaveData.spriteName;
            if (color_tmp[0] == '#')
            {
                color_tmp = color_tmp.Split('#')[1];
                string[] rgb = color_tmp.Split(',');
                SpriteData.instance.DrawBackGround(new Color(float.Parse(rgb[0]),float.Parse(rgb[1]),float.Parse(rgb[2])));
            }
            else
            {
                SpriteData.instance.DrawBackGround(color_tmp);
            }
            SpriteData.instance.Flip();
            length = backGameObjectKeys.Count;
            for (int i = 0; i < length; i++)
            {
                if (backGameObjectValues[i].place != "")
                {
                    SpriteData.instance.Draw(backGameObjectValues[i].pictureName, backGameObjectValues[i].place);
                }
                else
                {
                    SpriteData.instance.Draw(backGameObjectValues[i].pictureName, backGameObjectValues[i].spriteName, (int)backGameObjectValues[i].x, (int)backGameObjectValues[i].y, backGameObjectValues[i].isFace, backGameObjectValues[i].isActive);
                }
            }
            color_tmp = backBackGroundGameObjectSaveData.pictureName;
            if (color_tmp.Length > 0)
            {
                if (color_tmp[0] == '#')
                {
                    color_tmp = color_tmp.Split('#')[1];
                    string[] rgb = color_tmp.Split(',');
                    SpriteData.instance.DrawBackGround(new Color(float.Parse(rgb[0]), float.Parse(rgb[1]), float.Parse(rgb[2])));
                }
                else
                {
                    SpriteData.instance.DrawBackGround(color_tmp);
                }
            }
        }
    }
}