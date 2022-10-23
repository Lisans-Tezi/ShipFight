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

    private void Awake()
    {
        AIMoneyMaker.Name = "MoneyMaker";
        AIMoneyMaker.Piece = 2;
        AIMoneyMaker.HittedPiece = 0;
        AIMoneyMaker.FirstPieceI = -1;
        AIMoneyMaker.FirstPieceJ = -1;
        AIMoneyMaker.SecondPieceI = -1;
        AIMoneyMaker.SecondPieceJ = -1;
        AIMoneyMaker.PassiveAttribute = "";
        AIMoneyMaker.ActiveAttribute = "";
        AIMoneyMaker.ActiveAttributeCost = 10;

        AITank.Name = "Tank";
        AITank.Piece = 3;
        AITank.HittedPiece = 0;
        AITank.FirstPieceI = -1;
        AITank.FirstPieceJ = -1;
        AITank.SecondPieceI = -1;
        AITank.SecondPieceJ = -1;
        AITank.ThirdPieceI = -1;
        AITank.ThirdPieceJ = -1;
        AITank.PassiveAttribute = "";
        AITank.ActiveAttribute = "";
        AITank.ActiveAttributeCost = 10;

        AISideStep.Name = "SideStep";
        AISideStep.Piece = 3;
        AISideStep.HittedPiece = 0;
        AISideStep.FirstPieceI = -1;
        AISideStep.FirstPieceJ = -1;
        AISideStep.SecondPieceI = -1;
        AISideStep.SecondPieceJ = -1;
        AISideStep.ThirdPieceI = -1;
        AISideStep.ThirdPieceJ = -1;
        AISideStep.PassiveAttribute = "";
        AISideStep.ActiveAttribute = "";
        AISideStep.ActiveAttributeCost = 10;

        AIFaker.Name = "Faker";
        AIFaker.Piece = 4;
        AIFaker.HittedPiece = 0;
        AIFaker.FirstPieceI = -1;
        AIFaker.FirstPieceJ = -1;
        AIFaker.SecondPieceI = -1;
        AIFaker.SecondPieceJ = -1;
        AIFaker.ThirdPieceI = -1;
        AIFaker.ThirdPieceJ = -1;
        AIFaker.FourthPieceI = -1;
        AIFaker.FourthPieceJ = -1;
        AIFaker.PassiveAttribute = "";
        AIFaker.ActiveAttribute = "";
        AIFaker.ActiveAttributeCost = 10;

        AIHealer.Name = "Healer";
        AIHealer.Piece = 4;
        AIHealer.HittedPiece = 0;
        AIHealer.FirstPieceI = -1;
        AIHealer.FirstPieceJ = -1;
        AIHealer.SecondPieceI = -1;
        AIHealer.SecondPieceJ = -1;
        AIHealer.ThirdPieceI = -1;
        AIHealer.ThirdPieceJ = -1;
        AIHealer.FourthPieceI = -1;
        AIHealer.FourthPieceJ = -1;
        AIHealer.PassiveAttribute = "";
        AIHealer.ActiveAttribute = "";
        AIHealer.ActiveAttributeCost = 10;

        AILightBomber.Name = "LightBomber";
        AILightBomber.Piece = 4;
        AILightBomber.HittedPiece = 0;
        AILightBomber.FirstPieceI = -1;
        AILightBomber.FirstPieceJ = -1;
        AILightBomber.SecondPieceI = -1;
        AILightBomber.SecondPieceJ = -1;
        AILightBomber.ThirdPieceI = -1;
        AILightBomber.ThirdPieceJ = -1;
        AILightBomber.FourthPieceI = -1;
        AILightBomber.FourthPieceJ = -1;
        AILightBomber.PassiveAttribute = "";
        AILightBomber.ActiveAttribute = "";
        AILightBomber.ActiveAttributeCost = 10;

        AIBombCatcher.Name = "BombCatcher";
        AIBombCatcher.Piece = 5;
        AIBombCatcher.HittedPiece = 0;
        AIBombCatcher.FirstPieceI = -1;
        AIBombCatcher.FirstPieceJ = -1;
        AIBombCatcher.SecondPieceI = -1;
        AIBombCatcher.SecondPieceJ = -1;
        AIBombCatcher.ThirdPieceI = -1;
        AIBombCatcher.ThirdPieceJ = -1;
        AIBombCatcher.FourthPieceI = -1;
        AIBombCatcher.FourthPieceJ = -1;
        AIBombCatcher.FifthPieceI = -1;
        AIBombCatcher.FifthPieceJ = -1;
        AIBombCatcher.PassiveAttribute = "";
        AIBombCatcher.ActiveAttribute = "";
        AIBombCatcher.ActiveAttributeCost = 10;

        AIBomber.Name = "Bomber";
        AIBomber.Piece = 5;
        AIBomber.HittedPiece = 0;
        AIBomber.FirstPieceI = -1;
        AIBomber.FirstPieceJ = -1;
        AIBomber.SecondPieceI = -1;
        AIBomber.SecondPieceJ = -1;
        AIBomber.ThirdPieceI = -1;
        AIBomber.ThirdPieceJ = -1;
        AIBomber.FourthPieceI = -1;
        AIBomber.FourthPieceJ = -1;
        AIBomber.FifthPieceI = -1;
        AIBomber.FifthPieceJ = -1;
        AIBomber.PassiveAttribute = "";
        AIBomber.ActiveAttribute = "";
        AIBomber.ActiveAttributeCost = 10;

        AIBoomer.Name = "Boomer";
        AIBoomer.Piece = 6;
        AIBoomer.HittedPiece = 0;
        AIBoomer.FirstPieceI = -1;
        AIBoomer.FirstPieceJ = -1;
        AIBoomer.SecondPieceI = -1;
        AIBoomer.SecondPieceJ = -1;
        AIBoomer.ThirdPieceI = -1;
        AIBoomer.ThirdPieceJ = -1;
        AIBoomer.FourthPieceI = -1;
        AIBoomer.FourthPieceJ = -1;
        AIBoomer.FifthPieceI = -1;
        AIBoomer.FifthPieceJ = -1;
        AIBoomer.SixthPieceI = -1;
        AIBoomer.SixthPieceJ = -1;
        AIBoomer.PassiveAttribute = "";
        AIBoomer.ActiveAttribute = "";
        AIBoomer.ActiveAttributeCost = 10;

        AIFlameThrower.Name = "FlameThrower";
        AIFlameThrower.Piece = 7;
        AIFlameThrower.HittedPiece = 0;
        AIFlameThrower.FirstPieceI = -1;
        AIFlameThrower.FirstPieceJ = -1;
        AIFlameThrower.SecondPieceI = -1;
        AIFlameThrower.SecondPieceJ = -1;
        AIFlameThrower.ThirdPieceI = -1;
        AIFlameThrower.ThirdPieceJ = -1;
        AIFlameThrower.FourthPieceI = -1;
        AIFlameThrower.FourthPieceJ = -1;
        AIFlameThrower.FifthPieceI = -1;
        AIFlameThrower.FifthPieceJ = -1;
        AIFlameThrower.SixthPieceI = -1;
        AIFlameThrower.SixthPieceJ = -1;
        AIFlameThrower.SeventhPieceI = -1;
        AIFlameThrower.SeventhPieceJ = -1;
        AIFlameThrower.PassiveAttribute = "";
        AIFlameThrower.ActiveAttribute = "";
        AIFlameThrower.ActiveAttributeCost = 10;          
    }

    private void Start()
    {
        int rnd = Random.Range(0, 4);

        if (rnd == 0)
            AIFirst();
        else if (rnd == 1)
            AISecond();
        else if (rnd == 2)
            AIThird();
        else if(rnd == 3)
            AIFourth();
    }
    void AIFirst()
    {
        AIMoneyMaker.FirstPieceI = 3;
        AIMoneyMaker.FirstPieceJ = 7;
        AIMoneyMaker.SecondPieceI = 4;
        AIMoneyMaker.SecondPieceJ = 7;

        AITank.FirstPieceI = 3;
        AITank.FirstPieceJ = 2;
        AITank.SecondPieceI = 3;
        AITank.SecondPieceJ = 3;
        AITank.ThirdPieceI = 3;
        AITank.ThirdPieceJ = 4;

        AIFaker.FirstPieceI = 0;
        AIFaker.FirstPieceJ = 0;
        AIFaker.SecondPieceI = 1;
        AIFaker.SecondPieceJ = 0;
        AIFaker.ThirdPieceI = 2;
        AIFaker.ThirdPieceJ = 0;
        AIFaker.FourthPieceI = 3;
        AIFaker.FourthPieceJ = 0;

        AILightBomber.FirstPieceI = 9;
        AILightBomber.FirstPieceJ = 7;
        AILightBomber.SecondPieceI = 8;
        AILightBomber.SecondPieceJ = 8;
        AILightBomber.ThirdPieceI = 9;
        AILightBomber.ThirdPieceJ = 8;
        AILightBomber.FourthPieceI = 8;
        AILightBomber.FourthPieceJ = 9;

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
    }
    void AISecond()
    {
        AIMoneyMaker.FirstPieceI = 0;
        AIMoneyMaker.FirstPieceJ = 1;
        AIMoneyMaker.SecondPieceI = 0;
        AIMoneyMaker.SecondPieceJ = 2;

        AIHealer.FirstPieceI = 7;
        AIHealer.FirstPieceJ = 5;
        AIHealer.SecondPieceI = 8;
        AIHealer.SecondPieceJ = 5;
        AIHealer.ThirdPieceI = 9;
        AIHealer.ThirdPieceJ = 5;
        AIHealer.FourthPieceI = 9;
        AIHealer.FourthPieceJ = 6;

        AILightBomber.FirstPieceI = 8;
        AILightBomber.FirstPieceJ = 6;
        AILightBomber.SecondPieceI = 8;
        AILightBomber.SecondPieceJ = 7;
        AILightBomber.ThirdPieceI = 9;
        AILightBomber.ThirdPieceJ = 7;
        AILightBomber.FourthPieceI = 9;
        AILightBomber.FourthPieceJ = 8;

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
    }  
    void AIThird()
    {
        AISideStep.FirstPieceI = 1;
        AISideStep.FirstPieceJ = 1;
        AISideStep.SecondPieceI = 2;
        AISideStep.SecondPieceJ = 1;
        AISideStep.ThirdPieceI = 2;
        AISideStep.ThirdPieceJ = 2;

        AIHealer.FirstPieceI = 5;
        AIHealer.FirstPieceJ = 0;
        AIHealer.SecondPieceI = 6;
        AIHealer.SecondPieceJ = 0;
        AIHealer.ThirdPieceI = 7;
        AIHealer.ThirdPieceJ = 0;
        AIHealer.FourthPieceI = 7;
        AIHealer.FourthPieceJ = 1;

        AILightBomber.FirstPieceI = 4;
        AILightBomber.FirstPieceJ = 9;
        AILightBomber.SecondPieceI = 5;
        AILightBomber.SecondPieceJ = 9;
        AILightBomber.ThirdPieceI = 5;
        AILightBomber.ThirdPieceJ = 8;
        AILightBomber.FourthPieceI = 6;
        AILightBomber.FourthPieceJ = 8;

        AIBomber.FirstPieceI = 1;
        AIBomber.FirstPieceJ = 5;
        AIBomber.SecondPieceI = 1;
        AIBomber.SecondPieceJ = 6;
        AIBomber.ThirdPieceI = 1;
        AIBomber.ThirdPieceJ = 7;
        AIBomber.FourthPieceI = 2;
        AIBomber.FourthPieceJ = 6;
        AIBomber.FifthPieceI = 3;
        AIBomber.FifthPieceJ = 6;

        AIFlameThrower.FirstPieceI = 7;
        AIFlameThrower.FirstPieceJ = 3;
        AIFlameThrower.SecondPieceI = 8;
        AIFlameThrower.SecondPieceJ = 3;
        AIFlameThrower.ThirdPieceI = 9;
        AIFlameThrower.ThirdPieceJ = 3;
        AIFlameThrower.FourthPieceI = 9;
        AIFlameThrower.FourthPieceJ = 4;
        AIFlameThrower.FifthPieceI = 9;
        AIFlameThrower.FifthPieceJ = 5;
        AIFlameThrower.SixthPieceI = 8;
        AIFlameThrower.SixthPieceJ = 5;
        AIFlameThrower.SeventhPieceI = 7;
        AIFlameThrower.SeventhPieceJ = 5;
    }
    void AIFourth()
    {
        AISideStep.FirstPieceI = 1;
        AISideStep.FirstPieceJ = 8;
        AISideStep.SecondPieceI = 2;
        AISideStep.SecondPieceJ = 7;
        AISideStep.ThirdPieceI = 2;
        AISideStep.ThirdPieceJ = 8;

        AIHealer.FirstPieceI = 6;
        AIHealer.FirstPieceJ = 6;
        AIHealer.SecondPieceI = 6;
        AIHealer.SecondPieceJ = 7;
        AIHealer.ThirdPieceI = 6;
        AIHealer.ThirdPieceJ = 8;
        AIHealer.FourthPieceI = 7;
        AIHealer.FourthPieceJ = 8;

        AIBomber.FirstPieceI = 2;
        AIBomber.FirstPieceJ = 3;
        AIBomber.SecondPieceI = 2;
        AIBomber.SecondPieceJ = 4;
        AIBomber.ThirdPieceI = 2;
        AIBomber.ThirdPieceJ = 5;
        AIBomber.FourthPieceI = 3;
        AIBomber.FourthPieceJ = 4;
        AIBomber.FifthPieceI = 4;
        AIBomber.FifthPieceJ = 4;

        AIBoomer.FirstPieceI = 3;
        AIBoomer.FirstPieceJ = 2;
        AIBoomer.SecondPieceI = 4;
        AIBoomer.SecondPieceJ = 2;
        AIBoomer.ThirdPieceI = 5;
        AIBoomer.ThirdPieceJ = 2;
        AIBoomer.FourthPieceI = 6;
        AIBoomer.FourthPieceJ = 2;
        AIBoomer.FifthPieceI = 7;
        AIBoomer.FifthPieceJ = 2;
        AIBoomer.SixthPieceI = 8;
        AIBoomer.SixthPieceJ = 2;

        AIFlameThrower.FirstPieceI = 7;
        AIFlameThrower.FirstPieceJ = 4;
        AIFlameThrower.SecondPieceI = 7;
        AIFlameThrower.SecondPieceJ = 5;
        AIFlameThrower.ThirdPieceI = 7;
        AIFlameThrower.ThirdPieceJ = 6;
        AIFlameThrower.FourthPieceI = 8;
        AIFlameThrower.FourthPieceJ = 6;
        AIFlameThrower.FifthPieceI = 9;
        AIFlameThrower.FifthPieceJ = 4;
        AIFlameThrower.SixthPieceI = 9;
        AIFlameThrower.SixthPieceJ = 5;
        AIFlameThrower.SeventhPieceI = 9;
        AIFlameThrower.SeventhPieceJ = 6;
    }
}
