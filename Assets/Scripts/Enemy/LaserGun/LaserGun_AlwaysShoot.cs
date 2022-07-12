using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun_AlwaysShoot : MonoBehaviour
{
    private bool m_canShoot;
    public GameObject projectile;
    SpriteRenderer m_sr;
    public Sprite shootSprite;
    public Sprite idleSprite;
    // Start is called before the first frame update
    void Start()
    {
        m_canShoot = true;
        m_sr = GetComponent<SpriteRenderer>();
    }

    void Shoot()
    {
        projectile.SetActive(true);
        m_sr.sprite = shootSprite;
    }

    void StopShooting()
    {
        projectile.SetActive(false);
        m_sr.sprite = idleSprite;
    }

    public void SetShoot(bool state)
    {
        m_canShoot = state;
        if (m_canShoot)
        {
            Shoot();
        }
        else
        {
            StopShooting();
        }
    }

    public bool GetShoot()
    {
        return m_canShoot;
    }
}
