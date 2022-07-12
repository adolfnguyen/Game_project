using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSounds
{
    public static string bullet = "SoundBullet";
    public static string dynamiteExplore = "DynamiteExplore";
    public static string dynamiteExploreEnemy = "DynamiteExploreEnemy";
    public static string dynamiteDetonated = "DynamiteDetonated"; 
}
public class NameMusic
{
    public static string MenuMusic = "MenuMusic";
    public static string Stage1Music = "Stage1Music";
    public static string Stage2Music = "Stage2Music";
    public static string StageBossMusic = "StageBossMusic";
    public static string DeathMusic = "DeathSound";
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private SoundManager()
    {
        instance = this;
    }
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Transform[] audios;
    public Transform[] music;
    // Start is called before the first frame update
    void Start()
    {
        //SetAudio(NameSounds.coitrongtai,false,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudio(string name, bool loop, bool onOff)
    {
        
        for(int i = 0; i < audios.Length; i++)
        {
            if(audios[i].name == name)
            {
                if (onOff)
                {
                    if (CoreGame.SoundOn)
                    {
                        audios[i].GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    audios[i].GetComponent<AudioSource>().Stop();
                }
                
                audios[i].GetComponent<AudioSource>().loop = loop;
            }
        }
    }

    public void SetMusic(string name,bool loop, bool onOff)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].name == name)
            {
                if (onOff)
                {
                    if (CoreGame.MusicOn)
                    {
                        music[i].GetComponent<AudioSource>().Play();                                       
                    }
                }
                else
                {
                    music[i].GetComponent<AudioSource>().Stop();
                }

                music[i].GetComponent<AudioSource>().loop = loop;

            }        
        }
       
    }
}
