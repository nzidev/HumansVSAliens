using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelper : MonoBehaviour
{
    public int MaxHealth = 100; //Всего жизней
    public int Health = 100;    //Текущие жизни
    

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
        
        Health=health;
    }
}
