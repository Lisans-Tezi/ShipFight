using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedShip : MonoBehaviour
{
    public Image Map;
    public TextMeshProUGUI Text;
    public List<Image> Ships;

    public int piece;

    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 100);
    Color greenColor = new Color32(0, 255, 0, 200);

    bool isSelected;

    private void Start()
    {
        Create();


    }

    void Create()
    {
        int k = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = Map.transform.GetChild(k).gameObject;
                map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                k++;
            }
        }

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

    public void ShipPlacing()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color == whiteColor)
                    map[i, j].gameObject.GetComponent<Image>().color = greenColor;
                else if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;

        ButtonEnabledChange(false);

        isSelected = (isSelected == true) ? false : true;

        if(isSelected)
        {
            gameObject.GetComponent<Button>().enabled = true;
            Text.color = Color.red;
            FindSelectedShip();
            piece = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip"));
            Debug.Log("SelectedShip ::::: " + PlayerPrefs.GetString("SelectedShip"));

        }
        else
        {
            Text.color = Color.black;
            ButtonEnabledChange(true);
        }
    }
    void FindSelectedShip()
    {
        if (gameObject.name == "FirstShip")
            PlayerPrefs.SetString("SelectedShip", "MoneyMaker");
        else if (gameObject.name == "SecondShip")
            PlayerPrefs.SetString("SelectedShip", "Tank");
        else if (gameObject.name == "ThirdShip")
            PlayerPrefs.SetString("SelectedShip", "SideStep");
        else if (gameObject.name == "FourthShip")
            PlayerPrefs.SetString("SelectedShip", "Faker");
        else if (gameObject.name == "FifthShip")
            PlayerPrefs.SetString("SelectedShip", "Healer");
        else if (gameObject.name == "SixthShip")
            PlayerPrefs.SetString("SelectedShip", "LightBomber");
        else if (gameObject.name == "SeventhShip")
            PlayerPrefs.SetString("SelectedShip", "BombCatcher");
        else if (gameObject.name == "EighthShip")
            PlayerPrefs.SetString("SelectedShip", "Bomber");
        else if (gameObject.name == "NinethShip")
            PlayerPrefs.SetString("SelectedShip", "Boomer");
        else if (gameObject.name == "TenthShip")
            PlayerPrefs.SetString("SelectedShip", "FlameThrower");
    }
    void ButtonEnabledChange(bool enabled)
    {
        foreach (Image ship in Ships)
            ship.gameObject.GetComponent<Button>().enabled = enabled;
    }

}
