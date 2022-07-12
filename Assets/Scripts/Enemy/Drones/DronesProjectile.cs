using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronesProjectile : MonoBehaviour
{
    public float speed;
    public int dmg;
    Rigidbody2D bl;

    //Animator aim;
    //public bool touching;   
    // Start is called before the first frame update
    void Start()
    {
        bl = GetComponent<Rigidbody2D>();
        bl.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(transform.gameObject, 15f);
    }
    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
        if (hitintro.CompareTag("Player"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
        }
    }
}
