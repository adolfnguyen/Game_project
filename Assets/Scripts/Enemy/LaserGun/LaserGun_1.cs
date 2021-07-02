using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun_1 : MonoBehaviour
{
    private bool m_canShoot;
    public GameObject projectile;
    public float attackDelay;
    private float seconds;
    SpriteRenderer m_sr;
    public Sprite shootSprite;
    public Sprite idleSprite;
    // Start is called before the first frame update
    void Start()
    {
        m_canShoot = true;
        seconds = attackDelay;
        m_sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canShoot)
        {
            if (seconds <= 0)
            {
                StartCoroutine(Shoot());
                seconds = attackDelay;
            }
            else
            {
                seconds -= Time.deltaTime;
            }
        }
    }

    IEnumerator Shoot()
    {
        Debug.Log("Shoot ne");
        projectile.SetActive(true);
        m_sr.sprite = shootSprite;
        yield return new WaitForSeconds(attackDelay / 2);
        Debug.Log("Khong shoot ne");
        projectile.SetActive(false);
        m_sr.sprite = idleSprite;
    }
}
