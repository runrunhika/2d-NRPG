
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public int hp, at;

    // �U������
    public int Attack(EnemyManager enemy)
    {
        int damage = enemy.Damage(at);
        return damage;
    }

    // �_���[�W���󂯂�
    public int Damage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }

}