using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private void Start()
    {
        if (gameObject.name == "DefendInfoPanelText")
        {
            AIAttacking();
        }
        else
            ChoseShip();
    }
    public void ChoseShip()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Choose the ship and attack type to attack.";
    }
    public void BlownUp(string name)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "You completely blown up the " + name + " ship.";
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
    public void AIAttacking()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Enemy Attacking";
    }
    public void AIMissed()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Enemy Missed";
    }
    public void AIHitted()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Enemy Hitted";
    }
    public void Win()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "You Won!!! Well Done";
    }
    public void Lose()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "You Lose";
    }
}
