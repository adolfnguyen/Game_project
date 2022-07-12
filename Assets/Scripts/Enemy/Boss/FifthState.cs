using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FifthState : State<AI>
{
    private static FifthState m_instance;
    private float L, g = 9.8f;
    private float v0, v;

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
        //Throw
        L = Mathf.Abs(own.playerTransform.position.x - own.transform.position.x);
        v0 = Mathf.Sqrt(L * g);
        v = v0 * Mathf.Cos(45);
        if (own.canShoot)
        {
            own.StartCoroutine(Throw(own));
        }
        if(own.seconds >= 3)
        {
            own.switchState = Random.Range(2, 5);
            own.seconds = 0;
        }

        if (own.switchState == 1)
        {
            own.stateMachine.ChangeState(FirstState.Instance);
        }
        if (own.switchState == 3)
        {
            own.stateMachine.ChangeState(ThirdState.Instance);
        }
        if (own.switchState == 4)
        {
            own.stateMachine.ChangeState(FourthState.Instance);
        }
    }

    IEnumerator Throw(AI own)
    {
        own.canShoot = false;
        own.anim.SetBool("ThrowAnim", true);
        own.InstantiateThrowable(v);
        yield return new WaitForSeconds(0.25f);
        own.anim.SetBool("ThrowAnim", false);
        yield return new WaitForSeconds(own.attackDelay * 3 - 0.25f);
        own.canShoot = true;
    }
}
