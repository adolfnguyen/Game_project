using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public float attackDelay;
    //public Collider2D trigger;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    public float attackHeightRadius;
    public GameObject projectile;
    public float throwForce;
    private bool m_canAttack;
    public Transform firePoint;
    private bool m_isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        m_canAttack = true;
        //trigger.enabled = false;
        SetMoveSpeed(moveSpeed);
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetAttackRadius(attackRadius);
        SetAttackHeightRadius(attackHeightRadius);
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
            if (playerTransform.position.x < transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform) && m_canAttack)
                {
                    enemyAnim.SetBool("AttackAnim", true);
                    m_canAttack = false;
                    StartCoroutine(AttackDelay());
                }
            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform) && m_canAttack)
                {
                    enemyAnim.SetBool("AttackAnim", true);
                    Instantiate(projectile, firePoint.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * throwForce);
                    m_canAttack = false;
                    StartCoroutine(AttackDelay());
                }
            }
            else
            {
                enemyAnim.SetBool("AttackAnim", false);
            }
        }
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }
    
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.37f);
        projectile.GetComponent<ThrowerProjectile>().f = Vector2.left * throwForce;
        Instantiate(projectile, firePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(0.27f);
        enemyAnim.SetBool("AttackAnim", false);
        yield return new WaitForSeconds(attackDelay - 0.57f);
        m_canAttack = true;
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
}