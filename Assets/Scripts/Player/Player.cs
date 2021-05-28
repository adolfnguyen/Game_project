using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Animations;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // các thông số cơ bản cuiar người chơi
    public bool m_ground ;
    Rigidbody2D rigidbody;
    public Animator aim;
   
    public Collider2D secondCollider;
    public int ourHeal;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        aim = gameObject.GetComponent<Animator>();
        secondCollider.enabled = false;
        ourHeal = CoreGame.Heal;
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        aim.SetFloat("force", Mathf.Abs(rigidbody.velocity.x));
        ClickProcess();
        if (ourHeal <= 0)
        {
            Death();
        }

    }
    private void ClickProcess()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            rigidbody.velocity = new Vector2(5.0f, rigidbody.velocity.y);

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {


            rigidbody.velocity = new Vector2(-5.0f, rigidbody.velocity.y);

            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && m_ground)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 14.0f);
     
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            secondCollider.enabled = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
            aim.SetBool("Bending", true);

        }
       /* while (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                rigidbody.velocity = new Vector2(2.0f, rigidbody.velocity.y);

                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {


                rigidbody.velocity = new Vector2(-2.0f, rigidbody.velocity.y);

                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0.0f);
            }
        }*/
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            secondCollider.enabled = false;
            aim.SetBool("Bending", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(" cham dat");
            aim.SetBool("IsJumping", false);
            m_ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(" chua cham dat");
            aim.SetBool("IsJumping", true);
            m_ground = false;

        }
    
    }
   // hàm giảm số lượng đạn
  
    public void Damage(int dmg)
    {
        ourHeal -= dmg;
    }
    public void Death()
    {        
        aim.SetBool("Death", true);
        EventManager.TriggerEvent(GameEvents.GAMEOVER);
    }
    
}
