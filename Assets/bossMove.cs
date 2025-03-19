using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public bool timeUp;
    public int area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUp == true && area ==1){
            transform.position=Vector2.MoveTowards(transform.position, area1.transform.position, 7 * Time.deltaTime);
        }
        if(timeUp == true && area ==2){
            transform.position=Vector2.MoveTowards(transform.position, area2.transform.position, 7 * Time.deltaTime);
        }
        if(timeUp == true && area ==3){
            transform.position=Vector2.MoveTowards(transform.position, area3.transform.position, 7 * Time.deltaTime);
        }
        
    }
}
