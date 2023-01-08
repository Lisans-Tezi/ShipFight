using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
        AIMoneyMaker.FirstPieceI = -10;
        AIMoneyMaker.FirstPieceJ = -10;
        AIMoneyMaker.SecondPieceI = -10;
        AIMoneyMaker.SecondPieceJ = -10;
        AIMoneyMaker.PassiveAttribute = "";
        AIMoneyMaker.ActiveAttribute = "";
        AIMoneyMaker.ActiveAttributeCost = 10;

        AITank.Name = "Tank";
        AITank.Piece = 3;
        AITank.HittedPiece = 0;
        AITank.FirstPieceI = -10;
        AITank.FirstPieceJ = -10;
        AITank.SecondPieceI = -10;
        AITank.SecondPieceJ = -10;
        AITank.ThirdPieceI = -10;
        AITank.ThirdPieceJ = -10;
        AITank.PassiveAttribute = "";
        AITank.ActiveAttribute = "";
        AITank.ActiveAttributeCost = 10;

        AISideStep.Name = "SideStep";
        AISideStep.Piece = 3;
        AISideStep.HittedPiece = 0;
        AISideStep.FirstPieceI = -10;
        AISideStep.FirstPieceJ = -10;
        AISideStep.SecondPieceI = -10;
        AISideStep.SecondPieceJ = -10;
        AISideStep.ThirdPieceI = -10;
        AISideStep.ThirdPieceJ = -10;
        AISideStep.PassiveAttribute = "";
        AISideStep.ActiveAttribute = "";
        AISideStep.ActiveAttributeCost = 10;
        AISideStep.SideStepSkill = true;

        AIFaker.Name = "Faker";
        AIFaker.Piece = 4;
        AIFaker.HittedPiece = 0;
        AIFaker.FirstPieceI = -10;
        AIFaker.FirstPieceJ = -10;
        AIFaker.SecondPieceI = -10;
        AIFaker.SecondPieceJ = -10;
        AIFaker.ThirdPieceI = -10;
        AIFaker.ThirdPieceJ = -10;
        AIFaker.FourthPieceI = -10;
        AIFaker.FourthPieceJ = -10;
        AIFaker.PassiveAttribute = "";
        AIFaker.ActiveAttribute = "";
        AIFaker.ActiveAttributeCost = 10;

        AIHealer.Name = "Healer";
        AIHealer.Piece = 4;
        AIHealer.HittedPiece = 0;
        AIHealer.FirstPieceI = -10;
        AIHealer.FirstPieceJ = -10;
        AIHealer.SecondPieceI = -10;
        AIHealer.SecondPieceJ = -10;
        AIHealer.ThirdPieceI = -10;
        AIHealer.ThirdPieceJ = -10;
        AIHealer.FourthPieceI = -10;
        AIHealer.FourthPieceJ = -10;
        AIHealer.PassiveAttribute = "";
        AIHealer.ActiveAttribute = "";
        AIHealer.ActiveAttributeCost = 10;

        AILightBomber.Name = "LightBomber";
        AILightBomber.Piece = 4;
        AILightBomber.HittedPiece = 0;
        AILightBomber.FirstPieceI = -10;
        AILightBomber.FirstPieceJ = -10;
        AILightBomber.SecondPieceI = -10;
        AILightBomber.SecondPieceJ = -10;
        AILightBomber.ThirdPieceI = -10;
        AILightBomber.ThirdPieceJ = -10;
        AILightBomber.FourthPieceI = -10;
        AILightBomber.FourthPieceJ = -10;
        AILightBomber.PassiveAttribute = "";
        AILightBomber.ActiveAttribute = "";
        AILightBomber.ActiveAttributeCost = 10;

        AIBombCatcher.Name = "BombCatcher";
        AIBombCatcher.Piece = 5;
        AIBombCatcher.HittedPiece = 0;
        AIBombCatcher.FirstPieceI = -10;
        AIBombCatcher.FirstPieceJ = -10;
        AIBombCatcher.SecondPieceI = -10;
        AIBombCatcher.SecondPieceJ = -10;
        AIBombCatcher.ThirdPieceI = -10;
        AIBombCatcher.ThirdPieceJ = -10;
        AIBombCatcher.FourthPieceI = -10;
        AIBombCatcher.FourthPieceJ = -10;
        AIBombCatcher.FifthPieceI = -10;
        AIBombCatcher.FifthPieceJ = -10;
        AIBombCatcher.PassiveAttribute = "";
        AIBombCatcher.ActiveAttribute = "";
        AIBombCatcher.ActiveAttributeCost = 10;

        AIBomber.Name = "Bomber";
        AIBomber.Piece = 5;
        AIBomber.HittedPiece = 0;
        AIBomber.FirstPieceI = -10;
        AIBomber.FirstPieceJ = -10;
        AIBomber.SecondPieceI = -10;
        AIBomber.SecondPieceJ = -10;
        AIBomber.ThirdPieceI = -10;
        AIBomber.ThirdPieceJ = -10;
        AIBomber.FourthPieceI = -10;
        AIBomber.FourthPieceJ = -10;
        AIBomber.FifthPieceI = -10;
        AIBomber.FifthPieceJ = -10;
        AIBomber.PassiveAttribute = "";
        AIBomber.ActiveAttribute = "";
        AIBomber.ActiveAttributeCost = 10;

        AIBoomer.Name = "Boomer";
        AIBoomer.Piece = 6;
        AIBoomer.HittedPiece = 0;
        AIBoomer.FirstPieceI = -10;
        AIBoomer.FirstPieceJ = -10;
        AIBoomer.SecondPieceI = -10;
        AIBoomer.SecondPieceJ = -10;
        AIBoomer.ThirdPieceI = -10;
        AIBoomer.ThirdPieceJ = -10;
        AIBoomer.FourthPieceI = -10;
        AIBoomer.FourthPieceJ = -10;
        AIBoomer.FifthPieceI = -10;
        AIBoomer.FifthPieceJ = -10;
        AIBoomer.SixthPieceI = -10;
        AIBoomer.SixthPieceJ = -10;
        AIBoomer.PassiveAttribute = "";
        AIBoomer.ActiveAttribute = "";
        AIBoomer.ActiveAttributeCost = 10;

        AIFlameThrower.Name = "FlameThrower";
        AIFlameThrower.Piece = 7;
        AIFlameThrower.HittedPiece = 0;
        AIFlameThrower.FirstPieceI = -10;
        AIFlameThrower.FirstPieceJ = -10;
        AIFlameThrower.SecondPieceI = -10;
        AIFlameThrower.SecondPieceJ = -10;
        AIFlameThrower.ThirdPieceI = -10;
        AIFlameThrower.ThirdPieceJ = -10;
        AIFlameThrower.FourthPieceI = -10;
        AIFlameThrower.FourthPieceJ = -10;
        AIFlameThrower.FifthPieceI = -10;
        AIFlameThrower.FifthPieceJ = -10;
        AIFlameThrower.SixthPieceI = -10;
        AIFlameThrower.SixthPieceJ = -10;
        AIFlameThrower.SeventhPieceI = -10;
        AIFlameThrower.SeventhPieceJ = -10;
        AIFlameThrower.PassiveAttribute = "";
        AIFlameThrower.ActiveAttribute = "";
        AIFlameThrower.ActiveAttributeCost = 10;          
    }

    void Start()
    {
        int rnd = Random.Range(0, 4);
        //rnd = 1;
        Debug.Log("First,Second,Third,Fourth: " + (rnd + 1));
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
        Bomber(6, 8, 7, 8, 8, 7, 8, 8, 8, 9);
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
        BombCatcher(3, 9, 4, 9, 5, 9, 6, 9, 7, 9);
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
