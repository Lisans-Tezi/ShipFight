using System.Collections;
using System.Collections.Generic;
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
}
