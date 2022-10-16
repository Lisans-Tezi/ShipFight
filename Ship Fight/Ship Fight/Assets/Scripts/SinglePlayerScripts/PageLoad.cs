using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLoad : MonoBehaviour
{
    public Image Ship1;
    public Image Ship2;
    public Image Ship3;
    public Image Ship4;
    public Image Ship5;

    void Start()
    {
        Ship1.gameObject.SetActive(false);
        Ship2.gameObject.SetActive(false);
        Ship3.gameObject.SetActive(false);
        Ship4.gameObject.SetActive(false);
        Ship5.gameObject.SetActive(false);


        PlayerPrefs.SetInt("MoneyMaker", 0);
        PlayerPrefs.SetInt("Tank", 0);
        PlayerPrefs.SetInt("SideStep", 0);
        PlayerPrefs.SetInt("Faker", 0);
        PlayerPrefs.SetInt("Healer", 0);
        PlayerPrefs.SetInt("LightBomber", 0);
        PlayerPrefs.SetInt("BombCatcher", 0);
        PlayerPrefs.SetInt("Bomber", 0);
        PlayerPrefs.SetInt("Boomer", 0);
        PlayerPrefs.SetInt("FlameThrower", 0);
    }

}
