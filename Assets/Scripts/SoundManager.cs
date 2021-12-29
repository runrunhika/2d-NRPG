using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*  
     *  �V���O���g�� 
     *  �Q�[������1�������݂��Ȃ�����(�����Ǘ��������)
     *  ���p�ꏊ�FScene�Ԃł̃f�[�^���L/�I�u�W�F�N�g���L
     */
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            //SceneLoad���Ă��j�󂳂�Ȃ�
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public AudioSource audioSourceBGM;  //BGM�̃X�s�[�J�[
    public AudioClip[] audioClipsBGM;   //BGM�̑f��(0:Title 1:Town 2:Quest 3:Battle)


    public AudioSource audioSourceSE;   //SE�X�s�[�J�[
    public AudioClip[] audioClipSE; //�f��

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void OnThisSE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipSE[index]);
    }
}
