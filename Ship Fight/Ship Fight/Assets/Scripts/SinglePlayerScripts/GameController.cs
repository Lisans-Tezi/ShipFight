using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Image> Ships;
    public Button shipReady;
    public Button mapReady;

    int shipCount;

    void Start()
    {
        mapReady.enabled = false;
    }

    void Update()
    {
        shipCount = 0;
        foreach (Image ship in Ships)
        {
            if(ship.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color == Color.green)
            {
                shipCount++;
            }
        }
        if(shipCount == 5)
        {
            foreach (Image ship in Ships)
            {
                ship.GetComponent<Button>().enabled = false;
            }
            mapReady.enabled = true;
            shipReady.enabled = false;
        }
    }



}
