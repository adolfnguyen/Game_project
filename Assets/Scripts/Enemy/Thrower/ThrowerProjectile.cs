using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerProjectile : MonoBehaviour
{
    public float speed;
    public int dmg;
    private bool m_isBloom = false;
    [SerializeField] Animator mineAnim;
    private Rigidbody2D m_rb;
    public Vector2 f;
    private bool m_addf;
    void Start()
    {
        mineAnim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_addf = true;
    }
    void Update()
    {
        if (m_addf)
        {
            m_rb.AddForce(f);
            m_addf = false;
        }
        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            collision.gameObject.SendMessageUpwards("Damage", dmg);
            if (m_isBloom == false)
                StartCoroutine(Bloom());
        }
        if (collision.gameObject.CompareTag("Invisible Wall"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            if (m_isBloom == false)
                StartCoroutine(Bloom());
        }
    }

    IEnumerator Bloom()
    {
        m_isBloom = true;
        mineAnim.SetBool("BloomAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }
}
