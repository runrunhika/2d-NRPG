using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageUI(�X�e�[�W����UI/�i�s�{�^��/�X�ɖ߂�{�^��)�̊Ǘ�
public class StageUIManager : MonoBehaviour
{
    public Text stegeText;

    public GameObject nextButton, backButton, stageClearImage;

    private void Start()
    {
        stageClearImage.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stegeText.text = string.Format("�X�e�[�W�F{0}", currentStage + 1);
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        backButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        backButton.SetActive(true);
    }
}
