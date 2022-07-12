using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl2 : MonoBehaviour
{
    [SerializeField] private Text pickupText;
    public float waitTime = 0.3f;
    private bool m_enable;
    // Start is called before the first frame update
    void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.3f;
        }
        if (m_enable)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (waitTime <= 0)
                {
                    Destroy(pickupText);
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
            pickupText.gameObject.SetActive(true);
            m_enable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false);
            m_enable = false;
        }
    }
}
