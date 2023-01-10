using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image shipAttributes;
    public Image settings;
    public Image cast;

    public List<Button> buttons;

    private void Start()
    {
        shipAttributes.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        cast.gameObject.SetActive(false);
    }

    public void PlayGameBtn()
    {
        SceneManager.LoadScene("Scenes/SinglePlayer");
    }

    public void HowToPlayBtn()
    {
        if (shipAttributes.gameObject.activeSelf)
        {
            buttons.ForEach(i => i.gameObject.GetComponent<Button>().enabled = true);
            shipAttributes.gameObject.SetActive(false);
        }
        else
        {
            foreach (Button btn in buttons)
                if (btn.name != "HowToPlayBtn")
                    btn.enabled = false;
            shipAttributes.gameObject.SetActive(true);
        }
    }

    public void SettingsBtn()
    {
        if(settings.gameObject.activeSelf)
        {
            buttons.ForEach(i => i.gameObject.GetComponent<Button>().enabled = true);
            settings.gameObject.SetActive(false);
        }
        else
        {
            foreach (Button btn in buttons)
                if (btn.name != "SettingsBtn")
                    btn.enabled = false;
            settings.gameObject.SetActive(true);
        }
    }

    public void CreditsBtn()
    {
        if (cast.gameObject.activeSelf)
        {
            buttons.ForEach(i => i.gameObject.GetComponent<Button>().enabled = true);
            cast.gameObject.SetActive(false);
        }
        else
        {
            foreach (Button btn in buttons)
                if (btn.name != "CreditsBtn")
                    btn.enabled = false;
            cast.gameObject.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
