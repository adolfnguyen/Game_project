using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_1 : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public GameObject projectile;
    [SerializeField] Animator enemyAnim;
    [SerializeField] Transform playerTransform;
    SpriteRenderer m_enemySR;

    public float attackDelay;
    [SerializeField] Transform m_firePoint;
    private bool m_canShoot;
    private int m_walkState = 0;
    private bool m_isDeath = false;

    [SerializeField] private Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetMoveSpeed(moveSpeed);
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetAttackRadius(attackRadius);
        SetAttackDelay(attackDelay);
        m_canShoot = true;
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
            if (CheckAttackRadius(playerTransform, transform) && m_canShoot)
            {
                if (playerTransform.position.x < transform.position.x)
                {
                    StartCoroutine(EnemyShoot_L());
                    m_canShoot = false;
                }
                else
                {
                    StartCoroutine(EnemyShoot_R());
                    m_canShoot = false;
                }
            }
            else if (m_canShoot == true)
            {
                if (transform.position.x >= waypoints[1].position.x)
                {
                    m_walkState = 0;
                }
                if (transform.position.x <= waypoints[0].position.x)
                {
                    m_walkState = 0;
                }

                if (m_walkState == 2)
                    MoveRight();
                else if (m_walkState == 1)
                    MoveLeft();
                else if (m_walkState == 0)
                    StartCoroutine(Wait3s());

            }
        }   
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }

    IEnumerator EnemyShoot_L()
    {
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(attackDelay);
        transform.eulerAngles = new Vector3(0, 180, 0);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        enemyAnim.SetBool("AttackAnim", true);
        yield return new WaitForSeconds(attackDelay);
        enemyAnim.SetBool("AttackAnim", false);
        m_canShoot = true;
    }

    IEnumerator EnemyShoot_R()
    {
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(attackDelay);
        transform.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        enemyAnim.SetBool("AttackAnim", true);
        yield return new WaitForSeconds(attackDelay);
        enemyAnim.SetBool("AttackAnim", false);
        m_canShoot = true;
    }
    IEnumerator Death()
    {
        m_isDeath = true;
        enemyAnim.SetBool("AttackAnim", false);
        enemyAnim.SetBool("WalkAnim", false);
        enemyAnim.SetBool("DeathAnim", true);
        yield return new WaitForSeconds(0.85f);
        Destroy(transform.gameObject);
    }
    void MoveLeft()
    {
        m_walkState = 1;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 180, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }

    void MoveRight()
    {
        m_walkState = 2;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }

    private IEnumerator Wait3s()
    {
        m_walkState = 0;
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(3.0f);
        if (transform.position.x >= waypoints[1].position.x)
        {
            m_walkState = 1;
            attackRadius *= -1;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x <= waypoints[0].position.x)
        {
            m_walkState = 2;
            attackRadius *= -1;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        }
    }
}
