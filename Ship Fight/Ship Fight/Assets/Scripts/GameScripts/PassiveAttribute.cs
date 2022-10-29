using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveAttribute : MonoBehaviour
{
    public Image Map;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI ShipNameText;
    public List<Button> PassiveButtons;

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color blueColor = new Color32(0, 0, 255, 0);

    public bool isSelected;

    GameObject[,] map = new GameObject[10, 10];

    void Start()
    {
        Create();
    }

    void Create()
    {
        int k = 0;
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = Map.transform.GetChild(k).gameObject;
                map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                k++;
            }
        if (PlayerPrefs.GetString("Map")=="Map1")
        {
            map[3, 3].GetComponent<Image>().color = blueColor;
            map[3, 4].GetComponent<Image>().color = blueColor;
            map[3, 5].GetComponent<Image>().color = blueColor;
            map[3, 6].GetComponent<Image>().color = blueColor;

            map[4, 3].GetComponent<Image>().color = blueColor;
            map[4, 4].GetComponent<Image>().color = blueColor;
            map[4, 5].GetComponent<Image>().color = blueColor;
            map[4, 6].GetComponent<Image>().color = blueColor;

            map[5, 3].GetComponent<Image>().color = blueColor;
            map[5, 4].GetComponent<Image>().color = blueColor;
            map[5, 5].GetComponent<Image>().color = blueColor;
            map[5, 6].GetComponent<Image>().color = blueColor;

            map[6, 3].GetComponent<Image>().color = blueColor;
            map[6, 4].GetComponent<Image>().color = blueColor;
            map[6, 5].GetComponent<Image>().color = blueColor;
            map[6, 6].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map2")
        {
            map[0, 2].GetComponent<Image>().color = blueColor;
            map[0, 3].GetComponent<Image>().color = blueColor;
            map[0, 4].GetComponent<Image>().color = blueColor;
            map[0, 5].GetComponent<Image>().color = blueColor;
            map[0, 6].GetComponent<Image>().color = blueColor;
            map[0, 7].GetComponent<Image>().color = blueColor;

            map[1, 3].GetComponent<Image>().color = blueColor;
            map[1, 4].GetComponent<Image>().color = blueColor;
            map[1, 5].GetComponent<Image>().color = blueColor;
            map[1, 6].GetComponent<Image>().color = blueColor;

            map[2, 4].GetComponent<Image>().color = blueColor;
            map[2, 5].GetComponent<Image>().color = blueColor;

            map[7, 2].GetComponent<Image>().color = blueColor;
            map[7, 7].GetComponent<Image>().color = blueColor;

            map[8, 2].GetComponent<Image>().color = blueColor;
            map[8, 3].GetComponent<Image>().color = blueColor;
            map[8, 6].GetComponent<Image>().color = blueColor;
            map[8, 7].GetComponent<Image>().color = blueColor;

            map[9, 2].GetComponent<Image>().color = blueColor;
            map[9, 3].GetComponent<Image>().color = blueColor;
            map[9, 4].GetComponent<Image>().color = blueColor;
            map[9, 5].GetComponent<Image>().color = blueColor;
            map[9, 6].GetComponent<Image>().color = blueColor;
            map[9, 7].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map3")
        {
            map[0, 0].GetComponent<Image>().color = blueColor;
            map[0, 1].GetComponent<Image>().color = blueColor;

            map[1, 0].GetComponent<Image>().color = blueColor;

            map[2, 6].GetComponent<Image>().color = blueColor;
            map[2, 7].GetComponent<Image>().color = blueColor;
            map[2, 8].GetComponent<Image>().color = blueColor;
            map[2, 9].GetComponent<Image>().color = blueColor;

            map[3, 6].GetComponent<Image>().color = blueColor;
            map[3, 7].GetComponent<Image>().color = blueColor;
            map[3, 8].GetComponent<Image>().color = blueColor;
            map[3, 9].GetComponent<Image>().color = blueColor;

            map[4, 0].GetComponent<Image>().color = blueColor;
            map[4, 8].GetComponent<Image>().color = blueColor;
            map[4, 9].GetComponent<Image>().color = blueColor;

            map[5, 0].GetComponent<Image>().color = blueColor;
            map[5, 1].GetComponent<Image>().color = blueColor;
            map[5, 9].GetComponent<Image>().color = blueColor;

            map[6, 0].GetComponent<Image>().color = blueColor;
            map[6, 1].GetComponent<Image>().color = blueColor;
            map[6, 2].GetComponent<Image>().color = blueColor;
            map[6, 3].GetComponent<Image>().color = blueColor;

            map[7, 0].GetComponent<Image>().color = blueColor;
            map[7, 1].GetComponent<Image>().color = blueColor;
            map[7, 2].GetComponent<Image>().color = blueColor;
            map[7, 3].GetComponent<Image>().color = blueColor;

            map[8, 9].GetComponent<Image>().color = blueColor;

            map[9, 8].GetComponent<Image>().color = blueColor;
            map[9, 9].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map4")
        {
            map[0, 0].GetComponent<Image>().color = blueColor;
            map[0, 1].GetComponent<Image>().color = blueColor;
            map[0, 2].GetComponent<Image>().color = blueColor;
            map[0, 7].GetComponent<Image>().color = blueColor;
            map[0, 8].GetComponent<Image>().color = blueColor;
            map[0, 9].GetComponent<Image>().color = blueColor;

            map[1, 0].GetComponent<Image>().color = blueColor;
            map[1, 1].GetComponent<Image>().color = blueColor;
            map[1, 8].GetComponent<Image>().color = blueColor;
            map[1, 9].GetComponent<Image>().color = blueColor;

            map[2, 0].GetComponent<Image>().color = blueColor;
            map[2, 9].GetComponent<Image>().color = blueColor;

            map[3, 3].GetComponent<Image>().color = blueColor;
            map[3, 4].GetComponent<Image>().color = blueColor;
            map[3, 5].GetComponent<Image>().color = blueColor;
            map[3, 6].GetComponent<Image>().color = blueColor;

            map[4, 3].GetComponent<Image>().color = blueColor;
            map[4, 4].GetComponent<Image>().color = blueColor;
            map[4, 5].GetComponent<Image>().color = blueColor;
            map[4, 6].GetComponent<Image>().color = blueColor;

            map[5, 3].GetComponent<Image>().color = blueColor;
            map[5, 4].GetComponent<Image>().color = blueColor;
            map[5, 5].GetComponent<Image>().color = blueColor;
            map[5, 6].GetComponent<Image>().color = blueColor;

            map[6, 3].GetComponent<Image>().color = blueColor;
            map[6, 4].GetComponent<Image>().color = blueColor;
            map[6, 5].GetComponent<Image>().color = blueColor;
            map[6, 6].GetComponent<Image>().color = blueColor;

            map[7, 0].GetComponent<Image>().color = blueColor;
            map[7, 9].GetComponent<Image>().color = blueColor;

            map[8, 0].GetComponent<Image>().color = blueColor;
            map[8, 1].GetComponent<Image>().color = blueColor;
            map[8, 8].GetComponent<Image>().color = blueColor;
            map[8, 9].GetComponent<Image>().color = blueColor;

            map[9, 0].GetComponent<Image>().color = blueColor;
            map[9, 1].GetComponent<Image>().color = blueColor;
            map[9, 2].GetComponent<Image>().color = blueColor;
            map[9, 7].GetComponent<Image>().color = blueColor;
            map[9, 8].GetComponent<Image>().color = blueColor;
            map[9, 9].GetComponent<Image>().color = blueColor;
        }
    }

    public void PassiveShooting()
    {
        if(Text.color == Color.white || Text.color == Color.red)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == whiteColor)
                        map[i, j].gameObject.GetComponent<Image>().color = greenColor;
                    else if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;

            isSelected = (isSelected == true) ? false : true;

            if (isSelected)
            {
                ButtonEnabledChange(false);
                gameObject.GetComponent<Button>().enabled = true;
                Text.color = Color.red;
                FindShootingShip();
                PlayerPrefs.SetString("AttackType","Passive");
                GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().ChoseTile();
            }
            else
            {
                Text.color = Color.white;
                ButtonEnabledChange(true);
                GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().ChoseShip();
            }
        }
    }

    void ButtonEnabledChange(bool enabled)
    {
        foreach (Button passiveBtn in PassiveButtons)
            passiveBtn.enabled = enabled;
    }

    void FindShootingShip()
    {
        if (ShipNameText.name == "MoneyMaker")
            PlayerPrefs.SetString("ShootingShip", "MoneyMaker");
        else if (ShipNameText.name == "Tank")
            PlayerPrefs.SetString("ShootingShip", "Tank");
        else if (ShipNameText.name == "SideStep")
            PlayerPrefs.SetString("ShootingShip", "SideStep");
        else if (ShipNameText.name == "Faker")
            PlayerPrefs.SetString("ShootingShip", "Faker");
        else if (ShipNameText.name == "Healer")
            PlayerPrefs.SetString("ShootingShip", "Healer");
        else if (ShipNameText.name == "LightBomber")
            PlayerPrefs.SetString("ShootingShip", "LightBomber");
        else if (ShipNameText.name == "BombCatcher")
            PlayerPrefs.SetString("ShootingShip", "BombCatcher");
        else if (ShipNameText.name == "Bomber")
            PlayerPrefs.SetString("ShootingShip", "Bomber");
        else if (ShipNameText.name == "Boomer")
            PlayerPrefs.SetString("ShootingShip", "Boomer");
        else if (ShipNameText.name == "FlameThrower")
            PlayerPrefs.SetString("ShootingShip", "FlameThrower");
    }
}
