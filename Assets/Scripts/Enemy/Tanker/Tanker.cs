using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanker : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    [SerializeField] Animator enemyAnim;
    [SerializeField] Transform playerTransform;
    SpriteRenderer m_enemySR;
    public Collider2D trigger;
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
        trigger.enabled = false;
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
            if (CheckAttackRadius(playerTransform, transform))
            {
                if (playerTransform.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    enemyAnim.SetBool("AttackAnim", true);
                    trigger.enabled = true;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    enemyAnim.SetBool("AttackAnim", true);
                    trigger.enabled = true;
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