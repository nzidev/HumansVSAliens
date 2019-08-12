using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btnHeroFighter : MonoBehaviour
{
    GameHelper gameHelper;
    public GameObject FighterPrefab;
    public Text txtDamagePlus;
    public Text txtDamageInfo;
    public Text txtPrice;
    private bool isCreated = false; // флаг создан объект или нет
    private int DmgPlus = 1; 
    private int DmgStart = 1;
    
    private float AttackSpeed = 1.1f;
    private int Price = 100;
    private int PricePlus = 10; //procent
    
    private GameObject FighterPrefabTmp;
    private void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    
    private void Update()
    {
         if (gameHelper.PlayerGold >= Price)
        {
            gameObject.GetComponent<Button>().interactable = true;
           
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        txtDamagePlus.text = "+1";
        txtPrice.text = Price.ToString();
        txtDamageInfo.text = "Create Fighter DPS";
    }

    public void Click()
    {
        gameHelper.PayGold(Price);
        if(!isCreated)
        {
            
            FighterPrefabTmp = Instantiate(FighterPrefab) as GameObject;
            FighterPrefabTmp.GetComponent<HeroHelper>().AttackSpeed = AttackSpeed;
            FighterPrefabTmp.GetComponent<HeroHelper>().Damage = DmgStart;
            isCreated = true;
        }
        else
        {
            FighterPrefabTmp.GetComponent<HeroHelper>().Damage += DmgPlus;
        }
        Price = Price + ((Price * PricePlus) /100);
    }
}
