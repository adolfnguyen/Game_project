using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class SixthState : State<AI>
{
    private static SixthState m_instance;
    public Transform jumpPoint;
    private int m_moveState;
    Vector2 moveToPos;
    Vector3 playerTransformTemp;
    Vector3 offset = new Vector3(1.5f, 1.85f, 0f);

    private SixthState()
    {
        if (m_instance != null)
        {
            return;
        }
        m_instance = this;
    }

    public static SixthState Instance
    {
        get
        {
            if (m_instance == null)
            {
                new SixthState();
            }
            return m_instance;
        }
    }

    public override void EnterState(AI own)
    {
        Debug.Log("Enter state 6");
        m_moveState = 1;
        jumpPoint = GameObject.FindGameObjectWithTag("Jump Point").GetComponent<Transform>();
    }

    public override void ExitState(AI own)
    {

    }

    public override void UpdateState(AI own)
    {
        //Jump State
        if (m_moveState == 1)
        {
            own.rb.bodyType = RigidbodyType2D.Kinematic;
            moveToPos = jumpPoint.transform.position;
            own.transform.position = Vector2.MoveTowards(own.transform.position, moveToPos, own.moveSpeed * 10 * Time.deltaTime);
            own.anim.SetBool("JumpAnim", true);
            if (own.transform.position.x == moveToPos.x && own.transform.position.y == moveToPos.y)
            {
                m_moveState = 2;
                playerTransformTemp = own.playerTransform.position + offset;
            }
        }
        if (m_moveState == 2)
        {
            own.StartCoroutine(JumpOff(own));          
        }
        if (m_moveState == 3)
        {
            if (own.transform.position.y <= -1)
            {
                own.anim.SetBool("JumpOffAnim", false);
                own.rb.bodyType = RigidbodyType2D.Dynamic;
                own.switchState = 3;
                own.seconds = 0;
            }
        }

        if (own.switchState == 2)
        {
            own.stateMachine.ChangeState(SecondState.Instance);
        }
        if (own.switchState == 3)
        {
            own.stateMachine.ChangeState(ThirdState.Instance);
        }
    }

    IEnumerator JumpOff(AI own)
    {
        own.anim.SetBool("JumpAnim", false);
        own.anim.SetBool("JumpOffAnim", true);
        own.transform.position = Vector2.MoveTowards(own.transform.position, playerTransformTemp, own.moveSpeed * 10 * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        m_moveState = 3;
    }
}
