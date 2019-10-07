using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // Movement variables
    public float maxSpeed;

    // Jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    // Shooting variables
    public Transform gunTip;
    public GameObject gunShot;
    public float fireRate = 0.5f;
    float nextFire = 0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        // Player shooting
        if(Input.GetAxisRaw("Fire1")>0)
        {
            fireBullet();
        }
    }
    void FixedUpdate()
    {
        // Check if grounded if no then falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if(move>0 && !facingRight)
        {
            flip();
        }
        else if(move<0 && facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(gunShot, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else //if (!facingRight) // just use else
            {
                Instantiate(gunShot, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}
