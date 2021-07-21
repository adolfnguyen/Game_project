using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject state1;
    public GameObject state2;
    public GameObject state3;
    public GameObject state4;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        if (CoreGame.Level == 0)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            state4.SetActive(false);
        }
        if (CoreGame.Level == 1)
        {
            state1.SetActive(true);
            state2.SetActive(true);
            state3.SetActive(false);
            state4.SetActive(false);
        }
        if (CoreGame.Level == 2)
        {
            state1.SetActive(true);
            state2.SetActive(true);
            state3.SetActive(false);
            state4.SetActive(false);
        }
        if (CoreGame.Level == 3)
        {
            state1.SetActive(true);
            state2.SetActive(true);
            state3.SetActive(true);
            state4.SetActive(false);
        }
        if (CoreGame.Level == 3)
        {
            state1.SetActive(true);
            state2.SetActive(true);
            state3.SetActive(true);
            state4.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ToState1()
    {
        SceneManager.LoadScene(1);
    }
    public void ToState2()
    {
        SceneManager.LoadScene(2);
    }
    public void ToState3()
    {
        SceneManager.LoadScene(3);
    }
    public void ToBoss()
    {
        SceneManager.LoadScene(4);
    }
}
