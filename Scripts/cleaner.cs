using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
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
            playerHealth playerFell = collision.GetComponent<playerHealth>();
            playerFell.makeDead();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
