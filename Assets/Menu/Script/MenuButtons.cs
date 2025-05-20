using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtons : MonoBehaviour
{
    // Method yang akan dipanggil oleh button
    public void GoToChooseScene()
    {
        // Memuat scene "Choose" secara synchronous
        SceneManager.LoadScene("Choose");
        
        // Alternatif: Untuk loading screen (asynchronous)
        // StartCoroutine(LoadChooseSceneAsync());
    }
    
    // Alternatif dengan loading screen (coroutine)
    private IEnumerator LoadChooseSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Choose");
        
        // Tampilkan loading screen di sini
        
        // Tunggu sampai scene selesai dimuat
        while (!asyncLoad.isDone)
        {
            // Update progress bar jika ada
            // float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            // loadingBar.value = progress;
            
            yield return null;
        }
    }

     public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // Stop play mode
        #else
        Application.Quit(); // Works in built game
        #endif
    }
}
