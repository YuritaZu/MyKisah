using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingTextAnimator : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public float interval = 0.5f; // setengah detik

    private void Start()
    {
        StartCoroutine(AnimateLoadingText());
    }

    IEnumerator AnimateLoadingText()
    {
        int dotCount = 1;

        while (true)
        {
            // Buat string dengan titik
            string dots = new string('.', dotCount);
            loadingText.text = "Tunggu sebentar ya" + dots;

            dotCount++;

            if (dotCount > 3)
                dotCount = 1;

            yield return new WaitForSeconds(interval);
        }
    }
}
