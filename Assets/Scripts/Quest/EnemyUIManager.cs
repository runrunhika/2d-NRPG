using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    public Text nameText, hpText;

    public void SetupUI(EnemyManager enemy)
    {
        hpText.text = string.Format("HPÅF{0}", enemy.hp);
        nameText.text = string.Format("{0}", enemy.name);
    }

    public void UpdateUI(EnemyManager enemy)
    {
        hpText.text = string.Format("HPÅF{0}", enemy.hp);
    }
}