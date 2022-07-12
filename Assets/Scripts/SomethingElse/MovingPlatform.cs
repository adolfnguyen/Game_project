using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    private int m_walkState = 0;

    [SerializeField] private Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= waypoints[1].position.x)
        {
            m_walkState = 0;
        }
        if (transform.position.x <= waypoints[0].position.x)
        {
            m_walkState = 0;
        }

        if (m_walkState == 2)
        {
            MoveRight();
        }
        else if (m_walkState == 1)
        {
            MoveLeft();
        }
        else if (m_walkState == 0)
        {
            StartCoroutine(Wait3s());
        }   
    }

    public void MoveLeft()
    {
        m_walkState = 1;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        m_walkState = 2;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
    }

    private IEnumerator Wait3s()
    {
        m_walkState = 0;
        yield return new WaitForSeconds(3.0f);
        if (transform.position.x >= waypoints[1].position.x)
        {
            m_walkState = 1;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[0].transform.position,
                moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x <= waypoints[0].position.x)
        {
            m_walkState = 2;
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].transform.position,
                moveSpeed * Time.deltaTime);
        }
    }
}
