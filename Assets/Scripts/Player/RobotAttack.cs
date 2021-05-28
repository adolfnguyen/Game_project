using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    public float attackdelay = 0.3f; 
    public Animator aim;
    public Collider2D trigger;
    bool m_ground;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            trigger.enabled = true;
            attackdelay = 0.3f;
            aim.SetBool("Attacking", true);
        }
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
                aim.SetBool("Attacking", true);
            }
            else
            {
                //attacking = false;
                trigger.enabled = false;
                aim.SetBool("Attacking", false);
            }
     }
    
    
}
