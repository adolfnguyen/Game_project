using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Door : MonoBehaviour
{
    public int leveLoad;
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
            Debug.Log("qua man");
            int nextlevel = leveLoad + 1;
            EventManager.TriggerEvent<int>(GameEvents.SCENCETRANSITION,nextlevel);
            if (CoreGame.Level < leveLoad)
            {
                CoreGame.Level++;
                ControllerInfomation.instance.SavePhase(CoreGame.Level);
            }
        }
    }
}
