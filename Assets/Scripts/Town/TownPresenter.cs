using UnityEngine;
using UnityEngine.SceneManagement;


public class TownPresenter : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�X�ɓ���" });
    }
    public void OnToQuestButton()
    {
        SoundManager.instance.OnThisSE(0);
    }

    public void OnSaveButton()
    {
        
    }
}