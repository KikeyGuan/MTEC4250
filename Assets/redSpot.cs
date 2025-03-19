using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class redSpot : MonoBehaviour
{
    public int missingNum;
    public TextMeshProUGUI numTXT;
    bool pass0 = false;
    bool onTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        missingNum = Random.Range(1,50);
        Debug.Log("rand Num: "+ missingNum);
        
    }

    // Update is called once per frame
    void Update()
    {
        numTXT.text = missingNum.ToString();
        if(missingNum == 0){
            pass0 = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && onTrigger == true){
            missingNum = missingNum-1;
            Debug.Log("pressed numder 1");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && onTrigger == true){
            missingNum = missingNum-5;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            onTrigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            onTrigger = false;
        }
    }
}
