using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class redSpotVer2 : MonoBehaviour
{
    public float bucket;
    public float bucketLimit = 19;
    public float bucketFin = -10;
    public TextMeshProUGUI numTXT;
    bool onTrigger = false;
    bool canFill = true;
    bool routineHappening = false;
    public bool crash = false;
    //public IEnumerator bucketFill;
    // Start is called before the first frame update
    void Start()
    {
        bucket =20;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onTrigger == true){
            bucket = bucket-1;
            Debug.Log("pressed");
        }
        
    }
    public void FixedUpdate(){
        if(bucket<bucketFin){
            crash = true;
            numTXT.text = "-" + Random.Range(30,1000);
            
        }
        else{
            numTXT.text = bucket.ToString();
        }
        if (crash == false && bucket<=bucketLimit){
            canFill = true;
        }
        else{
            canFill = false;
        }
        if(canFill == true && routineHappening == false){
            StartCoroutine(bucketFill(0.5f));
            routineHappening = true;
        }
        
        
        
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            onTrigger = true;
            Debug.Log("enter");
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            onTrigger = false;
        }
    }
    
    IEnumerator bucketFill(float fillTime){
        yield return new WaitForSeconds(fillTime);
        bucket++;
        routineHappening = false;
    }
    

}
