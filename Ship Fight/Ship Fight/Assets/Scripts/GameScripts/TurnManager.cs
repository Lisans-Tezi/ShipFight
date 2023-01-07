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
        attackTurnText.text = "1";
        defendTurnText.text = "1";
    }
    public void AddTurn()
    {
        int turn = Convert.ToInt32(defendTurnText.text);
        turn++;

        attackTurnText.text = turn.ToString();
        defendTurnText.text = turn.ToString();

    }
}
