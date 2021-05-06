using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public float dmg = 75f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger !=true && col.CompareTag("enemy"))
        {
            col.SendMessageUpwards("Damage",dmg);
        }
    }

}
