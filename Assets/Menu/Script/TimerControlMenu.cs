using UnityEngine;

public class TimerControlMenu : MonoBehaviour
{
    private const string EndTimeKey = "CountdownEndTime";
    public double countdownTime = 86400f;

    public void LoadTimerScene()
    {
        SceneLoadManager.LoadWithLoader("PlantTime");
    }

    public void ResetAndLoad()
    {
        double now = (System.DateTime.UtcNow - System.DateTime.UnixEpoch).TotalSeconds;
        double endTime = now + countdownTime;

        PlayerPrefs.SetString(EndTimeKey, endTime.ToString());
        PlayerPrefs.Save();

        Debug.Log("Timer di-reset, masuk ke SceneTimer...");
        SceneLoadManager.LoadWithLoader("PlantTime");
    }

    public void StartButton()
    {
        if (PlayerPrefs.HasKey(EndTimeKey))
        {
            Debug.Log("Timer sudah pernah dimulai, masuk ke SceneTimer.");
            SceneLoadManager.LoadWithLoader("PlantTime");
        }
        else
        {
            Debug.Log("Timer belum dimulai, masuk ke scene 'Pilihtanaman'.");
            SceneLoadManager.LoadWithLoader("Choose");
        }
    }
}
