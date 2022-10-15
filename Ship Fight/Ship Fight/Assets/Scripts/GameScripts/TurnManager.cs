using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnManager : MonoBehaviour
{
    public TextMeshProUGUI attackTurnText;
    public TextMeshProUGUI defendTurnText;
    void Start()
    {
        attackTurnText.text = "0";
        defendTurnText.text = "0";
    }
    public void AddTurn()
    {
        int turn = Convert.ToInt32(attackTurnText.text);
        turn++;

        attackTurnText.text = turn.ToString();
        defendTurnText.text = turn.ToString();

    }
}
