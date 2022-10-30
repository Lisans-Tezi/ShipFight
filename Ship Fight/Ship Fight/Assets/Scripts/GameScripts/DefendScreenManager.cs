using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendScreenManager : MonoBehaviour
{
    public List<Sprite> Images;
    public List<Image> Ship;

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public Image Map;
    GameObject[,] map = new GameObject[10, 10];
    void Start()
    {
        Create();
        ImagePlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship1NameText.text, Ship[0]);
        ImagePlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship2NameText.text, Ship[1]);
        ImagePlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship3NameText.text, Ship[2]);
        ImagePlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship4NameText.text, Ship[3]);
        ImagePlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship5NameText.text, Ship[4]);

        ShipPlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship1NameText.text);
        ShipPlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship2NameText.text);
        ShipPlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship3NameText.text);
        ShipPlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship4NameText.text);
        ShipPlacement(GameObject.Find("GameManager").GetComponent<GameManager>().ship5NameText.text);
    }
    void Create()
    {
        int k = 0;
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = Map.transform.GetChild(k).gameObject;
                map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                k++;
            }
        if (PlayerPrefs.GetString("Map") == "Map1")
        {
            map[3, 3].GetComponent<Image>().color = blueColor;
            map[3, 4].GetComponent<Image>().color = blueColor;
            map[3, 5].GetComponent<Image>().color = blueColor;
            map[3, 6].GetComponent<Image>().color = blueColor;

            map[4, 3].GetComponent<Image>().color = blueColor;
            map[4, 4].GetComponent<Image>().color = blueColor;
            map[4, 5].GetComponent<Image>().color = blueColor;
            map[4, 6].GetComponent<Image>().color = blueColor;

            map[5, 3].GetComponent<Image>().color = blueColor;
            map[5, 4].GetComponent<Image>().color = blueColor;
            map[5, 5].GetComponent<Image>().color = blueColor;
            map[5, 6].GetComponent<Image>().color = blueColor;

            map[6, 3].GetComponent<Image>().color = blueColor;
            map[6, 4].GetComponent<Image>().color = blueColor;
            map[6, 5].GetComponent<Image>().color = blueColor;
            map[6, 6].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map2")
        {
            map[0, 2].GetComponent<Image>().color = blueColor;
            map[0, 3].GetComponent<Image>().color = blueColor;
            map[0, 4].GetComponent<Image>().color = blueColor;
            map[0, 5].GetComponent<Image>().color = blueColor;
            map[0, 6].GetComponent<Image>().color = blueColor;
            map[0, 7].GetComponent<Image>().color = blueColor;

            map[1, 3].GetComponent<Image>().color = blueColor;
            map[1, 4].GetComponent<Image>().color = blueColor;
            map[1, 5].GetComponent<Image>().color = blueColor;
            map[1, 6].GetComponent<Image>().color = blueColor;

            map[2, 4].GetComponent<Image>().color = blueColor;
            map[2, 5].GetComponent<Image>().color = blueColor;

            map[7, 2].GetComponent<Image>().color = blueColor;
            map[7, 7].GetComponent<Image>().color = blueColor;

            map[8, 2].GetComponent<Image>().color = blueColor;
            map[8, 3].GetComponent<Image>().color = blueColor;
            map[8, 6].GetComponent<Image>().color = blueColor;
            map[8, 7].GetComponent<Image>().color = blueColor;

            map[9, 2].GetComponent<Image>().color = blueColor;
            map[9, 3].GetComponent<Image>().color = blueColor;
            map[9, 4].GetComponent<Image>().color = blueColor;
            map[9, 5].GetComponent<Image>().color = blueColor;
            map[9, 6].GetComponent<Image>().color = blueColor;
            map[9, 7].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map3")
        {
            map[0, 0].GetComponent<Image>().color = blueColor;
            map[0, 1].GetComponent<Image>().color = blueColor;

            map[1, 0].GetComponent<Image>().color = blueColor;

            map[2, 6].GetComponent<Image>().color = blueColor;
            map[2, 7].GetComponent<Image>().color = blueColor;
            map[2, 8].GetComponent<Image>().color = blueColor;
            map[2, 9].GetComponent<Image>().color = blueColor;

            map[3, 6].GetComponent<Image>().color = blueColor;
            map[3, 7].GetComponent<Image>().color = blueColor;
            map[3, 8].GetComponent<Image>().color = blueColor;
            map[3, 9].GetComponent<Image>().color = blueColor;

            map[4, 0].GetComponent<Image>().color = blueColor;
            map[4, 8].GetComponent<Image>().color = blueColor;
            map[4, 9].GetComponent<Image>().color = blueColor;

            map[5, 0].GetComponent<Image>().color = blueColor;
            map[5, 1].GetComponent<Image>().color = blueColor;
            map[5, 9].GetComponent<Image>().color = blueColor;

            map[6, 0].GetComponent<Image>().color = blueColor;
            map[6, 1].GetComponent<Image>().color = blueColor;
            map[6, 2].GetComponent<Image>().color = blueColor;
            map[6, 3].GetComponent<Image>().color = blueColor;

            map[7, 0].GetComponent<Image>().color = blueColor;
            map[7, 1].GetComponent<Image>().color = blueColor;
            map[7, 2].GetComponent<Image>().color = blueColor;
            map[7, 3].GetComponent<Image>().color = blueColor;

            map[8, 9].GetComponent<Image>().color = blueColor;

            map[9, 8].GetComponent<Image>().color = blueColor;
            map[9, 9].GetComponent<Image>().color = blueColor;
        }
        else if (PlayerPrefs.GetString("Map") == "Map4")
        {
            map[0, 0].GetComponent<Image>().color = blueColor;
            map[0, 1].GetComponent<Image>().color = blueColor;
            map[0, 2].GetComponent<Image>().color = blueColor;
            map[0, 7].GetComponent<Image>().color = blueColor;
            map[0, 8].GetComponent<Image>().color = blueColor;
            map[0, 9].GetComponent<Image>().color = blueColor;

            map[1, 0].GetComponent<Image>().color = blueColor;
            map[1, 1].GetComponent<Image>().color = blueColor;
            map[1, 8].GetComponent<Image>().color = blueColor;
            map[1, 9].GetComponent<Image>().color = blueColor;

            map[2, 0].GetComponent<Image>().color = blueColor;
            map[2, 9].GetComponent<Image>().color = blueColor;

            map[3, 3].GetComponent<Image>().color = blueColor;
            map[3, 4].GetComponent<Image>().color = blueColor;
            map[3, 5].GetComponent<Image>().color = blueColor;
            map[3, 6].GetComponent<Image>().color = blueColor;

            map[4, 3].GetComponent<Image>().color = blueColor;
            map[4, 4].GetComponent<Image>().color = blueColor;
            map[4, 5].GetComponent<Image>().color = blueColor;
            map[4, 6].GetComponent<Image>().color = blueColor;

            map[5, 3].GetComponent<Image>().color = blueColor;
            map[5, 4].GetComponent<Image>().color = blueColor;
            map[5, 5].GetComponent<Image>().color = blueColor;
            map[5, 6].GetComponent<Image>().color = blueColor;

            map[6, 3].GetComponent<Image>().color = blueColor;
            map[6, 4].GetComponent<Image>().color = blueColor;
            map[6, 5].GetComponent<Image>().color = blueColor;
            map[6, 6].GetComponent<Image>().color = blueColor;

            map[7, 0].GetComponent<Image>().color = blueColor;
            map[7, 9].GetComponent<Image>().color = blueColor;

            map[8, 0].GetComponent<Image>().color = blueColor;
            map[8, 1].GetComponent<Image>().color = blueColor;
            map[8, 8].GetComponent<Image>().color = blueColor;
            map[8, 9].GetComponent<Image>().color = blueColor;

            map[9, 0].GetComponent<Image>().color = blueColor;
            map[9, 1].GetComponent<Image>().color = blueColor;
            map[9, 2].GetComponent<Image>().color = blueColor;
            map[9, 7].GetComponent<Image>().color = blueColor;
            map[9, 8].GetComponent<Image>().color = blueColor;
            map[9, 9].GetComponent<Image>().color = blueColor;
        }
    }


    void ImagePlacement(string shipName, Image ship)
    {
        if (shipName == "MoneyMaker")
            ship.GetComponent<Image>().sprite = Images[0];
        else if (shipName == "Tank")
            ship.GetComponent<Image>().sprite = Images[1];
        else if (shipName == "SideStep")
            ship.GetComponent<Image>().sprite = Images[2];
        else if (shipName == "Faker")
            ship.GetComponent<Image>().sprite = Images[3];
        else if (shipName == "Healer")
            ship.GetComponent<Image>().sprite = Images[4];
        else if (shipName == "LightBomber")
            ship.GetComponent<Image>().sprite = Images[5];
        else if (shipName == "BombCatcher")
            ship.GetComponent<Image>().sprite = Images[6];
        else if (shipName == "Bomber")
            ship.GetComponent<Image>().sprite = Images[7];
        else if (shipName == "Boomer")
            ship.GetComponent<Image>().sprite = Images[8];
        else if (shipName == "FlameThrower")
            ship.GetComponent<Image>().sprite = Images[9];
    }

    void ShipPlacement(string shipName)
    {
        if (shipName == "MoneyMaker")
        {
            map[GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>().FirstPieceI,
               GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>().SecondPieceI,
               GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>().SecondPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Tank")
        {
            map[GameObject.Find("Tank").GetComponent<Tank>().FirstPieceI,
               GameObject.Find("Tank").GetComponent<Tank>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Tank").GetComponent<Tank>().SecondPieceI,
               GameObject.Find("Tank").GetComponent<Tank>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Tank").GetComponent<Tank>().ThirdPieceI,
               GameObject.Find("Tank").GetComponent<Tank>().ThirdPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "SideStep")
        {
            map[GameObject.Find("SideStep").GetComponent<SideStep>().FirstPieceI,
               GameObject.Find("SideStep").GetComponent<SideStep>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("SideStep").GetComponent<SideStep>().SecondPieceI,
               GameObject.Find("SideStep").GetComponent<SideStep>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("SideStep").GetComponent<SideStep>().ThirdPieceI,
               GameObject.Find("SideStep").GetComponent<SideStep>().ThirdPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Faker")
        {
            map[GameObject.Find("Faker").GetComponent<Faker>().FirstPieceI,
               GameObject.Find("Faker").GetComponent<Faker>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Faker").GetComponent<Faker>().SecondPieceI,
               GameObject.Find("Faker").GetComponent<Faker>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Faker").GetComponent<Faker>().ThirdPieceI,
               GameObject.Find("Faker").GetComponent<Faker>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Faker").GetComponent<Faker>().FourthPieceI,
               GameObject.Find("Faker").GetComponent<Faker>().FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Healer")
        {
            map[GameObject.Find("Healer").GetComponent<Healer>().FirstPieceI,
               GameObject.Find("Healer").GetComponent<Healer>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Healer").GetComponent<Healer>().SecondPieceI,
               GameObject.Find("Healer").GetComponent<Healer>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Healer").GetComponent<Healer>().ThirdPieceI,
               GameObject.Find("Healer").GetComponent<Healer>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Healer").GetComponent<Healer>().FourthPieceI,
               GameObject.Find("Healer").GetComponent<Healer>().FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "LightBomber")
        {
            map[GameObject.Find("LightBomber").GetComponent<LightBomber>().FirstPieceI,
               GameObject.Find("LightBomber").GetComponent<LightBomber>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("LightBomber").GetComponent<LightBomber>().SecondPieceI,
               GameObject.Find("LightBomber").GetComponent<LightBomber>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("LightBomber").GetComponent<LightBomber>().ThirdPieceI,
               GameObject.Find("LightBomber").GetComponent<LightBomber>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("LightBomber").GetComponent<LightBomber>().FourthPieceI,
               GameObject.Find("LightBomber").GetComponent<LightBomber>().FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "BombCatcher")
        {
            map[GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FirstPieceI,
               GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("BombCatcher").GetComponent<BombCatcher>().SecondPieceI,
               GameObject.Find("BombCatcher").GetComponent<BombCatcher>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("BombCatcher").GetComponent<BombCatcher>().ThirdPieceI,
               GameObject.Find("BombCatcher").GetComponent<BombCatcher>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FourthPieceI,
               GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FifthPieceI,
               GameObject.Find("BombCatcher").GetComponent<BombCatcher>().FifthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Bomber")
        {
            map[GameObject.Find("Bomber").GetComponent<Bomber>().FirstPieceI,
               GameObject.Find("Bomber").GetComponent<Bomber>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Bomber").GetComponent<Bomber>().SecondPieceI,
               GameObject.Find("Bomber").GetComponent<Bomber>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Bomber").GetComponent<Bomber>().ThirdPieceI,
               GameObject.Find("Bomber").GetComponent<Bomber>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Bomber").GetComponent<Bomber>().FourthPieceI,
               GameObject.Find("Bomber").GetComponent<Bomber>().FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Bomber").GetComponent<Bomber>().FifthPieceI,
               GameObject.Find("Bomber").GetComponent<Bomber>().FifthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Boomer")
        {
            map[GameObject.Find("Boomer").GetComponent<Boomer>().FirstPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Boomer").GetComponent<Boomer>().SecondPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Boomer").GetComponent<Boomer>().ThirdPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Boomer").GetComponent<Boomer>().FourthPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Boomer").GetComponent<Boomer>().FifthPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().FifthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("Boomer").GetComponent<Boomer>().SixthPieceI,
               GameObject.Find("Boomer").GetComponent<Boomer>().SixthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "FlameThrower")
        {
            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FirstPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SecondPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().ThirdPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FourthPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FifthPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().FifthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SixthPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SixthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SeventhPieceI,
               GameObject.Find("FlameThrower").GetComponent<FlameThrower>().SeventhPieceJ].GetComponent<Image>().color = Color.black;
        }

    }

}
