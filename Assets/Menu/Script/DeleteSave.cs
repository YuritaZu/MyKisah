using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{
    public void ClearTimerData()
    {
        PlayerPrefs.DeleteKey("CountdownEndTime");
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs dihapus.");
    }
}
