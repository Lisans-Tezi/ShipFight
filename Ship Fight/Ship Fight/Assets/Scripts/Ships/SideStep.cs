using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideStep : MonoBehaviour
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
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    public bool SideStepSkill=true;

    public bool ActiveSkill = false;

    List<int> X = new List<int>();
    List<int> Y = new List<int>();

    public bool PassiveSkill(int x, int y)
    {
        FillX(GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker, 
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber, 
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber, 
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower);

        FillY(GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber,
            GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer, GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower);

        bool control = true;

        for (int i = 0; i < X.Count; i++)
        {
            if (x == X[i] && y == Y[i])
            {
                control = false;
            }
        }

        
        SideStepSkill = false;

        return control;
    }

    public int SideStepActiveSkill(int i, int j)
    {
        var MoneyMaker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker;
        var Tank = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank;
        var SideStep = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep;
        var Faker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker;
        var Healer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer;
        var LightBomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber;
        var BombCatcher = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher;
        var Bomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber;
        var Boomer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer;
        var FlameThrower = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower;

        if (MoneyMaker.FirstPieceI >= 0)
        {
            if ((i == MoneyMaker.FirstPieceI && j == MoneyMaker.FirstPieceJ) ||
                (i == MoneyMaker.SecondPieceI && j == MoneyMaker.SecondPieceJ))
            {
                return MoneyMaker.Piece;
            }
        }
        if (Tank.FirstPieceI >= 0)
        {
            if ((i == Tank.FirstPieceI && j == Tank.FirstPieceJ) ||
                 (i == Tank.SecondPieceI && j == Tank.SecondPieceJ) ||
                 (i == Tank.ThirdPieceI && j == Tank.ThirdPieceJ))
            {
                return Tank.Piece;
            }
        }
        if (SideStep.FirstPieceI >= 0)
        {
            if ((i == SideStep.FirstPieceI && j == SideStep.FirstPieceJ) ||
                 (i == SideStep.SecondPieceI && j == SideStep.SecondPieceJ) ||
                 (i == SideStep.ThirdPieceI && j == SideStep.ThirdPieceJ))
            {
                return SideStep.Piece;
            }
        }
        if (Faker.FirstPieceI >= 0)
        {
            if ((i == Faker.FirstPieceI && j == Faker.FirstPieceJ) ||
                 (i == Faker.SecondPieceI && j == Faker.SecondPieceJ) ||
                 (i == Faker.ThirdPieceI && j == Faker.ThirdPieceJ) ||
                 (i == Faker.FourthPieceI && j == Faker.FourthPieceJ))
            {
                return Faker.Piece;
            }
        }
        if (Healer.FirstPieceI >= 0)
        {
            if ((i == Healer.FirstPieceI && j == Healer.FirstPieceJ) ||
                 (i == Healer.SecondPieceI && j == Healer.SecondPieceJ) ||
                 (i == Healer.ThirdPieceI && j == Healer.ThirdPieceJ) ||
                 (i == Healer.FourthPieceI && j == Healer.FourthPieceJ))
            {
                return Healer.Piece;
            }
        }
        if (LightBomber.FirstPieceI >= 0)
        {
            if ((i == LightBomber.FirstPieceI && j == LightBomber.FirstPieceJ) ||
                 (i == LightBomber.SecondPieceI && j == LightBomber.SecondPieceJ) ||
                 (i == LightBomber.ThirdPieceI && j == LightBomber.ThirdPieceJ) ||
                 (i == LightBomber.FourthPieceI && j == LightBomber.FourthPieceJ))
            {
                return LightBomber.Piece;
            }
        }
        if (BombCatcher.FirstPieceI >= 0)
        {
            if ((i == BombCatcher.FirstPieceI && j == BombCatcher.FirstPieceJ) ||
                  (i == BombCatcher.SecondPieceI && j == BombCatcher.SecondPieceJ) ||
                  (i == BombCatcher.ThirdPieceI && j == BombCatcher.ThirdPieceJ) ||
                  (i == BombCatcher.FourthPieceI && j == BombCatcher.FourthPieceJ) ||
                  (i == BombCatcher.FifthPieceI && j == BombCatcher.FifthPieceJ))
            {
                return BombCatcher.Piece;
            }
        }
        if (Bomber.FirstPieceI >= 0)
        {
            if ((i == Bomber.FirstPieceI && j == Bomber.FirstPieceJ) ||
                  (i == Bomber.SecondPieceI && j == Bomber.SecondPieceJ) ||
                  (i == Bomber.ThirdPieceI && j == Bomber.ThirdPieceJ) ||
                  (i == Bomber.FourthPieceI && j == Bomber.FourthPieceJ) ||
                  (i == Bomber.FifthPieceI && j == Bomber.FifthPieceJ))
            {
                return Bomber.Piece;
            }
        }
        if (Boomer.FirstPieceI >= 0)
        {
            if ((i == Boomer.FirstPieceI && j == Boomer.FirstPieceJ) ||
                 (i == Boomer.SecondPieceI && j == Boomer.SecondPieceJ) ||
                 (i == Boomer.ThirdPieceI && j == Boomer.ThirdPieceJ) ||
                 (i == Boomer.FourthPieceI && j == Boomer.FourthPieceJ) ||
                 (i == Boomer.FifthPieceI && j == Boomer.FifthPieceJ) ||
                 (i == Boomer.SixthPieceI && j == Boomer.SixthPieceJ))
            {
                return Boomer.Piece;
            }
        }
        if (FlameThrower.FirstPieceI >= 0)
        {
            if ((i == FlameThrower.FirstPieceI && j == FlameThrower.FirstPieceJ) ||
                  (i == FlameThrower.SecondPieceI && j == FlameThrower.SecondPieceJ) ||
                  (i == FlameThrower.ThirdPieceI && j == FlameThrower.ThirdPieceJ) ||
                  (i == FlameThrower.FourthPieceI && j == FlameThrower.FourthPieceJ) ||
                  (i == FlameThrower.FifthPieceI && j == FlameThrower.FifthPieceJ) ||
                  (i == FlameThrower.SixthPieceI && j == FlameThrower.SixthPieceJ) ||
                  (i == FlameThrower.SeventhPieceI && j == FlameThrower.SeventhPieceJ))
            {
                return FlameThrower.Piece;
            }
        }
        return 0;
    }

    void FillX(MoneyMaker MoneyMaker, Tank Tank, SideStep SideStep, Faker Faker, Healer Healer,
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

        X.Add(Faker.FirstPieceI);
        X.Add(Faker.SecondPieceI);
        X.Add(Faker.ThirdPieceI);
        X.Add(Faker.FourthPieceI);

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
    void FillY(MoneyMaker MoneyMaker, Tank Tank, SideStep SideStep, Faker Faker, Healer Healer,
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

        Y.Add(Faker.FirstPieceJ);
        Y.Add(Faker.SecondPieceJ);
        Y.Add(Faker.ThirdPieceJ);
        Y.Add(Faker.FourthPieceJ);

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
}
