using System;
using UnityEngine;
using DG.Tweening;

/*  �G�̏����Ǘ�  */
public class EnemyManager : MonoBehaviour
{
    //�֐��o�^
    Action tapAction;   //�N���b�N���Ɏ��s�������֐�(�O������ݒ肵����)

    public new string name;
    public int hp, at;
    public GameObject hitEffect;

    // �U������
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
    }

    // �_���[�W���󂯂�
    public int Damage(int damage)
    {
        //�e�̐ݒ�:EnemyManager���Z�b�g
        Instantiate(hitEffect, this.transform, false);

        /*  �U����H����ĐU������ */
        //���� : �b���A�����A�h��A�����_��
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;

        if (hp <= 0) 
        {
            hp = 0;
        }
        return damage;
    }

    //tapAction�Ɋ֐���o�^����֐�
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }


    public void OnTap()
    {
        tapAction();
    }
}