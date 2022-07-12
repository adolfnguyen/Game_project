using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera cam;
    Vector2 m_velo;
    public Vector3 desirePos = new Vector3(51.48f, 12.44f, -10f);
    public float camSize;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_velo = cam.GetComponent<Camerafollow>().velocity;
    }
    private void Update()
    {
        if (active)
        {
            StartCoroutine(MovetoPos());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = true;
        }
    }
    IEnumerator MovetoPos()
    {        
        float posx = Mathf.SmoothDamp(cam.transform.position.x, desirePos.x, ref m_velo.x, 2.0f);
        float posy = Mathf.SmoothDamp(cam.transform.position.y, desirePos.y, ref m_velo.y, 2.0f);
        cam.transform.position = new Vector3(posx, posy, transform.position.z);
        if (cam.orthographicSize < camSize) cam.orthographicSize += Time.deltaTime;
        yield return new WaitForSeconds(0.1f);
        cam.GetComponent<Camerafollow>().SetActiveState(false);
    }
}
