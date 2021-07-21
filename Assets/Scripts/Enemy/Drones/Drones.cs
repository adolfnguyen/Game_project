using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : Enemies
{
    public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float timer;

    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    Rigidbody2D m_rb;
    private bool m_isDeath = false;

    public Vector3 offset = new Vector3(0, 3f, 0);

    Vector2 movetoPos;
    bool beginMove = false;
    float distanceTemp = 0f;

    void Start()
    {
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        enemyAnim = gameObject.GetComponent<Animator>();
        m_enemySR = GetComponent<SpriteRenderer>();
        SetAttackDamage(attackDamage);
        SetHitPoint(hitPoint);
        SetMoveSpeed(moveSpeed);
        m_rb = GetComponent<Rigidbody2D>();
    }
    //LateUpdate duoc goi moi frame, nhung sau Update
    void LateUpdate()
    {
        if (!playerTransform) 
            return;
        if (timer <= 0)
        {
            StopFollowing();
            m_rb.bodyType = RigidbodyType2D.Dynamic;
            if (!m_isDeath)
                StartCoroutine(DeathAfter5s());
        }
        else
        {
            timer -= Time.fixedDeltaTime;
            distanceTemp = ((playerTransform.position + offset) - transform.position).sqrMagnitude;
            if (beginMove)
            {
                //movetoPos = Vector3.Lerp(movetoPos, playerTransform.position + offset, Time.fixedDeltaTime * 1.5f);
                movetoPos = playerTransform.position + offset;
                transform.position = Vector2.MoveTowards(transform.position, movetoPos, moveSpeed * Time.deltaTime);
                if (distanceTemp < 0.05f * 0.05f)
                {
                    beginMove = false;
                }
            }
            else if (distanceTemp > 0.5f * 0.5f)
            {
                beginMove = true;
            }
            else
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
            }
        }
    }
    void StopFollowing()
    {
        beginMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!m_isDeath)
                StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        m_isDeath = true;
        enemyAnim.SetBool("DeathAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }

    IEnumerator DeathAfter5s()
    {
        yield return new WaitForSeconds(5.0f);
        m_isDeath = true;
        enemyAnim.SetBool("DeathAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }

    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }
}
