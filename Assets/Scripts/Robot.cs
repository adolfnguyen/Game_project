using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float force;
    public float jumpforce;
    private float maxforce = 7.8f;
    private float scale = 0.3f;
    private bool Ground = true;
    Rigidbody2D rigidbody;
    Animator aim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        aim.SetBool("Ground", Ground);
        aim.SetFloat("force", Mathf.Abs(rigidbody.velocity.x));
        ClickProcess();
    }
    private void ClickProcess()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(scale, scale);
            rigidbody.AddForce(Vector2.right * force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-scale, scale);
            rigidbody.AddForce(Vector2.left * force);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Ground)
        {
            Debug.Log("in " + Ground);
            rigidbody.AddForce(Vector2.up * jumpforce);
        }
    }
    private void FixedUpdate()
    {
        if (rigidbody.velocity.x > maxforce)
        {
            rigidbody.velocity = new Vector2(maxforce, rigidbody.velocity.y);
        }
        if (rigidbody.velocity.x < -maxforce)
        {
            rigidbody.velocity = new Vector2(-maxforce, rigidbody.velocity.y);
        }
        /*if (Ground)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x*0.3f,rigidbody.velocity.y);
        }*/

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("check " + Ground);
            Ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("check 2 " + Ground);
            Ground = false;
        }
    }
}
