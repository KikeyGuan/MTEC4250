using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public bool canFeed;
    public movement movementScript;
    public Transform attachToPlayer;
    private Vector2 insideCricle;
    private Vector3 randomCricle;
    public SpriteRenderer cakeSprite;
    public Sprite cakeB;
    public int egg, flour, milk;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float gatherArea = movementScript.gatherArea;
        randomCricle = Random.insideUnitCircle * gatherArea;
        insideCricle = attachToPlayer.transform.position + randomCricle;
        egg = movementScript.egg;
        flour = movementScript.flour;
        milk = movementScript.milk;

        if (egg >= 1 && flour >= 1 && milk >= 1)
        {
            canFeed = true;// cant make otehr cat scrpits false, perma true
        }
        else
        {
            canFeed = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && canFeed == true)
        {
            print("hit");
            this.gameObject.transform.SetParent(attachToPlayer);
            this.gameObject.transform.position = insideCricle;
            cakeSprite.sprite = cakeB;

            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            canFeed = false;
        }
    }
}
