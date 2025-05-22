using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        string targetScene = SceneLoadManager.TargetSceneName;

        if (string.IsNullOrEmpty(targetScene))
        {
            Debug.LogError("Scene tujuan tidak ditentukan!");
            yield break;
        }

        yield return new WaitForSeconds(5f); // durasi loading
        SceneManager.LoadScene(targetScene);
    }
}
