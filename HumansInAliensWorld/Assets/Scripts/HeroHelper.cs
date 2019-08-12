using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHelper : MonoBehaviour
{
    public int Damage{get;set;}
    public float AttackSpeed = 10.0f;
    HealthHelper _healthHelper;
    
    private void Start()
    {
        //При появлении зацикливаем анимацию атаки, урон происходит из эвента внутри анимации
        //методом GetHit()
          StartCoroutine(AttackAnimation());
        
    }

    // Update is called once per frame
    private void Update()
    {
        try
        {
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        }
        catch (System.Exception)
        {
            
            return;
        }
     
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(AttackSpeed);
        gameObject.GetComponent<Animator>().SetTrigger("Attack");    
        StartCoroutine(AttackAnimation());
    }
    private void GetHitbyHero()
    {
        
        _healthHelper.GetHit(Damage);
    }

    
}
