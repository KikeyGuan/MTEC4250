using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{
    //private float xMin, xMax, yMin, yMax;
    public int foodlimit = 100, foodSpawn, upgradelimit = 5, upgradeSpwan;
    public GameObject[] food;
    public GameObject[] upgrade;
    //get object position, add 5 to get area, spwan object in said area.
    // Start is called before the first frame update
    void Start()
    {
        /*
        xMin = transform.position.x - 5;
        xMax = transform.position.x + 5;
        yMin = transform.position.y - 5;
        yMax = transform.position.y + 5;
        */


        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomSpwanPos = new Vector3(Random.Range(-45, 44), Random.Range(-43, 43), 0); //x.y
        Vector3 randomSpwanPos1 = new Vector3(Random.Range(-45, 44), Random.Range(-43, 43), 0); //x.y
        Vector3 randomSpwanPos2 = new Vector3(Random.Range(-45, 44), Random.Range(-43, 43), 0); //x.y
        if (foodSpawn != foodlimit) //would add respwan but too many items
        {
            //Vector3 randomSpwanPos = new Vector3(Random.Range(-45, 44), Random.Range(-43, 43), 0); //x.y
            Instantiate(food[Random.Range(0, food.Length)], randomSpwanPos, Quaternion.identity);
            foodSpawn += 1;
        }
        
        if (upgradeSpwan != upgradelimit) //would add respwan but too many items
        {
            //Vector3 randomSpwanPos = new Vector3(Random.Range(-45, 44), Random.Range(-43, 43), 0); //x.y
            Instantiate(upgrade[0], randomSpwanPos, Quaternion.identity);
            Instantiate(upgrade[1], randomSpwanPos1, Quaternion.identity);
            Instantiate(upgrade[2], randomSpwanPos2, Quaternion.identity);
            upgradeSpwan += 1;
            
            
        }
        
    }
}
