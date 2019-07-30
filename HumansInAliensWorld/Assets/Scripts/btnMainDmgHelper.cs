using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnMainDmgHelper : MonoBehaviour
{
    public Text txtDamagePlus;
    public Text txtDamageInfo;
    public Text txtPrice;
    private int DmgPlus = 10; //procent
    
    private int Price = 100;
    GameHelper gameHelper;


    // Start is called before the first frame update
    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHelper.PlayerGold >= Price)
        {
            gameObject.GetComponent<Button>().interactable = true;
           
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }

        txtDamagePlus.text = "+" + ((DmgPlus*gameHelper.PlayerDamage)/100).ToString();
        txtPrice.text = Price.ToString();
        txtDamageInfo.text = gameHelper.PlayerDamage.ToString() + " DPS";
    }

    public void Click()
    {
        gameHelper.PlayerGold -= Price;
        gameHelper.PlayerDamage += ((DmgPlus*gameHelper.PlayerDamage)/100);
        Price = Price *3 / 2;
    }
}
