using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myRB;

    
    
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);





    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To stop the bullet
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);

    }
}
