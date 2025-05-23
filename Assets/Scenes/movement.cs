using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed, gatherArea, torque;
    private Vector2 move;
    public Transform attachToPlayer, attachToMove; //the cake or the move object
    private Vector3 insideCricle;
    private Vector3 randomCricle;
    public GameObject cake, shoal;
    public CinemachineVirtualCamera camera;
    public int egg, milk, flour, upgradeP, score = 0;
    public Sprite cakeF, cakeB, CE1, CE2, CE3;//CE = cat eat
    public SpriteRenderer cakeSprite;
    public bool canFeed = false;
    public AudioSource collect;
    public TextMeshProUGUI totalScore;
    public spwan spawnScript;

    void Start()
    {
        //turn = Input.GetAxisRaw("Horizontal");
        cake.transform.localScale = new Vector3(1f, 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        randomCricle = Random.insideUnitCircle * gatherArea;
        totalScore.text = "Score: " + score;

        move.y = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.Rotate(0, 0, -0.10f);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Rotate(0, 0, 0.10f);
        }
        player.velocity = transform.up * move.y * speed;


        //move item to random spot in cake
        insideCricle = attachToPlayer.transform.position + randomCricle;

        //upgrade cake, growth and cat collecting
        if (egg >= 1 && flour >= 1 && milk >= 1)
        {
            canFeed = true;
            gatherArea += 0.3f;
            cake.transform.localScale = new Vector3(cake.transform.localScale.x + .2f, cake.transform.localScale.y + .2f, cake.transform.localScale.z + .2f);
            shoal.transform.position = new Vector3(shoal.transform.position.x, shoal.transform.position.y - .5f, shoal.transform.position.z);//move to -y
            if (camera.m_Lens.OrthographicSize != 15)
            {
                camera.m_Lens.OrthographicSize += 0.3f;
            }
            cakeSprite.sprite = cakeF;


            egg -= 1;
            flour -= 1;
            milk -= 1;
        }



    }

    void FixedUpdate()
    {
        //float turn = move.y ;
        float xmove = Input.GetAxisRaw("Horizontal");
        //testingPlayer.AddRelativeTorque(transform.up * torque * xmove);//works in 3d
        player.AddTorque(xmove * torque); //dont forget to unfrezze z rotation. needs to be negtive so torque is not fighitng player controller
                                          //player.AddTorque(move.y * torque); //spins player when going forward.


    }

    /*
    scoring 
    cat-1000
    milk/eggs/flour- 100
    sweets- 50
    fruits- 30
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fruit" ||
            collision.gameObject.tag == "sweet" ||
            collision.gameObject.tag == "egg" ||
            collision.gameObject.tag == "flour" ||
            collision.gameObject.tag == "milk")
        {
            collect.pitch = Random.Range(0.5f, 1.9f);
            collect.Play();
            collision.gameObject.transform.SetParent(attachToPlayer);
            collision.gameObject.transform.position = insideCricle;
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
            if (collision.gameObject.tag == "fruit")
            {
                score += 30;
            }
            if (collision.gameObject.tag == "sweet")
            {
                score += 50;
            }

            if (collision.gameObject.tag == "egg")
            {
                score += 100;
                egg += 1;
            }
            if (collision.gameObject.tag == "flour")
            {
                score += 100;
                flour += 1;
            }
            if (collision.gameObject.tag == "milk")
            {
                score += 100;
                milk += 1;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cat" && canFeed == true)
        {
            score += 1000;
            collision.gameObject.transform.SetParent(attachToMove);
            collision.gameObject.transform.position = insideCricle;
            cakeSprite.sprite = cakeB;
            if (collision.gameObject.name == "cat1")
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = CE1;
            }
            if (collision.gameObject.name == "cat2")
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = CE2;
            }
            if (collision.gameObject.name == "cat3")
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = CE3;
            }
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            //int foodSpawn = spawnScript.foodSpawn;
            //print(foodSpawn);
            print("cant feed");
            canFeed = false;
            destroyfood();
            

        }
        else
        {

        }


    }

    void destroyfood()
        {
        print("destroy food");
            for (int i = attachToPlayer.transform.childCount - 1; 1 >= 0; i--)
        {
            spawnScript.foodSpawn = 200 - attachToPlayer.transform.childCount;
            Destroy(attachToPlayer.transform.GetChild(i).gameObject);
        }
         }
    
}
