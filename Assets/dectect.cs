using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dectect : MonoBehaviour
{
    public GameObject D;
    public GameObject D1;
    public bool switched = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (switched == false)
        {
            D.SetActive(true);
            D1.SetActive(false);
            StartCoroutine(DSwitchTrue(10f));
        }
        else {
            D1.SetActive(true);
            D.SetActive(false);
            StartCoroutine(DSwitchFalse(10f));
        }
        
    }
    void FixedUpdate(){
        D.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
        D1.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);

    }

    IEnumerator DSwitchTrue(float switchTime){
        yield return new WaitForSeconds(switchTime);
        switched = true;
    }
    IEnumerator DSwitchFalse(float switchTime)
    {
        yield return new WaitForSeconds(switchTime);
        switched = false;
    }
}
