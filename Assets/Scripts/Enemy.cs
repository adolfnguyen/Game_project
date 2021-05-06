using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hel = 100f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(hel <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
    void Damage(int dmg)
    {
        hel -= dmg;
    }
}
