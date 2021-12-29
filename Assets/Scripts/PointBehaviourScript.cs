using System;
using UnityEngine;

/*  セーブ機能   */
[Serializable]
public class PointBehaviourScript : MonoBehaviour
{
    //[SerializeField]
    //保存したい変数

    //string SAVE_KEY = 'PLAYER-SAVE-KEY';
    public void Save()
    {
        //Playerのデータを文字列に変換し保存
        //PlayerPrefs.SetString(SAVE_KEY, JsonUtility.ToJson(this));
        //PlayerPrefs.Save();
    }
    public void Load()
    {
        //JosnDataを取得
        //DataがNullの場合 : 空のData(new PlayerModel())を渡す
        //string jsonPlayer = PlayerPrefs.GetString(SAVE_KEY, JsonUtility.ToJson(new PlayerModel()));
        //JsonDataを復元
        //instance = JsonUtility.FromJson<PlayerModel>(jsonPlayer);
    }
    public void DeleteSaveData()
    {
        //PlayerPrefs.DeleteKey(SAVE_KEY);
        //PlayerPrefs.Save();
        //Load();
    }

    //[SerializeField] Transform parent;
    //[SerializeField] GameObject imagePrefab;

    //Objectの生成
    //GameObject image = Instantiate(imagePrefab);
    //親要素へ生成
    //image.transform.SetParent(parent, false);
}
