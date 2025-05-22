using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;
    private static VolumeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadVolume(); // Panggil hanya saat pertama kali
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadVolume()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume", 0.5f); // Default 50%
        float dB = (volume > 0.0001f) ? Mathf.Log10(volume) * 20 : -80f;
        mixer.SetFloat("MusicVolume", dB); // Pastikan nama ini sesuai exposed parameter
    }
}

