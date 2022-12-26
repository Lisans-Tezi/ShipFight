using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCatcher : MonoBehaviour
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
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    public bool control = false;
    bool AIcontrol = false;
    public void PassiveSkill()
    {
        if (!control)
        {
            PlayerPrefs.SetInt("HitPerTurn", 0);
            control = true;
        }            
    }
    public void AIPassiveSkill()
    {
        if (!AIcontrol)
        {
            PlayerPrefs.SetInt("AIAttackHitPerTurn", 0);
            AIcontrol = true;
        }              
    }
}
