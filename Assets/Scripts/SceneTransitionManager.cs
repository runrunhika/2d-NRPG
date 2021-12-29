using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  ‚·‚×‚Ä‚ÌScene‚Å—˜—p    */
public class SceneTransitionManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeInOutManager.instance.FadeOutToIn(() => Load(sceneName));

        
    }

    void Load(string sceneName)
    {
        SoundManager.instance.PlayBGM(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
