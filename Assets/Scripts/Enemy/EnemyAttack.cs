using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public float followRadius;
    public Collider2D trigger;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        trigger.enabled = false;
        SetMoveSpeed(moveSpeed);
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetAttackRadius(attackRadius);
        SetFollowRadius(followRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(transform.gameObject);
        }
        if (CheckFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                if (CheckAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAnim.SetBool("AttackAnim", true);
                    trigger.enabled = true;
                }
                else
                {
                    this.transform.position += new Vector3(-GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                    enemyAnim.SetBool("AttackAnim", false);
                    enemyAnim.SetBool("WalkAnim", true);
                    m_enemySR.flipX = true;
                    trigger.enabled = false;
                }
            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (CheckAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAnim.SetBool("AttackAnim", true);
                    trigger.enabled = true;
                }
                else
                {
                    this.transform.position += new Vector3(GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                    enemyAnim.SetBool("AttackAnim", false);
                    enemyAnim.SetBool("WalkAnim", true);
                    m_enemySR.flipX = false;
                    trigger.enabled = false;
                }
            }
        }
        else
        {
            enemyAnim.SetBool("WalkAnim", false);
            enemyAnim.SetBool("AttackAnim", false);
            trigger.enabled = false;
        }                                
    }
    public void Damage(int dmg)
    {
        hp -= dmg;
    }
}
