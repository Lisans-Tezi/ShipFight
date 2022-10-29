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
    Color blueColor = new Color32(0, 0, 255, 0);

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
        if (PlayerPrefs.GetString("SelectedShip") == "MoneyMaker")
            PlaceMoneyMaker();
        if (PlayerPrefs.GetString("SelectedShip") == "Tank")
            PlaceTank();
        if (PlayerPrefs.GetString("SelectedShip") == "SideStep")
            PlaceSideStep();
        if (PlayerPrefs.GetString("SelectedShip") == "Faker")
            PlacedFaker();
        if (PlayerPrefs.GetString("SelectedShip") == "Healer")
            PlacedHealer();
        if (PlayerPrefs.GetString("SelectedShip") == "LightBomber")
            PlacedLightBomber();
        if (PlayerPrefs.GetString("SelectedShip") == "BombCatcher")
            PlacedBombCatcher();
        if (PlayerPrefs.GetString("SelectedShip") == "Bomber")
            PlacedBomber();
        if (PlayerPrefs.GetString("SelectedShip") == "Boomer")
            PlacedBoomer();
        if (PlayerPrefs.GetString("SelectedShip") == "FlameThrower")
            PlacedFlameThrower();
    }

    void PlaceMoneyMaker()
    {
        if (PlayerPrefs.GetInt("MoneyMaker") == 0)
            FirstPlacement("MoneyMaker");
        else if (PlayerPrefs.GetInt("MoneyMaker") == 1)
            LastPlacement("MoneyMaker", 2);
    }
    void PlaceTank()
    {
        if (PlayerPrefs.GetInt("Tank") == 0)
            FirstPlacement("Tank");
        else if (PlayerPrefs.GetInt("Tank") == 1)
            MiddlePlacement("Tank", 2);
        else if (PlayerPrefs.GetInt("Tank") == 2)
            LastPlacement("Tank", 3);
    }
    void PlaceSideStep()
    {
        if (PlayerPrefs.GetInt("SideStep") == 0)
            FirstPlacement("SideStep");
        else if (PlayerPrefs.GetInt("SideStep") == 1)
            SideMiddlePlacement("SideStep", 2, false);
        else if (PlayerPrefs.GetInt("SideStep") == 2)
            LastPlacement("SideStep", 3);
    }
    void PlacedFaker()
    {
        if (PlayerPrefs.GetInt("Faker") == 0)
            FirstPlacement("Faker");
        else if (PlayerPrefs.GetInt("Faker") == 1)
            MiddlePlacement("Faker", 2);
        else if (PlayerPrefs.GetInt("Faker") == 2)
            MiddlePlacement("Faker", 3);
        else if (PlayerPrefs.GetInt("Faker") == 3)
            LastPlacement("Faker", 4);
    }
    void PlacedHealer()
    {
        if (PlayerPrefs.GetInt("Healer") == 0)
            FirstPlacement("Healer");
        else if (PlayerPrefs.GetInt("Healer") == 1)
            MiddlePlacement("Healer", 2);
        else if (PlayerPrefs.GetInt("Healer") == 2)
            SideMiddlePlacement("Healer", 3, true);
        else if (PlayerPrefs.GetInt("Healer") == 3)
            LastPlacement("Healer", 4);
    }
    void PlacedLightBomber()
    {
        if (PlayerPrefs.GetInt("LightBomber") == 0)
            FirstPlacement("LightBomber");
        else if (PlayerPrefs.GetInt("LightBomber") == 1)
            SideMiddlePlacement("LightBomber", 2, false);
        else if (PlayerPrefs.GetInt("LightBomber") == 2)
        {
            if (gameObject.GetComponent<Image>().color == orangeColor)
            {
                gameObject.GetComponent<Image>().color = Color.blue;
                deleteOrangeMap();
                bool control = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                        {
                            if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if ((i + 1) <= 9 && map[i + 1, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1);
                                    DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 1, jcontrol: '+', jnumber: 2);
                                }
                                if ((i + 1) <= 9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1, jcontrol: '+', jnumber: 1);
                                    DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 1, jcontrol: '-', jnumber: 1);
                                }
                            }
                            else if ((i + 1) <= 9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if ((j + 1) <= 9 && map[i + 1, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i: i, j: j, jcontrol: '-', jnumber: 1);
                                    DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2, jcontrol: '+', jnumber: 1);
                                }
                                if ((j - 1) >= 0 && map[i + 1, j - 1].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i: i, j: j, jcontrol: '+', jnumber: 1);
                                    DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2, jcontrol: '-', jnumber: 1);
                                }
                            }
                            control = true;
                            break;
                        }
                    }
                    if (control)
                        break;
                }

            }
            PlayerPrefs.SetInt("LightBomber", 3);
        }
        else if (PlayerPrefs.GetInt("LightBomber") == 3)
            LastPlacement("LightBomber", 4);
    }
    void PlacedBombCatcher()
    {
        if (PlayerPrefs.GetInt("BombCatcher") == 0)
            FirstPlacement("BombCatcher");
        else if (PlayerPrefs.GetInt("BombCatcher") == 1)
            MiddlePlacement("BombCatcher", 2);
        else if (PlayerPrefs.GetInt("BombCatcher") == 2)
            MiddlePlacement("BombCatcher", 3);
        else if (PlayerPrefs.GetInt("BombCatcher") == 3)
            MiddlePlacement("BombCatcher", 4);
        else if (PlayerPrefs.GetInt("BombCatcher") == 4)
            LastPlacement("BombCatcher", 5);
    }
    void PlacedBomber()
    {
        if (PlayerPrefs.GetInt("Bomber") == 0)
            FirstPlacement("Bomber");
        else if (PlayerPrefs.GetInt("Bomber") == 1)
            MiddlePlacement("Bomber", 2);
        else if (PlayerPrefs.GetInt("Bomber") == 2)
            SideMiddlePlacement("Bomber", 3, true);
        else if (PlayerPrefs.GetInt("Bomber") == 3)
        {
            if (gameObject.GetComponent<Image>().color == orangeColor)
            {
                gameObject.GetComponent<Image>().color = Color.blue;
                deleteOrangeMap();
                bool control = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                        {
                            if ((i + 1) <= 9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if ((i + 2) <= 9 && map[i + 2, j].gameObject.GetComponent<Image>().color != Color.blue)
                                {
                                    if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color != Color.blue)
                                        DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2);
                                    else if ((i - 1) >= 0 && map[i - 1, j].gameObject.GetComponent<Image>().color != Color.blue)
                                        DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1);
                                }
                                else if ((i + 2) <= 9 && map[i + 2, j].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    if ((j - 1) >= 0 && map[i + 2, j - 1].gameObject.GetComponent<Image>().color == Color.blue)
                                        DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2, jcontrol:'+', jnumber:1);
                                    else if ((j + 1) <= 9 && map[i + 2, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                        DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2,jcontrol:'-', jnumber:1);
                                }
                            }
                            if ((j + 2) <= 9 && map[i, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                if ((i + 1) <= 9 && map[i + 1, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                    DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1, jcontrol:'+',jnumber:2);

                            if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                if ((j + 2) <= 9 && map[i, j + 2].gameObject.GetComponent<Image>().color != Color.blue)
                                {
                                    if ((i + 1) <= 9 && map[i + 1, j].gameObject.GetComponent<Image>().color != Color.blue)
                                        DoControlAndPlacement(i: i, j: j, jcontrol: '+', jnumber: 2);
                                    else if ((j - 1) >= 0 && map[i, j - 1].gameObject.GetComponent<Image>().color != Color.blue)
                                        DoControlAndPlacement(i: i, j: j, jcontrol: '-', jnumber: 1);
                                }
                            control = true;
                            break;
                        }
                    }
                    if (control)
                        break;
                }


                PlayerPrefs.SetInt("Bomber", 4);
            }
        }
        else if (PlayerPrefs.GetInt("Bomber") == 4)
            LastPlacement("Bomber", 5);
    }
    void PlacedBoomer()
    {
        if (PlayerPrefs.GetInt("Boomer") == 0)
            FirstPlacement("Boomer");
        else if (PlayerPrefs.GetInt("Boomer") == 1)
            MiddlePlacement("Boomer", 2);
        else if (PlayerPrefs.GetInt("Boomer") == 2)
            MiddlePlacement("Boomer", 3);
        else if (PlayerPrefs.GetInt("Boomer") == 3)
            MiddlePlacement("Boomer", 4);
        else if (PlayerPrefs.GetInt("Boomer") == 4)
            MiddlePlacement("Boomer", 5);
        else if (PlayerPrefs.GetInt("Boomer") == 5)
            LastPlacement("Boomer", 6);
    }
    void PlacedFlameThrower()
    {
        if (PlayerPrefs.GetInt("FlameThrower") == 0)
            FirstPlacement("FlameThrower");
        else if (PlayerPrefs.GetInt("FlameThrower") == 1)
            MiddlePlacement("FlameThrower", 2);
        else if (PlayerPrefs.GetInt("FlameThrower") == 2)
            SideMiddlePlacement("FlameThrower", 3, true);
        else if (PlayerPrefs.GetInt("FlameThrower") == 3)
        {
            if (gameObject.GetComponent<Image>().color == orangeColor)
            {
                gameObject.GetComponent<Image>().color = Color.blue;
                deleteOrangeMap();
                bool control = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                        {
                            if ((i+1)<=9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if((i + 2) <= 9 && map[i + 2, j].gameObject.GetComponent<Image>().color != Color.blue)
                                {
                                    if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                        DoControlAndPlacement(i:i, j:j, icontrol:'+', inumber:2);
                                    else if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color != Color.blue)
                                        DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1);
                                }
                                if (i+2 > 9)
                                    DoControlAndPlacement(i: i, j: j, icontrol: '-', inumber: 1);                                 
                            }                                              
                            else if ((j+2)<=9 && (i+1)<=9 && map[i + 1, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2,jcontrol:'+',jnumber:2);

                            if ((j + 1) <= 9 && map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if ((i + 1) <= 9 && map[i + 1, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                    DoControlAndPlacement(i: i, j: j, jcontrol: '-', jnumber: 1);
                                else if ((i + 1) <= 9 && map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue && (j + 2) <= 9 && map[i, j + 2].gameObject.GetComponent<Image>().color != Color.blue)
                                    DoControlAndPlacement(i: i, j: j, jcontrol: '+', jnumber: 2);
                            }
                            else if ((i + 2) <= 9 && (j - 1) >= 0 && map[i + 2, j - 1].gameObject.GetComponent<Image>().color == Color.blue)
                                DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2, jcontrol:'-', jnumber:2);
                            else if ((i + 2) <= 9 && (j + 1) <= 9 && map[i + 2, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
                                DoControlAndPlacement(i: i, j: j, icontrol: '+', inumber: 2, jcontrol:'+', jnumber:2);

                            control = true;
                            break;
                        }
                    }
                    if (control)
                        break;
                }
                PlayerPrefs.SetInt("FlameThrower", 4);
            }
        }
        else if (PlayerPrefs.GetInt("FlameThrower") == 4)
        {
            if (gameObject.GetComponent<Image>().color == orangeColor)
            {
                gameObject.GetComponent<Image>().color = Color.blue;
                deleteOrangeMap();
                bool control = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                        {
                            if ((i+2)<=9 && (j+2)<=9 && map[i + 2, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if (map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 1);
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 2, inumber: 1, icontrol: '+');
                                }
                                else
                                {
                                    DoControlAndPlacement(i, j, icontrol: '+', inumber: 1);
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 1, icontrol: '+', inumber: 2);
                                }
                                    
                            }                                     
                            else if ((i+2)<=9 && (j-2)>=0 && map[i + 2, j - 2].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                DoControlAndPlacement(i, j, jcontrol: '-', jnumber: 1);
                                DoControlAndPlacement(i, j, jcontrol: '-', jnumber: 2, icontrol:'+',inumber:1);
                            }

                            else if ((i+2)<=9 && map[i + 2, j].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if ((j+2)<=9 && map[i, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                {
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 1, icontrol: '+', inumber: 2);
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 2, inumber: 1, icontrol: '+');
                                }                                      
                            }  
                            control = true;
                            break;
                        }
                    }
                    if (control)
                        break;
                }
                PlayerPrefs.SetInt("FlameThrower", 5);
            }
        }
        else if (PlayerPrefs.GetInt("FlameThrower") == 5)
        {
            if (gameObject.GetComponent<Image>().color == orangeColor)
            {
                gameObject.GetComponent<Image>().color = Color.blue;
                deleteOrangeMap();
                bool control = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                        {
                            if ((i + 2) <= 9 && (j + 2) <= 9 && map[i + 2, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                            {
                                if(map[i, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                    DoControlAndPlacement(i, j, icontrol: '+', inumber: 2);
                                else
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 2);

                            }                                       
                            else if ((i + 2) <= 9 && (j - 2) >= 0 && map[i + 2, j - 2].gameObject.GetComponent<Image>().color == Color.blue)
                                DoControlAndPlacement(i, j, jcontrol: '-', jnumber: 2);
                            else if ((i + 2) <= 9 && (j - 1) >= 0 && map[i + 2, j - 1].gameObject.GetComponent<Image>().color == Color.blue)
                                DoControlAndPlacement(i, j, jcontrol: '-', jnumber: 1);
                            else if ((j + 2) <= 9 && map[i, j + 2].gameObject.GetComponent<Image>().color == Color.blue)
                                if ((i+2)<=9 && map[i + 2, j].gameObject.GetComponent<Image>().color == Color.blue)
                                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: 2, icontrol:'+', inumber:2);
                                
                            control = true;
                            break;
                        }
                    }
                    if (control)
                        break;
                }
                PlayerPrefs.SetInt("FlameThrower", 6);
            }
        }
        else if (PlayerPrefs.GetInt("FlameThrower") == 6)
            LastPlacement("FlameThrower", 7);
    }
    void DoControlAndPlacement(int i, int j, char icontrol='+', char jcontrol='+', int inumber=0, int jnumber=0, bool orange=true)
    {
        if (icontrol == '+' && jcontrol == '+')
        {
            if ((i + inumber) <= 9 && (j + jnumber) <= 9 && map[i + inumber, j + jnumber].gameObject.GetComponent<Image>().color != Color.black && 
                map[i + inumber, j + jnumber].gameObject.GetComponent<Image>().color != blueColor)
                if (!orange)
                {
                    map[i + inumber, j + jnumber].gameObject.GetComponent<Image>().color = greenColor;
                }
                else
                {
                    map[i + inumber, j + jnumber].gameObject.GetComponent<Image>().color = orangeColor;
                }                    
        }
        else if(icontrol == '+' && jcontrol == '-')
        {
            if ((i + inumber) <= 9 && (j - jnumber) >= 0 && map[i + inumber, j - jnumber].gameObject.GetComponent<Image>().color != Color.black &&
                map[i + inumber, j - jnumber].gameObject.GetComponent<Image>().color != blueColor)
                if (!orange)
                {
                    map[i + inumber, j - jnumber].gameObject.GetComponent<Image>().color = greenColor;
                }
                else
                {
                    map[i + inumber, j - jnumber].gameObject.GetComponent<Image>().color = orangeColor;
                }               
        }
        else if (icontrol == '-' && jcontrol == '+')
        {
            if ((i - inumber) >= 0 && (j + jnumber) <= 9 && map[i - inumber, j + jnumber].gameObject.GetComponent<Image>().color != Color.black &&
                map[i - inumber, j + jnumber].gameObject.GetComponent<Image>().color != blueColor)
                if (!orange)
                {
                    map[i - inumber, j + jnumber].gameObject.GetComponent<Image>().color = greenColor;
                }
                else
                {
                    map[i - inumber, j + jnumber].gameObject.GetComponent<Image>().color = orangeColor;
                }               
        }
        else if (icontrol == '-' && jcontrol == '-')
        {
            if ((i - inumber) >= 0 && (j - jnumber) >= 0 && map[i - inumber, j - jnumber].gameObject.GetComponent<Image>().color != Color.black &&
                map[i - inumber, j - jnumber].gameObject.GetComponent<Image>().color != blueColor)
                if (!orange)
                {
                    map[i - inumber, j - jnumber].gameObject.GetComponent<Image>().color = greenColor;
                }
                else
                {
                    map[i - inumber, j - jnumber].gameObject.GetComponent<Image>().color = orangeColor;
                }                 
        }
    }
    void FirstPlacement(string shipName)
    {
        if (gameObject.GetComponent<Image>().color == greenColor)
        {
            gameObject.GetComponent<Image>().color = Color.blue;
            defaultPlacedShip();
            PlayerPrefs.SetInt(shipName, 1);
        }
    }
    void MiddlePlacement(string shipName, int pieces)
    {
        if (gameObject.GetComponent<Image>().color == orangeColor)
        {
            gameObject.GetComponent<Image>().color = Color.blue;
            deleteOrangeMap();
            bool control = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    {
                        {
                            if (i == 9)
                                Horizantal(i, j);
                            else if (j == 9)
                                Vertical(i, j);
                            else
                            {
                                Horizantal(i, j);
                                Vertical(i, j);
                            }
                        }
                        control = true;
                        break;
                    }
                }
                if (control)
                    break;
            }
            PlayerPrefs.SetInt(shipName, pieces);
        }
        void Horizantal(int i, int j)
        {
            if (map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
            {
                DoControlAndPlacement(i, j, jcontrol:'-',jnumber:1);
                DoControlAndPlacement(i, j, jcontrol: '+', jnumber: pieces);
            }
        }
        void Vertical(int i, int j)
        {
            if (map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
            {
                DoControlAndPlacement(i, j, icontrol: '-', inumber: 1);
                DoControlAndPlacement(i, j, icontrol: '+', inumber: pieces);
            }
        }
    }
    void SideMiddlePlacement(string shipName, int pieces, bool middleControl)
    {
        if (gameObject.GetComponent<Image>().color == orangeColor)
        {
            gameObject.GetComponent<Image>().color = Color.blue;
            defaultPlacedShip();
            PlayerPrefs.SetInt(shipName, pieces);
            bool control = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    {
                        if (i == 9)
                            DownController(i, j);
                        else if (j == 9)
                            RightController(i, j);
                        else
                        {
                            DownController(i, j);
                            RightController(i, j);
                        }
                        control = true;
                        break;
                    }
                }
                if (control)
                    break;
            }
        }

        void DownController(int i, int j)
        {
            if (map[i, j + 1].gameObject.GetComponent<Image>().color == Color.blue)
            {
                if ((j - 1) >= 0 && map[i, j - 1].gameObject.GetComponent<Image>().color == orangeColor)
                    DoControlAndPlacement(i, j, jcontrol: '-', jnumber: 1, orange:false);
                if ((j + pieces) <= 9 && map[i, j + pieces].gameObject.GetComponent<Image>().color == orangeColor)
                    DoControlAndPlacement(i, j, jcontrol: '+', jnumber: pieces, orange: false);
                if (middleControl)
                    VerticalController(i, j);
            }
        }

        void RightController(int i, int j)
        {
            if (map[i + 1, j].gameObject.GetComponent<Image>().color == Color.blue)
            {
                if ((i - 1) >= 0 && map[i - 1, j].gameObject.GetComponent<Image>().color == orangeColor)
                    DoControlAndPlacement(i, j, icontrol: '-', inumber: 1, orange: false);
                if ((i + pieces) <= 9 && map[i + pieces, j].gameObject.GetComponent<Image>().color == orangeColor)
                    DoControlAndPlacement(i, j, icontrol: '+', inumber: pieces, orange: false);
                if (middleControl)
                    HorizontalController(i, j);
            }
        }

        void VerticalController(int i, int j)
        {
            if ((i != 9 && j != 9) && map[i + 1, j + 1].gameObject.GetComponent<Image>().color == orangeColor)
                DoControlAndPlacement(i, j, icontrol: '+', inumber: 1, jcontrol:'+', jnumber:1 ,orange: false);
            if ((i != 0 && j != 9) && map[i - 1, j + 1].gameObject.GetComponent<Image>().color == orangeColor)
                DoControlAndPlacement(i, j, icontrol: '-', inumber: 1, jcontrol: '+', jnumber: 1, orange: false);
        }

        void HorizontalController(int i, int j)
        {
            if ((i != 9 && j != 0) && map[i + 1, j - 1].gameObject.GetComponent<Image>().color == orangeColor)
                DoControlAndPlacement(i, j, icontrol: '+', inumber: 1, jcontrol: '-', jnumber: 1, orange: false);
            if ((i != 9 && j != 9) && map[i + 1, j + 1].gameObject.GetComponent<Image>().color == orangeColor)
                DoControlAndPlacement(i, j, icontrol: '+', inumber: 1, jcontrol: '+', jnumber: 1, orange: false);
        }
    }
    void LastPlacement(string shipName, int pieces)
    {
        if (gameObject.GetComponent<Image>().color == orangeColor)
        {
            gameObject.GetComponent<Image>().color = Color.blue;
            deleteOrangeMap();
            PlayerPrefs.SetInt(shipName, pieces);
            GameObject.Find("ShipReadyButton").gameObject.GetComponent<Button>().enabled = true;
        }
    }
    void deleteOrangeMap()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color == orangeColor)
                    map[i, j].gameObject.GetComponent<Image>().color = greenColor;
    }
    void defaultPlacedShip()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                {
                    if (j != 0 && map[i, j - 1].gameObject.GetComponent<Image>().color != Color.black)
                        if (map[i, j - 1].gameObject.GetComponent<Image>().color != Color.blue && map[i, j - 1].gameObject.GetComponent<Image>().color != blueColor)
                            map[i, j - 1].gameObject.GetComponent<Image>().color = orangeColor;

                    if (j != 9 && map[i, j + 1].gameObject.GetComponent<Image>().color != Color.black)
                        if (map[i, j + 1].gameObject.GetComponent<Image>().color != Color.blue && map[i, j + 1].gameObject.GetComponent<Image>().color != blueColor)
                            map[i, j + 1].gameObject.GetComponent<Image>().color = orangeColor;

                    if (i != 0 && map[i - 1, j].gameObject.GetComponent<Image>().color != Color.black)
                        if (map[i - 1, j].gameObject.GetComponent<Image>().color != Color.blue && map[i - 1, j].gameObject.GetComponent<Image>().color != blueColor)
                            map[i - 1, j].gameObject.GetComponent<Image>().color = orangeColor;

                    if (i != 9 && map[i + 1, j].gameObject.GetComponent<Image>().color != Color.black)
                        if (map[i + 1, j].gameObject.GetComponent<Image>().color != Color.blue && map[i + 1, j].gameObject.GetComponent<Image>().color != blueColor)
                            map[i + 1, j].gameObject.GetComponent<Image>().color = orangeColor;
                }
    }

}