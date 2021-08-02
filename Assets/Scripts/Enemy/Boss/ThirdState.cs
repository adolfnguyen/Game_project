using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class ThirdState : State<AI>
{
    private static ThirdState m_instance;

    private ThirdState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static ThirdState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new ThirdState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 3");
        own.anim.SetBool("AttackAnim", false);
        own.anim.SetBool("WalkAnim", false);
        own.anim.SetBool("KickAnim", false);
        own.anim.SetBool("DeathAnim", false);
        own.anim.SetBool("JumpAnim", false);
    }

    public override void ExitState(AI own)
    {

    }

    public override void UpdateState(AI own)
    {
        //Shoot State
        own.anim.SetBool("AttackAnim", true);
        if (own.canShoot)
        {
            own.StartCoroutine(Shoot(own));
        }
        if (own.switchState == 4)
        {
            own.stateMachine.ChangeState(FourthState.Instance);
        }
    }

    IEnumerator Shoot(AI own)
    {
        own.canShoot = false;
        own.InstantiateProjectile();
        yield return new WaitForSeconds(own.attackDelay);
        own.canShoot = true;
    }
}
