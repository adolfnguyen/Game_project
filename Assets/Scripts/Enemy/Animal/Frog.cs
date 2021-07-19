using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemies
{
    public int attackDamage;
    public int hitPoint;
    public float attackRadius;
    public float attackHeightRadius;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    private bool m_isDeath = false;
    Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
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
                if (CheckAttackRadius(playerTransform, transform))
                {
                    enemyAnim.SetBool("JumpAnim", true);
                    m_rb.AddForce(new Vector2(5f, 10f));
                }
            }
            else if (playerTransform.position.x > transform.position.x)
            {
                if (CheckAttackRadius(playerTransform, transform))
                {
                    enemyAnim.SetBool("JumpAnim", true);
                }
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
        enemyAnim.SetBool("JumpAnim", false);
        yield return new WaitForSeconds(0.75f);
        Destroy(transform.gameObject);
    }
}
