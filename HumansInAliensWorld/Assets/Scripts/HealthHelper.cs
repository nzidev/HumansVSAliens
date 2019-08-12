using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthHelper : MonoBehaviour
{
   
    public int MaxHealth = 100; //Всего жизней
    public int Health = 100;    //Текущие жизни
    public int Gold = 100;    //Сколько золотых за смерть
    
    GameHelper gameHelper;
    [SerializeField] private GameObject textdamage;
    

    // Start is called before the first frame update
    private void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
        gameHelper.HealthSlider.maxValue = MaxHealth;
        gameHelper.HealthSlider.value = MaxHealth;

        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void GetHit(int damage) //получаем урон
    {
        Debug.Log(damage);
        int health = Health - damage;

        if (health <= 0)
        {
            gameHelper.TakeGold(Gold); //выдаем золото перед смертью
            Destroy(gameObject);
        }
        
        Health=health;
        gameHelper.HealthSlider.value = Health;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject textdamagetmp = Instantiate(textdamage, new Vector2(0, 0), Quaternion.identity) as GameObject; 
            textdamagetmp.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }
}
