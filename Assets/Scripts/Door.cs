﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Door : MonoBehaviour
{
    int leveLoad = 1;
   
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
            EventManager.TriggerEvent<int>(GameEvents.SCENCETRANSITION,1);
            CoreGame.Level++;
        }
    }
}
