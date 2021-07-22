using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun_PressToShoot : MonoBehaviour
{
    private bool m_canShoot;
    public GameObject projectile;
    SpriteRenderer m_sr;
    public Sprite shootSprite;
    public Sprite idleSprite;
    public float attackDelay;

    [SerializeField] Transform m_firePoint;
    // Start is called before the first frame update
    void Start()
    {
        m_canShoot = true;
        m_sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator ShootCoroutine()
    {
        m_canShoot = false;
        Instantiate(projectile, m_firePoint.position, projectile.transform.rotation);
        m_sr.sprite = shootSprite;
        yield return new WaitForSeconds(attackDelay);
        m_sr.sprite = idleSprite;
        m_canShoot = true;
    }

    public bool GetShoot()
    {
        return m_canShoot;
    }

    public void Shoot()
    {
        StartCoroutine(ShootCoroutine());
    }
}
