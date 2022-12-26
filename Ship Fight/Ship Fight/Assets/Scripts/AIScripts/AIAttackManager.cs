using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIAttackManager : MonoBehaviour
{
    public Image Map;
    public Image AIMap;
    GameObject[,] map = new GameObject[10, 10];
    GameObject[,] AImap = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    void Start()
    {
        Create();
        CreateAIMap();
        
        PlayerPrefs.SetInt("AIAttackHitPerTurn",3);
        InvokeRepeating("Attack",2,2);
    }       
    void CreateAIMap()
    {
        int k = 0;
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                AImap[i, j] = AIMap.transform.GetChild(k).gameObject;
                k++;
            }
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
    void Attack()
    {
        if (gameObject.activeInHierarchy)
        {
            if (PlayerPrefs.GetInt("AIAttackHitPerTurn") > 0)
            {
                int x = Random.Range(0, 10);
                int y = Random.Range(0, 10);

                if (map[x, y].gameObject.GetComponent<Image>().color == Color.black)
                {
                    if (AttackTank(x, y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }
                    else if (AttackSideStep(x, y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }
                    else if (AttackFaker(x,y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", 0);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                    }
                    else if(AttackHealer(x,y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }
                    else if (AttackLightBomber(x,y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }
                    else if (AttackBombCatcher(x, y))
                    {
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }
                    else
                    {
                        map[x, y].gameObject.GetComponent<Image>().color = redColor;
                        PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                    }  
                }
                else if (map[x, y].gameObject.GetComponent<Image>().color == Color.yellow)
                {
                    map[x, y].gameObject.GetComponent<Image>().color = redColor;
                    PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                    GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                }
                else if (map[x, y].gameObject.GetComponent<Image>().color == whiteColor)
                {
                    map[x, y].gameObject.GetComponent<Image>().color = blueColor;
                    GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                    Invoke("SkipRound", 1.5f);
                }
                else
                {
                    Attack();
                }
                bool control = true;

                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if(map[i, j].gameObject.GetComponent<Image>().color == Color.black || map[i, j].gameObject.GetComponent<Image>().color == Color.yellow)
                            control = false;

                if (control)
                {
                    GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().Lose();
                    Invoke("ReturnMenu",2);                        
                }                       
            }   
            else
            {
                Invoke("SkipRound",1.5f);
            }
        }                       
    }
    bool AttackTank(int x, int y)
    {
        var Tank = GameObject.Find("Tank").GetComponent<Tank>();
        if ((x == Tank.FirstPieceI && y == Tank.FirstPieceJ) ||
            (x == Tank.SecondPieceI && y == Tank.SecondPieceJ) ||
            (x == Tank.ThirdPieceI && y == Tank.ThirdPieceJ))
        {
            map[x, y].gameObject.GetComponent<Image>().color = Color.yellow;
            Tank.HittedPiece++;
            return true;                 
        }
        return false;
    }
    bool AttackSideStep(int x, int y)
    {
        var SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        if ((x == SideStep.FirstPieceI && y == SideStep.FirstPieceJ) ||
            (x == SideStep.SecondPieceI && y == SideStep.SecondPieceJ) ||
            (x == SideStep.ThirdPieceI && y == SideStep.ThirdPieceJ))
        {
            if (SideStep.SideStepSkill)
            {
                if (x - 1 >= 0 && (x - 1 != SideStep.FirstPieceI) && (x - 1 != SideStep.SecondPieceI) && (x - 1 != SideStep.ThirdPieceI))
                {
                    if (map[x - 1, y].gameObject.GetComponent<Image>().color != redColor &&
                        map[x - 1, y].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x - 1, y].gameObject.GetComponent<Image>().color = blueColor;
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                        SideStep.PassiveSkill();
                        Invoke("SkipRound", 1.5f);
                    }                       
                }
                else if (x + 1 <= 9 && (x + 1 != SideStep.FirstPieceI) && (x + 1 != SideStep.SecondPieceI) && (x + 1 != SideStep.ThirdPieceI))
                {
                    if (map[x + 1, y].gameObject.GetComponent<Image>().color != redColor &&
                        map[x + 1, y].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x + 1, y].gameObject.GetComponent<Image>().color = blueColor;
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                        SideStep.PassiveSkill();
                        Invoke("SkipRound", 1.5f);
                    }                        
                }
                else if (y - 1 >= 0 && (y - 1 != SideStep.FirstPieceJ) && (y - 1 != SideStep.SecondPieceJ) && (y - 1 != SideStep.ThirdPieceJ))
                {
                    if (map[x, y - 1].gameObject.GetComponent<Image>().color != redColor &&
                        map[x, y - 1].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x, y - 1].gameObject.GetComponent<Image>().color = blueColor;
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                        SideStep.PassiveSkill();
                        Invoke("SkipRound", 1.5f);
                    }                        
                }
                else if (y + 1 <= 9 && (y + 1 != SideStep.FirstPieceJ) && (y + 1 != SideStep.SecondPieceJ) && (y + 1 != SideStep.ThirdPieceJ))
                {
                    if (map[x, y + 1].gameObject.GetComponent<Image>().color != redColor &&
                        map[x, y + 1].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x, y + 1].gameObject.GetComponent<Image>().color = blueColor;
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
                        SideStep.PassiveSkill();
                        Invoke("SkipRound", 1.5f);
                    }                    
                }
                else
                {
                    map[x, y].gameObject.GetComponent<Image>().color = redColor;
                    SideStep.PassiveSkill();
                }
                return true;
            }
            else
            {
                map[x, y].gameObject.GetComponent<Image>().color = redColor;
                SideStep.HittedPiece++;
                return true;
            }
        }
        return false;
    }
    bool AttackFaker(int x, int y)
    {
        var Faker = GameObject.Find("Faker").GetComponent<Faker>();
        if((x == Faker.FirstPieceI && y == Faker.FirstPieceJ) ||
          (x == Faker.SecondPieceI && y == Faker.SecondPieceJ) ||
          (x == Faker.ThirdPieceI && y == Faker.ThirdPieceJ) || 
          (x == Faker.FourthPieceI && y == Faker.FourthPieceJ))
        {
            if (Faker.FakerSkill== false)
            {
                map=Faker.AIPassiveSkill(map);                 
                Faker.FakerSkill = true;
            }
            else
            {
                map[x, y].gameObject.GetComponent<Image>().color = redColor;
            }
            Faker.HittedPiece++;
            return true;
        }
        return false;
    }
    bool AttackHealer(int x, int y)
    {
        var Healer = GameObject.Find("Healer").GetComponent<Healer>();
        if ((x == Healer.FirstPieceI && y == Healer.FirstPieceJ) ||
          (x == Healer.SecondPieceI && y == Healer.SecondPieceJ) ||
          (x == Healer.ThirdPieceI && y == Healer.ThirdPieceJ) ||
          (x == Healer.FourthPieceI && y == Healer.FourthPieceJ))
        {                 
            map[x, y].gameObject.GetComponent<Image>().color = redColor;
            Healer.HittedPiece++;
            return true;
        }
        return false;
    }
    bool AttackLightBomber(int x, int y)
    {
        var LightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        if ((x == LightBomber.FirstPieceI && y == LightBomber.FirstPieceJ) ||
          (x == LightBomber.SecondPieceI && y == LightBomber.SecondPieceJ) ||
          (x == LightBomber.ThirdPieceI && y == LightBomber.ThirdPieceJ) ||
          (x == LightBomber.FourthPieceI && y == LightBomber.FourthPieceJ))
        {
            map[x, y].gameObject.GetComponent<Image>().color = redColor;
            LightBomber.HittedPiece++;              
            AImap = LightBomber.AIPassiveSkill(AImap);              
            return true;
        }
        return false;
    }
    bool AttackBombCatcher(int x, int y)
    {
        var BombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
        if ((x == BombCatcher.FirstPieceI && y == BombCatcher.FirstPieceJ) ||
          (x == BombCatcher.SecondPieceI && y == BombCatcher.SecondPieceJ) ||
          (x == BombCatcher.ThirdPieceI && y == BombCatcher.ThirdPieceJ) ||
          (x == BombCatcher.FourthPieceI && y == BombCatcher.FourthPieceJ) || 
          (x == BombCatcher.FifthPieceI && y == BombCatcher.FifthPieceJ))
        {
            map[x, y].gameObject.GetComponent<Image>().color = redColor;
            BombCatcher.HittedPiece++;
            BombCatcher.AIPassiveSkill();
            return true;
        }
        return false;
    }
    void ReturnMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
    void SkipRound()
    {
        var Healer = GameObject.Find("Healer").GetComponent<Healer>();
        if (Healer.FirstPieceI>=0)
        {
            map = Healer.PassiveSkill(map, Color.black);
        }           

        PlayerPrefs.SetInt("AIAttackHitPerTurn", 3);
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeCamera(true);
    }

    
}


