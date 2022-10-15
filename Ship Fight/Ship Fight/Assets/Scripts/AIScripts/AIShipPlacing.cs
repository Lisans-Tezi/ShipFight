using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShipPlacing : MonoBehaviour
{
    void Start()
    {
        int rnd = Random.Range(0, 2);

        switch (rnd)
        {
            case 0:
                AIFirst();
                break;
            case 1:
                AISecond();
                break;
        }

    }

    void AIFirst()
    {
        MoneyMaker mm;
        mm = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
        mm.Name = "MoneyMaker";
        mm.Piece = 2;
        mm.HittedPiece = 0;
        mm.FirstPieceI = 7;
        mm.FirstPieceJ = 3;
        mm.SecondPieceI = 7;
        mm.SecondPieceJ = 4;
        mm.PassiveAttribute = "";
        mm.ActiveAttribute = "";
        mm.ActiveAttributeCost = 2;

        Tank t;
        t = GameObject.Find("Tank").GetComponent<Tank>();
        t.Name = "Tank";
        t.Piece = 3;
        t.HittedPiece = 0;
        t.FirstPieceI = 3;
        t.FirstPieceJ = 2;
        t.SecondPieceI = 3;
        t.SecondPieceJ = 3;
        t.ThirdPieceI = 3;
        t.ThirdPieceJ = 4;
        t.PassiveAttribute = "";
        t.ActiveAttribute = "";
        t.ActiveAttributeCost = 3;

        Faker f;
        f = GameObject.Find("Faker").GetComponent<Faker>();
        f.Name = "Faker";
        f.Piece = 4;
        f.HittedPiece = 0;
        f.FirstPieceI = 0;
        f.FirstPieceJ = 0;
        f.SecondPieceI = 1;
        f.SecondPieceJ = 0;
        f.ThirdPieceI = 2;
        f.ThirdPieceJ = 0;
        f.FourthPieceI = 3;
        f.FourthPieceJ = 0;
        f.PassiveAttribute = "";
        f.ActiveAttribute = "";
        f.ActiveAttributeCost = 4;

        LightBomber lb;
        lb = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        lb.Name = "LightBomber";
        lb.Piece = 4;
        lb.HittedPiece = 0;
        lb.FirstPieceI = 9;
        lb.FirstPieceJ = 7;
        lb.SecondPieceI = 8;
        lb.SecondPieceJ = 8;
        lb.ThirdPieceI = 9;
        lb.ThirdPieceJ = 8;
        lb.FourthPieceI = 8;
        lb.FourthPieceJ = 9;
        lb.PassiveAttribute = "";
        lb.ActiveAttribute = "";
        lb.ActiveAttributeCost = 4;

        Bomber b;
        b = GameObject.Find("Bomber").GetComponent<Bomber>();
        b.Name = "Bomber";
        b.Piece = 5;
        b.HittedPiece = 0;
        b.FirstPieceI = 6;
        b.FirstPieceJ = 1;
        b.SecondPieceI = 7;
        b.SecondPieceJ = 1;
        b.ThirdPieceI = 7;
        b.ThirdPieceJ = 2;
        b.FourthPieceI = 7;
        b.FourthPieceJ = 3;
        b.FifthPieceI = 8;
        b.FifthPieceJ = 1;
        b.PassiveAttribute = "";
        b.ActiveAttribute = "";
        b.ActiveAttributeCost = 5;
    }

    void AISecond()
    {
        MoneyMaker mm;
        mm = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
        mm.Name = "MoneyMaker";
        mm.Piece = 2;
        mm.HittedPiece = 0;
        mm.FirstPieceI = 0;
        mm.FirstPieceJ = 1;
        mm.SecondPieceI = 0;
        mm.SecondPieceJ = 2;
        mm.PassiveAttribute = "";
        mm.ActiveAttribute = "";
        mm.ActiveAttributeCost = 2;

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
