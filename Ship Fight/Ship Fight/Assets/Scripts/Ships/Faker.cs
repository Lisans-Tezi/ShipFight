using System.Collections;
using System.Collections.Generic;
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
    public void PassiveSkill(Faker faker)
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

        if (faker.FirstPieceI == faker.SecondPieceI)
        {
            if (XControlUp(X, Y, faker))
            {
                faker.FirstPieceI--;
                faker.SecondPieceI--;
                faker.ThirdPieceI--;
                faker.FourthPieceI--;
            }
            else if (XControlDown(X, Y, faker))
            {
                faker.FirstPieceI++;
                faker.SecondPieceI++;
                faker.ThirdPieceI++;
                faker.FourthPieceI++;
            }
        }
        else if (faker.FirstPieceJ == faker.SecondPieceJ)
        {
            if (YControlLeft(X, Y, faker))
            {
                faker.FirstPieceJ--;
                faker.SecondPieceJ--;
                faker.ThirdPieceJ--;
                faker.FourthPieceJ--;
            }
            else if (YControlRight(X, Y, faker))
            {
                faker.FirstPieceJ++;
                faker.SecondPieceJ++;
                faker.ThirdPieceJ++;
                faker.FourthPieceJ++;
            }
        }
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
    bool XControlUp(List<int> X, List<int> Y, Faker faker)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceI - 1 > 0)
            {
                if ((X[i] == faker.FirstPieceI - 1 && Y[i] == faker.FirstPieceJ) ||
                (X[i] == faker.SecondPieceI - 1 && Y[i] == faker.SecondPieceJ) ||
                (X[i] == faker.ThirdPieceI - 1 && Y[i] == faker.ThirdPieceJ) ||
                (X[i] == faker.FourthPieceI - 1 && Y[i] == faker.FourthPieceJ))
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
    bool XControlDown(List<int> X, List<int> Y, Faker faker)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceI + 1 < 9)
            {
                if ((X[i] == faker.FirstPieceI + 1 && Y[i] == faker.FirstPieceJ) ||
                 (X[i] == faker.SecondPieceI + 1 && Y[i] == faker.SecondPieceJ) ||
                 (X[i] == faker.ThirdPieceI + 1 && Y[i] == faker.ThirdPieceJ) ||
                 (X[i] == faker.FourthPieceI + 1 && Y[i] == faker.FourthPieceJ))
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
    bool YControlLeft(List<int> X, List<int> Y, Faker faker)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceJ - 1 > 0)
            {
                if ((X[i] == faker.FirstPieceI && Y[i] == faker.FirstPieceJ - 1) ||
                 (X[i] == faker.SecondPieceI && Y[i] == faker.SecondPieceJ - 1) ||
                 (X[i] == faker.ThirdPieceI && Y[i] == faker.ThirdPieceJ - 1) ||
                 (X[i] == faker.FourthPieceI && Y[i] == faker.FourthPieceJ - 1))
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
    bool YControlRight(List<int> X, List<int> Y, Faker faker)
    {
        for (int i = 0; i < X.Count; i++)
        {
            if (faker.FirstPieceJ + 1 < 9)
            {
                if ((X[i] == faker.FirstPieceI && Y[i] == faker.FirstPieceJ + 1) ||
                    (X[i] == faker.SecondPieceI && Y[i] == faker.SecondPieceJ + 1) ||
                    (X[i] == faker.ThirdPieceI && Y[i] == faker.ThirdPieceJ + 1) ||
                    (X[i] == faker.FourthPieceI && Y[i] == faker.FourthPieceJ + 1))
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
}
