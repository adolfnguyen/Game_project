using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_NoMove : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public float attackHeightRadius;
    [SerializeField] Animator enemyAnim;
    [SerializeField] Transform playerTransform;
    SpriteRenderer m_enemySR;

    public float attackDelay;
    [SerializeField] Transform m_firePoint;
    private bool m_canShoot;
    public GameObject projectile;
    private bool m_isDeath = false;

    public GameObject bulletDrop, healingDrop;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetAttackHeightRadius(attackHeightRadius);
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
        enemyAnim.SetBool("AttackAnim", true);
        transform.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        yield return new WaitForSeconds(attackDelay);
        enemyAnim.SetBool("AttackAnim", false);
        m_canShoot = true;
    }

    IEnumerator EnemyShoot_R()
    {
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(attackDelay);
        enemyAnim.SetBool("AttackAnim", true);
        transform.eulerAngles = new Vector3(0, 180, 0);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        yield return new WaitForSeconds(0.05f);
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
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
        x = Random.Range(1, 101);
        if (x <= 30)
        {
            Instantiate(bulletDrop, transform.position, Quaternion.identity);
        }
        else if (x >= 90)
        {
            Instantiate(healingDrop, transform.position, Quaternion.identity);
        }
        Destroy(transform.gameObject);
    }
}
