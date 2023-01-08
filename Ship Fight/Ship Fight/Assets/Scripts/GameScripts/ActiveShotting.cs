using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActiveShotting : MonoBehaviour
{
    public Image FirstShip;
    public Image SecondShip;
    public Image ThirdShip;
    public Image FourthShip;
    public Image FifthShip;

    public List<Sprite> Images;

    public List<Image> PassiveAttributes;

    public Image Map;
    GameObject[,] map = new GameObject[10, 10];

    public Image AIMap;
    GameObject[,] AImap = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    MoneyMaker moneymaker;
    Tank tank;
    SideStep sidestep;
    Faker faker;
    Healer healer;
    LightBomber lightbomber;
    BombCatcher bombcatcher;
    Bomber bomber;
    Boomer boomer;
    FlameThrower flamethrower;


    void Start()
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

        var MoneyMaker = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
        var Tank = GameObject.Find("Tank").GetComponent<Tank>();
        var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        
        var Healer = GameObject.Find("Healer").GetComponent<Healer>();
        var LightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        var BombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
        
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

        k = 0;
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                AImap[i, j] = AIMap.transform.GetChild(k).gameObject;
                k++;
            }
    }

    public void Shot()
    {
        if (PlayerPrefs.GetString("AttackType") == "Active" && 
            gameObject.GetComponent<Image>().color == greenColor || (
                (PlayerPrefs.GetString("ShootingShip") != "FlameThrower" &&
                PlayerPrefs.GetString("ShootingShip") != "Boomer" &&
                PlayerPrefs.GetString("ShootingShip") != "Bomber") &&
            gameObject.GetComponent<Image>().color == Color.yellow))
        {
            string coordinat = gameObject.name;
            string[] xandy = coordinat.Split(":");

            int x = Convert.ToInt32(xandy[0]);
            int y = Convert.ToInt32(xandy[1]);

            DidMatched(x, y);
        }
    }

    void DidMatched(int x, int y)
    {
        var Faker = GameObject.Find("Faker").GetComponent<Faker>();
        var Bomber = GameObject.Find("Bomber").GetComponent<Bomber>();
        var Boomer = GameObject.Find("Boomer").GetComponent<Boomer>();
        var FlameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();

        if ((x == moneymaker.FirstPieceI && y == moneymaker.FirstPieceJ) ||
            (x == moneymaker.SecondPieceI && y == moneymaker.SecondPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            moneymaker.HittedPiece++;
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Faker.ActiveSkill(map, "MoneyMaker");
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x,y);
            IsFinished("MoneyMaker");
        }
        else if ((x == tank.FirstPieceI && y == tank.FirstPieceJ) ||
            (x == tank.SecondPieceI && y == tank.SecondPieceJ) ||
            (x == tank.ThirdPieceI && y == tank.ThirdPieceJ))
        {
            if (gameObject.GetComponent<Image>().color == greenColor)
            {
                gameObject.GetComponent<Image>().color = Color.yellow;
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                map = Bomber.ActiveSkill(map, x);
                map = Boomer.ActiveSkill(map, y);
                FlameThrower.ActiveSkill(map);
                IncreaseScore(x,y);
                IsFinished("Tank");

            }
            else if (gameObject.GetComponent<Image>().color == Color.yellow)
            {
                gameObject.GetComponent<Image>().color = redColor;
                tank.HittedPiece++;
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                map = Bomber.ActiveSkill(map, x);
                map = Boomer.ActiveSkill(map, y);
                FlameThrower.ActiveSkill(map);
                IncreaseScore(x,y);
                IsFinished("Tank");
            }
            map = Faker.ActiveSkill(map, "Tank");
            
            IsFinished("Tank");
        }
        else if ((x == sidestep.FirstPieceI && y == sidestep.FirstPieceJ) ||
            (x == sidestep.SecondPieceI && y == sidestep.SecondPieceJ) ||
            (x == sidestep.ThirdPieceI && y == sidestep.ThirdPieceJ))
        {
            if (sidestep.SideStepSkill)
            {
                if ((x - 1 >= 0) &&
                    (x - 1 != sidestep.FirstPieceI) &&
                    (x - 1 != sidestep.SecondPieceI) &&
                    (x - 1 != sidestep.ThirdPieceI &&
                    map[x - 1, y].gameObject.GetComponent<Image>().color != redColor &&
                    map[x - 1, y].gameObject.GetComponent<Image>().color != blueColor &&
                    sidestep.PassiveSkill(x - 1, y)))
                {
                    map[x - 1, y].gameObject.GetComponent<Image>().color = blueColor;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    FailedShot();
                }
                else if ((x + 1 <= 9) &&
                    (x + 1 != sidestep.FirstPieceI) &&
                    (x + 1 != sidestep.SecondPieceI) &&
                    (x + 1 != sidestep.ThirdPieceI &&
                    map[x + 1, y].gameObject.GetComponent<Image>().color != redColor &&
                    map[x + 1, y].gameObject.GetComponent<Image>().color != blueColor &&
                    sidestep.PassiveSkill(x + 1, y)))
                {
                    map[x + 1, y].gameObject.GetComponent<Image>().color = blueColor;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    FailedShot();
                }
                else if ((y - 1 >= 0) &&
                    (y - 1 != sidestep.FirstPieceI) &&
                    (y - 1 != sidestep.SecondPieceI) &&
                    (y - 1 != sidestep.ThirdPieceI &&
                    map[x, y - 1].gameObject.GetComponent<Image>().color != redColor &&
                    map[x, y - 1].gameObject.GetComponent<Image>().color != blueColor &&
                    sidestep.PassiveSkill(x, y - 1)))
                {
                    map[x, y - 1].gameObject.GetComponent<Image>().color = blueColor;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    FailedShot();
                }
                else if ((y + 1 <= 9) &&
                    (y + 1 != sidestep.FirstPieceI) &&
                    (y + 1 != sidestep.SecondPieceI) &&
                    (y + 1 != sidestep.ThirdPieceI &&
                    map[x, y + 1].gameObject.GetComponent<Image>().color != redColor &&
                    map[x, y + 1].gameObject.GetComponent<Image>().color != blueColor &&
                    sidestep.PassiveSkill(x, y + 1)))
                {
                    map[x, y + 1].gameObject.GetComponent<Image>().color = blueColor;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    FailedShot();
                }
                else
                {
                    gameObject.GetComponent<Image>().color = redColor;
                    sidestep.HittedPiece++;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    map = Bomber.ActiveSkill(map, x);
                    map = Boomer.ActiveSkill(map, y);
                    FlameThrower.ActiveSkill(map);
                    IncreaseScore(x, y);
                    map = faker.ActiveSkill(map, "SideStep");
                    IsFinished("SideStep");
                    sidestep.SideStepSkill = false;
                }
            }
            else
            {
                gameObject.GetComponent<Image>().color = redColor;
                sidestep.HittedPiece++;
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                map = Bomber.ActiveSkill(map, x);
                map = Boomer.ActiveSkill(map, y);
                FlameThrower.ActiveSkill(map);
                IncreaseScore(x, y);
                map = faker.ActiveSkill(map, "SideStep");
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
                if(faker.PassiveSkill(faker, map))
                {
                    gameObject.GetComponent<Image>().color = blueColor;
                    faker.FakerSkill = true;
                    GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().FailedShot();
                    FailedShot();
                }
                else
                {
                    gameObject.GetComponent<Image>().color = redColor;
                    faker.HittedPiece++;
                    faker.FakerSkill = true;
                    PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                    map = Bomber.ActiveSkill(map, x);
                    map = Boomer.ActiveSkill(map, y);
                    FlameThrower.ActiveSkill(map);
                    IncreaseScore(x, y);
                    map = faker.ActiveSkill(map, "Faker");
                    IsFinished("Faker");
                }
            }
            else
            {
                gameObject.GetComponent<Image>().color = redColor;
                faker.HittedPiece++;
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                map = Bomber.ActiveSkill(map, x);
                map = Boomer.ActiveSkill(map, y);
                FlameThrower.ActiveSkill(map);
                IncreaseScore(x,y);
                map = faker.ActiveSkill(map, "Faker");
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
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x,y);
            map = faker.ActiveSkill(map, "Healer");
            IsFinished("Healer");
        }
        else if ((x == lightbomber.FirstPieceI && y == lightbomber.FirstPieceJ) ||
            (x == lightbomber.SecondPieceI && y == lightbomber.SecondPieceJ) ||
            (x == lightbomber.ThirdPieceI && y == lightbomber.ThirdPieceJ) ||
            (x == lightbomber.FourthPieceI && y == lightbomber.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            lightbomber.HittedPiece++;
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x, y);
            map = faker.ActiveSkill(map, "LightBomber");
            AImap = lightbomber.AIPassiveSkill(AImap);
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
            if (bombcatcher.control == true)
            {
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
                map = Bomber.ActiveSkill(map, x);
                map = Boomer.ActiveSkill(map, y);
                FlameThrower.ActiveSkill(map);
                IncreaseScore(x, y);
                map = faker.ActiveSkill(map, "BombCatcher");
                IsFinished("BombCatcher");
            }
            else
            {
                PlayerPrefs.SetInt("ActiveHitPerTurn", 0);
                bombcatcher.control = true;
                IncreaseScore(x, y);
                map = faker.ActiveSkill(map, "BombCatcher");
                IsFinished("BombCatcher");
            }
        }
        else if ((x == bomber.FirstPieceI && y == bomber.FirstPieceJ) ||
           (x == bomber.SecondPieceI && y == bomber.SecondPieceJ) ||
           (x == bomber.ThirdPieceI && y == bomber.ThirdPieceJ) ||
           (x == bomber.FourthPieceI && y == bomber.FourthPieceJ) ||
           (x == bomber.FifthPieceI && y == bomber.FifthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            bomber.HittedPiece++;
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x, y);
            map = faker.ActiveSkill(map, "Bomber");
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
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x, y);
            boomer.PassiveSkill(); 
            map = faker.ActiveSkill(map, "Boomer");
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
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            IncreaseScore(x, y);
            map = faker.ActiveSkill(map, "FlameThrower");
            IsFinished("FlameThrower");
        }
        else
        {
            GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().FailedShot();
            gameObject.GetComponent<Image>().color = blueColor;
            PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") - 1);
            map = Bomber.ActiveSkill(map, x);
            map = Boomer.ActiveSkill(map, y);
            FlameThrower.ActiveSkill(map);
            FailedShot();
        }
    }

    void FailedShot()
    {
        var Tank = GameObject.Find("Tank").GetComponent<Tank>();

        if(PlayerPrefs.GetString("ShootingShip") == "MoneyMaker")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "Tank" && Tank.ActiveSkill)
        {
            PlayerPrefs.SetInt("ActiveHitPerTurn", 1);
            Tank.ActiveSkill = false;
        }
        else if(PlayerPrefs.GetString("ShootingShip") == "SideStep")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "Healer")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "LightBomber")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "BombCatcher")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "Bomber")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "Boomer")
        {
            HitPerTurnControl();
        }
        else if (PlayerPrefs.GetString("ShootingShip") == "FlameThrower")
        {
            HitPerTurnControl();
        }
        else
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                    {
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                    }
            GameObject.Find("GameManager").GetComponent<Control>().control();
            Invoke("SkipRound", 1.5f);
        }
        int RemainingShotPoint = PlayerPrefs.GetInt("ActiveHitPerTurn");
        GameObject.Find("RemainingShotPoint").GetComponent<TextMeshProUGUI>().text = RemainingShotPoint.ToString();
    }

    void IncreaseScore(int x, int y)
    {
        GameObject.Find("AttackInfoPanelText").GetComponent<TextManager>().SuccessfullShot();
        int point = Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        point++;
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();

        var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        if (PlayerPrefs.GetString("ShootingShip") == "SideStep" && SideStep.ActiveSkill)
        {
            PlayerPrefs.SetInt("ActiveHitPerTurn", SideStep.SideStepActiveSkill(x,y));
            SideStep.ActiveSkill = false;
            int RemainingShotPoint = PlayerPrefs.GetInt("ActiveHitPerTurn");
            GameObject.Find("RemainingShotPoint").GetComponent<TextMeshProUGUI>().text = RemainingShotPoint.ToString();
        }
        else
        {
            HitPerTurnControl();
        }
    }

    void HitPerTurnControl()
    {
        int RemainingShotPoint = PlayerPrefs.GetInt("ActiveHitPerTurn");
        GameObject.Find("RemainingShotPoint").GetComponent<TextMeshProUGUI>().text = RemainingShotPoint.ToString();
        if (PlayerPrefs.GetInt("ActiveHitPerTurn") <= 0)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;


            GameObject.Find("GameManager").GetComponent<Control>().control();
            Invoke("SkipRound", 1.5f);
        }
    }

    void IsFinished(string Name)
    {
        if (Name == "MoneyMaker")
        {
            if (moneymaker.HittedPiece == moneymaker.Piece)
            {
                ImageActiveControl(0);
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
            if (lightbomber.HittedPiece == lightbomber.Piece + 1)
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
                            for (int i = 0; i < 10; i++)
                                for (int j = 0; j < 10; j++)
                                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                                    {
                                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
                                    }
                            CancelInvoke("SkipRound");
                            Invoke("ReturnMenu", 2);
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

    void SkipRound()
    {
        PassiveAttributes.ForEach(p =>
        {
            p.GetComponent<Button>().enabled = true;
            p.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            p.GetComponent<PassiveAttribute>().isSelected = false;
        });

        ShipActiveTurnDown();


        if (healer.FirstPieceI >= 0)
        {
            map = healer.PassiveSkill(map, whiteColor);
        }
        PlayerPrefs.SetInt("HitPerTurn", 3);
        PlayerPrefs.SetString("AttackType", "");
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeCamera();
    }

    void ShipActiveTurnDown()
    {
        if(PlayerPrefs.GetInt("MoneyMakerActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("MoneyMakerActiveTurn", PlayerPrefs.GetInt("MoneyMakerActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("TankActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("TankActiveTurn", PlayerPrefs.GetInt("TankActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("SideStepActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("SideStepActiveTurn", PlayerPrefs.GetInt("SideStepActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("FakerActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("FakerActiveTurn", PlayerPrefs.GetInt("FakerActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("HealerActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("HealerActiveTurn", PlayerPrefs.GetInt("HealerActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("LightBomberActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("LightBomberActiveTurn", PlayerPrefs.GetInt("LightBomberActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("BombCatcherActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("BombCatcherActiveTurn", PlayerPrefs.GetInt("BombCatcherActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("BomberActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("BomberActiveTurn", PlayerPrefs.GetInt("BomberActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("BoomerActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("BoomerActiveTurn", PlayerPrefs.GetInt("BoomerActiveTurn") - 1);
        }
        if (PlayerPrefs.GetInt("FlameThrowerActiveTurn") > 0)
        {
            PlayerPrefs.SetInt("FlameThrowerActiveTurn", PlayerPrefs.GetInt("FlameThrowerActiveTurn") - 1);
        }
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
