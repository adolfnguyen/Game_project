using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;
    public Animator aim;
    public Collider2D trigger;
    private void Awake()
    {
        aim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
}
        if (attacking)
        {
            if(attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        aim.SetBool("Attacking", attacking);
    }
}
