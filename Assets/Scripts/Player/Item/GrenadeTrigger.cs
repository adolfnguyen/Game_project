using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    int dmg = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.isTrigger != true && hitintro.CompareTag("Enemy"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
        }
    }
}
