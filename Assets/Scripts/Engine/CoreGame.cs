using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoreGame : MonoBehaviour
{
    private static int state = 0;
    private static int heal = 2500;
    private static int bullet = 30;
    private static int curheal = 2500;
    private static int grenade = 3;
    private static bool pause;
    private static int level;
    private static bool soundOn;
    private static bool musicOn;
    private static string curMusic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static bool GameOver()
    {
        if (state == 1f)
        {
            return true;
        }
        return false;
    }
    public static void ResetStatus()
    {
        state = 0;
        heal = 2500;
        Bullet = 30;
        grenade = 3;
    }
    public static void DecreaseBullet()
    {
        bullet--;
    }
    public static void DecreaseGreande()
    {
        grenade--;
    }
    public static void IncreaseGreande()
    {
        if (grenade < 3)
        {
            grenade++;
        }
    }
    public static void IncreaseBullet()
    {   
            bullet+=5;   
    }
    public static void IncreaseHeal()
    {
        if (curheal < heal)
        {
            curheal = curheal + 500;
        }
    }
    /*public static bool IsGameOver()
        {
            if (state == 1)
            {
                return true;
            }

            return false;
        }*/
    public static int State { get => state; set => state = value; }
    public static int Heal { get => heal; set => heal = value; }
    public static int CurHeal { get => curheal; set => curheal = value; }
    public static int Bullet { get => bullet; set => bullet = value; }
    public static int Grenade { get => grenade; set => grenade = value; }
    public static bool Pause { get => pause; set => pause = value; }
    public static int Level { get => level; set => level = value; }
    public static bool SoundOn { get => soundOn; set => soundOn = value; }
    public static bool MusicOn { get => musicOn; set => musicOn = value; }
    public static string CurMusic { get => curMusic; set => curMusic = value; }
}
