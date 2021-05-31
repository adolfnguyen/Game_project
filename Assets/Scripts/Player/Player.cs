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
    public bool bendown = false;
    private bool m_isInvincible = false;
    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] private float invincibilityDeltaTime;
    [SerializeField] private GameObject model;
    private Vector3 m_scaleVec = new Vector3(0.38f, 0.3f, 1f);
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        aim = gameObject.GetComponent<Animator>();
        secondCollider.enabled = false;
        CoreGame.CurHeal = CoreGame.Heal;
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        aim.SetFloat("force", Mathf.Abs(rigidbody.velocity.x));
        ClickProcess();
        if (CoreGame.CurHeal <= 0)
        {
            Death();
        }

    }
    private void ClickProcess()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!bendown)
            {
                rigidbody.velocity = new Vector2(5.0f, rigidbody.velocity.y);
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if (!bendown)
            {
                rigidbody.velocity = new Vector2(-5.0f, rigidbody.velocity.y);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && m_ground)
        {
            if(!bendown)
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 14.0f);
     
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            secondCollider.enabled = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
            aim.SetBool("Bending", true);
            bendown = true;
        }
       
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            secondCollider.enabled = false;
            aim.SetBool("Bending", false);
            bendown = false;
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
    /*public void Damage(int dmg)
    {
        CoreGame.CurHeal -= dmg;
        EventManager.TriggerEvent(GameEvents.UPDATEHEAL);
        Debug.Log("nhập sát thương");
    }*/
    public void Damage(int dmg)
    {
        if (m_isInvincible) return;
        CoreGame.CurHeal -= dmg;
        Debug.Log("nhập sát thương");
        EventManager.TriggerEvent(GameEvents.UPDATEHEAL);
        if (CoreGame.CurHeal <= 0)
        {
            CoreGame.CurHeal = 0;
            return;
        }

        StartCoroutine(BecomeTemporarilyInvincible());
    }   
    private IEnumerator BecomeTemporarilyInvincible()
    {
        m_isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (model.transform.localScale == m_scaleVec)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(m_scaleVec);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }
        ScaleModelTo(m_scaleVec);
        m_isInvincible = false;
    }
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    public void Death()
    {        
        aim.SetBool("Death", true);
        EventManager.TriggerEvent(GameEvents.GAMEOVER);
    }
}
