using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsBtn : MonoBehaviour
{
    public Image cast;
    void Start()
    {
        HideCast();
    }

    public void ShowCast()
    {
        cast.gameObject.SetActive(true);
    }
    public void HideCast()
    {
        cast.gameObject.SetActive(false);
    }

}
