using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UIManager : MonoBehaviour
{
    public Text Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Bullet.text = "Bullet x20";
        EventManager.StartListening(GameEvents.UPDATEBULLET,new UnityAction(UpdateBullet));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBullet()
    {
        Bullet.text = "Bullet x" + Player.bulletLoad;
    }
}
