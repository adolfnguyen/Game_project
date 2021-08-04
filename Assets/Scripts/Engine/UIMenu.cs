using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public GameObject home;
    public GameObject stateSelect;
    public Text iputText;
    public GameObject uI;
    public static UIMenu instance;
    gameInfor game;
    private UIMenu()
    {
        instance = this;
    }
    public static UIMenu Instance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        LoadScene(0);
        if (File.Exists(Application.persistentDataPath + "/StoryInfo.txt"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/StoryInfo.txt");
            game = JsonUtility.FromJson<gameInfor>(json);
        }
        CoreGame.Level = game.level;
        CoreGame.MusicOn = game.musicOn;
        CoreGame.SoundOn = game.soundOn;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(int i)
    {
        home.SetActive(false);
        stateSelect.SetActive(false);
        uI.SetActive(false);
        iputText.gameObject.SetActive(false);
        if (i == 0)
        {
            home.SetActive(true);
        }
        if (i == 1)
        {
            stateSelect.SetActive(true);
        }
        if (i == 2)
        {
            iputText.gameObject.SetActive(true);
            uI.SetActive(true);
        }
    }

}
