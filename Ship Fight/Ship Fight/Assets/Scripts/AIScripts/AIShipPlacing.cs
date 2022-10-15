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
        //int rnd = Random.Range(0, 2);

        //switch (rnd)
        //{
        //    case 0:
        //        AIFirst();
        //        break;
        //    case 1:
        //        AISecond();
        //        break;
        //}
        AIFirst();
    }

    void AIFirst()
    {
        AIMoneyMaker.Name = "MoneyMaker";
        AIMoneyMaker.Piece = 2;
        AIMoneyMaker.HittedPiece = 0;
        AIMoneyMaker.FirstPieceI = 7;
        AIMoneyMaker.FirstPieceJ = 3;
        AIMoneyMaker.SecondPieceI = 7;
        AIMoneyMaker.SecondPieceJ = 4;
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

        Healer h;
        h = GameObject.Find("Healer").GetComponent<Healer>();
        h.Name = "Healer";
        h.Piece = 4;
        h.HittedPiece = 0;
        h.FirstPieceI = 7;
        h.FirstPieceJ = 5;
        h.SecondPieceI = 8;
        h.SecondPieceJ = 5;
        h.ThirdPieceI = 9;
        h.ThirdPieceJ = 5;
        h.FourthPieceI = 9;
        h.FourthPieceJ = 6;
        h.PassiveAttribute = "";
        h.ActiveAttribute = "";
        h.ActiveAttributeCost = 4;

        LightBomber lb;
        lb = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        lb.Name = "LightBomber";
        lb.Piece = 4;
        lb.HittedPiece = 0;
        lb.FirstPieceI = 8;
        lb.FirstPieceJ = 6;
        lb.SecondPieceI = 8;
        lb.SecondPieceJ = 7;
        lb.ThirdPieceI = 9;
        lb.ThirdPieceJ = 7;
        lb.FourthPieceI = 9;
        lb.FourthPieceJ = 8;
        lb.PassiveAttribute = "";
        lb.ActiveAttribute = "";
        lb.ActiveAttributeCost = 4;

        Boomer b;
        b = GameObject.Find("Boomer").GetComponent<Boomer>();
        b.Name = "Boomer";
        b.Piece = 6;
        b.HittedPiece = 0;
        b.FirstPieceI = 2;
        b.FirstPieceJ = 9;
        b.SecondPieceI = 3;
        b.SecondPieceJ = 9;
        b.ThirdPieceI = 4;
        b.ThirdPieceJ = 9;
        b.FourthPieceI = 5;
        b.FourthPieceJ = 9;
        b.FifthPieceI = 6;
        b.FifthPieceJ = 9;
        b.SixthPieceI = 7;
        b.SixthPieceJ = 9;
        b.PassiveAttribute = "";
        b.ActiveAttribute = "";
        b.ActiveAttributeCost = 6;

        FlameThrower ft;
        ft = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();
        ft.Name = "FlameThrower";
        ft.Piece = 7;
        ft.HittedPiece = 0;
        ft.FirstPieceI = 4;
        ft.FirstPieceJ = 1;
        ft.SecondPieceI = 4;
        ft.SecondPieceJ = 2;
        ft.ThirdPieceI = 4;
        ft.ThirdPieceJ = 3;
        ft.FourthPieceI = 5;
        ft.FourthPieceJ = 1;
        ft.FifthPieceI = 6;
        ft.FifthPieceJ = 1;
        ft.SixthPieceI = 6;
        ft.SixthPieceJ = 2;
        ft.SeventhPieceI = 6;
        ft.SeventhPieceJ = 3;
        ft.PassiveAttribute = "";
        ft.ActiveAttribute = "";
        ft.ActiveAttributeCost = 7;
    }
}
