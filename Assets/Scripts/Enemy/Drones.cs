using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : Enemies
{
    //public int moveSpeed;
    public int attackDamage;
    public int hitPoint;
    public float timer;

    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer m_enemySR;
    Rigidbody2D m_rb;

    public Vector3 offset = new Vector3(0, 2.8f, 0);
    public bool smoothFollow = true;

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
        }
        else
        {
            if (smoothFollow)
            {
                timer -= Time.fixedDeltaTime;
                distanceTemp = ((playerTransform.position + offset) - transform.position).sqrMagnitude;
                if (beginMove)
                {
                    //Lerp noi suy ra 1 vector nam giua 2 vector duoc truyen vao
                    movetoPos = Vector3.Lerp(movetoPos, playerTransform.position + offset, Time.fixedDeltaTime * 1.5f);
                    transform.position = new Vector3(movetoPos.x, movetoPos.y, 0);
                    if (distanceTemp < 0.05f * 0.05f)
                    {
                        beginMove = false;
                    }
                }
                else if (distanceTemp > 0.5f * 0.5f)
                {
                    beginMove = true;
                }
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

}
