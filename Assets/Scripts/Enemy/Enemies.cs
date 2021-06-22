using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    int m_moveSpeed;
    int m_attackDamage;
    int m_hitPoint;
    float m_attackDelay;
    float m_attackRadius;
    float m_followRadius;
    float m_attackHeightRadius;
    
    public void SetMoveSpeed(int speed)
    {
        m_moveSpeed = speed;
    }

    public int GetMoveSpeed()
    {
        return m_moveSpeed;
    }

    public void SetAttackDamage(int dmg)
    {
        m_attackDamage = dmg;
    }

    public int GetAttackDamage()
    {
        return m_attackDamage;
    }

    public void SetHitPoint(int hp)
    {
        m_hitPoint = hp;
    }

    public int GetHitPoint()
    {
        return m_hitPoint;
    }

    public void SetAttackDelay(float aD)
    {
        m_attackDelay = aD;
    }

    public float GetAttackDelay()
    {
        return m_attackDelay;
    }

    public void SetFollowRadius(float frad)
    {
        m_followRadius = frad;
    }

    public void SetAttackRadius(float arad)
    {
        m_attackRadius = arad;
    }

    public void SetAttackHeightRadius(float aHR)
    {
        m_attackHeightRadius = aHR;
    }

    public float GetAttackHeightRadius()
    {
        return m_attackHeightRadius;
    }

    public bool CheckFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < m_followRadius)
        {
            return true;
        }
        else return false;
    }

    public bool CheckAttackRadius(Transform playerTransform, Transform enemyTransform)
    {
        if (Mathf.Abs(playerTransform.position.x - enemyTransform.position.x) < m_attackRadius &&
            Mathf.Abs(playerTransform.position.y - enemyTransform.position.y) < m_attackHeightRadius)
        {
            return true;
        }
        else return false;
    }

    public bool CheckAttackRadiusX(Transform playerTransform, Transform enemyTransform)
    {
        if (Mathf.Abs(playerTransform.position.x - enemyTransform.position.x) < m_attackRadius)
        {
            return true;
        }
        else return false;
    }
}
