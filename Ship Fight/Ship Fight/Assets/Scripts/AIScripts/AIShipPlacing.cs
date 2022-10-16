using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipPlacing : MonoBehaviour
{
    public MoneyMaker AIMoneyMaker;
    public Tank AITank;
    public SideStep AISideStep;
    public Faker AIFaker;
    public Healer AIHealer;
    public LightBomber AILightBomber;
    public BombCatcher AIBombCatcher;
    public Bomber AIBomber;
    public Boomer AIBoomer;
    public FlameThrower AIFlameThrower;

    void Start()
    {
        int rnd = Random.Range(0, 2);

        if (rnd == 0)
            AIFirst();
        else if (rnd == 1)
            AISecond();
        Debug.Log("AI : " + rnd);
    }

    void AIFirst()
    {
        AIMoneyMaker.Name = "MoneyMaker";
        AIMoneyMaker.Piece = 2;
        AIMoneyMaker.HittedPiece = 0;
        AIMoneyMaker.FirstPieceI = 3;
        AIMoneyMaker.FirstPieceJ = 7;
        AIMoneyMaker.SecondPieceI = 4;
        AIMoneyMaker.SecondPieceJ = 7;
        AIMoneyMaker.PassiveAttribute = "";
        AIMoneyMaker.ActiveAttribute = "";
        AIMoneyMaker.ActiveAttributeCost = 2;

        AITank.Name = "Tank";
        AITank.Piece = 3;
        AITank.HittedPiece = 0;
        AITank.FirstPieceI = 3;
        AITank.FirstPieceJ = 2;
        AITank.SecondPieceI = 3;
        AITank.SecondPieceJ = 3;
        AITank.ThirdPieceI = 3;
        AITank.ThirdPieceJ = 4;
        AITank.PassiveAttribute = "";
        AITank.ActiveAttribute = "";
        AITank.ActiveAttributeCost = 3;

        AIFaker.Name = "Faker";
        AIFaker.Piece = 4;
        AIFaker.HittedPiece = 0;
        AIFaker.FirstPieceI = 0;
        AIFaker.FirstPieceJ = 0;
        AIFaker.SecondPieceI = 1;
        AIFaker.SecondPieceJ = 0;
        AIFaker.ThirdPieceI = 2;
        AIFaker.ThirdPieceJ = 0;
        AIFaker.FourthPieceI = 3;
        AIFaker.FourthPieceJ = 0;
        AIFaker.PassiveAttribute = "";
        AIFaker.ActiveAttribute = "";
        AIFaker.ActiveAttributeCost = 4;

        AILightBomber.Name = "LightBomber";
        AILightBomber.Piece = 4;
        AILightBomber.HittedPiece = 0;
        AILightBomber.FirstPieceI = 9;
        AILightBomber.FirstPieceJ = 7;
        AILightBomber.SecondPieceI = 8;
        AILightBomber.SecondPieceJ = 8;
        AILightBomber.ThirdPieceI = 9;
        AILightBomber.ThirdPieceJ = 8;
        AILightBomber.FourthPieceI = 8;
        AILightBomber.FourthPieceJ = 9;
        AILightBomber.PassiveAttribute = "";
        AILightBomber.ActiveAttribute = "";
        AILightBomber.ActiveAttributeCost = 4;

        AIBomber.Name = "Bomber";
        AIBomber.Piece = 5;
        AIBomber.HittedPiece = 0;
        AIBomber.FirstPieceI = 6;
        AIBomber.FirstPieceJ = 1;
        AIBomber.SecondPieceI = 7;
        AIBomber.SecondPieceJ = 1;
        AIBomber.ThirdPieceI = 7;
        AIBomber.ThirdPieceJ = 2;
        AIBomber.FourthPieceI = 7;
        AIBomber.FourthPieceJ = 3;
        AIBomber.FifthPieceI = 8;
        AIBomber.FifthPieceJ = 1;
        AIBomber.PassiveAttribute = "";
        AIBomber.ActiveAttribute = "";
        AIBomber.ActiveAttributeCost = 5;
    }

    void AISecond()
    {
        AIMoneyMaker.Name = "MoneyMaker";
        AIMoneyMaker.Piece = 2;
        AIMoneyMaker.HittedPiece = 0;
        AIMoneyMaker.FirstPieceI = 0;
        AIMoneyMaker.FirstPieceJ = 1;
        AIMoneyMaker.SecondPieceI = 0;
        AIMoneyMaker.SecondPieceJ = 2;
        AIMoneyMaker.PassiveAttribute = "";
        AIMoneyMaker.ActiveAttribute = "";
        AIMoneyMaker.ActiveAttributeCost = 2;

        AIHealer.Name = "Healer";
        AIHealer.Piece = 4;
        AIHealer.HittedPiece = 0;
        AIHealer.FirstPieceI = 7;
        AIHealer.FirstPieceJ = 5;
        AIHealer.SecondPieceI = 8;
        AIHealer.SecondPieceJ = 5;
        AIHealer.ThirdPieceI = 9;
        AIHealer.ThirdPieceJ = 5;
        AIHealer.FourthPieceI = 9;
        AIHealer.FourthPieceJ = 6;
        AIHealer.PassiveAttribute = "";
        AIHealer.ActiveAttribute = "";
        AIHealer.ActiveAttributeCost = 4;

        AILightBomber.Name = "LightBomber";
        AILightBomber.Piece = 4;
        AILightBomber.HittedPiece = 0;
        AILightBomber.FirstPieceI = 8;
        AILightBomber.FirstPieceJ = 6;
        AILightBomber.SecondPieceI = 8;
        AILightBomber.SecondPieceJ = 7;
        AILightBomber.ThirdPieceI = 9;
        AILightBomber.ThirdPieceJ = 7;
        AILightBomber.FourthPieceI = 9;
        AILightBomber.FourthPieceJ = 8;
        AILightBomber.PassiveAttribute = "";
        AILightBomber.ActiveAttribute = "";
        AILightBomber.ActiveAttributeCost = 4;

        AIBoomer.Name = "Boomer";
        AIBoomer.Piece = 6;
        AIBoomer.HittedPiece = 0;
        AIBoomer.FirstPieceI = 2;
        AIBoomer.FirstPieceJ = 9;
        AIBoomer.SecondPieceI = 3;
        AIBoomer.SecondPieceJ = 9;
        AIBoomer.ThirdPieceI = 4;
        AIBoomer.ThirdPieceJ = 9;
        AIBoomer.FourthPieceI = 5;
        AIBoomer.FourthPieceJ = 9;
        AIBoomer.FifthPieceI = 6;
        AIBoomer.FifthPieceJ = 9;
        AIBoomer.SixthPieceI = 7;
        AIBoomer.SixthPieceJ = 9;
        AIBoomer.PassiveAttribute = "";
        AIBoomer.ActiveAttribute = "";
        AIBoomer.ActiveAttributeCost = 6;

        AIFlameThrower.Name = "FlameThrower";
        AIFlameThrower.Piece = 7;
        AIFlameThrower.HittedPiece = 0;
        AIFlameThrower.FirstPieceI = 4;
        AIFlameThrower.FirstPieceJ = 1;
        AIFlameThrower.SecondPieceI = 4;
        AIFlameThrower.SecondPieceJ = 2;
        AIFlameThrower.ThirdPieceI = 4;
        AIFlameThrower.ThirdPieceJ = 3;
        AIFlameThrower.FourthPieceI = 5;
        AIFlameThrower.FourthPieceJ = 1;
        AIFlameThrower.FifthPieceI = 6;
        AIFlameThrower.FifthPieceJ = 1;
        AIFlameThrower.SixthPieceI = 6;
        AIFlameThrower.SixthPieceJ = 2;
        AIFlameThrower.SeventhPieceI = 6;
        AIFlameThrower.SeventhPieceJ = 3;
        AIFlameThrower.PassiveAttribute = "";
        AIFlameThrower.ActiveAttribute = "";
        AIFlameThrower.ActiveAttributeCost = 7;
    }
}
