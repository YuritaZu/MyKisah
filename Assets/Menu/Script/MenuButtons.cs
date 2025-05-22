using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuButtons : MonoBehaviour
{

    public void GoToChooseScene()
    {

        SceneManager.LoadScene("Choose");
        
    }
    

    private IEnumerator LoadChooseSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Choose");

        while (!asyncLoad.isDone)
        {

            
            yield return null;
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Choose");
    }

    public void OptionButton()
    {
        SceneManager.LoadScene("Setting");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
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
