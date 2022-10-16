using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassiveShotting : MonoBehaviour 
{
    public Image Map;
    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 100);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 200);
    Color blueColor = new Color32(0, 0, 255, 200);

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
        if(PlayerPrefs.GetString("AttackType") == "Passive" && gameObject.GetComponent<Image>().color == greenColor)
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
            Debug.Log("MoneyMaker hit");
            IncreaseScore();
        }
        else if((x == tank.FirstPieceI && y == tank.FirstPieceJ) || 
            (x == tank.SecondPieceI && y == tank.SecondPieceJ) || 
            (x == tank.ThirdPieceI && y == tank.ThirdPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            tank.HittedPiece++;
            Debug.Log("Tank hit");
            IncreaseScore();
        }
        else if ((x == sidestep.FirstPieceI && y == sidestep.FirstPieceJ) || 
            (x == sidestep.SecondPieceI && y == sidestep.SecondPieceJ) || 
            (x == sidestep.ThirdPieceI && y == sidestep.ThirdPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            sidestep.HittedPiece++;
            Debug.Log("SideStep hit");
            IncreaseScore();
        }
        else if ((x == faker.FirstPieceI && y == faker.FirstPieceJ) || 
            (x == faker.SecondPieceI && y == faker.SecondPieceJ) || 
            (x == faker.ThirdPieceI && y == faker.ThirdPieceJ) || 
            (x == faker.FourthPieceI && y == faker.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            faker.HittedPiece++;
            Debug.Log("Faker hit");
            IncreaseScore();
        }
        else if ((x == healer.FirstPieceI && y == healer.FirstPieceJ) ||
            (x == healer.SecondPieceI && y == healer.SecondPieceJ) ||
            (x == healer.ThirdPieceI && y == healer.ThirdPieceJ) ||
            (x == healer.FourthPieceI && y == healer.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            healer.HittedPiece++;
            Debug.Log("Healer hit");
            IncreaseScore();
        }
        else if ((x == lightbomber.FirstPieceI && y == lightbomber.FirstPieceJ) ||
            (x == lightbomber.SecondPieceI && y == lightbomber.SecondPieceJ) ||
            (x == lightbomber.ThirdPieceI && y == lightbomber.ThirdPieceJ) ||
            (x == lightbomber.FourthPieceI && y == lightbomber.FourthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            lightbomber.HittedPiece++;
            Debug.Log("Light Bomber hit");
            IncreaseScore();
        }
        else if ((x == bombcatcher.FirstPieceI && y == bombcatcher.FirstPieceJ) ||
            (x == bombcatcher.SecondPieceI && y == bombcatcher.SecondPieceJ) ||
            (x == bombcatcher.ThirdPieceI && y == bombcatcher.ThirdPieceJ) ||
            (x == bombcatcher.FourthPieceI && y == bombcatcher.FourthPieceJ) ||
            (x == bombcatcher.FifthPieceI && y == bombcatcher.FifthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            bombcatcher.HittedPiece++;
            Debug.Log("BombCacther hit");
            IncreaseScore();
        }
        else if ((x == bomber.FirstPieceI && y == bomber.FirstPieceJ) ||
           (x == bomber.SecondPieceI && y == bomber.SecondPieceJ) ||
           (x == bomber.ThirdPieceI && y == bomber.ThirdPieceJ) ||
           (x == bomber.FourthPieceI && y == bomber.FourthPieceJ) ||
           (x == bomber.FifthPieceI && y == bomber.FifthPieceJ))
        {
            gameObject.GetComponent<Image>().color = redColor;
            bomber.HittedPiece++;
            Debug.Log("Bomber hit");
            IncreaseScore();
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
            Debug.Log("Boomer hit");
            IncreaseScore();
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
            Debug.Log("FlameThrower hit");
            IncreaseScore();
        }
        else
        {
            GameObject.Find("InfoPanelText").GetComponent<TextManager>().FailedShot();
            gameObject.GetComponent<Image>().color = blueColor;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
            Invoke("SkipRound",1.5f);
        } 
    }

    void IncreaseScore()
    {
        GameObject.Find("InfoPanelText").GetComponent<TextManager>().SuccessfullShot();
        int point= Convert.ToInt32(GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text);
        point++;
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point.ToString();

        PlayerPrefs.SetInt("HitPerTurn", PlayerPrefs.GetInt("HitPerTurn") - 1);
        
        if(PlayerPrefs.GetInt("HitPerTurn") == 0)
        {
            GameObject.Find("InfoPanelText").GetComponent<TextManager>().ToManyShot();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (map[i, j].gameObject.GetComponent<Image>().color == greenColor)
                        map[i, j].gameObject.GetComponent<Image>().color = whiteColor;

            Invoke("SkipRound", 1.5f);
        }
    }

    void SkipRound()
    {
        PlayerPrefs.SetInt("HitPerTurn", 3);
        //GameObject.Find("TurnPoint").GetComponent<TurnManager>().AddTurn();
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeCamera();          
    }
}
