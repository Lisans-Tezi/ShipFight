using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PassiveShotting : MonoBehaviour 
{
    public Image Map;
    public GameObject[,] map = new GameObject[10, 10];

    public Image FirstShip;
    public Image SecondShip;
    public Image ThirdShip;
    public Image FourthShip;
    public Image FifthShip;

    public List<Sprite> Images;

    public List<Image> PassiveAttributes;

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public MoneyMaker moneymaker;
    public Tank tank;
    public SideStep sidestep;
    public Faker faker;
    public Healer healer;
    public LightBomber lightbomber;
    public BombCatcher bombcatcher;
    public Bomber bomber;
    public Boomer boomer;
    public FlameThrower flamethrower;

    private void Start()
    {
        Create();

        moneymaker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIMoneyMaker;
        tank = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AITank;
        sidestep = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStep;
        faker = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFaker;
        healer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIHealer;
        lightbomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AILightBomber;
        bombcatcher = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBombCatcher;
        bomber = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBomber;
        boomer = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIBoomer;
        flamethrower = GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AIFlameThrower;

        PlayerPrefs.SetInt("HitPerTurn", 3);
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
    public void Shot()
    {
        if(PlayerPrefs.GetString("AttackType") == "Passive" && (gameObject.GetComponent<Image>().color == greenColor || gameObject.GetComponent<Image>().color == Color.yellow))
        {
            string coordinat = gameObject.name;
            string[] xandy= coordinat.Split(":");

            int x = Convert.ToInt32(xandy[0]);
            int y = Convert.ToInt32(xandy[1]);

            DidMatched(x, y);
        }
    }
    void DidMatched(int x, int y)
    {
        if((x == moneymaker.FirstPieceI && y == moneymaker.FirstPieceJ) || 
            (x == moneymaker.SecondPieceI && y == moneymaker.SecondPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            moneymaker.HittedPiece++;             
            IncreaseScore();
            IsFinished("MoneyMaker");
        }
        else if((x == tank.FirstPieceI && y == tank.FirstPieceJ) || 
            (x == tank.SecondPieceI && y == tank.SecondPieceJ) || 
            (x == tank.ThirdPieceI && y == tank.ThirdPieceJ))
        {
            if (gameObject.GetComponent<Image>().color == greenColor)
            {
                gameObject.GetComponent<Image>().color = Color.yellow;
                IncreaseScore();
            }
            else if (gameObject.GetComponent<Image>().color == Color.yellow)
            {
                gameObject.GetComponent<Image>().color = redColor;
                tank.HittedPiece++;
                IncreaseScore();
                IsFinished("Tank");
            }              
        }
        else if ((x == sidestep.FirstPieceI && y == sidestep.FirstPieceJ) || 
            (x == sidestep.SecondPieceI && y == sidestep.SecondPieceJ) || 
            (x == sidestep.ThirdPieceI && y == sidestep.ThirdPieceJ))
        {
            if (GameObject.Find("SideStep").GetComponent<SideStep>().SideStepSkill)
            {
                if ((x-1>=0) && (x-1 != sidestep.FirstPieceI) && (x-1 != sidestep.SecondPieceI) && (x - 1 != sidestep.ThirdPieceI))
                {
                    if (map[x - 1, y].gameObject.GetComponent<Image>().color != redColor && 
                        map[x - 1, y].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x - 1, y].gameObject.GetComponent<Image>().color = blueColor;
                        FailedShot();
                    }    
                }
                else if ((x + 1 <= 9) && (x + 1 != sidestep.FirstPieceI) && (x + 1 != sidestep.SecondPieceI) && (x + 1 != sidestep.ThirdPieceI))
                {
                    if (map[x + 1, y].gameObject.GetComponent<Image>().color != redColor &&
                       map[x + 1, y].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x + 1, y].gameObject.GetComponent<Image>().color = blueColor;
                        FailedShot();
                    }
                }
                else if ((y - 1 >= 0) && (y - 1 != sidestep.FirstPieceJ) && (y - 1 != sidestep.SecondPieceJ) && (y - 1 != sidestep.ThirdPieceJ))
                {
                    if (map[x, y - 1].gameObject.GetComponent<Image>().color != redColor &&
                       map[x, y - 1].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x, y - 1].gameObject.GetComponent<Image>().color = blueColor;
                        FailedShot();
                    }
                }
                else if ((y + 1 <= 9) && (y + 1 != sidestep.FirstPieceJ) && (y + 1 != sidestep.SecondPieceJ) && (y + 1 != sidestep.ThirdPieceJ))
                {
                    if (map[x, y + 1].gameObject.GetComponent<Image>().color != redColor &&
                       map[x, y + 1].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x, y + 1].gameObject.GetComponent<Image>().color = blueColor;
                        FailedShot();
                    }
                }
                else
                {
                    gameObject.GetComponent<Image>().color = redColor;
                    sidestep.HittedPiece++;
                    IncreaseScore();
                    IsFinished("SideStep");
                }
                GameObject.Find("SideStep").GetComponent<SideStep>().SideStepSkill = false;
            }
            else
            {
                gameObject.GetComponent<Image>().color = redColor;
                sidestep.HittedPiece++;
                IncreaseScore();
                IsFinished("SideStep");
            }               
        }
        else if ((x == faker.FirstPieceI && y == faker.FirstPieceJ) || 
            (x == faker.SecondPieceI && y == faker.SecondPieceJ) || 
            (x == faker.ThirdPieceI && y == faker.ThirdPieceJ) || 
            (x == faker.FourthPieceI && y == faker.FourthPieceJ))
        {
            if (faker.FakerSkill == false)
            {
                faker.PassiveSkill(faker);
                faker.FakerSkill = true;
                GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().FailedShot();
                gameObject.GetComponent<Image>().color = blueColor;
                FailedShot();
            }
            else
            {
                gameObject.GetComponent<Image>().color = redColor;
                faker.HittedPiece++;
                IncreaseScore();
                IsFinished("Faker");
            }
            
        }
        else if ((x == healer.FirstPieceI && y == healer.FirstPieceJ) ||
            (x == healer.SecondPieceI && y == healer.SecondPieceJ) ||
            (x == healer.ThirdPieceI && y == healer.ThirdPieceJ) ||
            (x == healer.FourthPieceI && y == healer.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            healer.HittedPiece++;
            IncreaseScore();
            IsFinished("Healer");
        }
        else if ((x == lightbomber.FirstPieceI && y == lightbomber.FirstPieceJ) ||
            (x == lightbomber.SecondPieceI && y == lightbomber.SecondPieceJ) ||
            (x == lightbomber.ThirdPieceI && y == lightbomber.ThirdPieceJ) ||
            (x == lightbomber.FourthPieceI && y == lightbomber.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            lightbomber.HittedPiece++;
            IncreaseScore();
            IsFinished("LightBomber");
        }
        else if ((x == bombcatcher.FirstPieceI && y == bombcatcher.FirstPieceJ) ||
            (x == bombcatcher.SecondPieceI && y == bombcatcher.SecondPieceJ) ||
            (x == bombcatcher.ThirdPieceI && y == bombcatcher.ThirdPieceJ) ||
            (x == bombcatcher.FourthPieceI && y == bombcatcher.FourthPieceJ) ||
            (x == bombcatcher.FifthPieceI && y == bombcatcher.FifthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            bombcatcher.HittedPiece++;
            IncreaseScore();
            IsFinished("BombCatcher");
        }
        else if ((x == bomber.FirstPieceI && y == bomber.FirstPieceJ) ||
           (x == bomber.SecondPieceI && y == bomber.SecondPieceJ) ||
           (x == bomber.ThirdPieceI && y == bomber.ThirdPieceJ) ||
           (x == bomber.FourthPieceI && y == bomber.FourthPieceJ) ||
           (x == bomber.FifthPieceI && y == bomber.FifthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            bomber.HittedPiece++;
            IncreaseScore();
            IsFinished("Bomber");
        }
        else if ((x == boomer.FirstPieceI && y == boomer.FirstPieceJ) ||
           (x == boomer.SecondPieceI && y == boomer.SecondPieceJ) ||
           (x == boomer.ThirdPieceI && y == boomer.ThirdPieceJ) ||
           (x == boomer.FourthPieceI && y == boomer.FourthPieceJ) ||
           (x == boomer.FifthPieceI && y == boomer.FifthPieceJ) ||
           (x == boomer.SixthPieceI && y == boomer.SixthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            boomer.HittedPiece++;
            IncreaseScore();
            IsFinished("Boomer");
        }
        else if ((x == flamethrower.FirstPieceI && y == flamethrower.FirstPieceJ) ||
           (x == flamethrower.SecondPieceI && y == flamethrower.SecondPieceJ) ||
           (x == flamethrower.ThirdPieceI && y == flamethrower.ThirdPieceJ) ||
           (x == flamethrower.FourthPieceI && y == flamethrower.FourthPieceJ) ||
           (x == flamethrower.FifthPieceI && y == flamethrower.FifthPieceJ) ||
           (x == flamethrower.SixthPieceI && y == flamethrower.SixthPieceJ) ||
           (x == flamethrower.SeventhPieceI && y == flamethrower.SeventhPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            flamethrower.HittedPiece++;
            IncreaseScore();
            IsFinished("FlameThrower");
        }
        else
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().FailedShot();
            gameObject.GetComponent<Image>().color = blueColor;
            FailedShot();    
        } 
    }
    void FailedShot()
    {                                  
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;

        GameObject.Find("GameManager").GetComponent<Control>().control();
        Invoke("SkipRound", 1.5f);
    }
    void IsFinished(string Name)
    {
        if (Name=="MoneyMaker")
        {
            if (moneymaker.HittedPiece == moneymaker.Piece)
            {
                ImageActiveControl(0);
                GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>().increase=0;
            }                               
        }                   
        else if (Name == "Tank")
        {
            if (tank.HittedPiece == tank.Piece)
                ImageActiveControl(1);
        }
        else if (Name == "SideStep")
        {
            if (sidestep.HittedPiece == sidestep.Piece)
                ImageActiveControl(2);
        }
        else if (Name == "Faker")
        {
            if (faker.HittedPiece == faker.Piece)
                ImageActiveControl(3);
        }
        else if (Name == "Healer")
        {
            if (healer.HittedPiece == healer.Piece)
                ImageActiveControl(4);
        }
        else if (Name == "LightBomber")
        {
            if (lightbomber.HittedPiece == lightbomber.Piece)
                ImageActiveControl(5);
        }
        else if (Name == "BombCatcher")
        {
            if (bombcatcher.HittedPiece == bombcatcher.Piece)
                ImageActiveControl(6);
        }
        else if (Name == "Bomber")
        {
            if (bomber.HittedPiece == bomber.Piece)
                ImageActiveControl(7);
        }
        else if (Name == "Boomer")
        {
            if (boomer.HittedPiece == boomer.Piece)
                ImageActiveControl(8);
        }
        else if (Name == "FlameThrower")
        {
            if (flamethrower.HittedPiece == flamethrower.Piece)
                ImageActiveControl(9);
        }
        void ImageActiveControl(int shipNumber)
        {
            if (FirstShip.GetComponent<Image>().IsActive())
            {
                if (SecondShip.GetComponent<Image>().IsActive())
                {
                    if (ThirdShip.GetComponent<Image>().IsActive())
                    {
                        if (FourthShip.GetComponent<Image>().IsActive())
                        {
                            FifthShip.GetComponent<Image>().enabled = true;
                            FifthShip.GetComponent<Image>().sprite = Images[shipNumber];
                            GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().Win();
                            Invoke("ReturnMenu",2);
                        }
                        else
                        {
                            FourthShip.GetComponent<Image>().enabled = true;
                            FourthShip.GetComponent<Image>().sprite = Images[shipNumber];

                        }
                    }
                    else
                    {
                        ThirdShip.GetComponent<Image>().enabled = true;
                        ThirdShip.GetComponent<Image>().sprite = Images[shipNumber];

                    }
                }
                else
                {
                    SecondShip.GetComponent<Image>().enabled = true;
                    SecondShip.GetComponent<Image>().sprite = Images[shipNumber];
                }
            }
            else
            {
                FirstShip.GetComponent<Image>().enabled = true;
                FirstShip.GetComponent<Image>().sprite = Images[shipNumber];
            }
        }
    }
    void ReturnMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    void IncreaseScore()
    {
        GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().SuccessfullShot();
        int point= Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        point++;
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();

        PlayerPrefs.SetInt("HitPerTurn", PlayerPrefs.GetInt("HitPerTurn") - 1);
        
        if(PlayerPrefs.GetInt("HitPerTurn") == 0)
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().ToManyShot();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;


            GameObject.Find("GameManager").GetComponent<Control>().control();
            Invoke("SkipRound", 1.5f);
        }
    }

    void SkipRound()
    {
        PassiveAttributes.ForEach(p => 
        {
            p.GetComponent<Button>().enabled = true;
            p.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            p.GetComponent<PassiveAttribute>().isSelected = false;
        });

        map=healer.PassiveSkill(map,whiteColor);
        PlayerPrefs.SetInt("HitPerTurn", 3);
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeCamera();
    }
}
