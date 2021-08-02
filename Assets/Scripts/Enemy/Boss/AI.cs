using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour
{
    public float switchState;
    private float gameTimer;
    private int seconds = 0;

    public float moveSpeed;
    public float hitPoint;
    public float attackDamage;
    public Transform playerTransform;
    public Animator anim;
    public Rigidbody2D rb;
    public float attackDelay;
    [SerializeField] Transform m_firePoint;
    public bool canShoot = true;
    public GameObject projectile;
    public Collider2D trigger;

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        trigger.enabled = false;
    }

    private void Update()
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
            if (switchState == 6) switchState = 1;
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
}
