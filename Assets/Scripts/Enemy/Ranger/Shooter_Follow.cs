using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Follow : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public float followRadius;
    public GameObject projectile;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;

    public float attackDelay;
    [SerializeField] Transform m_firePoint;
    private bool m_canShoot;
    private bool m_isDeath = false;

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
        SetFollowRadius(followRadius);
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
        if (CheckFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform) && m_canShoot)
                {
                    StartCoroutine(EnemyShoot_L());
                    m_canShoot = false;
                }
                else if (!CheckAttackRadiusX(playerTransform, transform))
                {
                    transform.position += new Vector3(-GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                    enemyAnim.SetBool("AttackAnim", false);
                    enemyAnim.SetBool("WalkAnim", true);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform) && m_canShoot)
                {
                    StartCoroutine(EnemyShoot_R());
                    m_canShoot = false;
                }
                else if (!CheckAttackRadiusX(playerTransform, transform))
                {
                    transform.position += new Vector3(GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                    enemyAnim.SetBool("AttackAnim", false);
                    enemyAnim.SetBool("WalkAnim", true);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
        else
        {
            enemyAnim.SetBool("WalkAnim", false);
            enemyAnim.SetBool("AttackAnim", false);
        }                                
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
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

    IEnumerator EnemyShoot_L()
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

    IEnumerator EnemyShoot_R()
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
}
