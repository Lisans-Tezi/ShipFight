using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class AIShipPlacing : MonoBehaviour
{
    public bool AISideStepSkill = true;
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

    void Start()
    {
        int rnd = Random.Range(0, 1);
        if (PlayerPrefs.GetString("Map")=="Map1")
        {
            if (rnd == 0)
                AIFirstMap1();
            else if (rnd == 1)
                AISecondMap1();
            else if (rnd == 2)
                AIThirdMap1();
            else if (rnd == 3)
                AIFourthMap1();
        }
        else if (PlayerPrefs.GetString("Map") == "Map2")
        {
            if (rnd == 0)
                AIFirstMap2();
            else if (rnd == 1)
                AISecondMap2();
            else if (rnd == 2)
                AIThirdMap2();
            else if (rnd == 3)
                AIFourthMap2();
        }
        else if (PlayerPrefs.GetString("Map") == "Map3")
        {
            if (rnd == 0)
                AIFirstMap3();
            else if (rnd == 1)
                AISecondMap3();
            else if (rnd == 2)
                AIThirdMap3();
            else if (rnd == 3)
                AIFourthMap3();
        }
        else if (PlayerPrefs.GetString("Map") == "Map4")
        {
            if (rnd == 0)
                AIFirstMap4();
            else if (rnd == 1)
                AISecondMap4();
            else if (rnd == 2)
                AIThirdMap4();
            else if (rnd == 3)
                AIFourthMap4();
        }
        else
        {
            if (rnd == 0)
                AIFirstMap0();
            else if (rnd == 1)
                AISecondMap0();
            else if (rnd == 2)
                AIThirdMap0();
            else if (rnd == 3)
                AIFourthMap0();
        }              
    }
    void AIFirstMap0()
    {
        MoneyMaker(3,7,4,7);
        Tank(3,2,3,3,3,4);
        Faker(0,0,1,0,2,0,3,0);
        LightBomber(9,7,8,8,9,8,8,9);
        Bomber(6,1,7,1,7,2,7,3,8,1);
    }
    void AISecondMap0()
    {
        MoneyMaker(0, 1, 0, 2);
        Healer(7,5,8,5,9,5,9,6);
        LightBomber(8, 6, 8, 7, 9, 7, 9, 8);
        Boomer(2,9,3,9,4,9,5,9,6,9,7,9);
        FlameThrower(4,1,4,2,4,3,5,1,6,1,6,2,6,3);
    }  
    void AIThirdMap0()
    {
        SideStep(1,1,2,1,2,2);
        Healer(5, 0, 6, 0, 7, 0, 7, 1);
        LightBomber(4, 9, 5, 9, 4, 8, 6, 8);
        Bomber(1, 5, 1, 6, 1, 7, 2, 6, 3, 6);
        FlameThrower(7, 3, 8, 3, 9, 3, 9, 4, 9, 5, 8, 5, 7, 5);
    }
    void AIFourthMap0()
    {
        SideStep(1, 8, 2, 7, 2, 8);
        Healer(6, 6, 6, 7, 6, 8, 7, 8);
        Bomber(2, 3, 2, 4, 2, 5, 3, 4, 4, 4);
        Boomer(3, 2, 4, 2, 5, 2, 6, 2, 7, 2, 8, 2);
        FlameThrower(7, 4, 7, 5, 7, 6, 8, 6, 9, 4, 9, 5, 9, 6);
    }

    void AIFirstMap1()
    {
        Tank(9, 1, 9, 2, 9, 3);
        SideStep(0, 8, 1, 8, 1, 9);
        LightBomber(7, 7, 8, 7, 8, 8, 9, 8);
        Faker(1, 1, 1, 2, 1, 3, 1, 4);
        FlameThrower(4, 7, 5, 7, 6, 7, 6, 8, 6, 9, 5, 9, 4, 9);
    }
    void AISecondMap1() 
    {
        MoneyMaker(7, 4, 7, 5);
        SideStep(2, 2, 2, 3, 3, 2);
        Healer(5, 2, 6, 2, 7, 2, 7, 3);
        Bomber(5, 7, 6, 7, 8, 7, 8, 6, 8, 9);
        FlameThrower(0, 7, 1, 7, 2, 7, 0, 8, 0, 9, 1, 9, 2, 9);
    }
    void AIThirdMap1()
    {
        MoneyMaker(8, 2, 8, 3);
        Tank(7, 9, 8, 9, 9, 9);
        Faker(0, 9, 1, 9, 2, 9, 3, 9);
        BombCatcher(0, 0, 0, 1, 0, 2, 0, 3, 0, 4);
        Boomer(3, 7, 4, 7, 5, 7, 6, 7, 7, 7, 8, 7);
    }
    void AIFourthMap1()
    {
        MoneyMaker(2, 1, 3, 1);
        SideStep(8, 7, 9, 7, 9, 8);
        Faker(0, 3, 0, 4, 0, 5, 0, 6);
        BombCatcher(0, 9, 1, 9, 2, 9, 3, 9, 4, 9);
        FlameThrower(0, 7, 0, 8, 0, 9, 1, 9, 2, 9, 2, 8, 2, 7);
    }
    
    void AIFirstMap2()
    {
        SideStep(7, 4, 8, 4, 8, 5);
        Healer(7, 8, 8, 8, 9, 8, 9, 9);
        LightBomber(1, 7, 2, 7, 2, 6, 3, 6);
        Bomber(6, 0, 6, 1, 6, 2, 7, 1, 8, 1);
        FlameThrower(3, 1, 3, 2, 3, 3, 4, 1, 5, 1, 5, 2, 5, 3);
    }
    void AISecondMap2()
    {
        MoneyMaker(5, 4, 5, 5);
        SideStep(2, 3, 3, 3, 3, 4);
        LightBomber(8, 4, 8, 5, 7, 5, 7, 6);
        BombCatcher(2, 8, 3, 8, 4, 8, 5, 8, 6, 8);
        Boomer(2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1);
    }
    void AIThirdMap2()
    {
        Tank(7, 4, 7, 5, 7, 6);
        SideStep(8, 0, 8, 1, 7, 1);
        Healer(1, 1, 2, 1, 3, 1, 3, 2);
        Faker(6, 6, 6, 7, 6, 8, 6, 9);
        FlameThrower(2, 7, 2, 8, 2, 9, 3, 9, 4, 9, 4, 8, 4, 7);
    }
    void AIFourthMap2()
    {
        MoneyMaker(5, 1, 5, 2);
        SideStep(1, 2, 2, 3, 2, 2);
        LightBomber(2, 6, 2, 7, 1, 7, 1, 8);
        BombCatcher(2, 9, 3, 9, 4, 9, 5, 9, 6, 9);
        FlameThrower(4, 4, 4, 5, 4, 6, 5, 4, 6, 4, 6, 5, 6, 6);
    }

    void AIFirstMap3()
    {
        MoneyMaker(0, 8, 1, 8);
        Healer(2, 4, 3, 4, 4, 4, 4, 5);
        LightBomber(2, 3, 3, 3, 3, 2, 4, 2);
        Bomber(5, 8, 6, 8, 7, 8, 7, 7, 7, 9);
        Boomer(9, 0, 9, 1, 9, 2, 9, 3, 9, 4, 9, 5);
    }
    void AISecondMap3()
    {
        MoneyMaker(2, 1, 2, 2);
        Faker(3, 4, 4, 4, 5, 4, 6, 4);
        BombCatcher(9, 0, 9, 1, 9, 2, 9, 3, 9, 4);
        Boomer(0, 4, 0, 5, 0, 6, 0, 7, 0, 8, 0, 9);
        FlameThrower(5, 6, 6, 6, 7, 6, 7, 7, 7, 8, 6, 8, 5, 8);
    }
    void AIThirdMap3()
    {
        SideStep(8,0,9,0,9,1);
        Tank(4,5,4,6,4,7);
        Faker(0,5,1,5,2,5,3,5);
        LightBomber(1,3,2,3,2,2,3,2);
        Bomber(7,4,8,4,9,4,9,3,9,5);
    }
    void AIFourthMap3()
    {
        MoneyMaker(2,0,3,0);
        Tank(9,2,9,3,9,4);
        SideStep(3,5,4,5,4,6);
        LightBomber(6,9,7,9,7,8,8,8);
        BombCatcher(0,3,0,4,0,5,0,6,0,7);
    }

    void AIFirstMap4()
    {
        MoneyMaker(8,5,9,5);
        SideStep(0,3,1,3,1,4);
        Tank(4,0,4,1,4,2);
        BombCatcher(1,7,2,7,3,7,4,7,5,7);
        Bomber(4,8,5,8,6,8,6,7,6,9);
    }
    void AISecondMap4()
    {
        MoneyMaker(2,5,2,6);
        SideStep(2,2,3,2,2,3);
        Healer(5,7,6,7,7,7,7,6);
        Faker(0,3,0,4,0,5,0,6);
        Bomber(5,2,6,2,7,2,7,1,7,3);
    }
    void AIThirdMap4()
    {
        MoneyMaker(2,1,3,1);
        Tank(5,1,6,1,7,1);
        Faker(3,9,4,9,5,9,6,9);
        Boomer(1,2,1,3,1,4,1,5,1,6,1,7);
        FlameThrower(7,4,7,5,7,6,8,4,9,4,9,5,9,6);
    }
    void AIFourthMap4()
    {
        Tank(7,3,8,3,9,3);
        Healer(7,5,8,5,9,5,9,6);
        Faker(2,2,3,2,4,2,5,2);
        Boomer(2,8,3,8,4,8,5,8,6,8,7,8);
        FlameThrower(0,4,1,4,2,4,0,5,0,6,1,6,2,6);
    }

    void MoneyMaker(int i0,int j0, int i1, int j1)
    {
        AIMoneyMaker.FirstPieceI = i0;
        AIMoneyMaker.FirstPieceJ = j0;
        AIMoneyMaker.SecondPieceI = i1;
        AIMoneyMaker.SecondPieceJ = j1;
    }
    void Tank(int i0, int j0, int i1, int j1, int i2, int j2)
    {
        AITank.FirstPieceI = i0;
        AITank.FirstPieceJ = j0;
        AITank.SecondPieceI = i1;
        AITank.SecondPieceJ = j1;
        AITank.ThirdPieceI = i2;
        AITank.ThirdPieceJ = j2;
    }
    void SideStep(int i0, int j0, int i1, int j1, int i2, int j2)
    {
        AISideStep.FirstPieceI = i0;
        AISideStep.FirstPieceJ = j0;
        AISideStep.SecondPieceI = i1;
        AISideStep.SecondPieceJ = j1;
        AISideStep.ThirdPieceI = i2;
        AISideStep.ThirdPieceJ = j2;
    }
    void Faker(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3)
    {
        AIFaker.FirstPieceI = i0;
        AIFaker.FirstPieceJ = j0;
        AIFaker.SecondPieceI = i1;
        AIFaker.SecondPieceJ = j1;
        AIFaker.ThirdPieceI = i2;
        AIFaker.ThirdPieceJ = j2;
        AIFaker.FourthPieceI = i3;
        AIFaker.FourthPieceJ = j3;
    }
    void Healer(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3)
    {
        AIHealer.FirstPieceI = i0;
        AIHealer.FirstPieceJ = j0;
        AIHealer.SecondPieceI = i1;
        AIHealer.SecondPieceJ = j1;
        AIHealer.ThirdPieceI = i2;
        AIHealer.ThirdPieceJ = j2;
        AIHealer.FourthPieceI = i3;
        AIHealer.FourthPieceJ = j3;
    }
    void LightBomber(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3)
    {
        AILightBomber.FirstPieceI = i0;
        AILightBomber.FirstPieceJ = j0;
        AILightBomber.SecondPieceI = i1;
        AILightBomber.SecondPieceJ = j1;
        AILightBomber.ThirdPieceI = i2;
        AILightBomber.ThirdPieceJ = j2;
        AILightBomber.FourthPieceI = i3;
        AILightBomber.FourthPieceJ = j3;
    }
    void BombCatcher(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4)
    {
        AIBombCatcher.FirstPieceI = i0;
        AIBombCatcher.FirstPieceJ = j0;
        AIBombCatcher.SecondPieceI = i1;
        AIBombCatcher.SecondPieceJ = j1;
        AIBombCatcher.ThirdPieceI = i2;
        AIBombCatcher.ThirdPieceJ = j2;
        AIBombCatcher.FourthPieceI = i3;
        AIBombCatcher.FourthPieceJ = j3;
        AIBombCatcher.FifthPieceI = i4;
        AIBombCatcher.FifthPieceJ = j4;
    }
    void Bomber(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4)
    {
        AIBomber.FirstPieceI = i0;
        AIBomber.FirstPieceJ = j0;
        AIBomber.SecondPieceI = i1;
        AIBomber.SecondPieceJ = j1;
        AIBomber.ThirdPieceI = i2;
        AIBomber.ThirdPieceJ = j2;
        AIBomber.FourthPieceI = i3;
        AIBomber.FourthPieceJ = j3;
        AIBomber.FifthPieceI = i4;
        AIBomber.FifthPieceJ = j4;
    }
    void Boomer(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4, int i5, int j5) 
    {
        AIBoomer.FirstPieceI = i0;
        AIBoomer.FirstPieceJ = j0;
        AIBoomer.SecondPieceI = i1;
        AIBoomer.SecondPieceJ = j1;
        AIBoomer.ThirdPieceI = i2;
        AIBoomer.ThirdPieceJ = j2;
        AIBoomer.FourthPieceI = i3;
        AIBoomer.FourthPieceJ = j3;
        AIBoomer.FifthPieceI = i4;
        AIBoomer.FifthPieceJ = j4;
        AIBoomer.SixthPieceI = i5;
        AIBoomer.SixthPieceJ = j5;
    }
    void FlameThrower(int i0, int j0, int i1, int j1, int i2, int j2, int i3, int j3, int i4, int j4, int i5, int j5, int i6, int j6)
    {
        AIFlameThrower.FirstPieceI = i0;
        AIFlameThrower.FirstPieceJ = j0;
        AIFlameThrower.SecondPieceI = i1;
        AIFlameThrower.SecondPieceJ = j1;
        AIFlameThrower.ThirdPieceI = i2;
        AIFlameThrower.ThirdPieceJ = j2;
        AIFlameThrower.FourthPieceI = i3;
        AIFlameThrower.FourthPieceJ = j3;
        AIFlameThrower.FifthPieceI = i4;
        AIFlameThrower.FifthPieceJ = j4;
        AIFlameThrower.SixthPieceI = i5;
        AIFlameThrower.SixthPieceJ = j5;
        AIFlameThrower.SeventhPieceI = i6;
        AIFlameThrower.SeventhPieceJ = j6;
    }
}
