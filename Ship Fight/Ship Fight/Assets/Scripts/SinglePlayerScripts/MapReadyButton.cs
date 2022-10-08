using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapReadyButton : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().enabled = false;
    }

    public void CompleteScene()
    {
        //haritayý kaydet
        SceneManager.LoadScene("Scenes/GameScene");
    }
}
