using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement script from Jake Makes Games: https://www.youtube.com/watch?v=tFblCEFQoTs
    public Rigidbody2D player;
    public float speed;
    private Vector2 move;
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
    }
}
