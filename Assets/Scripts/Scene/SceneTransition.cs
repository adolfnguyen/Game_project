using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening<int>(GameEvents.SCENCETRANSITION, new UnityAction<int>(GetScene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetScene(int val )
    {
        StartCoroutine(LoadScene(val));
    }
    IEnumerator LoadScene(int val)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(val);
    }
}
