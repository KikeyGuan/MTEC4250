using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float speed;
    private Vector2 move;
    public int health = 10;
    bool cortineHappening = false;
    bool safe =true;
    //float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        move.Normalize();
        playerRB.velocity = move * speed;
        
    }
    
    void FixedUpdate(){
        if(safe == false && cortineHappening == false){
            StartCoroutine(damage(3f));
            cortineHappening = true;
        }

    }


    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "boss"){
            safe =true;
            //Debug.Log("safe");
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "boss"){
            safe = false;
            //Debug.Log("not safe");
        }
    }

    IEnumerator damage(float waitTime)
    {
        health--;
        yield return new WaitForSeconds(waitTime);
        cortineHappening = false;
        
    }

    
}
