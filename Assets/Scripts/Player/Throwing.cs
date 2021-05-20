using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject Grenade;
    public Transform firePoint;
    Rigidbody2D shellInstance;
    public float launch;
    public float speed;
   // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickProcess();
    }
    private void ClickProcess()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(Grenade, firePoint.position, firePoint.rotation);
            shellInstance.GetComponent<Rigidbody>().velocity = launch * firePoint.transform.GetChild(0).forward * speed;

        }
    }
}
