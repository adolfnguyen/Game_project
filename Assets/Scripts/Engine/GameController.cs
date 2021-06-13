using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CoreGame.Pause = !CoreGame.Pause;
        }
    }
    public void Restart()
    {
        Debug.Log("choi lai");
        CoreGame.Pause = false;
        SceneManager.LoadScene("Stage1");
        CoreGame.ResetStatus();
    }
    public void Resume()
    {
        CoreGame.Pause = false;
    }
}
