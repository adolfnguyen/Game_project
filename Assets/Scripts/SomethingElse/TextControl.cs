using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [SerializeField] private Text pickupText;
    [SerializeField] LaserGun_AlwaysShoot laserGun;
    // Start is called before the first frame update
    void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (laserGun.GetShoot() == false)
        {
            Destroy(pickupText);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(true);
        }
    }
}
