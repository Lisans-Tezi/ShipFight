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
            map[GameObject.Find("GameManager").GetComponent<GameManager>().moneyMaker.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().moneyMaker.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().moneyMaker.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().moneyMaker.SecondPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Tank")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().tank.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().tank.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().tank.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().tank.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().tank.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().tank.ThirdPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "SideStep")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().sideStep.ThirdPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Faker")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().faker.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().faker.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().faker.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().faker.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().faker.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().faker.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().faker.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().faker.FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Healer")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().healer.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().healer.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().healer.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().healer.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().healer.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().healer.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().healer.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().healer.FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "LightBomber")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().lightBomber.FourthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "BombCatcher")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FifthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bombCatcher.FifthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Bomber")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bomber.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bomber.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bomber.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bomber.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FifthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().bomber.FifthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "Boomer")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FifthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.FifthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().boomer.SixthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().boomer.SixthPieceJ].GetComponent<Image>().color = Color.black;
        }
        else if (shipName == "FlameThrower")
        {
            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FirstPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FirstPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SecondPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SecondPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.ThirdPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.ThirdPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FourthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FourthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FifthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.FifthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SixthPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SixthPieceJ].GetComponent<Image>().color = Color.black;

            map[GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SeventhPieceI,
               GameObject.Find("GameManager").GetComponent<GameManager>().flameThrower.SeventhPieceJ].GetComponent<Image>().color = Color.black;
        }

    }

}
