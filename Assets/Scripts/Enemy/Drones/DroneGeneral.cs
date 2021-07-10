using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGeneral : Enemies
{
    public int attackDamage;
    public int hitPoint;
    public int moveSpeed;
    private bool m_isDeath;

    public float distance;

    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    Rigidbody2D m_rb;

    [SerializeField] private Transform[] m_routes;
    private int m_routeToGo;
    private float m_tParam;
    private Vector2 m_myPos;
    public float speedModifier;
    private bool m_coroutineAllow;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetMoveSpeed(moveSpeed);
        m_rb = GetComponent<Rigidbody2D>();
        m_isDeath = false;

        m_routeToGo = 0;
        m_tParam = 0f;
        m_coroutineAllow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDeath)
        {
            m_rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            //for (distance = 10; distance <= 0; distance -= GetMoveSpeed() * Time.deltaTime)
            //{
            //    Vector3 vec = new Vector3(GetMoveSpeed() * Time.deltaTime, 0f, 0f);
            //    transform.position += vec;
            //    //distance -= vec.x;
            //}
            //m_coroutineAllow = true;
            if (m_coroutineAllow)
            {
                StartCoroutine(GoByTheRoute(m_routeToGo));
            }
        }
    }

    private IEnumerator GoByTheRoute(int routeNumer)
    {
        m_coroutineAllow = false;
        Vector2 p0 = m_routes[routeNumer].GetChild(0).position;
        Vector2 p1 = m_routes[routeNumer].GetChild(1).position;
        Vector2 p2 = m_routes[routeNumer].GetChild(2).position;
        Vector2 p3 = m_routes[routeNumer].GetChild(3).position;

        while (m_tParam < 1)
        {
            m_tParam += Time.deltaTime * speedModifier;
            
            m_myPos = Mathf.Pow(1 - m_tParam, 3) * p0 + 3 * Mathf.Pow(1 - m_tParam, 2) * m_tParam * p1 +
                3 * (1 - m_tParam) * Mathf.Pow(m_tParam, 2) * p2 + Mathf.Pow(m_tParam, 3) * p3;
            
            transform.position = m_myPos;
            yield return new WaitForEndOfFrame();
        }
        m_tParam = 0;
        m_routeToGo += 1;
        if (m_routeToGo > m_routes.Length - 1)
        {
            m_routeToGo = 0;
        }
        m_coroutineAllow = true;
    }

    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }

    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Enemy"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            hitintro.SendMessageUpwards("Damage", attackDamage);
            if (m_isDeath == false)
                StartCoroutine(Bloom());
        }
        if (hitintro.CompareTag("Ground"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            if (m_isDeath == false)
                StartCoroutine(Bloom());
        }
        if (hitintro.CompareTag("Player"))
        {
            m_rb.bodyType = RigidbodyType2D.Static;
            hitintro.SendMessageUpwards("Damage", attackDamage);
            if (m_isDeath == false)
                StartCoroutine(Bloom());
        }
    }

    IEnumerator Bloom()
    {
        m_isDeath = true;
        enemyAnim.SetBool("DeathAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }
}
