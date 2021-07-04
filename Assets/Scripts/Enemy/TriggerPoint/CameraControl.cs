using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //camera.maxpos.x = 51.48f;
            //camera.minpos.x = 51.48f;
            //camera.maxpos.y = 12.44f;
            //camera.minpos.y = 12.44f;
            //Camera.main.gameObject.transform.position = new Vector3(51.48f, 12.44f, -10.0f);
            Camera.main.gameObject.GetComponent<Camerafollow>().maxpos = new Vector2(51.48f, 12.44f);
            Camera.main.gameObject.GetComponent<Camerafollow>().minpos = new Vector2(51.48f, 12.44f);
        }
    }
}
