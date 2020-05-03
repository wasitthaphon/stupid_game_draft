using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    Animator animator;

    public Transform feetPos;
    public float speed;
    public float jumpForce;
    public GameObject projectile_bullet;
    
    private bool isGround;
    public LayerMask whatIsGround;
    public float checkRadius;

    public float bullet_speed = 2f;

    public bool lookRight = true;
    public float moveX = 0;
    private Vector3 m_velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;
    private bool isDisplayWeaponUI = false;

    public GameObject weaponsUI;

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        weaponsUI.SetActive(false);
    }

    private void FixedUpdate()
    {

        Vector2 position = rigidbody2D.position;
        moveX = Input.GetAxis("Horizontal");

        rigidbody2D.position = position + new Vector2(moveX, 0) * speed * Time.deltaTime;

       //Vector3 targetVelocity = new Vector2(moveX * 5f, rigidbody2D.velocity.y);
       //rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);

    }

    void Update()
    {    
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        if (moveX > 0f && !lookRight)
        {
            Flip();
        }else if(moveX < 0f && lookRight)
        {
            Flip();
        }

        if (!Mathf.Approximately(moveX, 0f))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false); 
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Fire projectile bullet");
            fireBullet();
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("IsDisplayWeaponUI : " + isDisplayWeaponUI);
            isDisplayWeaponUI = !isDisplayWeaponUI;
            weaponsUI.SetActive(isDisplayWeaponUI);
        }

        Debug.Log("LookRight : " + lookRight + " Direction : " + moveX);
    }


    public void fireBullet()
    { 
        int multiplier = 1;

        if (moveX < 0)
        {
            multiplier = -1;
        }

        GameObject clone = (Instantiate(projectile_bullet, transform.position, transform.rotation));

        clone.GetComponent<Rigidbody2D>().velocity = transform.right * bullet_speed * multiplier;
    }

    private void Flip()
    {
        lookRight = !lookRight;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
