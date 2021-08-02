using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FifthState : State<AI>
{
    private static FifthState m_instance;

    private FifthState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static FifthState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new FifthState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 5");
    }

    public override void ExitState(AI own)
    {

    }

    public override void UpdateState(AI own)
    {
        //
        if (own.switchState == 1)
        {
            own.stateMachine.ChangeState(FirstState.Instance);
        }
    }
}
