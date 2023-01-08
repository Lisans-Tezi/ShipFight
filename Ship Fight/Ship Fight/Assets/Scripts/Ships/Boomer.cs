using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    Color whiteColor = new Color32(255, 255, 255, 150);
    Color greenColor = new Color32(0, 255, 0, 200);
    Color redColor = new Color32(255, 0, 0, 150);
    Color blueColor = new Color32(0, 0, 255, 0);

    public void PassiveSkill()
    {
        if (HittedPiece==1)
        {
            GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = "0";
        }
    }

    public GameObject[,] ActiveSkill(GameObject[,] map, int y)
    {
        if (PlayerPrefs.GetString("ShootingShip") == "Boomer")
        {
            bool control = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, y].GetComponent<Image>().color == greenColor)
                    {
                        control = true;
                    }
                    if (y != j && map[i, j].GetComponent<Image>().color == greenColor)
                    {
                        map[i, j].GetComponent<Image>().color = whiteColor;
                    }
                }
            }

            if (control)
            {
                PlayerPrefs.SetInt("ActiveHitPerTurn", PlayerPrefs.GetInt("ActiveHitPerTurn") + 1);
            }
        }
        return map;
    }
}
