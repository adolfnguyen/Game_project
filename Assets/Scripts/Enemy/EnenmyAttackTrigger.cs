using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyAttackTrigger : MonoBehaviour
{
    public float dmg = 75f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
