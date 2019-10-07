using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public float weaponDamage;
    projectileController myPC; // reference to controller containing other scripts
    public GameObject explosionEffect; // reference to explosion particles

    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To get the info of the other collider hit by bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.tag == "Enemy")
            {
                enemyHealth enemyHurt = collision.gameObject.GetComponent<enemyHealth>();
                if(enemyHurt != null)   //if script exists call addDamage() from it
                {
                    enemyHurt.addDamage(weaponDamage);
                }
            }
        }
    }

    // Safeguard in case rocket isn't moving fast enough to detect initial contact/hit and stays in there
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

