using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihGame : MonoBehaviour
{
    public void BackToPreviousScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int previousIndex = currentIndex - 1;

        if (previousIndex >= 0)
        {
            SceneManager.LoadScene(previousIndex);
        }
        else
        {
            Debug.Log("Sudah di scene pertama, tidak bisa kembali.");
        }
    }
}
