using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyAttackTrigger : MonoBehaviour
{
    Vector3 pos;
    bool turn;
    private void Update()
    {
        pos=transform.position;
        if (pos.y>-3f)
        {
            turn = true;
        }
        if (pos.y < -6)
        {
            turn = false;
        }
        if (turn)
        {
            pos.y -= 6*Time.deltaTime;
        }
        else
        {
            pos.y += 6*Time.deltaTime;
        }
        transform.position = pos;
    }
    public float dmg = 75f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
