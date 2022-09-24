using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipReady : MonoBehaviour
{
    public Image Map;
    public List<Image> Ships;
    public List<TextMeshProUGUI> Texts;

    GameObject[,] map = new GameObject[10, 10];

    Color whiteColor = new Color32(255, 255, 255, 100);

    void Start()
    {
        gameObject.GetComponent<Button>().enabled = false;
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

    public void Clicked()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    map[i, j].gameObject.GetComponent<Image>().color = Color.black;

                if (map[i, j].gameObject.GetComponent<Image>().color != Color.black)
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
            }

    }
}
