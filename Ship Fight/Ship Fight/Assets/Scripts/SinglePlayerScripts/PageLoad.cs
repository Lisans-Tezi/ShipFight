using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLoad : MonoBehaviour
{
    public Image Ship1;
    public Image Ship2;
    public Image Ship3;
    public Image Ship4;
    public Image Ship5;
    // Start is called before the first frame update
    void Start()
    {
        Ship1.gameObject.SetActive(false);
        Ship2.gameObject.SetActive(false);
        Ship3.gameObject.SetActive(false);
        Ship4.gameObject.SetActive(false);
        Ship5.gameObject.SetActive(false);
    }

}
