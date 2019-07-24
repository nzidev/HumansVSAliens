using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
     public Slider HealthSlider; 
    public Transform StartPosition;
    public GameObject GoldPrefab;
    
    public GameObject[] MonstersPrefab;
    public Text PlayerGoldUI;
    public Text PlayerDamageUI;
    
    public int PlayerGold;
    public int PlayerDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString(); 
        PlayerDamageUI.text = PlayerDamage.ToString(); 

    }

     public void TakeGold(int gold) //выдаем золото
    {
        PlayerGold += gold;
        GameObject GoldPrefabTmp = Instantiate(GoldPrefab) as GameObject; //создаем новый перед удалением
        Destroy(GoldPrefabTmp,1.0f); //удаляем после анимации в 1 сек

        SpawnMonsters(); //Нового монстра
    }

    void SpawnMonsters()
    {
        int index = Random.Range(0,MonstersPrefab.Length);
        GameObject monsters = Instantiate(MonstersPrefab[index]) 
            as GameObject; //создаем новый перед удалением
        monsters.transform.position = StartPosition.position;
    }

}
