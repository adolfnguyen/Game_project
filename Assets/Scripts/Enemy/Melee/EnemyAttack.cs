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
    public float attackHeightRadius;
    public Collider2D trigger;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    private bool m_isDeath = false;
    
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
            if (CheckFollowRadius(playerTransform.position.x, transform.position.x))
            {
                if (playerTransform.position.x < transform.position.x)
                {
                    if (CheckAttackRadius(playerTransform, transform))
                    {
                        enemyAnim.SetBool("AttackAnim", true);
                        trigger.enabled = true;
                    }
                    else
                    {
                        transform.position += new Vector3(-GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                        enemyAnim.SetBool("AttackAnim", false);
                        enemyAnim.SetBool("WalkAnim", true);
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        trigger.enabled = false;
                    }
                }
                else if (playerTransform.position.x > transform.position.x)
                {
                    if (CheckAttackRadius(playerTransform, transform))
                    {
                        enemyAnim.SetBool("AttackAnim", true);
                        trigger.enabled = true;
                    }
                    else
                    {
                        transform.position += new Vector3(GetMoveSpeed() * Time.deltaTime, 0f, 0f);
                        enemyAnim.SetBool("AttackAnim", false);
                        enemyAnim.SetBool("WalkAnim", true);
                        transform.eulerAngles = new Vector3(0, 0, 0);
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
}
