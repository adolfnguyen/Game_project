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
    public GameObject stateClaerPanel;
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
        EventManager.StartListening(GameEvents.STATECLEAR, new UnityAction(StateClear));
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
            pausePanel.transform.GetChild(3).gameObject.SetActive(true);
            pausePanel.transform.GetChild(4).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (pause == false)
        {
            pausePanel.SetActive(false);
            pausePanel.transform.GetChild(3).gameObject.SetActive(false);
            pausePanel.transform.GetChild(4).gameObject.SetActive(false);
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
            SoundManager.instance.SetMusic(CoreGame.CurMusic, false, false);
            SoundManager.instance.SetMusic(NameMusic.DeathMusic, true, true);
            pause = false;
        }
    }
    public void Resume()
    {
        pause = false;
    }
    public void StateClear()
    {
        if (stateClaerPanel)
        {
            stateClaerPanel.SetActive(true);
        }
       
    }
    public void Back()
    {
        EventManager.TriggerEvent<int>(GameEvents.SCENCETRANSITION, 0);
    }
}
