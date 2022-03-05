using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Music : MonoBehaviour
{
    public AudioSource music;
    public Scrollbar musicbar;
    public TextMeshProUGUI musicvolume;

    public void MusicSettings()
    {
        music.volume = musicbar.value;
        musicvolume.text = (musicbar.value * 100).ToString();
        double number = Convert.ToDouble(musicvolume.text);
        if (number<10)
        {
            musicvolume.text = musicvolume.text[0] + "";
        }
        else if(number==100)
        {
            musicvolume.text = "100";
        }
        else
        {
            musicvolume.text = musicvolume.text[0] + "" + musicvolume.text[1];
        }
        
    }
}
