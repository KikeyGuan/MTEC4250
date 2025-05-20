using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed, torque, turn;
    private Vector2 move;
    public Transform attachToPlayer; //the cake or the move object
    private Vector2 insideCricle;
    private Vector3 randomCricle;
    public GameObject cake; 
    public CinemachineVirtualCamera camera;
    public float gatherArea; //checking
    // Start is called before the first frame update
    public int egg, milk, flour;
    void Start()
    {
        //turn = Input.GetAxisRaw("Horizontal");
        cake.transform.localScale = new Vector3(1f,1f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        randomCricle = Random.insideUnitCircle * gatherArea;

        move.y = Input.GetAxisRaw("Vertical");
        //Debug.Log (Input.GetAxisRaw("Horizontal"));
        

        if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.Rotate(0, 0, -0.20f);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Rotate(0, 0, 0.20f);
        }
        player.velocity = transform.up * move.y * speed;
        //move item to random spot in cake
        insideCricle = attachToPlayer.transform.position + randomCricle;
        //player.AddTorque(transform.up * torque * turn);

        if (egg >= 1 && flour >= 1 && milk >= 1){
            gatherArea +=0.5f;
            cake.transform.localScale = new Vector3(cake.transform.localScale.x+.2f,cake.transform.localScale.y+.2f,cake.transform.localScale.z+.2f);
            if (camera.m_Lens.OrthographicSize != 15){
                camera.m_Lens.OrthographicSize +=0.2f;
            }
            egg -= 1;
            flour -= 1;
            milk -= 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fruit" || 
            collision.gameObject.tag == "sweet" || 
            collision.gameObject.tag == "egg" ||
            collision.gameObject.tag == "flour" ||
            collision.gameObject.tag == "milk")
        {
            collision.gameObject.transform.SetParent(attachToPlayer);
            collision.gameObject.transform.position = insideCricle;
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
            if(collision.gameObject.tag == "egg"){
                egg +=1;
            }
            if(collision.gameObject.tag == "flour"){
                flour +=1;
            }
            if(collision.gameObject.tag == "milk"){
                milk +=1;
            }
        }

    }
}
