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
    void Start()
    {
        Create();
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
                            map[x, y].gameObject.GetComponent<Image>().color = redColor;
                            PlayerPrefs.SetInt("AIAttackHitPerTurn", PlayerPrefs.GetInt("AIAttackHitPerTurn") - 1);
                            GameObject.Find("DefendInfoPanelText").GetComponent<TextManager>().AIHitted();
                            break;
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
                        if(map[i, j].gameObject.GetComponent<Image>().color == Color.black)
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

