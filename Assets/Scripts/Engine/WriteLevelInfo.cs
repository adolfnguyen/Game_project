 using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using UnityEditor;
using UnityEngine;

public class WriteLevelInfo : MonoBehaviour {
    public static WriteLevelInfo instance;
    private WriteLevelInfo()
    {
        instance = this;
    }
    public static WriteLevelInfo Instance
    {
        get
        {
            return instance;
        }
    }
    public gameInfor game = new gameInfor();


    private void Awake()
    {
        //Debug.Log(PlayerPrefs.GetFloat("version"));
        //Debug.Log(Application.version);
        //PlayerPrefs.GetFloat("version", 0.1f);
        //float old_version = PlayerPrefs.GetFloat("version");
        //string new_version = Application.version;

        //if (new_version != old_version.ToString())
        //{
        //    Debug.Log("khác version");
        //    old_version = float.Parse(new_version);
        //    PlayerPrefs.SetFloat("version", old_version);
        //    CheckUpdateCreateFile();
        //}

        //string text = System.IO.File.ReadAllText(Application.persistentDataPath + "/StoryInfo.txt");
        //Debug.Log(text);

        CreateFile();
    }

    public void CreateFile()
    {
        if (File.Exists(Application.persistentDataPath + "/StoryInfo.txt")) return;
        string path = Application.persistentDataPath + "/StoryInfo.txt";
        string json = JsonUtility.ToJson(game);
        //Debug.LogError(json);

        File.WriteAllText(path, json);

        
    }

    public void CheckUpdateCreateFile()
    {
        string path = Application.persistentDataPath + "/StoryInfo.txt";
        string json = JsonUtility.ToJson(game);
        //Debug.LogError(json);

        File.WriteAllText(path, json);
        Debug.Log("////////////////////////////////////////");
    }

    private void Start()
    {
        //if (File.Exists(Application.persistentDataPath + "/StoryInfo.txt")) return;
        //string path = Application.persistentDataPath + "/StoryInfo.txt";
        //string json = JsonUtility.ToJson(game);
        ////Debug.LogError(json);

        //File.WriteAllText(path, json);
    }

}

public static class JsonHelper {
	public static T[] FromJson<T>(string json) {
		Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}

	public static string ToJson<T>(T[] array) {
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return UnityEngine.JsonUtility.ToJson(wrapper);
	}

	[Serializable]
	private class Wrapper<T> {
		public T[] Items;
	}
}
[Serializable]
public class gameInfor
{
    public int level;
    public bool soundOn;
    public bool musicOn;
}



