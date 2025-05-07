using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{
    private float xMin, xMax, yMin, yMax;
    public GameObject fish1;
    public GameObject fish2;
    //get object position, add 5 to get area, spwan object in said area.
    // Start is called before the first frame update
    void Start()
    {
        xMin = transform.position.x - 5;
        xMax = transform.position.x + 5;
        yMin = transform.position.y - 5;
        yMax = transform.position.y + 5;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
