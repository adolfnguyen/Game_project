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
        if (CoreGame.Level > 0)
        {
            LoadScene(1);
        }
        else
        {
            LoadScene(0);
        }
        if (File.Exists(Application.persistentDataPath + "/StoryInfo.txt"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/StoryInfo.txt");
            game = JsonUtility.FromJson<gameInfor>(json);
        }
        game.level = CoreGame.Level;
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
        }
    }

}
