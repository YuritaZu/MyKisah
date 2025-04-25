using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject UnityLogin;
    public GameObject CanvasLogo;

    public float delay = 3f;
    public float delayChangeScreen = 2f;

    private Animator logoAnimator;

    void Start() // Kapital 'S' penting
    {
        if (CanvasLogo != null)
        {
            Transform pgLogoTransform = CanvasLogo.transform.Find("PGLogo2");
            if (pgLogoTransform != null)
            {
                logoAnimator = pgLogoTransform.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError("PGLogo2 not found as a child of CanvasLogo.");
            }
        }
        else
        {
            Debug.LogError("CanvasLogo is not assigned.");
        }

        StartCoroutine(TransitionSplashToLogo());
    }

    IEnumerator TransitionSplashToLogo()
    {
        yield return new WaitForSeconds(delay);

        // Tutup splash, buka logo
        UnityLogin.SetActive(false);
        CanvasLogo.SetActive(true);

        // Jalankan animasi logo
        if (logoAnimator != null)
        {
            Debug.Log("Animator found, playing logo...");
            logoAnimator.SetTrigger("PlayLogo");
        }
        else
        {
            Debug.LogError("Animator NOT found!");
        }

        yield return new WaitForSeconds(delayChangeScreen);
        SceneManager.LoadScene("LoadingMenu");
    }
}
