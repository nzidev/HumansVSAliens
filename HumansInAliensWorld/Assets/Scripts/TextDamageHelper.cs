using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamageHelper : MonoBehaviour
{
        
    private Vector2 EndPosition;    

    float speed = 4.0f;
    GameHelper gameHelper;
    // Start is called before the first frame update
    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
         GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        Transform healthSlider = canvasObject.transform.Find("HealthSlider");
        EndPosition = new Vector2(Input.mousePosition.x +125,healthSlider.position.y);
        transform.position = new Vector2 (Input.mousePosition.x +125,Input.mousePosition.y);
        gameObject.GetComponent<Text>().text = gameHelper.PlayerDamage.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Vector2.Distance(transform.position, EndPosition)>=2f)
       {
            transform.position = Vector2.Lerp(transform.position, EndPosition, Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
