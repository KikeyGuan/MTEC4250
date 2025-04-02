using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float speed;
    private Vector2 move;
    public TextMeshProUGUI healthTXT;
    public int health = 10;
    bool cortineHappening = false;
    bool safe =true;
    public bool canMove = true;
    public SpriteRenderer playerColor;
    //float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        healthTXT.text = "<3: " + health;
        if(canMove == false){
            playerColor.color =new Color(1,1,1);
        }
        if(canMove == true){
            playerColor.color = new Color(0.2f,0.7f,0.9f);
        }
        if (health == 0){
            healthTXT.text = "<3: " + health + "  YOU HAVE FAILED TO CRASH THE MARKET";
            Time.timeScale = 0;
        }

        
        if (!canMove) return;// !!!!stops code underneth this one. (!canMove)= can move == false

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
        if (collision.gameObject.tag == "Look")
        {
            canMove = false;
            StartCoroutine(thaw(2f));
        }
        if (collision.gameObject.tag == "boss"){
            safe =true;
            //Debug.Log("safe");
        }
        //collision with Look to freeze
        
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
    IEnumerator thaw(float thawTime) {
        yield return new WaitForSeconds(thawTime);
        canMove = true;

    }

    
}
