using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;
    public Vector2 minpos, maxpos;
    public GameObject player;
    public bool bound;
    private bool m_active;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_active = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_active)
        {
            float posx = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
            float posy = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
            transform.position = new Vector3(posx, posy, transform.position.z);
            if (bound)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
                    Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                    Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
            }
        } 
    }
    public bool GetActiveState()
    {
        return m_active;
    }
    public void SetActiveState(bool state)
    {
        m_active = state;
    }
}
