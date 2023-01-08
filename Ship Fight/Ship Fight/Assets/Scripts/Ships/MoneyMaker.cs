using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class MoneyMaker : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public string Name { get; set; }
    public int Piece { get; set; }
    public int HittedPiece { get; set; }
    public int FirstPieceI { get; set; } 
    public int FirstPieceJ { get; set; }
    public int SecondPieceI { get; set; }
    public int SecondPieceJ { get; set; }

    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    string point = "";
    int Point = 0;
    public int increase = 1;

    private void Start()
    {
        increase = 1;
    }

    public void PassiveSkill()
    {
        point = GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text;
        Point = Convert.ToInt32(point);
        Point += increase;
        point = Point.ToString();
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point;
    }
}
