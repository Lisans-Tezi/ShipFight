using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIAttackManager : MonoBehaviour
{
    public Image Map;
    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    Tank Tank;
    SideStep SideStep;
    void Start()
    {
        Create();
        
        SideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        PlayerPrefs.SetInt("AIAttackHitPerTurn",3);
        InvokeRepeating("Attack",2,2);
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

                    }
                    else if (AttackSideStep(x, y))
                    {

                    }
                    else
                    {
                        map[x, y].gameObject.GetComponent<Image>().color = redColor;
                    }                      

                    PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                    GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
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
                    while (true)
                    {
                        x = Random.Range(0, 10);
                        y = Random.Range(0, 10);
                        if (map[x, y].gameObject.GetComponent<Image>().color == Color.black)
                        {
                            if (AttackTank(x, y))
                            {

                            }
                            else if (AttackSideStep(x, y))
                            {

                            }
                            else
                            {
                                map[x, y].gameObject.GetComponent<Image>().color = redColor;
                            }

                            PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                            GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                            break;
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
                            break;
                        }
                    }
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
            return true;
        }
        return false;
    }
    bool AttackSideStep(int x, int y)
    {
        if ((x == SideStep.FirstPieceI && y == SideStep.FirstPieceJ) ||
            (x == SideStep.SecondPieceI && y == SideStep.SecondPieceJ) ||
            (x == SideStep.ThirdPieceI && y == SideStep.ThirdPieceJ))
        {
            if (GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStepSkill)
            {
                if (x - 1 >= 0 && (x - 1 != SideStep.FirstPieceI) && (x - 1 != SideStep.SecondPieceI) && (x - 1 != SideStep.ThirdPieceI))
                {
                    if (map[x - 1, y].gameObject.GetComponent<Image>().color != redColor &&
                        map[x - 1, y].gameObject.GetComponent<Image>().color != blueColor)
                    {
                        map[x - 1, y].gameObject.GetComponent<Image>().color = blueColor;
                        GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIMissed();
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
                        Invoke("SkipRound", 1.5f);
                    }                    
                }
                else
                {
                    map[x, y].gameObject.GetComponent<Image>().color = redColor;
                }
                GameObject.Find("AIManager").GetComponent<AIShipPlacing>().AISideStepSkill = false;
                return true;
            }
            else
            {
                map[x, y].gameObject.GetComponent<Image>().color = redColor;
                return true;
            }
        }
        return false;
    }

    void ReturnMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
    void SkipRound()
    {
        PlayerPrefs.SetInt("AIAttackHitPerTurn", 3);
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeCamera(true);
    }
}

