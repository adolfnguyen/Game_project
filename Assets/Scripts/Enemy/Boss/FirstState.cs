using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FirstState : State<AI>
{
    private static FirstState m_instance;

    private FirstState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static FirstState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new FirstState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 1");
    }

    public override void ExitState(AI own)
    {
        
    }

    public override void UpdateState(AI own)
    {
        //Standby State
        own.anim.SetBool("IdleAnim", true);
        own.anim.SetBool("AttackAnim", false);
        own.anim.SetBool("WalkAnim", false);
        own.anim.SetBool("KickAnim", false);
        own.anim.SetBool("DeathAnim", false);
        own.anim.SetBool("JumpAnim", false);
        if (own.switchState == 2)
        {
            own.stateMachine.ChangeState(SecondState.Instance);
        }
    }
}
