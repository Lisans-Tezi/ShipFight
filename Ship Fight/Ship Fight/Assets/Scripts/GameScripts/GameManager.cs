using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {                           
        moneyMaker = GameObject.Find("MoneyMaker").GetComponent<MoneyMaker>();
        tank = GameObject.Find("Tank").GetComponent<Tank>();
        sideStep = GameObject.Find("SideStep").GetComponent<SideStep>();
        faker= GameObject.Find("Faker").GetComponent<Faker>();
        healer= GameObject.Find("Healer").GetComponent<Healer>();
        lightBomber = GameObject.Find("LightBomber").GetComponent<LightBomber>();
        bombCatcher = GameObject.Find("BombCatcher").GetComponent<BombCatcher>();
        bomber = GameObject.Find("Bomber").GetComponent<Bomber>();
        boomer = GameObject.Find("Boomer").GetComponent<Boomer>();
        flameThrower = GameObject.Find("FlameThrower").GetComponent<FlameThrower>();
        Debug.Log(moneyMaker.Name);
        Debug.Log(moneyMaker.FirstPieceI);
        Debug.Log(moneyMaker.FirstPieceJ);
        Debug.Log(tank.Name);
        Debug.Log(sideStep.Name);
        Debug.Log(faker.Name);
        Debug.Log(healer.Name);
        Debug.Log(lightBomber.Name);
        Debug.Log(bombCatcher.Name);
        Debug.Log(bomber.Name);
        Debug.Log(boomer.Name);
        Debug.Log(flameThrower.Name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
