using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamageHelper : MonoBehaviour
{
    public Transform MonsterPosition;    
    private Vector2 EndPosition; 


    float speed = 4.0f;
    GameHelper gameHelper;
    HealthHelper _healthHelper;
    // Start is called before the first frame update
    void Start()
    {
        
        
            gameHelper = GameObject.FindObjectOfType<GameHelper>();
            GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
            Transform healthSlider = canvasObject.transform.Find("HealthSlider");
            transform.position = new Vector2 (MonsterPosition.transform.position.x,MonsterPosition.transform.position.y);
            EndPosition = new Vector2(MonsterPosition.transform.position.x,healthSlider.position.y);
            gameObject.GetComponent<Text>().text = gameHelper.PlayerDamage.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Vector2.Distance(transform.position, EndPosition)>=0.1f)
       {
            transform.position = Vector2.Lerp(transform.position, EndPosition, Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
