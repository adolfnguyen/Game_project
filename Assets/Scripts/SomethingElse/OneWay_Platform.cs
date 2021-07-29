using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay_Platform : MonoBehaviour
{
    public PlatformEffector2D effector;
    public float waitTime;
    private bool m_enable;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.75f;
            effector.rotationalOffset = 0f;
        }
        if (m_enable)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (waitTime <= 0)
                {
                    effector.rotationalOffset = 180f;
                    waitTime = 0.75f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_enable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_enable = false;
        }
    }
}
