using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boomer : MonoBehaviour
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
    public int ThirdPieceI { get; set; }
    public int ThirdPieceJ { get; set; }
    public int FourthPieceI { get; set; }
    public int FourthPieceJ { get; set; }
    public int FifthPieceI { get; set; }
    public int FifthPieceJ { get; set; }
    public int SixthPieceI { get; set; }
    public int SixthPieceJ { get; set; }
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    public void PassiveSkill()
    {
        if (HittedPiece==1)
        {
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = "0";
        }
    }
}
