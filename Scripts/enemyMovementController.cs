using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;

    // facing
    public GameObject enemyGraphic;
    bool canFlip = true; // can't flip while charging
    bool facingRight = false;
    float flipTime = 5f; // rate of flipping (every 5sec)
    float nextFlipChance = 0f;

    // attacking
    public float chargeTime; // delay before enemy charges after entering zone
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if can flip
        if (Time.time > nextFlipChance)
        {
            if(Random.Range(0,10) > 5) // 50% chance
            {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // determine if what has entered collider is actually player
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime; // give player some time to react

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Time.time >= startChargeTime)
            {
                if (!facingRight)
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                else
                {
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                }
            }
            enemyAnimator.SetBool("isCharging", true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", false);
        }


    }

    void flipFacing()
    {
        if (!canFlip)
        {
            return;
        }
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;

    }
}
