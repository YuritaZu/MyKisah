using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("-------- SC ----------")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    [Header("-------- Song ----------")]
    public AudioClip BGM;
    public AudioClip Talk;

    private void Start()
    {
        Music.clip = BGM;
        Music.Play();
    }
}
