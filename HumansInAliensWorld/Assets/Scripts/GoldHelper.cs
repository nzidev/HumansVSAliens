using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldHelper : MonoBehaviour
{
    public Transform StartPosition;
    public Transform GroundPosition;
    public Transform EndPosition;    

    float speed = 4.0f;
    bool isGround = false;
    Vector2 newGroundPosition;
    Vector2 curPosition;
    Vector2 newEndPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        newEndPosition = EndPosition.position;
        transform.position = StartPosition.position;
        float rand = Random.Range (1, 3f);
        newGroundPosition = new Vector2 (rand,GroundPosition.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        curPosition = new Vector2(transform.position.x,transform.position.y);
        if (!isGround)
        {
            transform.position = Vector2.Lerp(transform.position, newGroundPosition, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, newEndPosition, Time.deltaTime * (speed/2)) ;
            ChangeAlphaColor();
        }
        if (Vector2.Distance(curPosition,newGroundPosition) <= 0.1f)
        {
            isGround = true;
        }

        if (Vector2.Distance(curPosition,newEndPosition)<= 0.1f)
        {
             Destroy(gameObject);
        }
        
    }

    void ChangeAlphaColor()
    {
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a -= (Time.deltaTime*speed/2);

        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
}
