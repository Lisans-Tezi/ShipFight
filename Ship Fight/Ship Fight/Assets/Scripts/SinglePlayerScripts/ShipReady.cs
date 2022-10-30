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

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public List<string> PlacedShipNames;

    int[,] Coordinats = new int[10, 10];
    int shipCount = 1;
    List<string> shipNames = new List<string>();

    public MoneyMaker MoneyMaker;
    public Tank Tank;
    public SideStep SideStep;
    public Faker Faker;
    public Healer Healer;
    public LightBomber LightBomber;
    public BombCatcher BombCatcher;
    public Bomber Bomber;
    public Boomer Boomer;
    public FlameThrower FlameThrower;
    private void Awake()
    {
        MoneyMaker.Name = null;
        MoneyMaker.Piece = 2;
        MoneyMaker.HittedPiece = 0;
        MoneyMaker.FirstPieceI = -1;
        MoneyMaker.FirstPieceJ = -1;
        MoneyMaker.SecondPieceI = -1;
        MoneyMaker.SecondPieceJ = -1;
        MoneyMaker.PassiveAttribute = "";
        MoneyMaker.ActiveAttribute = "";
        MoneyMaker.ActiveAttributeCost = 10;

        Tank.Name = null;
        Tank.Piece = 3;
        Tank.HittedPiece = 0;
        Tank.FirstPieceI = -1;
        Tank.FirstPieceJ = -1;
        Tank.SecondPieceI = -1;
        Tank.SecondPieceJ = -1;
        Tank.ThirdPieceI = -1;
        Tank.ThirdPieceJ = -1;
        Tank.PassiveAttribute = "";
        Tank.ActiveAttribute = "";
        Tank.ActiveAttributeCost = 10;

        SideStep.Name = null;
        SideStep.Piece = 3;
        SideStep.HittedPiece = 0;
        SideStep.FirstPieceI = -1;
        SideStep.FirstPieceJ = -1;
        SideStep.SecondPieceI = -1;
        SideStep.SecondPieceJ = -1;
        SideStep.ThirdPieceI = -1;
        SideStep.ThirdPieceJ = -1;
        SideStep.PassiveAttribute = "";
        SideStep.ActiveAttribute = "";
        SideStep.ActiveAttributeCost = 10;

        Faker.Name = null;
        Faker.Piece = 4;
        Faker.HittedPiece = 0;
        Faker.FirstPieceI = -1;
        Faker.FirstPieceJ = -1;
        Faker.SecondPieceI = -1;
        Faker.SecondPieceJ = -1;
        Faker.ThirdPieceI = -1;
        Faker.ThirdPieceJ = -1;
        Faker.FourthPieceI = -1;
        Faker.FourthPieceJ = -1;
        Faker.PassiveAttribute = "";
        Faker.ActiveAttribute = "";
        Faker.ActiveAttributeCost = 10;

        Healer.Name = null;
        Healer.Piece = 4;
        Healer.HittedPiece = 0;
        Healer.FirstPieceI = -1;
        Healer.FirstPieceJ = -1;
        Healer.SecondPieceI = -1;
        Healer.SecondPieceJ = -1;
        Healer.ThirdPieceI = -1;
        Healer.ThirdPieceJ = -1;
        Healer.FourthPieceI = -1;
        Healer.FourthPieceJ = -1;
        Healer.PassiveAttribute = "";
        Healer.ActiveAttribute = "";
        Healer.ActiveAttributeCost = 10;

        LightBomber.Name = null;
        LightBomber.Piece = 4;
        LightBomber.HittedPiece = 0;
        LightBomber.FirstPieceI = -1;
        LightBomber.FirstPieceJ = -1;
        LightBomber.SecondPieceI = -1;
        LightBomber.SecondPieceJ = -1;
        LightBomber.ThirdPieceI = -1;
        LightBomber.ThirdPieceJ = -1;
        LightBomber.FourthPieceI = -1;
        LightBomber.FourthPieceJ = -1;
        LightBomber.PassiveAttribute = "";
        LightBomber.ActiveAttribute = "";
        LightBomber.ActiveAttributeCost = 10;

        BombCatcher.Name = null;
        BombCatcher.Piece = 5;
        BombCatcher.HittedPiece = 0;
        BombCatcher.FirstPieceI = -1;
        BombCatcher.FirstPieceJ = -1;
        BombCatcher.SecondPieceI = -1;
        BombCatcher.SecondPieceJ = -1;
        BombCatcher.ThirdPieceI = -1;
        BombCatcher.ThirdPieceJ = -1;
        BombCatcher.FourthPieceI = -1;
        BombCatcher.FourthPieceJ = -1;
        BombCatcher.FifthPieceI = -1;
        BombCatcher.FifthPieceJ = -1;
        BombCatcher.PassiveAttribute = "";
        BombCatcher.ActiveAttribute = "";
        BombCatcher.ActiveAttributeCost = 10;

        Bomber.Name = null;
        Bomber.Piece = 5;
        Bomber.HittedPiece = 0;
        Bomber.FirstPieceI = -1;
        Bomber.FirstPieceJ = -1;
        Bomber.SecondPieceI = -1;
        Bomber.SecondPieceJ = -1;
        Bomber.ThirdPieceI = -1;
        Bomber.ThirdPieceJ = -1;
        Bomber.FourthPieceI = -1;
        Bomber.FourthPieceJ = -1;
        Bomber.FifthPieceI = -1;
        Bomber.FifthPieceJ = -1;
        Bomber.PassiveAttribute = "";
        Bomber.ActiveAttribute = "";
        Bomber.ActiveAttributeCost = 10;

        Boomer.Name = null;
        Boomer.Piece = 6;
        Boomer.HittedPiece = 0;
        Boomer.FirstPieceI = -1;
        Boomer.FirstPieceJ = -1;
        Boomer.SecondPieceI = -1;
        Boomer.SecondPieceJ = -1;
        Boomer.ThirdPieceI = -1;
        Boomer.ThirdPieceJ = -1;
        Boomer.FourthPieceI = -1;
        Boomer.FourthPieceJ = -1;
        Boomer.FifthPieceI = -1;
        Boomer.FifthPieceJ = -1;
        Boomer.SixthPieceI = -1;
        Boomer.SixthPieceJ = -1;
        Boomer.PassiveAttribute = "";
        Boomer.ActiveAttribute = "";
        Boomer.ActiveAttributeCost = 10;

        FlameThrower.Name = null;
        FlameThrower.Piece = 7;
        FlameThrower.HittedPiece = 0;
        FlameThrower.FirstPieceI = -1;
        FlameThrower.FirstPieceJ = -1;
        FlameThrower.SecondPieceI = -1;
        FlameThrower.SecondPieceJ = -1;
        FlameThrower.ThirdPieceI = -1;
        FlameThrower.ThirdPieceJ = -1;
        FlameThrower.FourthPieceI = -1;
        FlameThrower.FourthPieceJ = -1;
        FlameThrower.FifthPieceI = -1;
        FlameThrower.FifthPieceJ = -1;
        FlameThrower.SixthPieceI = -1;
        FlameThrower.SixthPieceJ = -1;
        FlameThrower.SeventhPieceI = -1;
        FlameThrower.SeventhPieceJ = -1;
        FlameThrower.PassiveAttribute = "";
        FlameThrower.ActiveAttribute = "";
        FlameThrower.ActiveAttributeCost = 10;
    }

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
                if (map[i, j].gameObject.GetComponent<Image>().color != Color.black && map[i, j].gameObject.GetComponent<Image>().color != blueColor)                         
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
            MoneyMaker.Name = "MoneyMaker";
            MoneyMaker.FirstPieceI = iPieces[0];
            MoneyMaker.FirstPieceJ = jPieces[0];
            MoneyMaker.SecondPieceI = iPieces[1];
            MoneyMaker.SecondPieceJ = jPieces[1];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Tank")
        {
            Tank.Name = "Tank";
            Tank.FirstPieceI = iPieces[0];
            Tank.FirstPieceJ = jPieces[0];
            Tank.SecondPieceI = iPieces[1];
            Tank.SecondPieceJ = jPieces[1];
            Tank.ThirdPieceI = iPieces[2];
            Tank.ThirdPieceJ = jPieces[2];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "SideStep")
        {
            SideStep.Name = "SideStep";
            SideStep.FirstPieceI = iPieces[0];
            SideStep.FirstPieceJ = jPieces[0];
            SideStep.SecondPieceI = iPieces[1];
            SideStep.SecondPieceJ = jPieces[1];
            SideStep.ThirdPieceI = iPieces[2];
            SideStep.ThirdPieceJ = jPieces[2];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Faker")
        {
            Faker.Name = "Faker";    
            Faker.FirstPieceI = iPieces[0];
            Faker.FirstPieceJ = jPieces[0];
            Faker.SecondPieceI = iPieces[1];
            Faker.SecondPieceJ = jPieces[1];
            Faker.ThirdPieceI = iPieces[2];
            Faker.ThirdPieceJ = jPieces[2];
            Faker.FourthPieceI = iPieces[3];
            Faker.FourthPieceJ = jPieces[3];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Healer")
        {
            Healer.Name = "Healer";
            Healer.FirstPieceI = iPieces[0];
            Healer.FirstPieceJ = jPieces[0];
            Healer.SecondPieceI = iPieces[1];
            Healer.SecondPieceJ = jPieces[1];
            Healer.ThirdPieceI = iPieces[2];
            Healer.ThirdPieceJ = jPieces[2];
            Healer.FourthPieceI = iPieces[3];
            Healer.FourthPieceJ = jPieces[3];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "LightBomber")
        {
            LightBomber.Name = "LightBomber";
            LightBomber.FirstPieceI = iPieces[0];
            LightBomber.FirstPieceJ = jPieces[0];
            LightBomber.SecondPieceI = iPieces[1];
            LightBomber.SecondPieceJ = jPieces[1];
            LightBomber.ThirdPieceI = iPieces[2];
            LightBomber.ThirdPieceJ = jPieces[2];
            LightBomber.FourthPieceI = iPieces[3];
            LightBomber.FourthPieceJ = jPieces[3];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "BombCatcher")
        {
            BombCatcher.Name = "BombCatcher";
            BombCatcher.FirstPieceI = iPieces[0];
            BombCatcher.FirstPieceJ = jPieces[0];
            BombCatcher.SecondPieceI = iPieces[1];
            BombCatcher.SecondPieceJ = jPieces[1];
            BombCatcher.ThirdPieceI = iPieces[2];
            BombCatcher.ThirdPieceJ = jPieces[2];
            BombCatcher.FourthPieceI = iPieces[3];
            BombCatcher.FourthPieceJ = jPieces[3];
            BombCatcher.FifthPieceI = iPieces[4];
            BombCatcher.FifthPieceJ = jPieces[4];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Bomber")
        {
            Bomber.Name = "Bomber";
            Bomber.FirstPieceI = iPieces[0];
            Bomber.FirstPieceJ = jPieces[0];
            Bomber.SecondPieceI = iPieces[1];
            Bomber.SecondPieceJ = jPieces[1];
            Bomber.ThirdPieceI = iPieces[2];
            Bomber.ThirdPieceJ = jPieces[2];
            Bomber.FourthPieceI = iPieces[3];
            Bomber.FourthPieceJ = jPieces[3];
            Bomber.FifthPieceI = iPieces[4];
            Bomber.FifthPieceJ = jPieces[4];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "Boomer")
        {
            Boomer.Name = "Boomer";
            Boomer.FirstPieceI = iPieces[0];
            Boomer.FirstPieceJ = jPieces[0];
            Boomer.SecondPieceI = iPieces[1];
            Boomer.SecondPieceJ = jPieces[1];
            Boomer.ThirdPieceI = iPieces[2];
            Boomer.ThirdPieceJ = jPieces[2];
            Boomer.FourthPieceI = iPieces[3];
            Boomer.FourthPieceJ = jPieces[3];
            Boomer.FifthPieceI = iPieces[4];
            Boomer.FifthPieceJ = jPieces[4];
            Boomer.SixthPieceI = iPieces[5];
            Boomer.SixthPieceJ = jPieces[5];
        }
        if (PlayerPrefs.GetString("SelectedShip") == "FlameThrower")
        {
            FlameThrower.Name = "FlameThrower";
            FlameThrower.FirstPieceI = iPieces[0];
            FlameThrower.FirstPieceJ = jPieces[0];
            FlameThrower.SecondPieceI = iPieces[1];
            FlameThrower.SecondPieceJ = jPieces[1];
            FlameThrower.ThirdPieceI = iPieces[2];
            FlameThrower.ThirdPieceJ = jPieces[2];
            FlameThrower.FourthPieceI = iPieces[3];
            FlameThrower.FourthPieceJ = jPieces[3];
            FlameThrower.FifthPieceI = iPieces[4];
            FlameThrower.FifthPieceJ = jPieces[4];
            FlameThrower.SixthPieceI = iPieces[5];
            FlameThrower.SixthPieceJ = jPieces[5];
            FlameThrower.SeventhPieceI = iPieces[6];
            FlameThrower.SeventhPieceJ = jPieces[6];
        }                 
        
        if (PlayerPrefs.GetInt("PlacedShipCount") == 5)
            GameObject.Find("MapReadyButton").gameObject.GetComponent<Button>().enabled = true;
    }
}
