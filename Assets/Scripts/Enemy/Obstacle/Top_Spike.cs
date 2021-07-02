using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top_Spike : MonoBehaviour
{
    public int dmg;
    [SerializeField] Transform playerTransform;
    Rigidbody2D m_rb;
    public Transform rayOrigin;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.down);
        if (hit.collider.CompareTag("Player"))
        {
            m_rb.bodyType = RigidbodyType2D.Dynamic;
        }
        //if (playerTransform.position.x == transform.position.x)
        //{
        //    m_rb.bodyType = RigidbodyType2D.Dynamic;
        //}
    }

    private void OnCollisionEnter2D(Collision2D hitintro)
    {
        if (hitintro.gameObject.CompareTag("Enemy"))
        {
            hitintro.gameObject.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
        }
        if (hitintro.gameObject.CompareTag("Player"))
        {
            hitintro.gameObject.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
        }
    }
}
