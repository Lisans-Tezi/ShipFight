using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    public Image settings;
    void Start()
    {
        HideSettings();
    }

    public void ShowSettings()
    {
        settings.gameObject.SetActive(true);
    }
    public void HideSettings()
    {
        settings.gameObject.SetActive(false);
    }
}
