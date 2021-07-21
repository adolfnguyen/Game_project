using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_JumpAround : Enemies
{
    public int attackDamage;
    public int hitPoint;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    private bool m_isDeath = false;
    Rigidbody2D m_rb;
    private bool m_coroutineAllow = true;
    private int m_jumpState = 1;

    [SerializeField] float jumpX, jumpY;
    [SerializeField] float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0)
        {
            if (m_isDeath == false)
                StartCoroutine(Death());
        }
        else
        {
            if (m_jumpState == 1)
            {
                if (m_coroutineAllow)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    StartCoroutine(Jump(-jumpX, jumpY));
                    m_jumpState = 2;
                }
            }
            else if (m_jumpState == 2)
            {
                if (m_coroutineAllow)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    StartCoroutine(Jump(jumpX, jumpY));
                    m_jumpState = 1;
                }
            }
        }
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
        enemyAnim.SetBool("HitAnim", true);
        StartCoroutine(WaitHitAnim());
    }
    IEnumerator WaitHitAnim()
    {
        yield return new WaitForSeconds(0.1f);
        enemyAnim.SetBool("HitAnim", false);
    }
    IEnumerator Death()
    {
        m_isDeath = true;
        enemyAnim.SetBool("JumpAnim", false);
        yield return new WaitForSeconds(0.75f);
        Destroy(transform.gameObject);
    }

    IEnumerator Jump(float x, float y)
    {
        m_coroutineAllow = false;
        enemyAnim.SetBool("JumpAnim", true);
        m_rb.velocity = new Vector2(x, y);
        yield return new WaitForSeconds(timeDelay);
        m_coroutineAllow = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enemyAnim.SetBool("JumpAnim", false);
        }
    }
}
