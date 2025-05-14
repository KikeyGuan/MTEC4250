using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed, torque, turn;
    private Vector2 move;
    public Transform attachToPlayer;
    private Vector2 insideCricle;
    private Vector3 randomCricle;
    public GameObject gameObj;
    public float gatherArea; //checking
    private int collectedItems;
    // Start is called before the first frame update
    void Start()
    {
        //turn = Input.GetAxisRaw("Horizontal");
        randomCricle = Random.insideUnitCircle * gatherArea;
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

        insideCricle = gameObj.transform.position + randomCricle;
        //expand cricle area
        if (collectedItems == 2) {
            //needs a STOP
            //gatherArea += 1;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            collectedItems += 1;
            collision.gameObject.transform.SetParent(attachToPlayer);
            collision.gameObject.transform.position = insideCricle;
        }

    }
}
