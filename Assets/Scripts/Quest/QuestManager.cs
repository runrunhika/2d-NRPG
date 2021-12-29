using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public StageUIManager stageUI;

    public GameObject[] enemyPrefab;
    private int randomEnemyPf;
    public GameObject questBG;

    // 敵に遭遇するテーブル：-1なら遭遇しない, 0なら遭遇
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; // 現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "魔物のにおいがする" });
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "探索中" });

        // 背景を大きく
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1)); //Scaleを戻す
        // フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        //2秒かけてフェードアウト
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0)); //Scaleを戻す

        yield return new WaitForSeconds(2f);

        currentStage++;
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            QuestClear();
        }
        else if (encountTable[currentStage] == 0) // 0なら遭遇
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }

    // Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.OnThisSE(0);
        stageUI.HideButtons();
        StartCoroutine(Searching());
    }

    public void OnToTownButton()
    {
        SoundManager.instance.OnThisSE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "モンスターが出現した" });
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab[SetRandomEnemy()]);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public int SetRandomEnemy()
    {
        if (Random.Range(0,10) > 5)
        {
            randomEnemyPf = 0;
        }
        else
        {
            randomEnemyPf = 1;
        }
        return randomEnemyPf;
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "ゴミ掃除修了\n街のおにゃの子でもひっかけよう" });
        SoundManager.instance.StopBGM();
        SoundManager.instance.OnThisSE(2);
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("Town");
    }

    public void PlayerDeath()
    {
        StartCoroutine(playerDeath());
    }

    IEnumerator playerDeath()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "この程度の虫けらにぃぃぃ\n負けるとは..." });
        yield return new WaitForSeconds(2f);
        sceneTransitionManager.LoadTo("Town");
    }
}
