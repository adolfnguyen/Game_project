using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class SecondState : State<AI>
{
    private static SecondState m_instance;

    private SecondState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static SecondState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new SecondState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 2");
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
        if (own.seconds >= 3)
        {
            own.switchState = Random.Range(3, 6);
            own.seconds = 0;
        }
        if (own.switchState == 3)
        {
            own.stateMachine.ChangeState(ThirdState.Instance);
        }
        if (own.switchState == 4)
        {
            own.stateMachine.ChangeState(FourthState.Instance);
        }
        if (own.switchState == 5)
        {
            own.stateMachine.ChangeState(FifthState.Instance);
        }
    }
}
