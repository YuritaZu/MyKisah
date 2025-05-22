using System;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public double countdownTime = 86400f; // default: 1 hari
    private double endTime;

    public TextMeshProUGUI countdownText;

    private const string EndTimeKey = "CountdownEndTime";

    void Start()
    {
        double now = GetUnixTimestamp();

        if (PlayerPrefs.HasKey(EndTimeKey))
        {
            // Ambil waktu selesai yang tersimpan
            endTime = double.Parse(PlayerPrefs.GetString(EndTimeKey));
        }
        else
        {
            // Jika belum ada, buat baru
            endTime = now + countdownTime;
            PlayerPrefs.SetString(EndTimeKey, endTime.ToString());
            PlayerPrefs.Save();
        }

        double remaining = endTime - now;
        if (remaining <= 0)
        {
            OnTimerFinished();
            return;
        }

        UpdateDisplay(remaining);
    }

    void Update()
    {
        double now = GetUnixTimestamp();
        double remaining = endTime - now;

        if (remaining <= 0)
        {
            OnTimerFinished();
            return;
        }

        UpdateDisplay(remaining);
    }

    public void ResetTimer()
    {
        double now = GetUnixTimestamp();
        endTime = now + countdownTime;
        PlayerPrefs.SetString(EndTimeKey, endTime.ToString());
        PlayerPrefs.Save();
        enabled = true; 
    }

    void OnTimerFinished()
    {
        UpdateDisplay(0);
        Debug.Log("Countdown selesai!");

        PlayerPrefs.DeleteKey(EndTimeKey); // hapus agar tidak lanjut
        enabled = false; // stop update
    }

    void UpdateDisplay(double remainingTime)
    {
        int totalSeconds = Mathf.FloorToInt((float)remainingTime);
        int days = totalSeconds / 86400;
        int hours = (totalSeconds % 86400) / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        if (countdownText != null)
        {
            countdownText.text = $"{days} hari {hours} jam {minutes} menit {seconds} detik";
        }
    }

    double GetUnixTimestamp()
    {
        return (DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
    }

    
}
