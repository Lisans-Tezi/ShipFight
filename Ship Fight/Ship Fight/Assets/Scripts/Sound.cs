using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Sound : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource sound2;
    public Scrollbar soundBar;
    public TextMeshProUGUI soundVolume;

    public void SoundSettings()
    {
        sound.volume = soundBar.value;
        sound2.volume = soundBar.value;
        
        soundVolume.text = (soundBar.value * 100).ToString();
        double number = Convert.ToDouble(soundVolume.text);
        if (number < 10)
        {
            soundVolume.text = soundVolume.text[0] + "";
        }
        else if (number == 100)
        {
            soundVolume.text = "100";
        }
        else
        {
            soundVolume.text = soundVolume.text[0] + "" + soundVolume.text[1];
        }

    }
}
