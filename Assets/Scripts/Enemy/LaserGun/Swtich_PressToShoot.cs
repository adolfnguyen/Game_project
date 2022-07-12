using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swtich_PressToShoot : MonoBehaviour
{
    private bool switchAllow;

    [SerializeField] Animator switchAnim;
    [SerializeField] LaserGun_PressToShoot laserGun;
    // Start is called before the first frame update
    void Start()
    {
        switchAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchAllow && Input.GetKeyDown(KeyCode.E))
        {
            ChangeState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchAllow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchAllow = false;
        }
    }

    void ChangeState()
    {
        if (laserGun.GetShoot() == true)
        {
            laserGun.Shoot();
            switchAnim.Play("ChangeAnim");
        }
    }
}
