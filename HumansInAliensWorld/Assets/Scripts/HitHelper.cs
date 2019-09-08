using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    GameHelper gameHelper;
   // TextDamageHelper textDamageHelper;
    
    // Start is called before the first frame update
    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        gameObject.GetComponent<Animator>().enabled  = true;
        gameObject.GetComponent<Animator>().SetTrigger("Hit");
        gameObject.GetComponent<HealthHelper>().GetHit(gameHelper.PlayerDamage);
        
    }

}
