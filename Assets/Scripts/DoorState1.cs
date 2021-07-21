using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent(GameEvents.STATECLEAR);
            if (CoreGame.Level < 1)
            {
                CoreGame.Level++;
                ControllerInfomation.instance.SavePhase(CoreGame.Level);
            }
            
        }
    }
}
