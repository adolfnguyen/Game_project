using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class FourthState : State<AI>
{
    private static FourthState m_instance;
    Vector3 currentPos;
    Vector2 moveToPos;
    Vector3 offset = new Vector3(2.5f, 2f, 0f);
    private int m_moveState;

    private FourthState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static FourthState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new FourthState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 4");
        currentPos = own.transform.position;
        m_moveState = 1;

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
        //Kick State
        if (m_moveState == 1)
        {
            own.rb.bodyType = RigidbodyType2D.Kinematic;
            moveToPos = own.playerTransform.position + offset;
            own.transform.position = Vector2.MoveTowards(own.transform.position, moveToPos, own.moveSpeed * 8 * Time.deltaTime);
            if (own.transform.position.x == moveToPos.x && own.transform.position.y == moveToPos.y) m_moveState = 2;
        }
        if (m_moveState == 2)
        {
            own.StartCoroutine(Kick(own));
            own.rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (m_moveState == 3)
        {
            own.transform.position = Vector2.MoveTowards(own.transform.position, currentPos, own.moveSpeed * 8 * Time.deltaTime);
        }
        if (own.switchState == 5)
        {
            own.stateMachine.ChangeState(FifthState.Instance);
        }
    }

    IEnumerator Kick(AI own)
    {
        own.anim.SetBool("KickAnim", true);
        own.trigger.enabled = true;
        yield return new WaitForSeconds(2f);
        m_moveState = 3;
        own.anim.SetBool("KickAnim", false);
        own.trigger.enabled = false;
    }
}
