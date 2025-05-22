using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
[SerializeField] private Slider SC;

private void Start()
{
    if (PlayerPrefs.HasKey("musicVolume"))
    {
        LoadVolume();
    }
    else
    {
        SC.value = 0.5f; // default volume 50%
        SetMusicVolume();
    }

    // Tambahkan listener ke slider jika belum
    SC.onValueChanged.AddListener(delegate { SetMusicVolume(); });
}

public void SetMusicVolume()
{
    float volume = SC.value;

    // Tangani log10(0)
    float dB = (volume > 0.0001f) ? Mathf.Log10(volume) * 20 : -80f;

    Mixer.SetFloat("Music", dB);
    PlayerPrefs.SetFloat("musicVolume", volume);
}

private void LoadVolume()
{
    float volume = PlayerPrefs.GetFloat("musicVolume", 0.5f); // Default 0.5 jika belum ada
    SC.value = volume;
    SetMusicVolume();
}

}
