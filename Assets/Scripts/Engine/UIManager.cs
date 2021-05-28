using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool pause = false;
    public GameObject gameOverPanel;
    public Text Bullet;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        Bullet.text = "20";
        EventManager.StartListening(GameEvents.UPDATEBULLET, new UnityAction(UpdateBullet));
        EventManager.StartListening(GameEvents.GAMEOVER, new UnityAction(GameOver));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (pause == false)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void UpdateBullet()
    {
        Bullet.text = "" + CoreGame.Bullet;
    }
    public void Restart()
    {
        pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CoreGame.ResetStatus();
    }
    public void GameOver()
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(true);
            pause = false;
        }
    }
        public void Resume()
    {
        pause = false;
    }
}
