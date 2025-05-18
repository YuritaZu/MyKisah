using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static Data;

public class Management : MonoBehaviour
{
    public int playerCoins = 9000; // Jumlah koin
    public TextMeshProUGUI coinText; // Menampilkan jumlah koin

    private void Start()
    {
        // Ketika memulai scene akan menampilkan jumlah koin
        LoadCoins();
        UpdateUI();
    }

    public bool IsStageUnlocked(StageData data)
    {
        return PlayerPrefs.GetInt($"stage_{data.id}_unlocked", 0) == 1;
    }

    public void BuyStage(StageData data)
    {
        if (playerCoins >= data.price)
        {
            playerCoins -= data.price;
            PlayerPrefs.SetInt($"stage_{data.id}_unlocked", 1);
            PlayerPrefs.SetInt("Coins", playerCoins);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Not enough coins.");
        }

        UpdateUI();
    }

    void LoadCoins()
    {
        playerCoins = PlayerPrefs.GetInt("Coins", playerCoins);
    }

    void UpdateUI()
    {
        coinText.text = $"Coins: {playerCoins}";
    }
}
