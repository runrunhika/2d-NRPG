using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    public void OnToTownButton()
    {
        SoundManager.instance.OnThisSE(0);
    }

    public void OnContinueButton()
    {
        SoundManager.instance.OnThisSE(0);
    }
}