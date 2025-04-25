using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("-------- SC ----------")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    [Header("-------- Song ----------")]
    public AudioClip BGM;
    public AudioClip Talk;

    public static AudioController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Music.clip = BGM;
        Music.Play();
    }
}
