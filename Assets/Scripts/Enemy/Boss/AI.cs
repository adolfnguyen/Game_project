using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour
{
    public bool switchState = false;
    private float gameTimer;
    private int seconds = 0;

    public float moveSpeed;
    public float hitPoint;
    public float attackDamage;
    public Transform playerTransform;
    public Animator anim;

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
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
            switchState = !switchState;
        }
        stateMachine.Update();
    }

    public void Damage(int dmg)
    {
        hitPoint -= dmg;
    }
}
