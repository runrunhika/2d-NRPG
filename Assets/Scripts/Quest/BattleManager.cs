using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*   Player��Enemy�̑ΐ�̊Ǘ� */
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
        //Inspector��EnemyUIManger(Component)�������Ă���I�u�W�F�N�g���\��
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
    }

    // �����ݒ�
    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        //�G�ɑ���������AEnemyUI�\��
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
        //Action��PlayerAttack�֐���o�^
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
            "�t�@�C���[�g���l�[�h�I�I�I\n�G��" +damage+ "�̃_���[�W��^����"});

        //�G�����j
        if (enemy.hp == 0)
        {
            StartCoroutine(EndBattle());
        }
        //�G�����j�ł��Ȃ������ꍇ
        else
        {
            //�G�^�[��
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
        DialogTextManager.instance.SetScenarios(new string[] { "���͂��I\n" + damage + "�_���[�W�������" });
        yield return new WaitForSeconds(2f);

        //Player ���S
        if (player.hp <= 0)
        {
            questManager.PlayerDeath();
        }
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);

        DialogTextManager.instance.SetScenarios(new string[] { "�����X�^�[���Ԃ��E������" });

        enemyUI.gameObject.SetActive(false);
        //Enemy(Obj)��j��
        Destroy(enemy.gameObject);

        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }
}