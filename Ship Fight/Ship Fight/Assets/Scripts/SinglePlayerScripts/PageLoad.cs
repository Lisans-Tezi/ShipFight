using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageLoad : MonoBehaviour
{
    public Image Ship1;
    public Image Ship2;
    public Image Ship3;
    public Image Ship4;
    public Image Ship5;

    Color blueColor = new Color32(0, 0, 255, 0);

    public Image Map;
    GameObject[,] map = new GameObject[10,10];
    void Start()
    {
        Ship1.gameObject.SetActive(false);
        Ship2.gameObject.SetActive(false);
        Ship3.gameObject.SetActive(false);
        Ship4.gameObject.SetActive(false);
        Ship5.gameObject.SetActive(false);


        PlayerPrefs.SetInt("MoneyMaker", 0);
        PlayerPrefs.SetInt("Tank", 0);
        PlayerPrefs.SetInt("SideStep", 0);
        PlayerPrefs.SetInt("Faker", 0);
        PlayerPrefs.SetInt("Healer", 0);
        PlayerPrefs.SetInt("LightBomber", 0);
        PlayerPrefs.SetInt("BombCatcher", 0);
        PlayerPrefs.SetInt("Bomber", 0);
        PlayerPrefs.SetInt("Boomer", 0);
        PlayerPrefs.SetInt("FlameThrower", 0);

        Create();
        ChoseMap();
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

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Scenes/Menu");
            }
        }
    }

    void ChoseMap()
    {
        int rnd = Random.Range(0,5);
        //rnd = 4;
        Debug.Log("Map: " + rnd);
        if (rnd == 0)
            Map0();
        else if(rnd==1)
            Map1();
        else if(rnd==2)
            Map2();
        else if(rnd==3)
            Map3();
        else
            Map4();
    }
    void Map0()
    {
        PlayerPrefs.SetString("Map", "Map0");
    }
    void Map1()
    {
        map[3,3].GetComponent<Image>().color = blueColor;
        map[3,4].GetComponent<Image>().color = blueColor;
        map[3,5].GetComponent<Image>().color = blueColor;
        map[3,6].GetComponent<Image>().color = blueColor;

        map[4,3].GetComponent<Image>().color = blueColor;
        map[4,4].GetComponent<Image>().color = blueColor;
        map[4,5].GetComponent<Image>().color = blueColor;
        map[4,6].GetComponent<Image>().color = blueColor;

        map[5,3].GetComponent<Image>().color = blueColor;
        map[5,4].GetComponent<Image>().color = blueColor;
        map[5,5].GetComponent<Image>().color = blueColor;
        map[5,6].GetComponent<Image>().color = blueColor;

        map[6,3].GetComponent<Image>().color = blueColor;
        map[6,4].GetComponent<Image>().color = blueColor;
        map[6,5].GetComponent<Image>().color = blueColor;
        map[6,6].GetComponent<Image>().color = blueColor;
        PlayerPrefs.SetString("Map","Map1");
    }
    void Map2()
    {
        map[0,2].GetComponent<Image>().color = blueColor;
        map[0,3].GetComponent<Image>().color = blueColor;
        map[0,4].GetComponent<Image>().color = blueColor;
        map[0,5].GetComponent<Image>().color = blueColor;
        map[0,6].GetComponent<Image>().color = blueColor;
        map[0,7].GetComponent<Image>().color = blueColor;

        map[1,3].GetComponent<Image>().color = blueColor;
        map[1,4].GetComponent<Image>().color = blueColor;
        map[1,5].GetComponent<Image>().color = blueColor;
        map[1,6].GetComponent<Image>().color = blueColor;

        map[2,4].GetComponent<Image>().color = blueColor;
        map[2,5].GetComponent<Image>().color = blueColor;

        map[7,2].GetComponent<Image>().color = blueColor;
        map[7,7].GetComponent<Image>().color = blueColor;

        map[8,2].GetComponent<Image>().color = blueColor;
        map[8,3].GetComponent<Image>().color = blueColor;
        map[8,6].GetComponent<Image>().color = blueColor;
        map[8,7].GetComponent<Image>().color = blueColor;

        map[9,2].GetComponent<Image>().color = blueColor;
        map[9,3].GetComponent<Image>().color = blueColor;
        map[9,4].GetComponent<Image>().color = blueColor;
        map[9,5].GetComponent<Image>().color = blueColor;
        map[9,6].GetComponent<Image>().color = blueColor;
        map[9,7].GetComponent<Image>().color = blueColor;
        PlayerPrefs.SetString("Map", "Map2");
    }
    void Map3()
    {
        map[0,0].GetComponent<Image>().color = blueColor;
        map[0,1].GetComponent<Image>().color = blueColor;

        map[1,0].GetComponent<Image>().color = blueColor;

        map[2,6].GetComponent<Image>().color = blueColor;
        map[2,7].GetComponent<Image>().color = blueColor;
        map[2,8].GetComponent<Image>().color = blueColor;
        map[2,9].GetComponent<Image>().color = blueColor;

        map[3,6].GetComponent<Image>().color = blueColor;
        map[3,7].GetComponent<Image>().color = blueColor;
        map[3,8].GetComponent<Image>().color = blueColor;
        map[3,9].GetComponent<Image>().color = blueColor;

        map[4,0].GetComponent<Image>().color = blueColor;
        map[4,8].GetComponent<Image>().color = blueColor;
        map[4,9].GetComponent<Image>().color = blueColor;

        map[5,0].GetComponent<Image>().color = blueColor;
        map[5,1].GetComponent<Image>().color = blueColor;
        map[5,9].GetComponent<Image>().color = blueColor;

        map[6,0].GetComponent<Image>().color = blueColor;
        map[6,1].GetComponent<Image>().color = blueColor;
        map[6,2].GetComponent<Image>().color = blueColor;
        map[6,3].GetComponent<Image>().color = blueColor;

        map[7,0].GetComponent<Image>().color = blueColor;
        map[7,1].GetComponent<Image>().color = blueColor;
        map[7,2].GetComponent<Image>().color = blueColor;
        map[7,3].GetComponent<Image>().color = blueColor;

        map[8,9].GetComponent<Image>().color = blueColor;

        map[9,8].GetComponent<Image>().color = blueColor;
        map[9,9].GetComponent<Image>().color = blueColor;
        PlayerPrefs.SetString("Map", "Map3");
    }
    void Map4()
    {
        map[0,0].GetComponent<Image>().color = blueColor;
        map[0,1].GetComponent<Image>().color = blueColor;
        map[0,2].GetComponent<Image>().color = blueColor;
        map[0,7].GetComponent<Image>().color = blueColor;
        map[0,8].GetComponent<Image>().color = blueColor;
        map[0,9].GetComponent<Image>().color = blueColor;

        map[1,0].GetComponent<Image>().color = blueColor;
        map[1,1].GetComponent<Image>().color = blueColor;
        map[1,8].GetComponent<Image>().color = blueColor;
        map[1,9].GetComponent<Image>().color = blueColor;

        map[2,0].GetComponent<Image>().color = blueColor;
        map[2,9].GetComponent<Image>().color = blueColor;

        map[3,3].GetComponent<Image>().color = blueColor;
        map[3,4].GetComponent<Image>().color = blueColor;
        map[3,5].GetComponent<Image>().color = blueColor;
        map[3,6].GetComponent<Image>().color = blueColor;

        map[4,3].GetComponent<Image>().color = blueColor;
        map[4,4].GetComponent<Image>().color = blueColor;
        map[4,5].GetComponent<Image>().color = blueColor;
        map[4,6].GetComponent<Image>().color = blueColor;

        map[5,3].GetComponent<Image>().color = blueColor;
        map[5,4].GetComponent<Image>().color = blueColor;
        map[5,5].GetComponent<Image>().color = blueColor;
        map[5,6].GetComponent<Image>().color = blueColor;

        map[6,3].GetComponent<Image>().color = blueColor;
        map[6,4].GetComponent<Image>().color = blueColor;
        map[6,5].GetComponent<Image>().color = blueColor;
        map[6,6].GetComponent<Image>().color = blueColor;

        map[7,0].GetComponent<Image>().color = blueColor;
        map[7,9].GetComponent<Image>().color = blueColor;

        map[8,0].GetComponent<Image>().color = blueColor;
        map[8,1].GetComponent<Image>().color = blueColor;
        map[8,8].GetComponent<Image>().color = blueColor;
        map[8,9].GetComponent<Image>().color = blueColor;

        map[9,0].GetComponent<Image>().color = blueColor;
        map[9,1].GetComponent<Image>().color = blueColor;
        map[9,2].GetComponent<Image>().color = blueColor;
        map[9,7].GetComponent<Image>().color = blueColor;
        map[9,8].GetComponent<Image>().color = blueColor;
        map[9,9].GetComponent<Image>().color = blueColor;
        PlayerPrefs.SetString("Map", "Map4");
    }
}

