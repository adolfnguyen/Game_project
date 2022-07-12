using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.gameObject);
            CoreGame.IncreaseHeal();
            EventManager.TriggerEvent(GameEvents.UPDATEHEAL);

        }

    }
}
