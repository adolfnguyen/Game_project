using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera cam;
    Vector2 m_velo;
    Vector3 m_desirePos = new Vector3(51.48f, 12.44f, -10f);
    bool hehe = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_velo = cam.GetComponent<Camerafollow>().velocity;
    }
    private void Update()
    {
        if (hehe)
        {
            StartCoroutine(MovetoPos());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(MovetoPos());
            hehe = true;
        }
    }
    IEnumerator MovetoPos()
    {        
        float posx = Mathf.SmoothDamp(cam.transform.position.x, 51.48f, ref m_velo.x, 2.0f);
        float posy = Mathf.SmoothDamp(cam.transform.position.y, 12.44f, ref m_velo.y, 2.0f);
        cam.transform.position = new Vector3(posx, posy, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        cam.GetComponent<Camerafollow>().SetActiveState(false);
    }
}
