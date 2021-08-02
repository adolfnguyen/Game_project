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
        //Jump State

        if (own.switchState == 3)
        {
            own.stateMachine.ChangeState(ThirdState.Instance);
        }
    }
}
