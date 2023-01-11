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
    public List<Button> ActiveButtons;

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color blueColor = new Color32(0, 0, 255, 0);

    public bool isSelected;

    GameObject[,] map = new GameObject[10, 10];

    void Start()
    {
        Create();
    }

    void OnEnable()
    {
        GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().ChoseShip();
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
                int RemainingShotPoint = 1;
                GameObject.Find("RemainingShotPoint").GetComponent<TextMeshProUGUI>().text = RemainingShotPoint.ToString();
                PlayerPrefs.SetString("AttackType","Passive");
            }
            else
            {
                Text.color = Color.white;
                ButtonEnabledChange(true);
                PlayerPrefs.SetString("AttackType", "");
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
        if (ShipNameText.text == "MoneyMaker")
        {
            PlayerPrefs.SetString("ShootingShip", "MoneyMaker");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "MoneyMaker passive ability is to add 1 battle point at the end of each turn if the ship has not completely exploded.";
        }
        else if (ShipNameText.text == "Tank")
        {
            PlayerPrefs.SetString("ShootingShip", "Tank");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Tank passive ability is that its parts do not explode on one hit. When a piece of it is hit, it first turns yellow. If hit once again, it will turn red.";
        }
        else if (ShipNameText.text == "SideStep")
        {
            PlayerPrefs.SetString("ShootingShip", "SideStep");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "The first time the SideStep passive is hit, if the appropriate location is available, the ship will bounce the shot 1 unit aside and the shot will fail. If there is no suitable position, the shot does not bounce and the shot is successful.";
        }
        else if (ShipNameText.text == "Faker")
        {
            PlayerPrefs.SetString("ShootingShip", "Faker");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Faker passive skill when the ship is hit for the first time, if there is a suitable position, the ship will move 1 unit and the shot will fail. If there is no suitable position, the ship cannot move and the shot is successful.";
        }
        else if (ShipNameText.text == "Healer")
        {
            PlayerPrefs.SetString("ShootingShip", "Healer");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Healer passive ability heals itself by 1 piece at the end of each turn if the ship is hit and does not explode completely.";
        }
        else if (ShipNameText.text == "LightBomber")
        {
            PlayerPrefs.SetString("ShootingShip", "LightBomber");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "LightBomber passive ability detonates 1 piece of a ship that has not taken any damage from enemy ships at the end of the turn if the LightBomber detonates completely. If the opponent has no ships that have not been hit, the shot will not take place.";
        }
        else if (ShipNameText.text == "BombCatcher")
        {
            PlayerPrefs.SetString("ShootingShip", "BombCatcher");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "BombCatcher passive ability finishes the opponent's shot the first time the Bomb Catcher is hit.";
        }
        else if (ShipNameText.text == "Bomber")
        {
            PlayerPrefs.SetString("ShootingShip", "Bomber");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "If the first shot with the Bomber passive is inaccurate, detonates 1 piece of an opponent's ship that has never been hit. If the opponent has no ships that have not been hit, the shot will be void.";
        }
        else if (ShipNameText.text == "Boomer")
        {
            PlayerPrefs.SetString("ShootingShip", "Boomer");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Boomer passive ability The first time Boomer is hit, the shooter's score is reset.";
        }
        else if (ShipNameText.text == "FlameThrower")
        {
            PlayerPrefs.SetString("ShootingShip", "FlameThrower");
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "FlameThrower passive skill explodes an additional piece of the hit ship if the shot is accurate. If the ship completely explodes, there will be no extra hits.";
        }
    }
}
