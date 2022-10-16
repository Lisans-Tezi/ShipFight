using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedShip : MonoBehaviour
{
    public Image Ship1;
    public Image Ship2;
    public Image Ship3;
    public Image Ship4;
    public Image Ship5;

    public List<Sprite> ShipImages;

    public Image Map;
    public TextMeshProUGUI Text;
    public List<Image> Ships;

    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 100);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color orangeColor = new Color32(255, 165, 0, 255);

    bool isSelected;

    void Start()
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
    }

    public void ShipPlacing()
    {
        if(Text.color == Color.black || Text.color == Color.red)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == whiteColor)
                        map[i, j].gameObject.GetComponent<Image>().color = greenColor;
                    else if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;

            ButtonEnabledChange(false);

            isSelected = (isSelected == true) ? false : true;

            if (isSelected)
            {
                gameObject.GetComponent<Button>().enabled = true;
                Text.color = Color.red;
                FindSelectedShip();
                InformationPanelOpen();
            }
            else
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), 0);
                Text.color = Color.black;
                ButtonEnabledChange(true);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue || map[i, j].gameObject.GetComponent<Image>().color == orangeColor)
                        {
                            map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                        }
                    }
                }
                InformationPanelClose();
            }
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
    void InformationPanelOpen()
    {
        if (Ship1.gameObject.activeSelf == false)
        {
            Ship1.gameObject.SetActive(true);
            Ship1.transform.GetChild(0).GetComponent<Image>().sprite = FindShipImage();
            Ship1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        else if (Ship2.gameObject.activeSelf == false)
        {
            Ship2.gameObject.SetActive(true);
            Ship2.transform.GetChild(0).GetComponent<Image>().sprite = FindShipImage();
            Ship2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        else if (Ship3.gameObject.activeSelf == false)
        {
            Ship3.gameObject.SetActive(true);
            Ship3.transform.GetChild(0).GetComponent<Image>().sprite = FindShipImage();
            Ship3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        else if (Ship4.gameObject.activeSelf == false)
        {
            Ship4.gameObject.SetActive(true);
            Ship4.transform.GetChild(0).GetComponent<Image>().sprite = FindShipImage();
            Ship4.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
        else
        {
            Ship5.gameObject.SetActive(true);
            Ship5.transform.GetChild(0).GetComponent<Image>().sprite = FindShipImage();
            Ship5.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        }
    }
    void InformationPanelClose()
    {
        if (Ship5.gameObject.activeSelf == true)
            Ship5.gameObject.SetActive(false);
        else if (Ship4.gameObject.activeSelf == true)
            Ship4.gameObject.SetActive(false);
        else if (Ship3.gameObject.activeSelf == true)
            Ship3.gameObject.SetActive(false);
        else if (Ship2.gameObject.activeSelf == true)
            Ship2.gameObject.SetActive(false);
        else
            Ship1.gameObject.SetActive(false);
    }

    Sprite FindShipImage()
    {
        if (gameObject.name == "FirstShip")
            return ShipImages[0];
        else if (gameObject.name == "SecondShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[1];
        else if (gameObject.name == "ThirdShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[2];
        else if (gameObject.name == "FourthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[3];
        else if (gameObject.name == "FifthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[4];
        else if (gameObject.name == "SixthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[5];
        else if (gameObject.name == "SeventhShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[6];
        else if (gameObject.name == "EighthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[7];
        else if (gameObject.name == "NinethShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[8];
        else if (gameObject.name == "TenthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
            //return ShipImages[9];
        else
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
    }
}
