using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlameThrower : MonoBehaviour
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
    public int SixthPieceI { get; set; }
    public int SixthPieceJ { get; set; }
    public int SeventhPieceI { get; set; }
    public int SeventhPieceJ { get; set; }
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public bool FlameThrowerActiveSkill = true;

    private void Start()
    {
        FlameThrowerActiveSkill = true;
    }

    void IncreaseScore()
    {
        int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        point++;
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
    }

    public GameObject[,] PassiveSkill(GameObject[,] map, string Ship)
    {
        if (PlayerPrefs.GetString("ShootingShip")=="FlameThrower")
        {
            if (Ship == "MoneyMaker")
            {
                var MoneyMaker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker;
                if (MoneyMaker.HittedPiece < MoneyMaker.Piece)
                {
                    if (map[MoneyMaker.FirstPieceI, MoneyMaker.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[MoneyMaker.SecondPieceI, MoneyMaker.SecondPieceJ].GetComponent<Image>().color = redColor;
                    }
                    else
                    {
                        map[MoneyMaker.FirstPieceI, MoneyMaker.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    MoneyMaker.HittedPiece++;
                    IncreaseScore();
                }
            }
            if (Ship=="Tank")
            {
                var Tank= GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank;
                if (Tank.HittedPiece < Tank.Piece)
                {
                    if (map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color == Color.yellow)
                    {
                        map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color == Color.yellow)
                    {
                        map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color == Color.yellow)
                    {
                        map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    Tank.HittedPiece++;
                    IncreaseScore();
                }
            }
            if (Ship=="SideStep")
            {
                var SideStep = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep;
                if (SideStep.HittedPiece < SideStep.Piece)
                {
                    if (map[SideStep.FirstPieceI, SideStep.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[SideStep.SecondPieceI, SideStep.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            map[SideStep.ThirdPieceI, SideStep.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        }
                        else
                        {
                            map[SideStep.SecondPieceI, SideStep.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }                          
                    }
                    else
                    {
                        map[SideStep.FirstPieceI, SideStep.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    SideStep.HittedPiece++;
                    IncreaseScore();
                }                
            }
            if (Ship == "Faker")
            {
                var Faker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker;
                if (Faker.HittedPiece < Faker.Piece)
                {
                    if (map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                map[Faker.FourthPieceI, Faker.FourthPieceJ].GetComponent<Image>().color = redColor;
                            }
                            else
                            {
                                map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }                             
                        }
                        else
                        {
                            map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    Faker.HittedPiece++;
                    IncreaseScore();
                }                   
            }
            if (Ship == "Healer")
            {
                var Healer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer;
                if (Healer.HittedPiece < Healer.Piece)
                {
                    if (map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                map[Healer.FourthPieceI, Healer.FourthPieceJ].GetComponent<Image>().color = redColor;
                            }
                            else
                            {
                                map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    Healer.HittedPiece++;
                    IncreaseScore();
                }                    
            }
            if (Ship == "LightBomber")
            {
                var LightBomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber;
                if (LightBomber.HittedPiece < LightBomber.Piece)
                {
                    if (map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                map[LightBomber.FourthPieceI, LightBomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                            }
                            else
                            {
                                map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    LightBomber.HittedPiece++;
                    IncreaseScore();
                }                       
            }
            if (Ship == "BombCatcher")
            {
                var BombCatcher = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher;
                if (BombCatcher.HittedPiece < BombCatcher.Piece)
                {
                    if (map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                if (map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color == redColor)
                                {
                                    map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color = redColor;
                                }
                                else
                                {
                                    map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color = redColor;
                                }                                 
                            }
                            else
                            {
                                map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    BombCatcher.HittedPiece++;
                    IncreaseScore();
                }                     
            }
            if (Ship == "Bomber")
            {
                var Bomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber;
                if (Bomber.HittedPiece < Bomber.Piece)
                {
                    if (map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                if (map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color == redColor)
                                {
                                    map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color = redColor;
                                }
                                else
                                {
                                    map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                                }
                            }
                            else
                            {
                                map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    Bomber.HittedPiece++;
                    IncreaseScore();
                }                     
            }
            if (Ship == "Boomer")
            {
                var Boomer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer;
                if (Boomer.HittedPiece < Boomer.Piece)
                {
                    if (map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                if (map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color == redColor)
                                {
                                    if (map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color == redColor)
                                    {
                                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                                    }
                                    else
                                    {
                                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                                    }                                     
                                }
                                else
                                {
                                    map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                                }
                            }
                            else
                            {
                                map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    Boomer.HittedPiece++;
                    IncreaseScore();
                }                      
            }
            if (Ship == "FlameThrower")
            {
                var FlameThrower = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower;
                if (FlameThrower.HittedPiece < FlameThrower.Piece)
                {
                    if (map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        if (map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color == redColor)
                        {
                            if (map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color == redColor)
                            {
                                if (map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color == redColor)
                                {
                                    if (map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color == redColor)
                                    {
                                        if (map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color == redColor)
                                        {
                                            map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                                        }
                                        else
                                        {
                                            map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                                        }                                          
                                    }
                                    else
                                    {
                                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                                    }
                                }
                                else
                                {
                                    map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                                }
                            }
                            else
                            {
                                map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                            }
                        }
                        else
                        {
                            map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        }
                    }
                    else
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                    }
                    FlameThrower.HittedPiece++;
                    IncreaseScore();
                }                   
            }
        }
        return map;
    }

    public void ActiveSkill(GameObject[,] map)
    {
        if (PlayerPrefs.GetString("ShootingShip") == "FlameThrower")
        {
            bool control = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j].GetComponent<Image>().color == greenColor)
                    {
                        control = true;
                    }
                }
            }

            if (control)
            {
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") + 1);
            }
        }
    }
}