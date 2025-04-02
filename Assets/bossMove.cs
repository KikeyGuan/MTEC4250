using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bossMove : MonoBehaviour
{
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    //area 1 badspots
    public redSpotVer2 level10;
    public redSpotVer2 level12;
    public redSpotVer2 level13;
    bool level1Complete = false;
    //area 2 badspots
    public redSpotVer2 level21;
    public redSpotVer2 level22;
    public redSpotVer2 level23;
    bool level2Complete = false;
    //area 3 badspots
    public redSpotVer2 level31;
    public redSpotVer2 level32;
    public redSpotVer2 level33;
    public redSpotVer2 level34;
    bool level3Complete = false;

    public int area= 0;
    public bool routineHappening = false;
    public redSpotVer2 tutori;
    public int speed = 7;
    public IEnumerator waitForTimeLimit;
    public IEnumerator waitForTimeLimit2;
    public player text;
    public TextMeshProUGUI countdownTXT;
    float countdown = 58;
    // Start is called before the first frame update
    void Start()
    {
        waitForTimeLimit = timeLimit(56f);
        waitForTimeLimit2 = timeLimit2(56f);
 
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;


        if (area == 0 && tutori.crash == true)
        {
            area++;
        }

        if(area ==1){
            transform.position=Vector2.MoveTowards(transform.position, area1.transform.position, speed * Time.deltaTime);
            countdownTXT.text = countdown.ToString();
            if (routineHappening == false) {
                StartCoroutine(waitForTimeLimit);
                routineHappening = true;
            }
            // if red spot in next area is broken && timeUp == false area++
            if(level10.crash == true && level12.crash == true && level13.crash == true){
                StopCoroutine(waitForTimeLimit);
                level1Complete = true;
                area++;
            }

            
        }
        if(area ==2){
            transform.position=Vector2.MoveTowards(transform.position, area2.transform.position, speed * Time.deltaTime);
            countdown = 58f - Time.deltaTime;
            countdownTXT.text = countdown.ToString();
            if (routineHappening == false)
            {
                StartCoroutine(waitForTimeLimit2);
                routineHappening = true;
            }
            if(level21.crash == true && level22.crash == true && level23.crash == true){
                speed = 7;
                StopCoroutine(waitForTimeLimit2);
                area++;
                level2Complete = true;
            }

        }
        if(area ==3){
            //routineHappening=false;
            transform.position=Vector2.MoveTowards(transform.position, area3.transform.position, speed * Time.deltaTime);
            if (routineHappening == false)
            {
                StartCoroutine(timeWinCheck(55f));
                routineHappening = true;
            }
            if (level31.crash == true && level32.crash == true && level33.crash == true && level34.crash == true){
                speed = 7;
                level3Complete = true;
                winCheck();

            }
        }

        
        
        
    }
    public IEnumerator timeLimit(float waitTime) {
        //Debug.Log(waitTime + area);
        yield return new WaitForSeconds(waitTime);
        area++;
        speed = 10;
        routineHappening = false;
        //Debug.Log(area);
    }
    //making aonther coroutine since the second one keeps adding a extra 1, and i have no clue
    public IEnumerator timeLimit2(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        area++;
        speed = 10;
        routineHappening = false;
    }
    
    IEnumerator timeWinCheck(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        winCheck();
    }
    
    void winCheck(){
        //wining check
        if(level1Complete == true && level2Complete == true && level3Complete == true){
            text.canMove = false;
            text.healthTXT.text = "YOU WIN!!";
            //TEXT YOU WIN!!
        }
        else{
            text.healthTXT.text = "<3: " + text.health + "  YOU HAVE FAILED TO CRASH THE MARKET";
            text.canMove = false;
            transform.position=Vector2.MoveTowards(transform.position, area1.transform.position, speed * Time.deltaTime);
        }

    }
}
