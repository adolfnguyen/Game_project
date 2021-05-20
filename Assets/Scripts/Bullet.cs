using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int dmg = 75;
    public Vector3 xPosition;
    Rigidbody2D bl;
    public float forward;
    // Start is called before the first frame update
    void Start()
    {
        bl = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bl.velocity = transform.right * speed;
        Destroy(transform.gameObject, 1.5f);
    }
    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        /*Enemy enemy = hitintro.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(dmg);
        }*/
        if (hitintro.isTrigger != true && hitintro.CompareTag("Enemy"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
        }
        //Destroy(transform.gameObject);
        if (hitintro.isTrigger != true && hitintro.CompareTag("Ground"))
        {
            Destroy(transform.gameObject);
        }
    }
}
