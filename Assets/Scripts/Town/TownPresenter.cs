using UnityEngine;
using UnityEngine.SceneManagement;


public class TownPresenter : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "ŠX‚É“ž’…" });
    }
    public void OnToQuestButton()
    {
        SoundManager.instance.OnThisSE(0);
    }

    public void OnSaveButton()
    {
        
    }
}