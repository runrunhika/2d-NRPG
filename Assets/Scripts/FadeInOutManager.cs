using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//  Scene切り替え時のFadeIn・Out
public class FadeInOutManager : MonoBehaviour
{
    public float fadeTime = 1;
    public static FadeInOutManager instance;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CanvasGroup canvasGroup;

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(0, fadeTime)
            .OnComplete(() => canvasGroup.blocksRaycasts = false);
    }

    public void FadeOutToIn(TweenCallback action)
    {
        canvasGroup.blocksRaycasts = true;
        //FadeOutが終了次第FadeInを実行
        canvasGroup.DOFade(1, fadeTime)
            //action(登録された関数(SceneTransitionManager<Load))とFadeIn関数を実行
            .OnComplete(() =>
            {
                action();
                FadeIn();
            }
        );
    }
}
