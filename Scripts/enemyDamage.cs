using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate; // how often damage occurs so that player can escape
    public float pushBackForce;

    float nextDamage; // when next damage can occur
    
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time; // enemy can incur damage now or use 0f
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && nextDamage < Time.time)
        {
            playerHealth thePlayerHealth = collision.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(collision.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized; // push direction set to opposite or directly away in the y-direction of pushing object(just use 1)
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero; // same as Vector2(0, 0) - done to counteract player input and previous movement
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
