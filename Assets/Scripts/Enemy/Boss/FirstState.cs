using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FirstState : State<AI>
{
    private static FirstState m_instance;
    private Camera cam;

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
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public override void ExitState(AI own)
    {
        
    }

    public override void UpdateState(AI own)
    {
        //Appearance
        own.rb.velocity = Vector2.down * own.moveSpeed * 10;
        own.StartCoroutine(own.cameraShake.Shake(1.0f));
        own.seconds = 0;
        own.switchState = 2;   

        if (own.switchState == 2)
        {
            own.stateMachine.ChangeState(SecondState.Instance);
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
