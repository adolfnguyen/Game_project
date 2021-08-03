using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageControl : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] platform;
    private float bossHitPoint;
    private float x;
    public float y;
    public GameObject bulletDrop, healingDrop;
    private float gameTimer;
    private int seconds;
    public CameraShake cameraShake;
    private bool m_isSpawn;
    Vector2 m_velo;
    Camera cam;
    public float camSize;
    private bool m_inOut;
    public GameObject camControl;

    void Start()
    {
        m_isSpawn = false;
        bossHitPoint = enemy.GetComponent<AI>().hitPoint;
        cameraShake = FindObjectOfType<Camera>().GetComponent<CameraShake>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_velo = cam.GetComponent<Camerafollow>().velocity;
        m_inOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy)
        {
            if (enemy.GetComponent<AI>().hitPoint < bossHitPoint / 3)
            {
                for (int i = 0; i < platform.Length; i++)
                {
                    platform[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
            if (Time.time > gameTimer + 1)
            {
                gameTimer = Time.time;
                seconds++;
            }
            if (seconds == 10)
            {
                seconds = 0;
                x = Random.Range(51f, 62f);
                if (Random.Range(1, 6) < 4)
                {
                    Instantiate(bulletDrop, new Vector2(x, y), Quaternion.identity);
                }
                else
                {
                    Instantiate(healingDrop, new Vector2(x, y), Quaternion.identity);
                }
            }
            if (enemy.GetComponent<AI>().hitPoint <= 0)
            {
                Destroy(camControl);
                if (m_inOut)
                    StartCoroutine(ZoomInCam());
            }
        }
        else
        {
            cam.GetComponent<Camerafollow>().SetActiveState(true);
            cam.orthographicSize = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_isSpawn)
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SetActiveBoss());
        }
    }

    IEnumerator SetActiveBoss()
    {
        m_isSpawn = true;
        yield return new WaitForSeconds(2f);
        enemy.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(cameraShake.Shake(1.0f));
    }

    IEnumerator ZoomInCam()
    {
        float posx = Mathf.SmoothDamp(cam.transform.position.x, enemy.GetComponent<Transform>().position.x + 2f, ref m_velo.x, 0.5f);
        float posy = Mathf.SmoothDamp(cam.transform.position.y, enemy.GetComponent<Transform>().position.y - 1f, ref m_velo.y, 0.5f);
        cam.transform.position = new Vector3(posx, posy, transform.position.z);
        if (cam.orthographicSize > camSize) cam.orthographicSize -= Time.deltaTime * 3;
        yield return null;
    }
}
