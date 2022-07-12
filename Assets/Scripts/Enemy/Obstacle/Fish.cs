using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int dmg;
    private bool m_isBloom = false;
    [SerializeField] Animator mineAnim;
    private Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        mineAnim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Enemy"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            hitintro.SendMessageUpwards("Damage", dmg);
            if (m_isBloom == false)
                StartCoroutine(Bloom());
        }
        if (hitintro.CompareTag("Ground"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            if (m_isBloom == false)
                StartCoroutine(Bloom());
        }
        if (hitintro.CompareTag("Player"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            hitintro.SendMessageUpwards("Damage", dmg);
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
