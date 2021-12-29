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

    // �G�ɑ�������e�[�u���F-1�Ȃ瑘�����Ȃ�, 0�Ȃ瑘��
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; // ���݂̃X�e�[�W�i�s�x

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "�����̂ɂ���������" });
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "�T����" });

        // �w�i��傫��
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1)); //Scale��߂�
        // �t�F�[�h�A�E�g
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        //2�b�����ăt�F�[�h�A�E�g
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0)); //Scale��߂�

        yield return new WaitForSeconds(2f);

        currentStage++;
        // �i�s�x��UI�ɔ��f
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            QuestClear();
        }
        else if (encountTable[currentStage] == 0) // 0�Ȃ瑘��
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }

    // Next�{�^���������ꂽ��
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
        DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[���o������" });
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
        DialogTextManager.instance.SetScenarios(new string[] { "�S�~�|���C��\n�X�̂��ɂ�̎q�ł��Ђ������悤" });
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
        DialogTextManager.instance.SetScenarios(new string[] { "���̒��x�̒�����ɂ�����\n������Ƃ�..." });
        yield return new WaitForSeconds(2f);
        sceneTransitionManager.LoadTo("Town");
    }
}
