using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_1 : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;

    public float attackDelay;
    private RaycastHit2D m_vision;
    private Transform m_firePoint;
    public GameObject projectile;
    private int m_walkState;

    [SerializeField] private Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetMoveSpeed(moveSpeed);
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetAttackRadius(attackRadius);
        SetAttackDelay(attackDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0)
        {
            enemyAnim.SetBool("DeathAnim", true);
            //Destroy(transform.gameObject);
        }
        Debug.DrawLine(transform.position, transform. * attackRadius, Color.red, 5.0f);
        m_vision = Physics2D.Raycast(transform.position, transform.forward, attackRadius);
        if (m_vision.collider.CompareTag("Player"))
        {
            //if (m_vision.collider.tag == "Player")
            //{
                Debug.Log(m_vision.collider.name);
                Shooting();
            //}
        }
        else
        {
            if (transform.position.x >= waypoints[1].position.x)
            {
                m_walkState = 0;
            }
            if (transform.position.x <= waypoints[0].position.x)
            {
                m_walkState = 0;
            }

            if (m_walkState == 1)
                MoveRight();
            else if (m_walkState == 2)
                MoveLeft();
            else if (m_walkState == 0)
                StartCoroutine(Wait3s());
        }


        //if (playerTransform.position.x < transform.position.x)
        //{
        //    if (CheckAttackRadius(playerTransform.position.x, transform.position.x))
        //    {
        //        enemyAnim.SetBool("AttackAnim", true);
        //        trigger.enabled = true;
        //    }
        //    else
        //    {
        //        transform.position += new Vector3(-GetMoveSpeed() * Time.deltaTime, 0f, 0f);
        //        enemyAnim.SetBool("AttackAnim", false);
        //        enemyAnim.SetBool("WalkAnim", true);
        //        transform.eulerAngles = new Vector3(0, 180, 0);
        //        trigger.enabled = false;
        //    }
        //}
        //else if (playerTransform.position.x > transform.position.x)
        //{
        //    if (CheckAttackRadius(playerTransform.position.x, transform.position.x))
        //    {
        //        enemyAnim.SetBool("AttackAnim", true);
        //        trigger.enabled = true;
        //    }
        //    else
        //    {
        //        transform.position += new Vector3(GetMoveSpeed() * Time.deltaTime, 0f, 0f);
        //        enemyAnim.SetBool("AttackAnim", false);
        //        enemyAnim.SetBool("WalkAnim", true);
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //        trigger.enabled = false;
        //    }
        //}
        //else
        //{
        //    enemyAnim.SetBool("WalkAnim", false);
        //    enemyAnim.SetBool("AttackAnim", false);
        //    trigger.enabled = false;
        //}
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }

    Coroutine EnemyShot;

    private void Shooting()
    {
        EnemyShot = StartCoroutine(EnemyShoot());
        if (EnemyShot != null) StopCoroutine(EnemyShot);
    }

    IEnumerator EnemyShoot()
    {
        Instantiate(projectile, m_firePoint.position, m_firePoint.rotation);
        enemyAnim.SetBool("AttackAnim", true);
        yield return new WaitForSeconds(attackDelay);
        enemyAnim.SetBool("AttackAnim", false);
    }

    void MoveRight()
    {
        m_walkState = 1;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 180, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }

    void MoveLeft()
    {
        m_walkState = 2;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }

    private IEnumerator Wait3s()
    {
        m_walkState = 0;
        Debug.Log(m_walkState);
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(3.0f);
        if (transform.position.x >= waypoints[1].position.x)
        {
            m_walkState = 2;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x <= waypoints[0].position.x)
        {
            m_walkState = 1;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        }
    }
}
