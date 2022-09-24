using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacingShip : MonoBehaviour
{
    public Image Map;

    GameObject[,] map = new GameObject[10, 10];

    Color greenColor = new Color32(0, 255, 0, 200);
    Color orangeColor = new Color32(255, 165, 0, 255);

    void Start()
    {
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
    bool Control()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color != greenColor)
                    return false;
        return true;
    }
    int FindShipSize(string shipName)
    {
        if (shipName == "MoneyMaker")
            return 2;
        else if (shipName == "Tank")
            return 3;
        else if (shipName == "SideStep")
            return 3;
        else if (shipName == "Faker")
            return 4;
        else if (shipName == "Healer")
            return 4;
        else if (shipName == "LightBomber")
            return 4;
        else if (shipName == "BombCatcher")
            return 5;
        else if (shipName == "Bomber")
            return 5;
        else if (shipName == "Boomer")
            return 6;
        else if (shipName == "FlameThrower")
            return 7;
        else
            return 0;
    }
    public void ShipPlacing()
    {
        if (Control())
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), FindShipSize(PlayerPrefs.GetString("SelectedShip")));
        }
        int piece = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip"));


        if (FindShipSize(PlayerPrefs.GetString("SelectedShip")) == piece)
        {
            if (gameObject.GetComponent<Image>().color == greenColor && piece > 0)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip")) - 1);
                gameObject.GetComponent<Image>().color = Color.blue;
            }
        }
        else
        {
            if (gameObject.GetComponent<Image>().color == orangeColor && piece > 0)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip")) - 1);
                gameObject.GetComponent<Image>().color = Color.blue;
            }
        }

        for (int i = 0; i < 10; i++) 
            for (int j = 0; j < 10; j++) 
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                {
                    if (j != 0 && map[i, j - 1].gameObject.GetComponent<Image>().color != Color.black)
                    {
                        if (map[i, j - 1].gameObject.GetComponent<Image>().color != Color.blue)
                        {
                            map[i, j - 1].gameObject.GetComponent<Image>().color = orangeColor;
                        }
                    }

                    if (j != 9 && map[i, j + 1].gameObject.GetComponent<Image>().color != Color.black)
                    {
                        if (map[i, j + 1].gameObject.GetComponent<Image>().color != Color.blue)
                        {
                            map[i, j + 1].gameObject.GetComponent<Image>().color = orangeColor;
                        }
                    }

                    if (i != 0 && map[i - 1, j].gameObject.GetComponent<Image>().color != Color.black)
                    {
                        if (map[i - 1, j].gameObject.GetComponent<Image>().color != Color.blue)
                        {
                            map[i - 1, j].gameObject.GetComponent<Image>().color = orangeColor;
                        }
                    }

                    if (i != 9 && map[i + 1, j].gameObject.GetComponent<Image>().color != Color.black)
                    {
                        if (map[i + 1, j].gameObject.GetComponent<Image>().color != Color.blue)
                        {
                            map[i + 1, j].gameObject.GetComponent<Image>().color = orangeColor;
                        }
                    }
                }
        piece = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip"));
        if (piece == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j].gameObject.GetComponent<Image>().color == orangeColor)
                    {
                        map[i, j].gameObject.GetComponent<Image>().color = greenColor;
                    }
                }
            }
            GameObject.Find("ShipReadyButton").gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
