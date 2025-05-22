using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoadManager
{
    public static string TargetSceneName;

    public static void LoadWithLoader(string targetScene)
    {
        TargetSceneName = targetScene;
        SceneManager.LoadScene("Loader"); // nama scene loader kamu
    }
}
