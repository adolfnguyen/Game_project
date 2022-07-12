using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soundButton;
    public GameObject musicButton;
    void Start()
    {
        
    }
    private void Awake()
    {
        Debug.Log(CoreGame.MusicOn);
        soundButton.SetActive(true);
        musicButton.SetActive(true);
        SoundManager.instance.SetMusic(NameMusic.MenuMusic, true, true);
        CoreGame.CurMusic = NameMusic.MenuMusic;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        UIMenu.instance.LoadScene(1);
    }
    public void NewGame()
    {
        UIMenu.instance.LoadScene(2);
        SoundManager.instance.SetMusic(NameMusic.MenuMusic, true, false);
        SoundManager.instance.SetMusic(NameMusic.Stage1Music, true, true);
        CoreGame.CurMusic = NameMusic.Stage1Music;
    }
}
