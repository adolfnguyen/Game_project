using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int dmg;
    private bool m_isBloom = false;
    [SerializeField] Animator mineAnim;
    // Start is called before the first frame update
    void Start()
    {
        mineAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D hitintro)
    {
        if (hitintro.CompareTag("Enemy"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            if (m_isBloom == false)
            {
                SoundManager.instance.SetAudio(NameSounds.dynamiteDetonated, false, true);
                StartCoroutine(Bloom());
            }         
        }
        if (hitintro.CompareTag("Player"))
        {
            hitintro.SendMessageUpwards("Damage", dmg);
            if (m_isBloom == false)
            {
                SoundManager.instance.SetAudio(NameSounds.dynamiteDetonated, false, true);
                StartCoroutine(Bloom());
            }
        }
    }

    IEnumerator Bloom()
    {
        SoundManager.instance.SetAudio(NameSounds.dynamiteExploreEnemy, false, true);
        m_isBloom = true;
        mineAnim.SetBool("BloomAnim", true);
        yield return new WaitForSeconds(0.40f);
        Destroy(transform.gameObject);
    }
}
