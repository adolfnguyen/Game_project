using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class RobotShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bullet;
    public float Bullet;
    Animator anim;
    public float attackdelay = 0.3f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickProcess();
    }
    Coroutine shot;
    private void ClickProcess()
    {
        Bullet = Player.bulletLoad;
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("check 3");           
            if (Bullet > 0)
            {              
                Debug.Log("case1");
                shot = StartCoroutine(Shoot());         
            }
            else
            {
                Debug.Log("het dan");
            }
        }
        else if(Input.GetKeyUp(KeyCode.X)) {
            anim.SetBool("Shooting", false);
            Debug.Log("check here");
            if (shot != null) StopCoroutine(shot);
        }      
    }
    //void Shoot()
    //{
    //    Instantiate(bullet, firePoint.position, firePoint.rotation);
    //    Debug.Log("case 2");
    //    anim.SetBool("Shooting", true);
    //    Player.DecreaseBullet();
    //    EventManager.TriggerEvent(GameEvents.UPDATEBULLET);
    //    attackdelay = 0;
    //}

    IEnumerator Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Debug.Log("case 2");
        anim.SetBool("Shooting", true);
        Player.DecreaseBullet();
        EventManager.TriggerEvent(GameEvents.UPDATEBULLET);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Shooting", false);
    }
}
