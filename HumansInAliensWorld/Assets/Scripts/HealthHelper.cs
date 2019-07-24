﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthHelper : MonoBehaviour
{
   
    public int MaxHealth = 100; //Всего жизней
    public int Health = 100;    //Текущие жизни
    public int Gold = 100;    //Сколько золотых за смерть
    
    GameHelper gameHelper;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
        gameHelper.HealthSlider.maxValue = MaxHealth;
        gameHelper.HealthSlider.value = MaxHealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(int damage) //получаем урон
    {
        int health = Health - damage;

        if (health <= 0)
        {
            gameHelper.TakeGold(Gold); //выдаем золото перед смертью
            Destroy(gameObject);
        }
        
        Health=health;
        gameHelper.HealthSlider.value = Health;
    }
}
