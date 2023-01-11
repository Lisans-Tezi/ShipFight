using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAttribute : MonoBehaviour
{
    public Image Map;
    public TextMeshProUGUI shipName;
    public TextMeshProUGUI Text;

    public List<Button> PassiveButtons;
    public List<Button> ActiveButtons;

    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color blueColor = new Color32(0, 0, 255, 0);

    void Start()
    {
        gameObject.GetComponent<Button>().enabled = false;
        Create();
        PlayerPrefs.SetInt("MoneyMakerActiveTurn", 0);
        PlayerPrefs.SetInt("TankActiveTurn", 0);
        PlayerPrefs.SetInt("SideStepActiveTurn", 0);
        PlayerPrefs.SetInt("FakerActiveTurn", 0);
        PlayerPrefs.SetInt("HealerActiveTurn", 0);
        PlayerPrefs.SetInt("LightBomberActiveTurn", 0);
        PlayerPrefs.SetInt("BombCatcherActiveTurn", 0);
        PlayerPrefs.SetInt("BomberActiveTurn", 0);
        PlayerPrefs.SetInt("BoomerActiveTurn", 0);
        PlayerPrefs.SetInt("FlameThrowerActiveTurn", 0);
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
        if (PlayerPrefs.GetString("Map") == "Map1")
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
    void OnEnable()
    {
        PointControl();
        Text.color = Color.white;
    }
    void Update()
    {
        if(PlayerPrefs.GetString("AttackType") == "Passive")
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
        else if(PlayerPrefs.GetString("AttackType") == "Active")
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
        else
        {
            PointControl();
        }
    }

    void PointControl()
    {
        int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        if (shipName.text == "MoneyMaker")
        {
            var MoneyMaker = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
            if (point >= MoneyMaker.ActiveAttributeCost && (PlayerPrefs.GetInt("MoneyMakerActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "Tank")
        {
            var Tank = GameObject.Find("Tank").GetComponent<Tank>();
            if (point >= Tank.ActiveAttributeCost && (PlayerPrefs.GetInt("TankActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "SideStep")
        {
            var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
            if (point >= SideStep.ActiveAttributeCost && (PlayerPrefs.GetInt("SideStepActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "Faker")
        {
            var Faker = GameObject.Find("Faker").GetComponent<Faker>();
            if (point >= Faker.ActiveAttributeCost && (PlayerPrefs.GetInt("FakerActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "Healer")
        {
            var Healer = GameObject.Find("Healer").GetComponent<Healer>();
            if (point >= Healer.ActiveAttributeCost && (PlayerPrefs.GetInt("HealerActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "LightBomber")
        {
            var LightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();
            if (point >= LightBomber.ActiveAttributeCost && (PlayerPrefs.GetInt("LightBomberActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "BombCatcher")
        {
            var BombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
            if (point >= BombCatcher.ActiveAttributeCost && (PlayerPrefs.GetInt("BombCatcherActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "Bomber")
        {
            var Bomber = GameObject.Find("Bomber").GetComponent<Bomber>();
            if (point >= Bomber.ActiveAttributeCost && (PlayerPrefs.GetInt("BomberActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "Boomer")
        {
            var Boomer = GameObject.Find("Boomer").GetComponent<Boomer>();
            if (point >= Boomer.ActiveAttributeCost && (PlayerPrefs.GetInt("BoomerActiveTurn") == 0))
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
        if (shipName.text == "FlameThrower")
        {
            var FlameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();
            if (point >= FlameThrower.ActiveAttributeCost && 
                PlayerPrefs.GetInt("FlameThrowerActiveTurn") == 0 &&
                FlameThrower.FlameThrowerActiveSkill)
            {
                gameObject.GetComponent<Button>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }

    public void Clicked()
    {
        foreach (Button passiveBtn in PassiveButtons)
            passiveBtn.enabled = false;
        foreach (Button activeBtn in ActiveButtons)
            activeBtn.enabled = false;

        Text.color = Color.red;
        FindShootingShip();
        PlayerPrefs.SetString("AttackType", "Active");
        GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().ChoseTile();
        PointDrop();
        FindShip();

    }
    void FindShip()
    {
        PlayerPrefs.SetInt("ActiveHitPerTurn", 1);
        if (PlayerPrefs.GetString("ShootingShip") == "MoneyMaker")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "MoneyMaker active feature grants 2 shot.  The cost of the skill is 2 points.";
            PlayerPrefs.SetInt("ActiveHitPerTurn", 2);
            PlayerPrefs.SetInt("MoneyMakerActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "Tank")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Tank active feature grants 1 shot. If this shot is accurate, the turn passes to the opponent. If this shot is inaccurate, it gains 1 more shot. The cost of the skill is 3 points.";
            var Tank = GameObject.Find("Tank").GetComponent<Tank>();
            Tank.ActiveSkill = true;
            PlayerPrefs.SetInt("TankActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "SideStep")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "SideStep active feature grants 1 shot. If this shot is accurate, it gains the right to shoot as much as the initial piece size of the hit ship. For example, if you hit the Boomer ship with the SideStepin active feature, you will gain 6 more shots. The cost of the skill is 4 points.";
            var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
            SideStep.ActiveSkill = true;
            PlayerPrefs.SetInt("SideStepActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "Faker")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Faker active feature grants 1 shot. If the shot is successful, it completely polishes the opposing ship. The cost of the skill is 5 points.";
            PlayerPrefs.SetInt("FakerActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "Healer")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Healer active feature grants 3 shot. The cost of the skill is 6 points.";
            PlayerPrefs.SetInt("ActiveHitPerTurn", 3);
            PlayerPrefs.SetInt("HealerActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "LightBomber")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "LightBomber active feature grants 4 shot. The cost of the skill is 7 points.";
            PlayerPrefs.SetInt("ActiveHitPerTurn", 4);
            PlayerPrefs.SetInt("LightBomberActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "BombCatcher")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "BombCatcher active feature grants 5 shot. The cost of the skill is 8 points.";
            PlayerPrefs.SetInt("ActiveHitPerTurn", 5);
            PlayerPrefs.SetInt("BombCatcherActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "Bomber")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Bomber active ability detonates a selected line completely. If there is a tank ship in the selected row and the ship is yellow, that piece cannot be hit. The cost of the skill is 9 points.";
            PlayerPrefs.SetInt("BomberActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "Boomer")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "Boomer active ability completely detonates a selected column. If there is a tank ship in the selected column and the ship is yellow, that piece cannot be hit. The cost of the skill is 10 points.";
            PlayerPrefs.SetInt("BoomerActiveTurn", 3);
        }
        if (PlayerPrefs.GetString("ShootingShip") == "FlameThrower")
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextMeshProUGUI>().text = "The FlameThrower active ability detonates all the starting edges of the map. If there is a tank ship on the starting edges of the map and the ship is yellow, that piece cannot be hit. It can only be used once. The cost of the skill is 11 points.";
            var FlameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();
            FlameThrower.FlameThrowerActiveSkill = false;
            PlayerPrefs.SetInt("FlameThrowerActiveTurn", 3);
            MapEdgeColor();
        }
        int RemainingShotPoint = PlayerPrefs.GetInt("ActiveHitPerTurn");
        GameObject.Find("RemainingShotPoint").GetComponent<TextMeshProUGUI>().text = RemainingShotPoint.ToString();
    }

    void MapEdgeColor()
    {
        for (int i = 0; i < 10; i++)
        {
            if (map[0, i].GetComponent<Image>().color == whiteColor)
            {
                map[0, i].GetComponent<Image>().color = greenColor;
            }
            if (map[9, i].GetComponent<Image>().color == whiteColor)
            {
                map[9, i].GetComponent<Image>().color = greenColor;
            }
            if (map[i, 0].GetComponent<Image>().color == whiteColor)
            {
                map[i, 0].GetComponent<Image>().color = greenColor;
            }
            if (map[i, 9].GetComponent<Image>().color == whiteColor)
            {
                map[i, 9].GetComponent<Image>().color = greenColor;
            }
        }
        if(PlayerPrefs.GetString("Map") == "Map2")
        {
            if (map[1, 2].GetComponent<Image>().color == whiteColor)
                map[1, 2].GetComponent<Image>().color = greenColor;
            if (map[2, 3].GetComponent<Image>().color == whiteColor)
                map[2, 3].GetComponent<Image>().color = greenColor;
            if (map[3, 4].GetComponent<Image>().color == whiteColor)
                map[3, 4].GetComponent<Image>().color = greenColor;
            if (map[3, 5].GetComponent<Image>().color == whiteColor)
                map[3, 5].GetComponent<Image>().color = greenColor;
            if (map[2, 6].GetComponent<Image>().color == whiteColor)
                map[2, 6].GetComponent<Image>().color = greenColor;
            if (map[1, 7].GetComponent<Image>().color == whiteColor)
                map[1, 7].GetComponent<Image>().color = greenColor;

            if (map[6, 2].GetComponent<Image>().color == whiteColor)
                map[6, 2].GetComponent<Image>().color = greenColor;
            if (map[7, 3].GetComponent<Image>().color == whiteColor)
                map[7, 3].GetComponent<Image>().color = greenColor;
            if (map[8, 4].GetComponent<Image>().color == whiteColor)
                map[8, 4].GetComponent<Image>().color = greenColor;
            if (map[8, 5].GetComponent<Image>().color == whiteColor)
                map[8, 5].GetComponent<Image>().color = greenColor;
            if (map[7, 6].GetComponent<Image>().color == whiteColor)
                map[7, 6].GetComponent<Image>().color = greenColor;
            if (map[6, 7].GetComponent<Image>().color == whiteColor)
                map[6, 7].GetComponent<Image>().color = greenColor;
        }
        if(PlayerPrefs.GetString("Map") == "Map3")
        {
            if (map[1, 1].GetComponent<Image>().color == whiteColor)
                map[1, 1].GetComponent<Image>().color = greenColor;
            if (map[2, 5].GetComponent<Image>().color == whiteColor)
                map[2, 5].GetComponent<Image>().color = greenColor;
            if (map[3, 5].GetComponent<Image>().color == whiteColor)
                map[3, 5].GetComponent<Image>().color = greenColor;
            if (map[4, 1].GetComponent<Image>().color == whiteColor)
                map[4, 1].GetComponent<Image>().color = greenColor;
            if (map[4, 7].GetComponent<Image>().color == whiteColor)
                map[4, 7].GetComponent<Image>().color = greenColor;
            if (map[5, 2].GetComponent<Image>().color == whiteColor)
                map[5, 2].GetComponent<Image>().color = greenColor;
            if (map[5, 8].GetComponent<Image>().color == whiteColor)
                map[5, 8].GetComponent<Image>().color = greenColor;
            if (map[6, 4].GetComponent<Image>().color == whiteColor)
                map[6, 4].GetComponent<Image>().color = greenColor;
            if (map[7, 4].GetComponent<Image>().color == whiteColor)
                map[7, 4].GetComponent<Image>().color = greenColor;
            if (map[8, 8].GetComponent<Image>().color == whiteColor)
                map[8, 8].GetComponent<Image>().color = greenColor;
        }
        if (PlayerPrefs.GetString("Map") == "Map4")
        {
            if (map[2, 1].GetComponent<Image>().color == whiteColor)
                map[2, 1].GetComponent<Image>().color = greenColor;
            if (map[1, 2].GetComponent<Image>().color == whiteColor)
                map[1, 2].GetComponent<Image>().color = greenColor;
            if (map[1, 7].GetComponent<Image>().color == whiteColor)
                map[1, 7].GetComponent<Image>().color = greenColor;
            if (map[2, 8].GetComponent<Image>().color == whiteColor)
                map[2, 8].GetComponent<Image>().color = greenColor;
            if (map[7, 1].GetComponent<Image>().color == whiteColor)
                map[7, 1].GetComponent<Image>().color = greenColor;
            if (map[8, 2].GetComponent<Image>().color == whiteColor)
                map[8, 2].GetComponent<Image>().color = greenColor;
            if (map[7, 8].GetComponent<Image>().color == whiteColor)
                map[7, 8].GetComponent<Image>().color = greenColor;
            if (map[8, 7].GetComponent<Image>().color == whiteColor)
                map[8, 7].GetComponent<Image>().color = greenColor;
        }
    }

    void PointDrop()
    {
        if(PlayerPrefs.GetString("ShootingShip") != "FlameThrower")
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == whiteColor)
                        map[i, j].gameObject.GetComponent<Image>().color = greenColor;
        if (shipName.text == "MoneyMaker")
        {
            var MoneyMaker = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - MoneyMaker.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "Tank")
        {
            var Tank = GameObject.Find("Tank").GetComponent<Tank>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - Tank.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "SideStep")
        {
            var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - SideStep.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "Faker")
        {
            var Faker = GameObject.Find("Faker").GetComponent<Faker>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - Faker.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "Healer")
        {
            var Healer = GameObject.Find("Healer").GetComponent<Healer>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - Healer.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "LightBomber")
        {
            var LightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - LightBomber.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "BombCatcher")
        {
            var BombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - BombCatcher.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "Bomber")
        {
            var Bomber = GameObject.Find("Bomber").GetComponent<Bomber>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - Bomber.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "Boomer")
        {
            var Boomer = GameObject.Find("Boomer").GetComponent<Boomer>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - Boomer.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
        if (shipName.text == "FlameThrower")
        {
            var FlameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();

            int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
            point = point - FlameThrower.ActiveAttributeCost;
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
        }
    }

    void FindShootingShip()
    {
        if (shipName.text == "MoneyMaker")
            PlayerPrefs.SetString("ShootingShip", "MoneyMaker");
        else if (shipName.text == "Tank")
            PlayerPrefs.SetString("ShootingShip", "Tank");
        else if (shipName.text == "SideStep")
            PlayerPrefs.SetString("ShootingShip", "SideStep");
        else if (shipName.text == "Faker")
            PlayerPrefs.SetString("ShootingShip", "Faker");
        else if (shipName.text == "Healer")
            PlayerPrefs.SetString("ShootingShip", "Healer");
        else if (shipName.text == "LightBomber")
            PlayerPrefs.SetString("ShootingShip", "LightBomber");
        else if (shipName.text == "BombCatcher")
            PlayerPrefs.SetString("ShootingShip", "BombCatcher");
        else if (shipName.text == "Bomber")
            PlayerPrefs.SetString("ShootingShip", "Bomber");
        else if (shipName.text == "Boomer")
            PlayerPrefs.SetString("ShootingShip", "Boomer");
        else if (shipName.text == "FlameThrower")
            PlayerPrefs.SetString("ShootingShip", "FlameThrower");
    }

}
