using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipReady : MonoBehaviour
{
    public List<Image> First50Map;
    public List<Image> Second50Map;

    Color whiteColor = new Color32(255, 255, 255, 100);
    Color greenColor = new Color32(0, 255, 0, 200);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked()
    {
        First50Map.ForEach(x => 
        {
            if (x.gameObject.GetComponent<Image>().color == Color.blue)
            {
                x.gameObject.GetComponent<Image>().color = Color.black;
            }
            if (x.gameObject.GetComponent<Image>().color != Color.black)
            {
                x.gameObject.GetComponent<Image>().color = whiteColor;
            }
        });

        if (GameObject.Find("FirstShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("FirstShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("SecondShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("SecondShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("ThirdShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("ThirdShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("FourthShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("FourthShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("FifthShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("FifthShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("SixthShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("SixthShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("SeventhShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("SeventhShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("EighthShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("EighthShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("NinethShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("NinethShip").GetComponent<Button>().enabled = true;
        }
        if (GameObject.Find("TenthShip").GetComponent<Button>().enabled == false)
        {
            GameObject.Find("TenthShip").GetComponent<Button>().enabled = true;
        }

        if (GameObject.Find("FirstShipName").GetComponent<TextMeshProUGUI>().color==Color.red)
        {
            GameObject.Find("FirstShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("SecondShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("SecondShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("ThirdShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("ThirdShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("FourthShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("FourthShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("FifthShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("FifthShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("SixthShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("SixthShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("SeventhShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("SeventhShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("EighthShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("EighthShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("NinethShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("NinethShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (GameObject.Find("TenthShipName").GetComponent<TextMeshProUGUI>().color == Color.red)
        {
            GameObject.Find("TenthShipName").GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }
}
