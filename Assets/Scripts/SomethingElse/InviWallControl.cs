using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviWallControl : MonoBehaviour
{
    public GameObject[] inviWall;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (enemies == null)
        {
            for (int i = 0; i < inviWall.Length; i++)
            {
                inviWall[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SetActiveWall());
        }
    }

    IEnumerator SetActiveWall()
    {
        for (int i = 0; i < inviWall.Length; i++)
        {
            inviWall[i].SetActive(true);
        }
        yield return null;
    }
}
