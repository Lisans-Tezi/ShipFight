using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public Scrollbar musicScrollbar;
    public TextMeshProUGUI musicVolume;

    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetFloat("MusicVolume", 0.2f);
        musicVolume.text = (PlayerPrefs.GetFloat("MusicVolume") * 100).ToString();
        musicScrollbar.value = (PlayerPrefs.GetFloat("MusicVolume"));
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        music.Play();
    }

    public void MusicVolumeChanged()
    {
        musicVolume.text = (musicScrollbar.value * 100).ToString();
        PlayerPrefs.SetFloat("MusicVolume", musicScrollbar.value);
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
