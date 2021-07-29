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
        
    }

    public override void ExitState(AI own)
    {
        
    }

    public override void UpdateState(AI own)
    {

        if (own.switchState)
        {
            own.stateMachine.ChangeState(SecondState.Instance);
        }
    }
}
