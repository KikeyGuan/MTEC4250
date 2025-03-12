using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement script from Jake Makes Games: https://www.youtube.com/watch?v=tFblCEFQoTs
    public Rigidbody2D player;
    public float speed;
    private Vector2 move;
    private bool isWalking = false;
    public AudioSource boomBox;
    public AudioSource walk;
    public AudioClip wallBump;
    public AudioClip twinkle;
    public AudioClip over;
    //public GameObject starCheck;
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
        player.velocity = move * speed;
        //Debug.Log(player.velocity.magnitude);
        if (move.x != 0 || move.y != 0){
            isWalking = true;
        }
        else{
            isWalking = false;
        }

        if (isWalking==true){
            walk.enabled = true;
        }
        else{
            walk.enabled = false;
        }




        /*
        if (walk.isPlaying == false && player.velocity.magnitude == 3){
            walk.Play();
            Debug.Log("walk is playing");
        }
        if(walk.isPlaying){
            walk.Stop();
        }

        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall"){
            boomBox.PlayOneShot(wallBump);
        }

        if (collision.gameObject.tag == "star") {
            FindObjectOfType<spwan>().starCollected(-1);
            //starCheck.<spwan>().int(starCount);
            boomBox.PlayOneShot(twinkle);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "danger"){
            boomBox.PlayOneShot(over);
        }
        //script to script help : https://www.youtube.com/watch?v=tJOw9mI6GtU&ab_channel=LittleArchGames
    }
}
