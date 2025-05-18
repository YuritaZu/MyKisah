using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Data;

public class PopUp : MonoBehaviour
{
    public GameObject popupPanel;
    public Button buyButton;
    public TextMeshProUGUI IsiTeks;
    public Animator animator;

    private StageData currentStage;
    private Management stageManager;

    public void ShowPopUp(StageData stage, Management manager)
    {
        currentStage = stage;
        stageManager = manager;

        IsiTeks.text = $"Apa kamu yakin akan membeli stage {stage.stageName} seharga {stage.price}?";
        popupPanel.SetActive(true);
        animator.SetTrigger("a");

    }

    public void ConfirmBuy()
    {
        if (currentStage != null && stageManager != null)
        {
            stageManager.BuyStage(currentStage);
        }

        popupPanel.SetActive(false);
    }

    public void Cancel()
    {
        popupPanel.SetActive(false);
    }
}
