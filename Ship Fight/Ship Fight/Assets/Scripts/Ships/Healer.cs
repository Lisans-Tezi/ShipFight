using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healer : MonoBehaviour
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
    public string PassiveAttribute { get; set; }
    public string ActiveAttribute { get; set; }
    public int ActiveAttributeCost { get; set; }

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public GameObject[,] PassiveSkill(GameObject[,] map, Color32 color)
    {
        if (HittedPiece < Piece)
        {
            if (map[FirstPieceI, FirstPieceJ].GetComponent<Image>().color == redColor)
            {
                map[FirstPieceI, FirstPieceJ].GetComponent<Image>().color = color;
                HittedPiece--;
            }
            else if (map[SecondPieceI, SecondPieceJ].GetComponent<Image>().color == redColor)
            {
                map[SecondPieceI, SecondPieceJ].GetComponent<Image>().color = color;
                HittedPiece--;
            }
            else if (map[ThirdPieceI, ThirdPieceJ].GetComponent<Image>().color == redColor)
            {
                map[ThirdPieceI, ThirdPieceJ].GetComponent<Image>().color = color;
                HittedPiece--;
            }
            else if (map[FourthPieceI, FourthPieceJ].GetComponent<Image>().color == redColor)
            {
                map[FourthPieceI, FourthPieceJ].GetComponent<Image>().color = color;
                HittedPiece--;
            }
        }
        return map;
    }
    
}
