using System;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public double countdownTime = 86400f; // default 1 hari
    private double endTime;

    private bool eventActive = false;


    public TextMeshProUGUI countdownText;     // Teks merah: waktu panen
    public TextMeshProUGUI conditionText;     // Teks kuning: kondisi tanaman

    public PlantEventReceiver[] allPlants;    // Semua tanaman yang akan diubah secara otomatis

    private double[] eventOffsets = { 10, 20, 30, 40 }; // 10m, 2h, 5h, 10h
    private string[] eventKeys = { "Event1", "Event2", "Event3", "Event4" };
    private string[] eventTypes = { "Serangga", "AirHabis", "AirBusuk", "Layu" };

    private const string EndTimeKey = "CountdownEndTime";

    void Start()
    {
        double now = GetUnixTimestamp();

        if (PlayerPrefs.HasKey(EndTimeKey))
        {
            endTime = double.Parse(PlayerPrefs.GetString(EndTimeKey));
        }
        else
        {
            endTime = now + countdownTime;
            PlayerPrefs.SetString(EndTimeKey, endTime.ToString());
            PlayerPrefs.Save();
        }

        // Tampilkan event jika sudah terjadi sebelumnya
        for (int i = 0; i < eventOffsets.Length; i++)
{
    if (PlayerPrefs.HasKey(eventKeys[i]))
    {
        double triggerTime = endTime - countdownTime + eventOffsets[i];
        if (now >= triggerTime)  // hanya trigger kalau memang sudah waktunya
        {
            string savedEvent = PlayerPrefs.GetString(eventKeys[i]);
            TriggerAllPlantsEvent(savedEvent);
        }
    }
}

        UpdateDisplay(endTime - now);
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

        for (int i = 0; i < eventOffsets.Length; i++)
        {
            double triggerTime = endTime - countdownTime + eventOffsets[i];
            if (now >= triggerTime && !PlayerPrefs.HasKey(eventKeys[i]))
            {
                string selectedEvent = eventTypes[UnityEngine.Random.Range(0, eventTypes.Length)];
                PlayerPrefs.SetString(eventKeys[i], selectedEvent);
                PlayerPrefs.Save();

                TriggerAllPlantsEvent(selectedEvent);
            }
        }
    }

    public void ResetTimer()
{
    double now = GetUnixTimestamp();
    endTime = now + countdownTime;
    PlayerPrefs.SetString(EndTimeKey, endTime.ToString());

    foreach (string key in eventKeys)
    {
        PlayerPrefs.DeleteKey(key);
    }

    PlayerPrefs.Save();

    foreach (var plant in allPlants)
    {
        plant.ResetVisual();
    }

    if (conditionText != null)
        conditionText.text = "Tanaman sehat";

    eventActive = false; // Tambahkan ini
    enabled = true;
}


    void OnTimerFinished()
    {
        UpdateDisplay(0);
        Debug.Log("Countdown selesai!");
        PlayerPrefs.DeleteKey(EndTimeKey);
        enabled = false;
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

    void TriggerAllPlantsEvent(string eventType)
{
    if (eventActive) return; // Cegah jika sudah ada event aktif

    eventActive = true;

    foreach (var plant in allPlants)
    {
        plant.ApplyEvent(eventType);
    }

    if (conditionText != null)
    {
        switch (eventType)
        {
            case "Serangga":
                conditionText.text = "Terserang serangga!";
                break;
            case "AirHabis":
                conditionText.text = "Tanaman kekurangan air!";
                break;
            case "AirBusuk":
                conditionText.text = "Air busuk merusak tanaman!";
                break;
            case "Layu":
                conditionText.text = "Tanaman layu!";
                break;
        }
    }
}


    double GetUnixTimestamp()
    {
        return (DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
    }
}
