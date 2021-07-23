using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGeneral : Enemies
{
    public int attackDamage;
    public int hitPoint;
    private bool m_isDeath;

    [SerializeField] Animator enemyAnim;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform playerTransform;
    SpriteRenderer m_enemySR;
    Rigidbody2D m_rb;

    [SerializeField] private Transform[] m_routes;
    private int m_routeToGo;
    private float m_tParam;
    private Vector2 m_myPos;
    public float speedModifier;
    private bool m_coroutineAllow;
    public GameObject projectile;
    public int fireRate;
    public float attackDelay;
    private bool m_canAttack;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        m_rb = GetComponent<Rigidbody2D>();
        m_isDeath = false;

        m_routeToGo = 0;
        m_tParam = 0f;
        m_coroutineAllow = true;
        m_canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0)
        {
            if (!m_isDeath)
            {
                StartCoroutine(Bloom());
            }
        }
        else
        {
            if (m_coroutineAllow)
            {
                StartCoroutine(GoByTheRoute(m_routeToGo));
            }
            if (Mathf.Abs(playerTransform.position.x - transform.position.x) < 1)
            {
                Debug.Log("hehe");
                if (Random.Range(1, fireRate) == 1 && m_canAttack)
                {
                    StartCoroutine(Shoot());
                }
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

    IEnumerator Shoot()
    {
        m_canAttack = false;
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(attackDelay);
        m_canAttack = true;
    }
}
