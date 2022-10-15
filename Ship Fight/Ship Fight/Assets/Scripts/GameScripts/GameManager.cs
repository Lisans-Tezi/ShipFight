using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    MoneyMaker moneyMaker;
    Tank tank;
    SideStep sideStep;
    Faker faker;
    Healer healer;
    LightBomber lightBomber;
    BombCatcher bombCatcher;
    Bomber bomber;
    Boomer boomer;
    FlameThrower flameThrower;

    public Image Ship1;
    public Image Ship2;
    public Image Ship3;
    public Image Ship4;
    public Image Ship5; 
    
    public TextMeshProUGUI ship1NameText;
    public TextMeshProUGUI ship2NameText;
    public TextMeshProUGUI ship3NameText;
    public TextMeshProUGUI ship4NameText;
    public TextMeshProUGUI ship5NameText;

    public Image ship1ActiveBtn;
    public Image ship2ActiveBtn;
    public Image ship3ActiveBtn;
    public Image ship4ActiveBtn;
    public Image ship5ActiveBtn;


    bool ship1Control, ship2Control, ship3Control, ship4Control, ship5Control, ship6Control, ship7Control, ship8Control, ship9Control, ship10Control;
    
    void Start()
    {
        moneyMaker = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
        tank = GameObject.Find("Tank").GetComponent<Tank>();
        sideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        faker = GameObject.Find("Faker").GetComponent<Faker>();
        healer = GameObject.Find("Healer").GetComponent<Healer>();
        lightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        bombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
        bomber = GameObject.Find("Bomber").GetComponent<Bomber>();
        boomer = GameObject.Find("Boomer").GetComponent<Boomer>();
        flameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();

        Place(Ship1);
        Place(Ship2);
        Place(Ship3);
        Place(Ship4);
        Place(Ship5);

        ship1NameText.text = Ship1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        ship2NameText.text = Ship2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        ship3NameText.text = Ship3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        ship4NameText.text = Ship4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        ship5NameText.text = Ship5.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;


        ship1ActiveBtn.GetComponent<Button>().enabled = false;
        ship2ActiveBtn.GetComponent<Button>().enabled = false;
        ship3ActiveBtn.GetComponent<Button>().enabled = false;
        ship4ActiveBtn.GetComponent<Button>().enabled = false;
        ship5ActiveBtn.GetComponent<Button>().enabled = false;
    }

    void Place(Image ship)
    {
        if (moneyMaker.Name != null && ship1Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = moneyMaker.Name;
            ship1Control = true;
        }
        else if (tank.Name != null && ship2Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tank.Name;
            ship2Control = true;
        }
        else if (sideStep.Name != null && ship3Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = sideStep.Name;
            ship3Control = true;
        }
        else if (faker.Name != null && ship4Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = faker.Name;
            ship4Control = true;
        }
        else if (healer.Name != null && ship5Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = healer.Name;
            ship5Control = true;
        }
        else if (lightBomber.Name != null && ship6Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lightBomber.Name;
            ship6Control = true;
        }
        else if (bombCatcher.Name != null && ship7Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bombCatcher.Name;
            ship7Control = true;
        }
        else if (bomber.Name != null && ship8Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bomber.Name;
            ship8Control = true;
        }
        else if (boomer.Name != null && ship9Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = boomer.Name;
            ship9Control = true;
        }
        else if (flameThrower.Name != null && ship10Control == false)
        {
            ship.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = flameThrower.Name;
            ship10Control = true;
        }
    }


    void Update()
    {
        
    }
}
