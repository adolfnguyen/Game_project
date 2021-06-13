using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    //public Collider2D trigger;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        //trigger.enabled = false;
        SetMoveSpeed(moveSpeed);
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetAttackRadius(attackRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoint <= 0)
        {
            Destroy(transform.gameObject);
        }
            if (playerTransform.position.x < transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform))
                {
                    enemyAnim.SetBool("AttackAnim", true);
                    Instantiate(projectile, transform.position, Quaternion.identity);
                }
            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform))
                {
                    enemyAnim.SetBool("AttackAnim", true);
                }
            }
        else
        {
            enemyAnim.SetBool("AttackAnim", false);
        }
    }
    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }    
}