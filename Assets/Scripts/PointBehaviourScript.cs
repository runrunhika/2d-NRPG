using System;
using UnityEngine;

/*  �Z�[�u�@�\   */
[Serializable]
public class PointBehaviourScript : MonoBehaviour
{
    //[SerializeField]
    //�ۑ��������ϐ�

    //string SAVE_KEY = 'PLAYER-SAVE-KEY';
    public void Save()
    {
        //Player�̃f�[�^�𕶎���ɕϊ����ۑ�
        //PlayerPrefs.SetString(SAVE_KEY, JsonUtility.ToJson(this));
        //PlayerPrefs.Save();
    }
    public void Load()
    {
        //JosnData���擾
        //Data��Null�̏ꍇ : ���Data(new PlayerModel())��n��
        //string jsonPlayer = PlayerPrefs.GetString(SAVE_KEY, JsonUtility.ToJson(new PlayerModel()));
        //JsonData�𕜌�
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

    //Object�̐���
    //GameObject image = Instantiate(imagePrefab);
    //�e�v�f�֐���
    //image.transform.SetParent(parent, false);
}
