using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageControl : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] platform;
    private float bossHitPoint;

    void Start()
    {
        bossHitPoint = enemy.GetComponent<AI>().hitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<AI>().hitPoint < bossHitPoint/2)
        {
            for (int i = 0; i < platform.Length; i++)
            {
                platform[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SetActiveBoss());
        }
    }

    IEnumerator SetActiveBoss()
    {
        yield return new WaitForSeconds(2.5f);
        enemy.SetActive(true);
    }
}
