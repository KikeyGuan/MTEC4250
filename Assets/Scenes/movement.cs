using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed, torque, turn;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        //turn = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        move.y = Input.GetAxisRaw("Vertical");
        //Debug.Log (Input.GetAxisRaw("Horizontal"));
        

        if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Rotate(0, 0, 1);
        }
        player.velocity = transform.up * move.y * speed;
        //player.AddTorque(transform.up * torque * turn);

    }
}
