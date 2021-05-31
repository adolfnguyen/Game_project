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
    public Text Greande;
    public Slider Heal;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        Bullet.text = "20";
        Heal.maxValue = CoreGame.Heal;
        Heal.value = CoreGame.CurHeal;
        EventManager.StartListening(GameEvents.UPDATEBULLET, new UnityAction(UpdateBullet));
        EventManager.StartListening(GameEvents.GAMEOVER, new UnityAction(GameOver));
        EventManager.StartListening(GameEvents.UPDATEHEAL, new UnityAction(UpdateHeal));
        EventManager.StartListening(GameEvents.UPDATEGRENADE, new UnityAction(UpdateGrenade));
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
    void UpdateHeal()
    {
        Heal.value = CoreGame.CurHeal;
    }
    public void UpdateBullet()
    {
        Bullet.text = "" + CoreGame.Bullet;
    }
    public void UpdateGrenade()
    {
        Greande.text = "X " + CoreGame.Grenade;
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
