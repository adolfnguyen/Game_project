using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoreGame : MonoBehaviour
{
    private static int state = 0;
    private static int heal = 1000;
    private static int bullet = 20;
    private static int greanade = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ResetStatus()
    {
     state = 0;
     heal = 1000;
     Bullet = 20;
    }
    public static void DecreaseBullet()
    {
        bullet--;
    }
    public static void IncreaseBullet()
    {
        if (bullet < 20)
        {
            bullet++;
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
    public static int Bullet { get => bullet; set => bullet = value; }
    public static int Grenade { get => greanade; set => greanade = value; }
}
