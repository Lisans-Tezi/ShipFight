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

    public List<string> PlacedShipNames;

    int[,] Coordinats = new int[10, 10];
    int shipCount = 1;
    List<string> shipNames = new List<string>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                Coordinats[i, j] = 0;

        PlacedShipNames = new List<string>();
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
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    Coordinats[i, j] = shipCount;

        shipNames.Add(PlayerPrefs.GetString("SelectedShip"));
        shipCount++;

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                if (map[i, j].gameObject.GetComponent<Image>().color == Color.blue)
                    map[i, j].gameObject.GetComponent<Image>().color = Color.black;

                if (map[i, j].gameObject.GetComponent<Image>().color != Color.black)
                    map[i, j].gameObject.GetComponent<Image>().color = whiteColor;
            }


        foreach (Image ship in Ships)
        {
            ship.GetComponent<Button>().enabled = true;
            if (ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color == Color.red)
            {
                ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;
                ship.GetComponent<Button>().enabled = false;
                PlacedShipNames.Add(ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text);
            }
        }
    }
}
