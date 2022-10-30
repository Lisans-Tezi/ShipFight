using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class moneymaker : MonoBehaviour
{
    string point ="";
    int Point=0;
    public int increase = 1;
    public void PassiveAttribute()
    {
        point = GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text;
        Point = Convert.ToInt32(point);
        Point+=increase;
        point = Point.ToString();
        GameObject.Find("ScorePoint").GetComponent<TextMeshProUGUI>().text = point;
    }
}
