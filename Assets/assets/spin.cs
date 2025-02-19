using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class spin : MonoBehaviour
{
    public int score = 0;
    public int num;
    public int click;
    public int upgrade = 1;
    public int downgrade = 1;
    public int gradeLevel;
    public bool canAuto = false;
    public TextMeshProUGUI moneySpentText;
    public TextMeshProUGUI scoreText;
    public Animator animate;
    public GameObject upgradeB;
    public GameObject upgradeA;
    public GameObject party;
    public GameObject autoSlot;
    //public IEnumerator autoS;
    // Start is called before the first frame update
    void Start()
    {
        //turns whole game object off. hides it
        upgradeB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        num = Random.Range(1,3);
        moneySpentText.text = "Money Spent: " + click;
        scoreText.text = "Score: " + score;
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("down");
            animate.SetBool("rolling", true);
        }
        else {
            animate.SetBool("rolling",false);
        }

        //make clicks and money spent different

        if (gradeLevel == 0 && click >= 20){
            upgradeB.SetActive(true);
        }
        if (gradeLevel == 1 && click >= 40){
            upgradeB.SetActive(true);
        }
        if (gradeLevel == 2 && click >= 60){
            upgradeB.SetActive(true);
        }
        if (gradeLevel == 3 && click >= 80){
            upgradeB.SetActive(true);
        }
        if (gradeLevel == 4 && click >= 100){
            upgradeB.SetActive(true);
        }
        
        if (gradeLevel == 5 && click >= 120){     //gradeLevel == 5 click = 120
            //auto, make coroutine
            if (gradeLevel == 5 && click >= 120)//condition needs to turn off 
            {
                upgradeA.SetActive(true);//start upgradeP
            }
            while (canAuto==true &&Time.timeScale == 1) {
                StartCoroutine(auto(2));
                Debug.Log("auto spin happening");
            }
            
        }

        if (score > 1000){
            party.SetActive(true);

        }
        
    }

    IEnumerator auto(float autoTime) {
        canAuto = false;//keep this or unity will crash!
        yield return new WaitForSeconds(autoTime);
        if (num == 1)
        {
            score = score + upgrade;
            canAuto = true;
        }
        else
        {
            score = score - downgrade;
            canAuto = true;
        }

    }

    public void testing(){
        //created new function so we can call it from the button event system.
        Debug.Log("spin");
    }

    public void roll(){
        if (num==1){
            score = score + upgrade;
        }
        else{
            score = score - downgrade;
        }
    }

    public void clickCounter(){
        click++;

    }

    public void upgradeP(){
        gradeLevel++;
        upgrade = upgrade + 2;
        downgrade = downgrade + 1;
        upgradeB.SetActive(false);
    }

    public void upgradeAuto() {
        canAuto = true;
        gradeLevel++;
        autoSlot.SetActive(true);//turn on visual
        upgradeA.SetActive(false);
    }



}
