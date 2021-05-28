using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Animations;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // các thông số cơ bản cuiar người chơi
    public int hp;
    public static int bulletLoad =20;

    public bool m_ground ;
    Rigidbody2D rigidbody;
    public Animator aim;
   
    public Collider2D secondCollider;

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
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        aim.SetFloat("force", Mathf.Abs(rigidbody.velocity.x));
        ClickProcess();

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
   public static void DecreaseBullet()
    {
        bulletLoad--;
    }
    public void Damage(int dmg)
    {
        if (m_isInvincible) return;

        hp -= dmg;

        if (hp <= 0)
        {
            hp = 0;
            return;
        }

        StartCoroutine(BecomeTemporarilyInvincible());
    }
    public static int BulletLoad { get => BulletLoad; set => BulletLoad = value; }

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
}
