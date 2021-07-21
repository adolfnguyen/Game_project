using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControllerInfomation : MonoBehaviour
{
    public static ControllerInfomation instance;
    private ControllerInfomation()
    {
        instance = this;
    }
    public static ControllerInfomation Instance
    {
        get
        {
            return instance;
        }
    }

    gameInfor game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePhase(int phase)
    {
        if (File.Exists(Application.persistentDataPath + "/StoryInfo.txt"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/StoryInfo.txt");
            game = JsonUtility.FromJson<gameInfor>(json);
        }
        game.level = CoreGame.Level;
        string path = Application.persistentDataPath + "/StoryInfo.txt";
        string jsonWrite = JsonUtility.ToJson(game);
        File.WriteAllText(path, jsonWrite);
    }
}
