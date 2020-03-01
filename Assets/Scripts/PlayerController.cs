using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


   
    Vector2 lookDirection = new Vector2(0.1f, 0);
 

        
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2D.position;
        
        float horizontal = Input.GetAxis("Horizontal");


        Vector2 move = new Vector2(horizontal, 0f);
        



        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (!Mathf.Approximately(move.x , 0.0f))
        {
            lookDirection.Set(move.x, 0f);
            //lookDirection.Normalize();
        }

        if(isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }


        position.x = position.x + speed * horizontal * Time.deltaTime;
        rigidbody2D.position = position;

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Fire projectile bullet");
            fireBullet();
        }


        Debug.Log(isGround + " : " +  " Look: " + lookDirection + " Magnitude: " + move.magnitude + " Move : " + move);
        
    }


    public void fireBullet()
    { 
        int multiplier = 1;

        if (lookDirection.x < 0)
        {
            multiplier = -1;
        }

        GameObject clone = (Instantiate(projectile_bullet, transform.position, transform.rotation));

        clone.GetComponent<Rigidbody2D>().velocity = transform.right * bullet_speed * multiplier;
    }

}
