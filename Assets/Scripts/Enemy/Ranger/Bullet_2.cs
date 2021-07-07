using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_2 : MonoBehaviour
{
    public float speed;
    public int dmg;
    Rigidbody2D bl;
    public float shootingPower;
    [SerializeField] Transform playerTransform;
    private Vector2 m_direction;

    // Start is called before the first frame update
    void Start()
    {
        bl = GetComponent<Rigidbody2D>();
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        m_direction = (playerTransform.position - transform.position).normalized * shootingPower;
    }

    // Update is called once per frame
    void Update()
    {
        bl.velocity = new Vector2(m_direction.x, m_direction.y);
        Destroy(transform.gameObject, 1.5f);
    }
    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Enemy"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            Destroy(transform.gameObject);
        }
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
