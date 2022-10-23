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
