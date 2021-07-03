using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swtich : MonoBehaviour
{
    SpriteRenderer m_sr;
    public Sprite onSprite;
    public Sprite offSprite;
    private bool switchAllow;
    [SerializeField] LaserGun_AlwaysShoot laserGun;
    // Start is called before the first frame update
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
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
            laserGun.SetShoot(false);
            m_sr.sprite = offSprite;
        }
        else
        {
            laserGun.SetShoot(true);
            m_sr.sprite = onSprite;
        }
    }
}
