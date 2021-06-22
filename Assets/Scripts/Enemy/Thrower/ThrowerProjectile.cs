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
    void Start()
    {
        mineAnim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
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
    }

    IEnumerator Bloom()
    {
        m_isBloom = true;
        mineAnim.SetBool("BloomAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }
}
