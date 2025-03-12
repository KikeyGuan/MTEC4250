using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector2(0,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("help");
        
        if (collision.gameObject.tag == "star" || collision.gameObject.tag == "danger"){
            FindObjectOfType<spwan>().starCollected(-1);
            Destroy(this.transform.parent.gameObject);
            //^^https://discussions.unity.com/t/destroy-parent-of-child-gameobject/45464
        }
        
    }
}
