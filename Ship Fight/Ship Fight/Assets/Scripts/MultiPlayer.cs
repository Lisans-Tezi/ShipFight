using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayer : MonoBehaviour
{
    public Button multiplayer;
    public Button option1;
    public Button option2;
    private void Start()
    {
        HideOptions();
    }
    public void ShowOptions()
    {
        option1.gameObject.SetActive(true);
        option2.gameObject.SetActive(true);
    }
    public void HideOptions()
    {
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
    }
}
