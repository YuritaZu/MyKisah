using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Data;

public class UI : MonoBehaviour
{
    public Management manager;
    public StageData CurrentStage;
    public PopUp popupManager;
    public Button buyButton;

    private void Start()
    {
        UpdateButtons();
    }

    public void OnStageClicked()
    {
        if (manager.IsStageUnlocked(CurrentStage))
        {
            // Mainkan
            SceneManager.LoadScene(CurrentStage.stageName);
        }
        else
        {
            // Tampilkan popup
            popupManager.ShowPopUp(CurrentStage, manager);
        }
    }

    void UpdateButtons()
    {
        bool unlocked = manager.IsStageUnlocked(CurrentStage);
        buyButton.gameObject.SetActive(!unlocked);
    }
}
