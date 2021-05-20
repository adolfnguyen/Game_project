using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
   public void Damage(int dmg)
    {
        hp -= dmg;
    }
}
