using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallsound : MonoBehaviour
{
    public AudioSource hitWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitWall.Play(0);
    }
}
