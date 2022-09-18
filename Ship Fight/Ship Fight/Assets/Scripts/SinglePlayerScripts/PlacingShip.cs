using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacingShip : MonoBehaviour
{
    public List<Image> First50Map;
    public List<Image> Second50Map;

    Color greenColor = new Color32(0, 255, 0, 200);
    Color whiteColor = new Color32(255, 255, 255, 100);
    Color orangeColor = new Color32(255, 165, 0, 255);

    int moneyMaker = 2;
    int tank = 3;
    int sideStep = 3;
    int faker = 4;
    int healer = 4;
    int lightBomber = 4;
    int bombCatcher = 5;
    int bomber = 5;
    int boomer = 6;
    int flameThrower = 7;


    bool Control(List<Image> map)
    {
        bool control = true;
        map.ForEach(x =>
        {
            if (x.gameObject.GetComponent<Image>().color != greenColor)
                control = false;
        });
        return control;
    }

    public void ShipPlacing()
    {
        if (Control(First50Map) && Control(Second50Map))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), FindShipName(PlayerPrefs.GetString("SelectedShip")));
        }
        int piece = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip"));
        
       
        if (FindShipName(PlayerPrefs.GetString("SelectedShip"))==piece)
        {
            if (gameObject.GetComponent<Image>().color == greenColor && piece > 0)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip")) - 1);
                gameObject.GetComponent<Image>().color = Color.blue;
            }
        }
        else
        {
            if(gameObject.GetComponent<Image>().color == orangeColor && piece>0)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetString("SelectedShip"), PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip")) - 1);
                gameObject.GetComponent<Image>().color = Color.blue;
            }
        }

        int count = 0;
        First50Map.ForEach(x =>
        {
            if (x.gameObject.GetComponent<Image>().color == Color.blue)
            {
                if (First50Map[count-1].gameObject.GetComponent<Image>().color != Color.black)
                {
                    if(First50Map[count-1].gameObject.GetComponent<Image>().color != Color.blue)
                    {
                        First50Map[count-1].gameObject.GetComponent<Image>().color = orangeColor;
                    }                           
                }
            }
            count++;
        });
        int count1 = 0;
        First50Map.ForEach(x =>
        {
            if (x.gameObject.GetComponent<Image>().color == Color.blue)
            {                       
                if (First50Map[count1+1].gameObject.GetComponent<Image>().color != Color.black)
                {
                    if (First50Map[count1+1].gameObject.GetComponent<Image>().color != Color.blue)
                    {
                        First50Map[count1+1].gameObject.GetComponent<Image>().color = orangeColor;
                    }
                }
            }
            count1++;
        });

        piece = PlayerPrefs.GetInt(PlayerPrefs.GetString("SelectedShip"));
        if (piece == 0)
        {
            First50Map.ForEach(x =>
            {
                if (x.gameObject.GetComponent<Image>().color == orangeColor)
                {
                    x.gameObject.GetComponent<Image>().color = greenColor;
                }
            });

            GameObject.Find("ShipReadyButton").gameObject.GetComponent<Button>().enabled = true;
        }
    }

    int FindShipName(string shipName)
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
}
