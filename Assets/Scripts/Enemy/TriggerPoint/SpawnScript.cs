using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Xpos;
    public float Ypos;
    public GameObject enemy;
    public GameObject spawnPoint;
    private bool m_canSpawn = false;
    private Vector2 pos;
    public float spawnTime;
    void Start()
    {
        pos = new Vector2(Xpos, Ypos);
    }
    void Update()
    {
        if (m_canSpawn)
        {
            StartCoroutine(SpawnCoroutine());
            m_canSpawn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (enemy)
            {
                m_canSpawn = true;
                spawnPoint.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    IEnumerator SpawnCoroutine()
    {
        Instantiate(enemy, pos, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        m_canSpawn = true;
    }
}
