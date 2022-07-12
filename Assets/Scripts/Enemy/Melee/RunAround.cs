using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAround : Enemies
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
    private bool m_canAttack;
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
        SetAttackHeightRadius(attackHeightRadius);
        m_canAttack = true;
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
            if (CheckAttackRadius(playerTransform, transform) && m_canAttack)
            {
                StartCoroutine(Attack());
                m_canAttack = false;
            }
            else if (m_canAttack == true)
            {
                if (transform.position.x >= waypoints[1].position.x)
                {
                    m_walkState = 1;
                }
                if (transform.position.x <= waypoints[0].position.x)
                {
                    m_walkState = 2;
                }
                if (m_walkState == 2)
                    MoveRight();
                else if (m_walkState == 1)
                    MoveLeft();
            }
        }   
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }

    IEnumerator Attack()
    {
        enemyAnim.SetBool("AttackAnim", true);
        enemyAnim.SetBool("WalkAnim", false);
        yield return new WaitForSeconds(attackDelay);
        m_canAttack = true;
    }
    IEnumerator Death()
    {
        m_isDeath = true;
        enemyAnim.SetBool("AttackAnim", false);
        enemyAnim.SetBool("WalkAnim", false);
        enemyAnim.SetBool("DeathAnim", true);
        yield return new WaitForSeconds(0.7f);
        Destroy(transform.gameObject);
    }
    void MoveLeft()
    {
        enemyAnim.SetBool("AttackAnim", false);
        m_walkState = 1;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 180, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }

    void MoveRight()
    {
        enemyAnim.SetBool("AttackAnim", false);
        m_walkState = 2;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 0);
        enemyAnim.SetBool("WalkAnim", true);
    }
}
