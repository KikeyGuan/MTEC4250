using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class spin : MonoBehaviour
{
    public int score = 0;
    public int num;
    private int autoNum;
    public int click= 10;
    private int upgrade = 1;
    private int downgrade = 1;
    private int autoRolled;
    private int autoRolled2;
    public int pos = 11;
    public int neg = -10;
    public int gradeLevel;
    public bool canAuto = false;
    public bool canAuto2 = false;
    public TextMeshProUGUI moneySpentText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rolledScore;
    public TextMeshProUGUI possibleRoll;
    public TextMeshProUGUI auto1;
    public TextMeshProUGUI auto2;
    public Animator animate;
    public GameObject upgradeB;
    public GameObject upgradeA;
    public GameObject autoSlot2;
    public GameObject party;
    public GameObject autoSlot;
    public AudioSource winSound;
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
        autoNum = Random.Range(1,3);
        num = Random.Range(neg,pos);
        moneySpentText.text = "Money Spent: " + click;
        scoreText.text = "Score: " + score;
        possibleRoll.text = "Possible Rolls: " + neg + " to " + pos;
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
        
        if (gradeLevel >= 5 && click >= 120){     //gradeLevel == 5 click = 120
            //auto, make coroutine
            if (gradeLevel == 5 && click >= 120)//condition needs to turn off 
            {
                upgradeA.SetActive(true);//start upgradeP
            }
            while (canAuto==true &&Time.timeScale == 1) {
                StartCoroutine(auto(2));
                auto1.text = autoRolled.ToString();
                //Debug.Log("auto spin happening");
            }
        }

        if (gradeLevel >= 6 && click >= 140){     //gradeLevel == 5 click = 120
            //auto, make coroutine
            if (gradeLevel == 6 && click >= 140)//condition needs to turn off 
            {
                upgradeA.SetActive(true);//start upgradeP
            }
            while (canAuto2==true &&Time.timeScale == 1) {
                StartCoroutine(auto2nd(2));
                auto2.text = autoRolled2.ToString(); // text not changing
                
                
            }
        }

        /*
        if (score > 1000){
            party.SetActive(true);
        }
        */
        
    }

    IEnumerator auto(float autoTime) {
        canAuto = false;//keep this or unity will crash!
        yield return new WaitForSeconds(autoTime);
        if (autoNum == 1)
        {
            score = score + upgrade;
            autoRolled = 1;
            canAuto = true;
        }
        else
        {
            score = score - downgrade;
            autoRolled = -1;
            canAuto = true;
        }

    }

    IEnumerator auto2nd(float autoTime) {
        canAuto2 = false;//keep this or unity will crash!
        yield return new WaitForSeconds(autoTime);
        if (autoNum == 1)
        {
            score = score + upgrade;
            autoRolled2 = 1;
            canAuto2 = true;
        }
        else
        {
            score = score - downgrade;
            autoRolled2 = -1;
            canAuto2 = true;
        }

    }


    /// BUTTONS DOWN BELOW

    public void testing(){
        //created new function so we can call it from the button event system.
        Debug.Log("spin");
    }

    public void roll(){
        /*
        if (num==1){
            score = score + upgrade;
        }
        else{
            score = score - downgrade;
        }
        */
        if (click>=1){
            if (winSound.isPlaying == false){
                Debug.Log ("winSound played");
                winSound.Play();
            }
            
            score = score + num;
            rolledScore.text = num.ToString();
        }
    }

    public void clickCounter(){
        if (click >= 1){
            click--;
        }

    }

    public void upgradeP(){
        gradeLevel++;
        //upgrade = upgrade + 2;
        //downgrade = downgrade + 1;
        neg = neg + -10;
        pos = pos + 10;
        upgradeB.SetActive(false);
    }

    public void upgradeAuto() {
        canAuto = true;
        canAuto2 = true;
        autoSlot.SetActive(true);//turn on visual
        if (gradeLevel == 6){
            autoSlot2.SetActive(true);
        }
        gradeLevel++;
        upgradeA.SetActive(false);
    }

    public void cashOut() {
        click=click + score;
        score = 0;
    }

    public void loan() {
        if (0 != 0)// click >=20. 0==0 for upgrade testing
        {
            click = 0;
        }
        else
        {
            click = click + 20;
        }
        

    }

    public void bet() {
        if (autoNum == 1)
        {
            click = click * 2;
        }
        else
        {
            click = 0;
        }
    }



}
