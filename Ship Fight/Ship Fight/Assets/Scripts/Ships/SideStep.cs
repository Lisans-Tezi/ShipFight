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
