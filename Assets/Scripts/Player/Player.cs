using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Animations;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // các thông số cơ bản cuiar người chơi
    public bool m_ground;
    Rigidbody2D rigidbody;
    public Animator aim;

    public Collider2D secondCollider;
    public bool bendown = false;
    private bool m_isInvincible = false;
    private bool death;
    private bool takedamage;
    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] private float invincibilityDeltaTime;
    private SpriteRenderer m_spriteRenderer;
    private Vector3 m_scaleVec = new Vector3(0.38f, 0.3f, 1f);
    Vector3 pos;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        aim = gameObject.GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        secondCollider.enabled = false;
        CoreGame.CurHeal = CoreGame.Heal;
    }
    private void FixedUpdate()
    {
       
    }
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (CoreGame.CurHeal <= 0)
        {
            if (death == false)
            {
                EventManager.TriggerEvent(GameEvents.GAMEOVER);
                //aim.SetBool("Death", true);
                CoreGame.State = 1;
                CoreGame.CurHeal = 0;
                Debug.Log("chết");
                StartCoroutine(Death());
            }
        }

        if (CoreGame.GameOver())
        {
            return;
        }
        aim.SetFloat("force", Mathf.Abs(rigidbody.velocity.x));
        ClickProcess();


    }
    private void ClickProcess()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!bendown&& !takedamage)
            {
                rigidbody.velocity = new Vector2(5.0f, rigidbody.velocity.y);
                
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if (!bendown && !takedamage)
            {
                rigidbody.velocity = new Vector2(-5.0f, rigidbody.velocity.y);
            }
           
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        // && m_ground
        if (Input.GetKeyDown(KeyCode.UpArrow) && m_ground)
        {
            if (!bendown)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 14.0f);              
                aim.SetBool("IsJumping", true);
            }


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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("chạm địch");
            //m_ground = true;
            //CoreGame.CurHeal -= 50;
            //EventManager.TriggerEvent(GameEvents.UPDATEHEAL);
            
            Damage(50);
        }
        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_ground = false;
        }
    }

    public void Damage(int dmg)
    {
        if (m_isInvincible) return;
        CoreGame.CurHeal -= dmg;
        rigidbody.velocity = Vector2.zero;
        takedamage = true;
        Debug.Log("nhận sát thương");
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            rigidbody.AddForce(Vector2.right * -50 + Vector2.up * 20);
        }
        else { rigidbody.velocity = new Vector2(10f, 5f); }
        
        EventManager.TriggerEvent(GameEvents.UPDATEHEAL);
        if (CoreGame.CurHeal <= 0)
        {

            return;
        }
        StartCoroutine(SetTakeDamage());
        StartCoroutine(BecomeTemporarilyInvincible());
    }
    private IEnumerator SetTakeDamage()
    {
        yield return new WaitForSeconds(0.5f);
        takedamage = false;
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        m_isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            if (m_spriteRenderer.maskInteraction == SpriteMaskInteraction.None)
            {
                m_spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
            else
            {
                m_spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }
        m_spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
        m_isInvincible = false;
    }
    public IEnumerator Death()
    {
        death = true;
        aim.SetBool("IsJumping", false);
        aim.SetBool("Attackingg", false);
        aim.SetBool("Shooting", false);
        aim.SetBool("Bending", false);
        aim.SetFloat("force", 0);
        aim.SetBool("Death", true);
        yield return new WaitForSeconds(0.1f);

        //EventManager.TriggerEvent(GameEvents.GAMEOVER);
    }
}
