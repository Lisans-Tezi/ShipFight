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
    public void ShipPlacing()
    {
        if (PlayerPrefs.GetString("SelectedShip") == "Tank")
        {
            if (PlayerPrefs.GetInt("Tank") == 0)
            {
                if (gameObject.GetComponent<Image>().color == greenColor)
                {
                    gameObject.GetComponent<Image>().color = Color.blue;
                    defaultPlacedShip();
                    PlayerPrefs.SetInt("Tank", 1);
                }
            }
            else if (PlayerPrefs.GetInt("Tank") == 1)
            {
                if (gameObject.GetComponent<Image>().color == orangeColor)
                {
                    gameObject.GetComponent<Image>().color = Color.blue;
                    deleteOrangeMap();
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if (i != 9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    map[i - 1, j].gameObject.GetComponent<Image>().color = orangeColor;
                                    map[i + 2, j].gameObject.GetComponent<Image>().color = orangeColor;
                                }
                                if (j != 9 && map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    map[i, j - 1].gameObject.GetComponent<Image>().color = orangeColor;
                                    map[i, j + 2].gameObject.GetComponent<Image>().color = orangeColor;
                                }
                                break;
                            }
                        }
                        PlayerPrefs.SetInt("Tank", 2);
                    }
                }
            }
            else if (PlayerPrefs.GetInt("Tank") == 2)
            {
                if (gameObject.GetComponent<Image>().color == orangeColor)
                {
                    gameObject.GetComponent<Image>().color = Color.blue;
                }
                deleteOrangeMap();
                GameObject.Find("ShipReadyButton").gameObject.GetComponent<Button>().enabled = true;
            }
        }

        void deleteOrangeMap()
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
        }

        void defaultPlacedShip()
        {
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
        }
    }
}

