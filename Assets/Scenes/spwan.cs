using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject monsterPrefab;
    public GameObject beesPrefab;
    public int starCount =10;
    public int dangerSpwan = 5;


    Vector3 randomSpwanPos;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < starCount; i++)
        {
            Vector3 randomSpwanPos = new Vector3(Random.Range(-35, 39),Random.Range(24,-20) , 0);
            Instantiate(starPrefab, randomSpwanPos, Quaternion.identity);
        }
        for (int i = 0; i <dangerSpwan; i++)
        {
            Vector3 randomSpwanPos = new Vector3(Random.Range(-35, 39), Random.Range(24, -20), 0);
            Instantiate(monsterPrefab, randomSpwanPos, Quaternion.identity);
            Instantiate(beesPrefab, new Vector3(Random.Range(-35, 39), Random.Range(24, -20), 0), Quaternion.identity);
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
