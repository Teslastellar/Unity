using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth theHealth = collision.gameObject.GetComponent<playerHealth>(); //reference to playerHealth script
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
