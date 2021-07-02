using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Spike : MonoBehaviour
{
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D hitintro)
    {
        if (hitintro.gameObject.CompareTag("Enemy"))
        {
            hitintro.gameObject.SendMessageUpwards("Damage", dmg);
        }
        if (hitintro.gameObject.CompareTag("Player"))
        {
            hitintro.gameObject.SendMessageUpwards("Damage", dmg);
        }
    }
}
