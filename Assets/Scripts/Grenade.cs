using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D gren;

    public GameObject trigger;
    public GameObject grenade;
    void Start()
    {
        gren = GetComponent<Rigidbody2D>();
        trigger.SetActive(false);
        grenade.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Lựu đạn chạm địch");
            trigger.SetActive(true);
            grenade.SetActive(false);
            gren.velocity = Vector2.zero;
            Destroy(transform.gameObject, 0.5f);

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Lựu đạn chạm đất");
            gren.AddForce(Vector2.up * 5);
            StartCoroutine(Explore());

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Lựu đạn chạm địch");
            trigger.SetActive(true);
            grenade.SetActive(false);
            gren.velocity = Vector2.zero;
            Destroy(transform.gameObject, 0.5f);

        }
        if (collision.gameObject.CompareTag("Ground"))
        {



        }
    }

    IEnumerator Explore()
    {

        yield return new WaitForSeconds(1f);
        trigger.SetActive(true);
        gren.velocity = Vector2.zero;
        grenade.SetActive(false);
        Destroy(transform.gameObject, 0.5f);
    }
}
