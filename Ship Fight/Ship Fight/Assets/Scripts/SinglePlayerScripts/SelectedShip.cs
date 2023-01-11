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

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color orangeColor = new Color32(255, 165, 0, 255);
    Color blueColor = new Color32(0, 0, 255, 0);

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
                if (map[i, j].gameObject.GetComponent<Image>().color != blueColor)
                {
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;                    
                }
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
                GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "";
                InformationPanelClose();
            }
        }
    }
    void FindSelectedShip()
    {
        if (gameObject.name == "FirstShip")
        {
            PlayerPrefs.SetString("SelectedShip", "MoneyMaker");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "MoneyMaker passive ability is to add 1 battle point at the end of each turn if the ship has not completely exploded.\r\nMoneyMaker active feature grants 2 shot. The cost of the skill is 2 points.";
        }
        else if (gameObject.name == "SecondShip")
        {
            PlayerPrefs.SetString("SelectedShip", "Tank");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "Tank passive ability is that its parts do not explode on one hit. When a piece of it is hit, it first turns yellow. If hit once again, it will turn red.\r\nTank active feature grants 1 shot. If this shot is accurate, the turn passes to the opponent. If this shot is inaccurate, it gains 1 more shot. The cost of the skill is 3 points.";
        }
        else if (gameObject.name == "ThirdShip")
        {
            PlayerPrefs.SetString("SelectedShip", "SideStep");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "The first time the SideStep passive is hit, if the appropriate location is available, the ship will bounce the shot 1 unit aside and the shot will fail. If there is no suitable position, the shot does not bounce and the shot is successful.\r\nSideStep active feature grants 1 shot. If this shot is accurate, it gains the right to shoot as much as the initial piece size of the hit ship. For example, if you hit the Boomer ship with the SideStepin active feature, you will gain 6 more shots. The cost of the skill is 4 points.";
        }
        else if (gameObject.name == "FourthShip")
        {
            PlayerPrefs.SetString("SelectedShip", "Faker");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "Faker passive skill when the ship is hit for the first time, if there is a suitable position, the ship will move 1 unit and the shot will fail. If there is no suitable position, the ship cannot move and the shot is successful.\r\nFaker active feature grants 1 shot. If the shot is successful, it completely polishes the opposing ship. The cost of the skill is 5 points.";
        }
        else if (gameObject.name == "FifthShip")
        {
            PlayerPrefs.SetString("SelectedShip", "Healer");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "Healer passive ability heals itself by 1 piece at the end of each turn if the ship is hit and does not explode completely.\r\nHealer active feature grants 3 shot. The cost of the skill is 6 points.";
        }
        else if (gameObject.name == "SixthShip")
        {
            PlayerPrefs.SetString("SelectedShip", "LightBomber");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "LightBomber passive ability detonates 1 piece of a ship that has not taken any damage from enemy ships at the end of the turn if the LightBomber detonates completely. If the opponent has no ships that have not been hit, the shot will not take place.\r\nLightBomber active feature grants 4 shot. The cost of the skill is 7 points.";
        }
        else if (gameObject.name == "SeventhShip")
        {
            PlayerPrefs.SetString("SelectedShip", "BombCatcher");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "BombCatcher passive ability finishes the opponent's shot the first time the Bomb Catcher is hit.\r\nBombCatcher active feature grants 5 shot. The cost of the skill is 8 points.";
        }
        else if (gameObject.name == "EighthShip")
        {
            PlayerPrefs.SetString("SelectedShip", "Bomber");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "If the first shot with the Bomber passive is inaccurate, detonates 1 piece of an opponent's ship that has never been hit. If the opponent has no ships that have not been hit, the shot will be void.\r\nBomber active ability detonates a selected line completely. If there is a tank ship in the selected row and the ship is yellow, that piece cannot be hit. The cost of the skill is 9 points.";
        }
        else if (gameObject.name == "NinethShip")
        {
            PlayerPrefs.SetString("SelectedShip", "Boomer");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "Boomer passive ability The first time Boomer is hit, the shooter's score is reset.\r\nBoomer active ability completely detonates a selected column. If there is a tank ship in the selected column and the ship is yellow, that piece cannot be hit. The cost of the skill is 10 points.";
        }
        else if (gameObject.name == "TenthShip")
        {
            PlayerPrefs.SetString("SelectedShip", "FlameThrower");
            GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>().text = "FlameThrower passive skill explodes an additional piece of the hit ship if the shot is accurate. If the ship completely explodes, there will be no extra hits.\r\nThe FlameThrower active ability detonates all the starting edges of the map. If there is a tank ship on the starting edges of the map and the ship is yellow, that piece cannot be hit. It can only be used once. The cost of the skill is 11 points.";
        }
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
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "SecondShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "ThirdShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "FourthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "FifthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "SixthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "SeventhShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "EighthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "NinethShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else if (gameObject.name == "TenthShip")
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        else
            return gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
    }
}
