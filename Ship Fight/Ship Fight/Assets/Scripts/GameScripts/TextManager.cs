using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private void Start()
    {
        ChoseShip();
    }
    public void ChoseShip()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Chose a Ship";
    }
    public void ChoseTile()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Select a Tile To Attack";
    }
    public void SuccessfullShot()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Successfull Shot !!! Keep Shooting";
    }
    public void FailedShot()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "You Missed !!! Enemy's Turn";
    }
    public void ShipCompleted(string shipName)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"You Boom The {shipName} !!! Well Done";
    }
    public void ToManyShot()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "You Hit 3 Times a Row !!! Give a Chance's a Enemy";
    }
}
