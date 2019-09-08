using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{

   
    public Slider HealthSlider; 
     public Slider TimerSlider; 
    public Transform StartPosition;
    public GameObject GoldPrefab;
    public Button FightWithBoss;
    
    /// <summary>
    /// Атлас спрайтов монстров
    /// </summary>
    [SerializeField]
    private SpriteAtlas spriteAtlasMonsters;
    /// <summary>
    /// Имена монстров в спрайте монстров
    /// </summary>
    private string[] NameOfSpritesMonsters;

    private static Object[] objs;
    public GameObject[] MonstersPrefab;
    public Text PlayerGoldUI;
   // public Text PlayerDamageUI;
    
    public int PlayerGold;
    public int PlayerDamage = 1;
    private int TimeForBoss = 30;
    /// <summary>
    /// Количество убитых монстров.
    /// </summary>
    private int CountMobs = 0;
    /// <summary>
    /// Количество мобов для появления босса.
    /// </summary>
    private int CountForBoss = 10;
    /// <summary>
    /// Появлялся ли босс.
    /// </summary>
    private bool IsBossShowed = false;
    /// <summary>
    /// Индекс текущего монстра.
    /// </summary>
    private int index;
    /// <summary>
    /// Объект монстра.
    /// </summary>
    private GameObject monsters;
    // Start is called before the first frame update
    private void Start()
    {
        
        PlayerGoldUI.text = PlayerGold.ToString(); 
        SpawnMonsters();
        FightWithBoss.gameObject.SetActive(false);
        objs = SpriteAtlasExtensions.GetPackables(spriteAtlasMonsters);
        Debug.Log(objs.ToString());
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsBossShowed && index == (MonstersPrefab.Length - 1) && TimerSlider.value <= 0.1f)
        {
            Destroy(monsters);
            SpawnMonsters();
            FightWithBoss.gameObject.SetActive(true);
        }
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
        if(CountMobs >= CountForBoss && !IsBossShowed)
        {
            //Показываем босса
            ShowBoss();
        }
        else
        {
            //Показываем обычного рандомного монстра
            ShowMob();
        }


    }

    private void ShowMob()
    {
        index = Random.Range(0, MonstersPrefab.Length - 1);
        TimerSlider.gameObject.SetActive(false);
        monsters = Instantiate(MonstersPrefab[index])
            as GameObject; //создаем нового моба
        monsters.transform.position = StartPosition.position;
        
        // monsters.GetComponent<SpriteRenderer>().sprite = GetPackables(spriteAtlasMonsters);
    }

    public void ShowBoss()
    {
        FightWithBoss.gameObject.SetActive(false);
        Destroy(monsters);
        IsBossShowed = true;
        index = MonstersPrefab.Length - 1;
        monsters = Instantiate(MonstersPrefab[index])
                as GameObject; //создаем нового моба
        monsters.transform.position = StartPosition.position;
        TimerSlider.gameObject.SetActive(true);
        TimerSlider.maxValue = TimeForBoss;
        TimerSlider.value = TimerSlider.maxValue;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(0.1f);
        TimerSlider.value-=0.1f; 
        if(TimerSlider.value > 0.1f) 
        StartCoroutine(StartTimer());
    }

    /// <summary>
    /// Увеличиваем количество убитых монстров
    /// </summary>
    public void IncrMob()
    {
        Debug.Log(CountMobs);
        if (index == (MonstersPrefab.Length - 1))
        {
            CountMobs = 0;
            IsBossShowed = false;
        }
        else
            CountMobs++;
    }

}
