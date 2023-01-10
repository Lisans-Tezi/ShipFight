using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Bomber : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public string Name { get; set; }
    public int Piece { get; set; }
    public int HittedPiece { get; set; }
    public int FirstPieceI { get; set; }
    public int FirstPieceJ { get; set; }
    public int SecondPieceI { get; set; }
    public int SecondPieceJ { get; set; }
    public int ThirdPieceI { get; set; }
    public int ThirdPieceJ { get; set; }
    public int FourthPieceI { get; set; }
    public int FourthPieceJ { get; set; }
    public int FifthPieceI { get; set; }
    public int FifthPieceJ { get; set; }
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    public bool control = false;
    public bool tank = false;

    private void Start()
    {
        control = false;
        tank = false;
    }

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);
    public GameObject[,] PassiveSkill(GameObject[,] map)
    {
        bool loopcontrol = false;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (IsHitted(GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank,
                            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker,
                            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber,
                            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber,
                            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower, i, j))
                { 
                    if (tank == true && map[i, j].GetComponent<Image>().color != Color.yellow && map[i, j].GetComponent<Image>().color != redColor)
                    {
                        map[i, j].GetComponent<Image>().color = Color.yellow;
                    }
                    else
                    {
                        map[i, j].GetComponent<Image>().color = redColor;
                    }
                    loopcontrol = true;
                    break;
                }
            }
            if (loopcontrol)
            {
                break;
            }
        }
        return map;
    }

    bool IsHitted(MoneyMaker MoneyMaker, Tank Tank, SideStep SideStep, Faker Faker, Healer Healer, LightBomber LightBomber,
        BombCatcher BombCatcher, Bomber Bomber, Boomer Boomer, FlameThrower FlameThrower, int i, int j)
    {
        if (MoneyMaker.FirstPieceI >= 0 && MoneyMaker.HittedPiece == 0)
        {
            if ((i == MoneyMaker.FirstPieceI && j == MoneyMaker.FirstPieceJ) ||
                (i == MoneyMaker.SecondPieceI && j == MoneyMaker.SecondPieceJ))
            {
                MoneyMaker.HittedPiece++;
                return true;
            }
        }
        if (Tank.FirstPieceI >= 0 && Tank.HittedPiece == 0)
        {
            if ((i == Tank.FirstPieceI && j == Tank.FirstPieceJ) ||
                 (i == Tank.SecondPieceI && j == Tank.SecondPieceJ) ||
                 (i == Tank.ThirdPieceI && j == Tank.ThirdPieceJ))
            {
                Tank.HittedPiece++;
                tank = true;
                return true;
            }
        }
        if (SideStep.FirstPieceI >= 0 && SideStep.HittedPiece == 0)
        {
            if ((i == SideStep.FirstPieceI && j == SideStep.FirstPieceJ) ||
                 (i == SideStep.SecondPieceI && j == SideStep.SecondPieceJ) ||
                 (i == SideStep.ThirdPieceI && j == SideStep.ThirdPieceJ))
            {
                SideStep.HittedPiece++;
                return true;
            }
        }
        if (Faker.FirstPieceI >= 0 && Faker.HittedPiece == 0)
        {
            if ((i == Faker.FirstPieceI && j == Faker.FirstPieceJ) ||
                 (i == Faker.SecondPieceI && j == Faker.SecondPieceJ) ||
                 (i == Faker.ThirdPieceI && j == Faker.ThirdPieceJ) ||
                 (i == Faker.FourthPieceI && j == Faker.FourthPieceJ))
            {
                Faker.HittedPiece++;
                return true;
            }
        }
        if (Healer.FirstPieceI >= 0 && Healer.HittedPiece == 0)
        {
            if ((i == Healer.FirstPieceI && j == Healer.FirstPieceJ) ||
                 (i == Healer.SecondPieceI && j == Healer.SecondPieceJ) ||
                 (i == Healer.ThirdPieceI && j == Healer.ThirdPieceJ) ||
                 (i == Healer.FourthPieceI && j == Healer.FourthPieceJ))
            {
                Healer.HittedPiece++;
                return true;
            }
        }
        if (LightBomber.FirstPieceI >= 0 && LightBomber.HittedPiece == 0)
        {
            if ((i == LightBomber.FirstPieceI && j == LightBomber.FirstPieceJ) ||
                 (i == LightBomber.SecondPieceI && j == LightBomber.SecondPieceJ) ||
                 (i == LightBomber.ThirdPieceI && j == LightBomber.ThirdPieceJ) ||
                 (i == LightBomber.FourthPieceI && j == LightBomber.FourthPieceJ))
            {
                LightBomber.HittedPiece++;
                return true;
            }
        }
        if (BombCatcher.FirstPieceI >= 0 && BombCatcher.HittedPiece == 0)
        {
            if ((i == BombCatcher.FirstPieceI && j == BombCatcher.FirstPieceJ) ||
                  (i == BombCatcher.SecondPieceI && j == BombCatcher.SecondPieceJ) ||
                  (i == BombCatcher.ThirdPieceI && j == BombCatcher.ThirdPieceJ) ||
                  (i == BombCatcher.FourthPieceI && j == BombCatcher.FourthPieceJ) ||
                  (i == BombCatcher.FifthPieceI && j == BombCatcher.FifthPieceJ))
            {
                BombCatcher.HittedPiece++;
                return true;
            }
        }
        if (Bomber.FirstPieceI >= 0 && Bomber.HittedPiece == 0)
        {
            if ((i == Bomber.FirstPieceI && j == Bomber.FirstPieceJ) ||
                  (i == Bomber.SecondPieceI && j == Bomber.SecondPieceJ) ||
                  (i == Bomber.ThirdPieceI && j == Bomber.ThirdPieceJ) ||
                  (i == Bomber.FourthPieceI && j == Bomber.FourthPieceJ) ||
                  (i == Bomber.FifthPieceI && j == Bomber.FifthPieceJ))
            {
                Bomber.HittedPiece++;
                return true;
            }
        }
        if (Boomer.FirstPieceI >= 0 && Boomer.HittedPiece == 0)
        {
            if ((i == Boomer.FirstPieceI && j == Boomer.FirstPieceJ) ||
                 (i == Boomer.SecondPieceI && j == Boomer.SecondPieceJ) ||
                 (i == Boomer.ThirdPieceI && j == Boomer.ThirdPieceJ) ||
                 (i == Boomer.FourthPieceI && j == Boomer.FourthPieceJ) ||
                 (i == Boomer.FifthPieceI && j == Boomer.FifthPieceJ) ||
                 (i == Boomer.SixthPieceI && j == Boomer.SixthPieceJ))
            {
                Boomer.HittedPiece++;
                return true;
            }
        }
        if (FlameThrower.FirstPieceI >= 0 && FlameThrower.HittedPiece == 0)
        {
            if ((i == FlameThrower.FirstPieceI && j == FlameThrower.FirstPieceJ) ||
                  (i == FlameThrower.SecondPieceI && j == FlameThrower.SecondPieceJ) ||
                  (i == FlameThrower.ThirdPieceI && j == FlameThrower.ThirdPieceJ) ||
                  (i == FlameThrower.FourthPieceI && j == FlameThrower.FourthPieceJ) ||
                  (i == FlameThrower.FifthPieceI && j == FlameThrower.FifthPieceJ) ||
                  (i == FlameThrower.SixthPieceI && j == FlameThrower.SixthPieceJ) ||
                  (i == FlameThrower.SeventhPieceI && j == FlameThrower.SeventhPieceJ))
            {
                Boomer.HittedPiece++;
                return true;
            }
        }
        return false;
    }

    public GameObject[,] ActiveSkill(GameObject[,] map, int x)
    {
        if (PlayerPrefs.GetString("ShootingShip") == "Bomber")
        {
            bool control = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[x, j].GetComponent<Image>().color == greenColor)
                    {
                        control = true;
                    }
                    if(x != i && map[i, j].GetComponent<Image>().color == greenColor)
                    {
                        map[i, j].GetComponent<Image>().color = whiteColor;
                    }
                }
            }

            if (control)
            {
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") + 1);
            }
        }
        return map;
    }
}
