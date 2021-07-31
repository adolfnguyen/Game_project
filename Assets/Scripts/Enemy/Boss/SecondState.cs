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

    }

    public override void ExitState(AI own)
    {

    }

    public override void UpdateState(AI own)
    {
        //if ( )
        if (!own.switchState)
        {
            own.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
