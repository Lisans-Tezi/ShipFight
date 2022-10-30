using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Control : MonoBehaviour
{
    string Ship1="", Ship2="", Ship3="", Ship4="", Ship5="";
    
    public void control()
    {
        Ship1 = GameObject.Find("GameManager").GetComponent<GameManager>().ship1NameText.text;
        Ship2 = GameObject.Find("GameManager").GetComponent<GameManager>().ship2NameText.text;
        Ship3 = GameObject.Find("GameManager").GetComponent<GameManager>().ship3NameText.text;
        Ship4 = GameObject.Find("GameManager").GetComponent<GameManager>().ship4NameText.text;
        Ship5 = GameObject.Find("GameManager").GetComponent<GameManager>().ship5NameText.text;

        ShipControl(Ship1);
        ShipControl(Ship2);
        ShipControl(Ship3);
        ShipControl(Ship4);
        ShipControl(Ship5);
    }

    void ShipControl(string ship)
    {
        if (ship == "MoneyMaker")
        {
            GameObject.Find("MoneyMaker").GetComponent<moneymaker>().PassiveAttribute();
        }
        else if (ship == "Tank")
        {

        }
        else if (ship=="SideStep")
        {

        }
        else if (ship=="Faker")
        {

        }
        else if (ship == "Healer")
        {

        }
        else if (ship == "LightBomber")
        {

        }
        else if (ship == "BombCatcher")
        {

        }
        else if (ship == "Bomber")
        {

        }
        else if (ship == "Boomer")
        {

        }
        else if (ship == "FlameThrower")
        {

        }
    }
}
