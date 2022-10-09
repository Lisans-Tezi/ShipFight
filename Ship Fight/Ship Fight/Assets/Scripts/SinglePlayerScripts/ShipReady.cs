using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipReady : MonoBehaviour
{
    public Image Map;
    public List<Image> Ships;
    public List<TextMeshProUGUI> Texts;

    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 100);

    public List<string> PlacedShipNames;

    int[,] Coordinats = new int[10, 10];
    int shipCount = 1;
    List<string> shipNames = new List<string>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                Coordinats[i, j] = 0;

        PlayerPrefs.SetInt("PlacedShipCount", 0);
        PlacedShipNames = new List<string>();
        gameObject.GetComponent<Button>().enabled = false;
        Create();
    }

    void Create()
    {
        int k = 0;
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = Map.transform.GetChild(k).gameObject;
                k++;
            }
    }

    public void Clicked()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    Coordinats[i, j] = shipCount;

        shipNames.Add(PlayerPrefs.GetString("SelectedShip"));
        shipCount++;

        List<int> iPieces = new List<int>();
        List<int> jPieces = new List<int>();

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                {
                    map[i, j].gameObject.GetComponent<Image>().color = Color.black;
                    iPieces.Add(i);
                    jPieces.Add(j);
                }        
                if (map[i, j].gameObject.GetComponent<Image>().color != Color.black)
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
            }

        PlayerPrefs.SetInt("PlacedShipCount", PlayerPrefs.GetInt("PlacedShipCount") + 1);
        gameObject.GetComponent<Button>().enabled = false;

        foreach (Image ship in Ships)
        {
            if(PlayerPrefs.GetInt("PlacedShipCount") != 5)
                ship.GetComponent<Button>().enabled = true;
            if (ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color == Color.red)
            {
                ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;
                ship.GetComponent<Button>().enabled = false;
                PlacedShipNames.Add(ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text);
            }
        }

        if (PlayerPrefs.GetString("SelectedShip")== "MoneyMaker")
        {
            var mm = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
            mm.Name = "MoneyMaker";
            mm.Piece = 2;
            mm.HittedPiece = 0;
            mm.FirstPieceI = iPieces[0];
            mm.FirstPieceJ = jPieces[0];
            mm.SecondPieceI = iPieces[1];
            mm.SecondPieceJ = jPieces[1];
            mm.PassiveAttribute = "";
            mm.ActiveAttribute = "";
            mm.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Tank")
        {
            var t = GameObject.Find("Tank").GetComponent<Tank>();
            t.Name = "Tank";
            t.Piece = 3;
            t.HittedPiece = 0;
            t.FirstPieceI = iPieces[0];
            t.FirstPieceJ = jPieces[0];
            t.SecondPieceI = iPieces[1];
            t.SecondPieceJ = jPieces[1];
            t.ThirdPieceI = iPieces[2];
            t.ThirdPieceJ = jPieces[2];
            t.PassiveAttribute = "";
            t.ActiveAttribute = "";
            t.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "SideStep")
        {
            var ss = GameObject.Find("SideStep").GetComponent<SideStep>();
            ss.Name = "SideStep";
            ss.Piece = 3;
            ss.HittedPiece = 0;
            ss.FirstPieceI = iPieces[0];
            ss.FirstPieceJ = jPieces[0];
            ss.SecondPieceI = iPieces[1];
            ss.SecondPieceJ = jPieces[1];
            ss.ThirdPieceI = iPieces[2];
            ss.ThirdPieceJ = jPieces[2];
            ss.PassiveAttribute = "";
            ss.ActiveAttribute = "";
            ss.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Faker")
        {
            var f = GameObject.Find("Faker").GetComponent<Faker>();
            f.Name = "Faker";
            f.Piece = 4;
            f.HittedPiece = 0;
            f.FirstPieceI = iPieces[0];
            f.FirstPieceJ = jPieces[0];
            f.SecondPieceI = iPieces[1];
            f.SecondPieceJ = jPieces[1];
            f.ThirdPieceI = iPieces[2];
            f.ThirdPieceJ = jPieces[2];
            f.FourthPieceI = iPieces[3];
            f.FourthPieceJ = jPieces[3];
            f.PassiveAttribute = "";
            f.ActiveAttribute = "";
            f.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Healer")
        {
            var h = GameObject.Find("Healer").GetComponent<Healer>();
            h.Name = "Healer";
            h.Piece = 4;
            h.HittedPiece = 0;
            h.FirstPieceI = iPieces[0];
            h.FirstPieceJ = jPieces[0];
            h.SecondPieceI = iPieces[1];
            h.SecondPieceJ = jPieces[1];
            h.ThirdPieceI = iPieces[2];
            h.ThirdPieceJ = jPieces[2];
            h.FourthPieceI = iPieces[3];
            h.FourthPieceJ = jPieces[3];
            h.PassiveAttribute = "";
            h.ActiveAttribute = "";
            h.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "LightBomber")
        {
            var lb = GameObject.Find("LightBomber").GetComponent<LightBomber>();
            lb.Name = "LightBomber";
            lb.Piece = 4;
            lb.HittedPiece = 0;
            lb.FirstPieceI = iPieces[0];
            lb.FirstPieceJ = jPieces[0];
            lb.SecondPieceI = iPieces[1];
            lb.SecondPieceJ = jPieces[1];
            lb.ThirdPieceI = iPieces[2];
            lb.ThirdPieceJ = jPieces[2];
            lb.FourthPieceI = iPieces[3];
            lb.FourthPieceJ = jPieces[3];
            lb.PassiveAttribute = "";
            lb.ActiveAttribute = "";
            lb.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "BombCatcher")
        {
            var bc = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
            bc.Name = "BombCatcher";
            bc.Piece = 5;
            bc.HittedPiece = 0;
            bc.FirstPieceI = iPieces[0];
            bc.FirstPieceJ = jPieces[0];
            bc.SecondPieceI = iPieces[1];
            bc.SecondPieceJ = jPieces[1];
            bc.ThirdPieceI = iPieces[2];
            bc.ThirdPieceJ = jPieces[2];
            bc.FourthPieceI = iPieces[3];
            bc.FourthPieceJ = jPieces[3];
            bc.FifthPieceI = iPieces[4];
            bc.FifthPieceJ = jPieces[4];
            bc.PassiveAttribute = "";
            bc.ActiveAttribute = "";
            bc.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Bomber")
        {
            var b = GameObject.Find("Bomber").GetComponent<Bomber>();
            b.Name = "Bomber";
            b.Piece = 5;
            b.HittedPiece = 0;
            b.FirstPieceI = iPieces[0];
            b.FirstPieceJ = jPieces[0];
            b.SecondPieceI = iPieces[1];
            b.SecondPieceJ = jPieces[1];
            b.ThirdPieceI = iPieces[2];
            b.ThirdPieceJ = jPieces[2];
            b.FourthPieceI = iPieces[3];
            b.FourthPieceJ = jPieces[3];
            b.FifthPieceI = iPieces[4];
            b.FifthPieceJ = jPieces[4];
            b.PassiveAttribute = "";
            b.ActiveAttribute = "";
            b.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Boomer")
        {
            var b = GameObject.Find("Boomer").GetComponent<Boomer>();
            b.Name = "Boomer";
            b.Piece = 6;
            b.HittedPiece = 0;
            b.FirstPieceI = iPieces[0];
            b.FirstPieceJ = jPieces[0];
            b.SecondPieceI = iPieces[1];
            b.SecondPieceJ = jPieces[1];
            b.ThirdPieceI = iPieces[2];
            b.ThirdPieceJ = jPieces[2];
            b.FourthPieceI = iPieces[3];
            b.FourthPieceJ = jPieces[3];
            b.FifthPieceI = iPieces[4];
            b.FifthPieceJ = jPieces[4];
            b.SixthPieceI = iPieces[5];
            b.SixthPieceJ = jPieces[5];
            b.PassiveAttribute = "";
            b.ActiveAttribute = "";
            b.ActiveAttributeCost = 10;
        }
        if (PlayerPrefs.GetString("SelectedShip") == "FlameThrower")
        {
            var b = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();
            b.Name = "FlameThrower";
            b.Piece = 7;
            b.HittedPiece = 0;
            b.FirstPieceI = iPieces[0];
            b.FirstPieceJ = jPieces[0];
            b.SecondPieceI = iPieces[1];
            b.SecondPieceJ = jPieces[1];
            b.ThirdPieceI = iPieces[2];
            b.ThirdPieceJ = jPieces[2];
            b.FourthPieceI = iPieces[3];
            b.FourthPieceJ = jPieces[3];
            b.FifthPieceI = iPieces[4];
            b.FifthPieceJ = jPieces[4];
            b.SixthPieceI = iPieces[5];
            b.SixthPieceJ = jPieces[5];
            b.SeventhPieceI = iPieces[6];
            b.SeventhPieceJ = jPieces[6];
            b.PassiveAttribute = "";
            b.ActiveAttribute = "";
            b.ActiveAttributeCost = 10;
        }          
        
        
        if (PlayerPrefs.GetInt("PlacedShipCount") == 5)
            GameObject.Find("MapReadyButton").gameObject.GetComponent<Button>().enabled = true;
    }
}
