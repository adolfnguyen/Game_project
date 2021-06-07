using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        //aim = gameObject.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        bl.velocity = transform.right * speed;
        Destroy(transform.gameObject, 1.5f);
        //aim.SetBool("Touching", touching);
    }
    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Enemy"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
            //touching = true;
        }
        if (hitintro.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
            //touching = true;
        }
        if (hitintro.CompareTag("Player"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
            //touching = true;
        }
    }
}
