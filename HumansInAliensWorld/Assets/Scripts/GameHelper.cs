using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
     public Slider HealthSlider; 
     public Slider TimerSlider; 
    public Transform StartPosition;
    public GameObject GoldPrefab;
    
    public GameObject[] MonstersPrefab;
    public Text PlayerGoldUI;
   // public Text PlayerDamageUI;
    
    public int PlayerGold;
    public int PlayerDamage = 1;
    private int TimeForBoss = 30;

    // Start is called before the first frame update
    private void Start()
    {
        PlayerGoldUI.text = PlayerGold.ToString(); 
        SpawnMonsters();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void TakeGold(int gold) //выдаем золото
    {
        PlayerGold += gold;
        PlayerGoldUI.text = PlayerGold.ToString(); 
        GameObject GoldPrefabTmp = Instantiate(GoldPrefab) as GameObject; //создаем новое золото
        SpawnMonsters(); //Нового монстра
    }

    public void PayGold(int gold)
    {
        PlayerGold -= gold;
        PlayerGoldUI.text = PlayerGold.ToString(); 
    }

    void SpawnMonsters()
    {
        int index = Random.Range(0,MonstersPrefab.Length);
        GameObject monsters = Instantiate(MonstersPrefab[index]) 
            as GameObject; //создаем новый 
        monsters.transform.position = StartPosition.position;
        if(index == MonstersPrefab.Length - 1)
        {
            TimerSlider.gameObject.SetActive(true);
            TimerSlider.maxValue = TimeForBoss;
            TimerSlider.value = TimerSlider.maxValue;
            StartCoroutine(StartTimer());
        }
        else
        {
            TimerSlider.gameObject.SetActive(false);
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(0.1f);
        TimerSlider.value-=0.1f; 
        if(TimerSlider.value > 0.1f) 
        StartCoroutine(StartTimer());
    }

}
