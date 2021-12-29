using System;
using UnityEngine;
using DG.Tweening;

/*  敵の情報を管理  */
public class EnemyManager : MonoBehaviour
{
    //関数登録
    Action tapAction;   //クリック時に実行したい関数(外部から設定したい)

    public new string name;
    public int hp, at;
    public GameObject hitEffect;

    // 攻撃する
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
    }

    // ダメージを受ける
    public int Damage(int damage)
    {
        //親の設定:EnemyManagerをセット
        Instantiate(hitEffect, this.transform, false);

        /*  攻撃を食らって振動する */
        //引数 : 秒数、強さ、揺れ、ランダム
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;

        if (hp <= 0) 
        {
            hp = 0;
        }
        return damage;
    }

    //tapActionに関数を登録する関数
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }


    public void OnTap()
    {
        tapAction();
    }
}