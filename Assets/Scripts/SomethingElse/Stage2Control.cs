using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Control : MonoBehaviour
{
    public GameObject[] inviWall;
    public GameObject camControl;
    private bool m_setTrue;
    // Start is called before the first frame update
    void Start()
    {
        m_setTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_setTrue)
        {
            StartCoroutine(Exit());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inviWall.Length; i++)
            {
                inviWall[i].SetActive(true);
            }
            m_setTrue = true;
        }
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds (20f);
        camControl.GetComponent<Camerafollow>().SetActiveState(true);
        Destroy(camControl);
        Destroy(transform);
    }
}
