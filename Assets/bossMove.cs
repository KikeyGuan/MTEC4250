using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    //public bool timeUp = false;
    public int area= 0;
    bool routineHappening = false;
    public redSpotVer2 tutori;
    int speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (routineHappening == false && tutoriDone == true) {
            StartCoroutine(timeLimit(3f));
            routineHappening = true;
        }
        */

        if (area == 0 && tutori.crash == true)
        {
            area++;
        }

        if(area ==1){
            transform.position=Vector2.MoveTowards(transform.position, area1.transform.position, speed * Time.deltaTime);
            if (routineHappening == false) {
                StartCoroutine(timeLimit(15f));
                routineHappening = true;
            }
            // if red spot in next area is broken && timeUp == false area++
            
        }
        if(area ==2){
            transform.position=Vector2.MoveTowards(transform.position, area2.transform.position, speed * Time.deltaTime);
            if (routineHappening == false)
            {
                speed = 7;
                //timeUp = false;
                StartCoroutine(timeLimit(15f));
                routineHappening = true;
            }
        }
        if(area ==3){
            transform.position=Vector2.MoveTowards(transform.position, area3.transform.position, speed * Time.deltaTime);
        }
        
        
    }
    IEnumerator timeLimit(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        area++;
        speed = 10;
        //timeUp = true;
        routineHappening = false;
        Debug.Log("movingOn");
    }
}
