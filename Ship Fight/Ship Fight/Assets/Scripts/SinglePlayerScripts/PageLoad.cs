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
    // Start is called before the first frame update
    void Start()
    {
        Ship1.gameObject.SetActive(false);
        Ship2.gameObject.SetActive(false);
        Ship3.gameObject.SetActive(false);
        Ship4.gameObject.SetActive(false);
        Ship5.gameObject.SetActive(false);


        PlayerPrefs.SetInt("MoneyMaker", 2);
        PlayerPrefs.SetInt("Tank", 3);
        PlayerPrefs.SetInt("SideStep", 3);
        PlayerPrefs.SetInt("Faker", 4);
        PlayerPrefs.SetInt("Healer", 4);
        PlayerPrefs.SetInt("LightBomber", 4);
        PlayerPrefs.SetInt("BombCatcher", 5);
        PlayerPrefs.SetInt("Bomber", 5);
        PlayerPrefs.SetInt("Boomer", 6);
        PlayerPrefs.SetInt("FlameThrower", 7);
    }

}
