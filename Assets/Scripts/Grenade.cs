using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
   
    Rigidbody2D gren;
    public float forward;
    
    void Start()
    {
        gren = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        Destroy(transform.gameObject, 1.5f);
    }
}
