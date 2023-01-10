using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound;
    public Scrollbar soundScrollbar;
    public TextMeshProUGUI soundVolume;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SoundVolume"))
            PlayerPrefs.SetFloat("SoundVolume", 0.2f);
        soundVolume.text = (PlayerPrefs.GetFloat("SoundVolume") * 100).ToString();
        soundScrollbar.value = (PlayerPrefs.GetFloat("SoundVolume"));
        sound.volume = PlayerPrefs.GetFloat("SoundVolume");
    }

    public void SoundPlay()
    {
        sound.Play();
    }

    public void SoundVolumeChanged()
    {
        soundVolume.text = (soundScrollbar.value * 100).ToString();
        PlayerPrefs.SetFloat("SoundVolume", soundScrollbar.value);
        sound.volume = PlayerPrefs.GetFloat("SoundVolume");
    }
}
