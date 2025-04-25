using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public GameObject LoadingScreen;  // GameObject untuk layar loading
    public Image LoadingBarFill;      // Gambar yang berfungsi sebagai loading bar
    public string menuSceneName = "Menu";  // Nama scene Menu yang akan dimuat setelah bar 100%

    void Start()
    {
        // Mulai memuat scene dengan urutan loading palsu dan diam
        StartCoroutine(LoadSceneWithCustomFakeBar());
    }

    IEnumerator LoadSceneWithCustomFakeBar()
    {
        // Aktifkan layar loading dan mulai progress bar
        LoadingScreen.SetActive(true);

        // 1. Loading bar mengisi hingga 40% dalam 2 detik
        yield return StartCoroutine(UpdateLoadingBar(0f, 0.4f, 2f));

        // 2. Diam selama 2 detik, progress bar tidak berubah
        yield return new WaitForSeconds(2f);

        // 3. Loading bar mengisi hingga 80% dalam 1 detik
        yield return StartCoroutine(UpdateLoadingBar(0.4f, 0.8f, 1f));

        // 4. Diam selama 1 detik, progress bar tidak berubah
        yield return new WaitForSeconds(1f);

        // 5. Mulai loading scene asli
        AsyncOperation operation = SceneManager.LoadSceneAsync(menuSceneName);
        operation.allowSceneActivation = false; // Jangan aktifkan scene dulu, hanya lakukan loading

        // Update progress bar selama pemuatan scene asli
        while (!operation.isDone)
        {
            // Update loading bar sesuai progres asli
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f); // Progress aslinya
            LoadingBarFill.fillAmount = Mathf.Lerp(0.8f, 1f, progressValue); // Teruskan dari 80% sampai 100%

            // Jika sudah selesai memuat, aktifkan scene
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true; // Aktifkan scene setelah hampir selesai
            }

            yield return null;
        }

        // Pastikan progress bar terisi penuh saat selesai
        LoadingBarFill.fillAmount = 1f;

        // Setelah progress bar penuh, scene Menu akan dimuat
        SceneManager.LoadScene(menuSceneName);  // Muat scene Menu
    }

    // Fungsi untuk mengupdate loading bar secara bertahap
    IEnumerator UpdateLoadingBar(float startProgress, float endProgress, float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            // Hitung progres bar secara linear
            float progress = Mathf.Lerp(startProgress, endProgress, timeElapsed / duration);
            LoadingBarFill.fillAmount = progress;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Pastikan progres bar terisi sesuai dengan endProgress
        LoadingBarFill.fillAmount = endProgress;
    }
}
