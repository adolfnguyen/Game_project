using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    public GameObject grenade;
    public Transform firePoint;
    Rigidbody2D shellInstance;
    public float launch= 10f;
    public float distance=10f;
    public float speed=10f;
    public int ngrenade;
    Transform gre;
   // Start is called before the first frame update
   void Start()
    {
        shellInstance = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ClickProcess();
    }
    private void ClickProcess()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ngrenade = CoreGame.Grenade;
            if (ngrenade > 0)
            {
                gre = Instantiate(grenade.transform, firePoint.position, firePoint.rotation) as Transform;
                gre.GetComponent<Rigidbody2D>().velocity = distance * firePoint.right * speed;
                CoreGame.DecreaseGreande();
                EventManager.TriggerEvent(GameEvents.UPDATEGRENADE);
            }
            else
            {
                Debug.Log("het luu dan");
            }
        }
    }
}
