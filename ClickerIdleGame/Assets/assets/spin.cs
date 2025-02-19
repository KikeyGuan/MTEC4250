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
    public TextMeshProUGUI moneySpentText;
    public TextMeshProUGUI scoreText;
    public Animator animate;
    public GameObject upgradeB;
    public GameObject party;
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

        if (upgrade==1 && click == 20){
            upgradeB.SetActive(true);
        }
        if (upgrade==3 && click == 40){
            upgradeB.SetActive(true);
        }
        if (upgrade==5 && click == 60){
            upgradeB.SetActive(true);
        }
        if (upgrade==7 && click == 80){
            upgradeB.SetActive(true);
        }
        if (upgrade==9 && click == 100){
            upgradeB.SetActive(true);
        }
        if (upgrade==11 && click == 120){
            //auto
        }

        if (score > 200){
            party.SetActive(true);

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
        upgrade = upgrade + 2;
        downgrade = downgrade + 1;
        upgradeB.SetActive(false);


    }



}
