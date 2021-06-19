using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    // Start is called before the first frame update
    public float Xpos;
    public float Ypos;
    public GameObject enemy;
    public GameObject spawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 pos = new Vector2(Xpos, Ypos);
            if (enemy)
            {
                Instantiate(enemy, pos, Quaternion.identity);
                spawnPoint.SetActive(false);
            }
        }
    }
}
