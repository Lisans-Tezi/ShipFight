using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Faker : MonoBehaviour
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
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    public bool FakerSkill=false;

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    List<int> X = new List<int>();
    List<int> Y = new List<int>();

    public GameObject[,] AIPassiveSkill(GameObject[,] map)
    {
        var faker = GameObject.Find("Faker").GetComponent<Faker>();
        if (FirstPieceI == SecondPieceI)
        {
            //yatay
            if (faker.FirstPieceI - 1 > 0 &&
                map[FirstPieceI - 1, FirstPieceJ].GetComponent<Image>().color == whiteColor &&
                map[SecondPieceI - 1, SecondPieceJ].GetComponent<Image>().color == whiteColor &&
                map[ThirdPieceI - 1, ThirdPieceJ].GetComponent<Image>().color == whiteColor &&
                map[FourthPieceI - 1, FourthPieceJ].GetComponent<Image>().color == whiteColor)
            {
                ChangeColors(map, '-', '+', 1, 0);
                FirstPieceI--;
                SecondPieceI--;
                ThirdPieceI--;
                FourthPieceI--; 
            }      
            else if(faker.FirstPieceI + 1 < 9 &&
                map[FirstPieceI + 1, FirstPieceJ].GetComponent<Image>().color == whiteColor &&
                map[SecondPieceI + 1, SecondPieceJ].GetComponent<Image>().color == whiteColor &&
                map[ThirdPieceI + 1, ThirdPieceJ].GetComponent<Image>().color == whiteColor &&
                map[FourthPieceI + 1, FourthPieceJ].GetComponent<Image>().color == whiteColor)
            {
                ChangeColors(map, '+', '+', 1, 0);
                FirstPieceI++;
                SecondPieceI++;
                ThirdPieceI++;
                FourthPieceI++;
            }
        }
        else
        {
            //dikey
            if (faker.FirstPieceJ - 1 > 0 && 
               map[FirstPieceI, FirstPieceJ - 1].GetComponent<Image>().color == whiteColor &&
               map[SecondPieceI, SecondPieceJ - 1].GetComponent<Image>().color == whiteColor &&
               map[ThirdPieceI, ThirdPieceJ - 1].GetComponent<Image>().color == whiteColor &&
               map[FourthPieceI, FourthPieceJ - 1].GetComponent<Image>().color == whiteColor)
            {
                ChangeColors(map, '+', '-', 0, 1);
                FirstPieceJ--;
                SecondPieceJ--;
                ThirdPieceJ--;
                FourthPieceJ--;
            }
            else if (faker.FirstPieceJ + 1 < 9 && 
                map[FirstPieceI, FirstPieceJ + 1].GetComponent<Image>().color == whiteColor &&
                map[SecondPieceI, SecondPieceJ + 1].GetComponent<Image>().color == whiteColor &&
                map[ThirdPieceI, ThirdPieceJ + 1].GetComponent<Image>().color == whiteColor &&
                map[FourthPieceI, FourthPieceJ + 1].GetComponent<Image>().color == whiteColor)
            {
                ChangeColors(map, '+', '+', 0, 1);
                FirstPieceJ++;
                SecondPieceJ++;
                ThirdPieceJ++;
                FourthPieceJ++;
            }
        }
        return map;
    }
    public bool PassiveSkill(Faker faker, GameObject[,] map)
    {
        FillX(GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower);

        FillY(GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower);

        bool control = false;
        if (faker.FirstPieceI == faker.SecondPieceI)
        {
            if (XControlUp(X, Y, faker, map))
            {
                faker.FirstPieceI--;
                faker.SecondPieceI--;
                faker.ThirdPieceI--;
                faker.FourthPieceI--;
                control = true;
            }
            else if (XControlDown(X, Y, faker, map))
            {
                faker.FirstPieceI++;
                faker.SecondPieceI++;
                faker.ThirdPieceI++;
                faker.FourthPieceI++;
                control = true;
            }
        }
        else if (faker.FirstPieceJ == faker.SecondPieceJ)
        {
            if (YControlLeft(X, Y, faker, map))
            {
                faker.FirstPieceJ--;
                faker.SecondPieceJ--;
                faker.ThirdPieceJ--;
                faker.FourthPieceJ--;
                control = true;
            }
            else if (YControlRight(X, Y, faker, map))
            {
                faker.FirstPieceJ++;
                faker.SecondPieceJ++;
                faker.ThirdPieceJ++;
                faker.FourthPieceJ++;
                control = true;
            }
        }
        return control;
    }

    void FillX(MoneyMaker MoneyMaker, Tank Tank, SideStep SideStep, Healer Healer,
        LightBomber LightBomber, BombCatcher BombCatcher, Bomber Bomber, Boomer Boomer, FlameThrower FlameThrower)
    {
        X.Add(MoneyMaker.FirstPieceI);
        X.Add(MoneyMaker.SecondPieceI);

        X.Add(Tank.FirstPieceI);
        X.Add(Tank.SecondPieceI);
        X.Add(Tank.ThirdPieceI);

        X.Add(SideStep.FirstPieceI);
        X.Add(SideStep.SecondPieceI);
        X.Add(SideStep.ThirdPieceI);

        X.Add(Healer.FirstPieceI);
        X.Add(Healer.SecondPieceI);
        X.Add(Healer.ThirdPieceI);
        X.Add(Healer.FourthPieceI);

        X.Add(LightBomber.FirstPieceI);
        X.Add(LightBomber.SecondPieceI);
        X.Add(LightBomber.ThirdPieceI);
        X.Add(LightBomber.FourthPieceI);

        X.Add(BombCatcher.FirstPieceI);
        X.Add(BombCatcher.SecondPieceI);
        X.Add(BombCatcher.ThirdPieceI);
        X.Add(BombCatcher.FourthPieceI);
        X.Add(BombCatcher.FifthPieceI);

        X.Add(Bomber.FirstPieceI);
        X.Add(Bomber.SecondPieceI);
        X.Add(Bomber.ThirdPieceI);
        X.Add(Bomber.FourthPieceI);
        X.Add(Bomber.FifthPieceI);

        X.Add(Boomer.FirstPieceI);
        X.Add(Boomer.SecondPieceI);
        X.Add(Boomer.ThirdPieceI);
        X.Add(Boomer.FourthPieceI);
        X.Add(Boomer.FifthPieceI);
        X.Add(Boomer.SixthPieceI);

        X.Add(FlameThrower.FirstPieceI);
        X.Add(FlameThrower.SecondPieceI);
        X.Add(FlameThrower.ThirdPieceI);
        X.Add(FlameThrower.FourthPieceI);
        X.Add(FlameThrower.FifthPieceI);
        X.Add(FlameThrower.SixthPieceI);
        X.Add(FlameThrower.SeventhPieceI);
    }
    void FillY(MoneyMaker MoneyMaker, Tank Tank, SideStep SideStep, Healer Healer,
        LightBomber LightBomber, BombCatcher BombCatcher, Bomber Bomber, Boomer Boomer, FlameThrower FlameThrower)
    {
        Y.Add(MoneyMaker.FirstPieceJ);
        Y.Add(MoneyMaker.SecondPieceJ);

        Y.Add(Tank.FirstPieceJ);
        Y.Add(Tank.SecondPieceJ);
        Y.Add(Tank.ThirdPieceJ);

        Y.Add(SideStep.FirstPieceJ);
        Y.Add(SideStep.SecondPieceJ);
        Y.Add(SideStep.ThirdPieceJ);

        Y.Add(Healer.FirstPieceJ);
        Y.Add(Healer.SecondPieceJ);
        Y.Add(Healer.ThirdPieceJ);
        Y.Add(Healer.FourthPieceJ);

        Y.Add(LightBomber.FirstPieceJ);
        Y.Add(LightBomber.SecondPieceJ);
        Y.Add(LightBomber.ThirdPieceJ);
        Y.Add(LightBomber.FourthPieceJ);

        Y.Add(BombCatcher.FirstPieceJ);
        Y.Add(BombCatcher.SecondPieceJ);
        Y.Add(BombCatcher.ThirdPieceJ);
        Y.Add(BombCatcher.FourthPieceJ);
        Y.Add(BombCatcher.FifthPieceJ);

        Y.Add(Bomber.FirstPieceJ);
        Y.Add(Bomber.SecondPieceJ);
        Y.Add(Bomber.ThirdPieceJ);
        Y.Add(Bomber.FourthPieceJ);
        Y.Add(Bomber.FifthPieceJ);

        Y.Add(Boomer.FirstPieceJ);
        Y.Add(Boomer.SecondPieceJ);
        Y.Add(Boomer.ThirdPieceJ);
        Y.Add(Boomer.FourthPieceJ);
        Y.Add(Boomer.FifthPieceJ);
        Y.Add(Boomer.SixthPieceJ);

        Y.Add(FlameThrower.FirstPieceJ);
        Y.Add(FlameThrower.SecondPieceJ);
        Y.Add(FlameThrower.ThirdPieceJ);
        Y.Add(FlameThrower.FourthPieceJ);
        Y.Add(FlameThrower.FifthPieceJ);
        Y.Add(FlameThrower.SixthPieceJ);
        Y.Add(FlameThrower.SeventhPieceJ);
    }
    bool XControlUp(List<int> X, List<int> Y, Faker faker, GameObject[,] map)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceI - 1 > 0)
            {
                if ((X[i] == faker.FirstPieceI - 1 && Y[i] == faker.FirstPieceJ ||
                    map[faker.FirstPieceI - 1, faker.FirstPieceJ].GetComponent<Image>().color != greenColor) ||
                (X[i] == faker.SecondPieceI - 1 && Y[i] == faker.SecondPieceJ ||
                    map[faker.SecondPieceI - 1, faker.SecondPieceJ].GetComponent<Image>().color != greenColor) ||
                (X[i] == faker.ThirdPieceI - 1 && Y[i] == faker.ThirdPieceJ ||
                    map[faker.ThirdPieceI - 1, faker.ThirdPieceJ].GetComponent<Image>().color != greenColor) ||
                (X[i] == faker.FourthPieceI - 1 && Y[i] == faker.FourthPieceJ ||
                    map[faker.FourthPieceI - 1, faker.FourthPieceJ].GetComponent<Image>().color != greenColor))
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }                
        }
        return true;
    }
    bool XControlDown(List<int> X, List<int> Y, Faker faker, GameObject[,] map)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceI + 1 < 9)
            {
                if ((X[i] == faker.FirstPieceI + 1 && Y[i] == faker.FirstPieceJ ||
                    map[faker.FirstPieceI + 1, faker.FirstPieceJ].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.SecondPieceI + 1 && Y[i] == faker.SecondPieceJ ||
                    map[faker.SecondPieceI + 1, faker.SecondPieceJ].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.ThirdPieceI + 1 && Y[i] == faker.ThirdPieceJ ||
                    map[faker.ThirdPieceI + 1, faker.ThirdPieceJ].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.FourthPieceI + 1 && Y[i] == faker.FourthPieceJ ||
                    map[faker.FourthPieceI + 1, faker.FourthPieceJ].GetComponent<Image>().color != greenColor))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    bool YControlLeft(List<int> X, List<int> Y, Faker faker, GameObject[,] map)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceJ - 1 > 0)
            {
                if ((X[i] == faker.FirstPieceI && Y[i] == faker.FirstPieceJ - 1 ||
                    map[faker.FirstPieceI, faker.FirstPieceJ - 1].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.SecondPieceI && Y[i] == faker.SecondPieceJ - 1 ||
                    map[faker.SecondPieceI, faker.SecondPieceJ - 1].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.ThirdPieceI && Y[i] == faker.ThirdPieceJ - 1 ||
                    map[faker.ThirdPieceI, faker.ThirdPieceJ - 1].GetComponent<Image>().color != greenColor) ||
                 (X[i] == faker.FourthPieceI && Y[i] == faker.FourthPieceJ - 1 ||
                    map[faker.FourthPieceI, faker.FourthPieceJ - 1].GetComponent<Image>().color != greenColor))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    bool YControlRight(List<int> X, List<int> Y, Faker faker, GameObject[,] map)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceJ + 1 < 9)
            {
                if ((X[i] == faker.FirstPieceI && Y[i] == faker.FirstPieceJ + 1 || 
                    map[faker.FirstPieceI, faker.FirstPieceJ + 1].GetComponent<Image>().color != greenColor) || 
                    (X[i] == faker.SecondPieceI && Y[i] == faker.SecondPieceJ + 1 ||
                    map[faker.SecondPieceI, faker.SecondPieceJ + 1].GetComponent<Image>().color != greenColor) ||
                    (X[i] == faker.ThirdPieceI && Y[i] == faker.ThirdPieceJ + 1 ||
                    map[faker.ThirdPieceI, faker.ThirdPieceJ + 1].GetComponent<Image>().color != greenColor) ||
                    (X[i] == faker.FourthPieceI && Y[i] == faker.FourthPieceJ + 1 ||
                    map[faker.FourthPieceI, faker.FourthPieceJ + 1].GetComponent<Image>().color != greenColor))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    void ChangeColors(GameObject[,] map, char icontrol = '+', char jcontrol = '+', int inumber = 0, int jnumber = 0)
    {
        if (icontrol == '+' && jcontrol == '+')
        {
            map[FirstPieceI + inumber, FirstPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[SecondPieceI + inumber, SecondPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[ThirdPieceI + inumber, ThirdPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[FourthPieceI + inumber, FourthPieceJ + jnumber].GetComponent<Image>().color = Color.black;             
        }
        else if (icontrol == '+' && jcontrol == '-')
        {
            map[FirstPieceI + inumber, FirstPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[SecondPieceI + inumber, SecondPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[ThirdPieceI + inumber, ThirdPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[FourthPieceI + inumber, FourthPieceJ - jnumber].GetComponent<Image>().color = Color.black;
        }
        else if (icontrol == '-' && jcontrol == '+')
        {
            map[FirstPieceI - inumber, FirstPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[SecondPieceI - inumber, SecondPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[ThirdPieceI - inumber, ThirdPieceJ + jnumber].GetComponent<Image>().color = Color.black;
            map[FourthPieceI - inumber, FourthPieceJ + jnumber].GetComponent<Image>().color = Color.black;
        }
        else if (icontrol == '-' && jcontrol == '-')
        {
            map[FirstPieceI - inumber, FirstPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[SecondPieceI - inumber, SecondPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[ThirdPieceI - inumber, ThirdPieceJ - jnumber].GetComponent<Image>().color = Color.black;
            map[FourthPieceI - inumber, FourthPieceJ - jnumber].GetComponent<Image>().color = Color.black;
        }
        map[FirstPieceI, FirstPieceJ].GetComponent<Image>().color = whiteColor;
        map[SecondPieceI, SecondPieceJ].GetComponent<Image>().color = whiteColor;
        map[ThirdPieceI, ThirdPieceJ].GetComponent<Image>().color = whiteColor;
        map[FourthPieceI, FourthPieceJ].GetComponent<Image>().color = whiteColor;
    }


    void IncreaseScore()
    {
        int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        point++;
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();
    }
    public GameObject[,] ActiveSkill(GameObject[,] map, string Ship)
    {
        if (PlayerPrefs.GetString("ShootingShip") == "Faker")
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
                    while(MoneyMaker.Piece != MoneyMaker.HittedPiece)
                    {
                        MoneyMaker.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "Tank")
            {
                var Tank = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank;
                if (Tank.HittedPiece < Tank.Piece)
                {
                    if (map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color == Color.yellow ||
                        map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color == Color.yellow ||
                        map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color == Color.yellow ||
                        map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Tank.FirstPieceI, Tank.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.SecondPieceI, Tank.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Tank.ThirdPieceI, Tank.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (Tank.Piece != Tank.HittedPiece)
                    {
                        Tank.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "SideStep")
            {
                var SideStep = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep;
                if (SideStep.HittedPiece < SideStep.Piece)
                {
                    if (map[SideStep.FirstPieceI, SideStep.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[SideStep.SecondPieceI, SideStep.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[SideStep.ThirdPieceI, SideStep.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[SideStep.SecondPieceI, SideStep.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[SideStep.FirstPieceI, SideStep.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[SideStep.ThirdPieceI, SideStep.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[SideStep.ThirdPieceI, SideStep.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[SideStep.FirstPieceI, SideStep.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[SideStep.SecondPieceI, SideStep.SecondPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (SideStep.Piece != SideStep.HittedPiece)
                    {
                        SideStep.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "Faker")
            {
                var Faker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker;
                if (Faker.HittedPiece < Faker.Piece)
                {
                    if (map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.FourthPieceI, Faker.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.FourthPieceI, Faker.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.FourthPieceI, Faker.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Faker.FourthPieceI, Faker.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Faker.FirstPieceI, Faker.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.SecondPieceI, Faker.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Faker.ThirdPieceI, Faker.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (Faker.Piece != Faker.HittedPiece)
                    {
                        Faker.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "Healer")
            {
                var Healer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer;
                if (Healer.HittedPiece < Healer.Piece)
                {
                    if (map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.FourthPieceI, Healer.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.FourthPieceI, Healer.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.FourthPieceI, Healer.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Healer.FourthPieceI, Healer.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Healer.FirstPieceI, Healer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.SecondPieceI, Healer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Healer.ThirdPieceI, Healer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (Healer.Piece != Healer.HittedPiece)
                    {
                        Healer.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "LightBomber")
            {
                var LightBomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber;
                if (LightBomber.HittedPiece < LightBomber.Piece)
                {
                    if (map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.FourthPieceI, LightBomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.FourthPieceI, LightBomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.FourthPieceI, LightBomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[LightBomber.FourthPieceI, LightBomber.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[LightBomber.FirstPieceI, LightBomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.SecondPieceI, LightBomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[LightBomber.ThirdPieceI, LightBomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (LightBomber.Piece != LightBomber.HittedPiece)
                    {
                        LightBomber.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "BombCatcher")
            {
                var BombCatcher = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher;
                if (BombCatcher.HittedPiece < BombCatcher.Piece)
                {
                    if (map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[BombCatcher.FifthPieceI, BombCatcher.FifthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[BombCatcher.FirstPieceI, BombCatcher.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.SecondPieceI, BombCatcher.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.ThirdPieceI, BombCatcher.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[BombCatcher.FourthPieceI, BombCatcher.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (BombCatcher.Piece != BombCatcher.HittedPiece)
                    {
                        BombCatcher.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "Bomber")
            {
                var Bomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber;
                if (Bomber.HittedPiece < Bomber.Piece)
                {
                    if (map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Bomber.FifthPieceI, Bomber.FifthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Bomber.FirstPieceI, Bomber.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.SecondPieceI, Bomber.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.ThirdPieceI, Bomber.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Bomber.FourthPieceI, Bomber.FourthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (Bomber.Piece != Bomber.HittedPiece)
                    {
                        Bomber.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "Boomer")
            {
                var Boomer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer;
                if (Boomer.HittedPiece < Boomer.Piece)
                {
                    if (map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[Boomer.SixthPieceI, Boomer.SixthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[Boomer.FirstPieceI, Boomer.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.SecondPieceI, Boomer.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.ThirdPieceI, Boomer.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FourthPieceI, Boomer.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[Boomer.FifthPieceI, Boomer.FifthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (Boomer.Piece != Boomer.HittedPiece)
                    {
                        Boomer.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
            if (Ship == "FlameThrower")
            {
                var FlameThrower = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower;
                if (FlameThrower.HittedPiece < FlameThrower.Piece)
                {
                    if (map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color = redColor;
                    }
                    if (map[FlameThrower.SeventhPieceI, FlameThrower.SeventhPieceJ].GetComponent<Image>().color == redColor)
                    {
                        map[FlameThrower.FirstPieceI, FlameThrower.FirstPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SecondPieceI, FlameThrower.SecondPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.ThirdPieceI, FlameThrower.ThirdPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FourthPieceI, FlameThrower.FourthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.FifthPieceI, FlameThrower.FifthPieceJ].GetComponent<Image>().color = redColor;
                        map[FlameThrower.SixthPieceI, FlameThrower.SixthPieceJ].GetComponent<Image>().color = redColor;
                    }
                    while (FlameThrower.Piece != FlameThrower.HittedPiece)
                    {
                        FlameThrower.HittedPiece++;
                        IncreaseScore();
                    }
                }
            }
        }
        return map;
    }
}
