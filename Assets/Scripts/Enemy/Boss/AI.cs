using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour
{
    public float switchState;
    private float gameTimer;
    public int seconds = 0;

    public float moveSpeed;
    public float hitPoint, originalHitPoint;
    public float attackDamage;
    public Transform playerTransform;
    public Animator anim;
    public Rigidbody2D rb;
    public float attackDelay;
    [SerializeField] Transform m_firePoint;
    public bool canShoot = true;
    public GameObject projectile;
    public GameObject throwable;
    public Collider2D trigger;
    public CameraShake cameraShake;
    private bool m_canKick = true;

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        originalHitPoint = hitPoint;
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        trigger.enabled = false;
        cameraShake = FindObjectOfType<Camera>().GetComponent<CameraShake>();
    }

    private void Update()
    {
        if (hitPoint > originalHitPoint / 2)
        {
            if (Time.time > gameTimer + 1)
            {
                gameTimer = Time.time;
                seconds++;
            }

            if (seconds == 5)
            {
                seconds = 0;
                switchState++;
                if (switchState == 6) switchState = 2;
            }

            if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 8.0f && m_canKick)
            {
                switchState = 4;
                m_canKick = false;
            }

            if (playerTransform.position.y >= 1.474131f)
            {
                switchState = 5;
                seconds = 0;
            }
        }
        else
        {
            if (Time.time > gameTimer + 1)
            {
                gameTimer = Time.time;
                seconds++;
            }

            if (seconds == 3)
            {
                seconds = 0;
                if (switchState == 3)
                {
                    switchState = 6;
                }
                if (switchState == 6)
                {
                    switchState = 2;
                }
                if (switchState == 2)
                {
                    switchState = 3;
                }
            }
        }
        stateMachine.Update();
    }

    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }

    public void InstantiateProjectile()
    {
        Vector3 dir = playerTransform.position - m_firePoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Instantiate(projectile, m_firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    public void InstantiateThrowable(float v)
    {
        throwable.GetComponent<ThrowerProjectile>().f = new Vector2(-v, 4*v) * 20;
        Instantiate(throwable, m_firePoint.position, Quaternion.identity);
    }

    public void SetKick(bool state)
    {
        m_canKick = state;
    }
}
