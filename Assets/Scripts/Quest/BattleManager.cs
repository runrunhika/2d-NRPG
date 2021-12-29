using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*   PlayerとEnemyの対戦の管理 */
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel;

    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;

    private void Start()
    {
        //Inspector＜EnemyUIManger(Component)を持っているオブジェクトを非表示
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
    }

    // 初期設定
    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        //敵に遭遇したら、EnemyUI表示
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
        //ActionにPlayerAttack関数を登録
        enemy.AddEventListenerOnTap(PlayerAttack);

        //enemy.transform.DOMove(new Vector3(0, 10, 0), 5f);
    }

    void PlayerAttack()
    {
        StopAllCoroutines();
        
        SoundManager.instance.OnThisSE(1);

        int damage =  player.Attack(enemy);
        enemyUI.UpdateUI(enemy);

        DialogTextManager.instance.SetScenarios(new string[] {
            "ファイヤートルネード！！！\n敵に" +damage+ "のダメージを与えた"});

        //敵を撃破
        if (enemy.hp == 0)
        {
            StartCoroutine(EndBattle());
        }
        //敵を撃破できなかった場合
        else
        {
            //敵ターン
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        
        SoundManager.instance.OnThisSE(3);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        int damage = enemy.Attack(player);
        playerUI.UpdateUI(player);
        DialogTextManager.instance.SetScenarios(new string[] { "ぐはっ！\n" + damage + "ダメージくらった" });
        yield return new WaitForSeconds(2f);

        //Player 死亡
        if (player.hp <= 0)
        {
            questManager.PlayerDeath();
        }
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);

        DialogTextManager.instance.SetScenarios(new string[] { "モンスターをぶち殺した☆" });

        enemyUI.gameObject.SetActive(false);
        //Enemy(Obj)を破壊
        Destroy(enemy.gameObject);

        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }
}