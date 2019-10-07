using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour
{
    public GameObject theProjectile;
    public float shootTime; // how often to shoot
    public Transform shootFrom; // location to shoot from
    public int chanceShoot;

    float nextShootTime;
    Animator cannonAnime; // make sure cannon is the top most child b/c we're gonna use the first animation


    // Start is called before the first frame update
    void Start()
    {
        cannonAnime = GetComponentInChildren<Animator>(); // finds first animator in first child
        nextShootTime = 0f; // shoot immediately

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0,10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity); // identity = no rotation
                cannonAnime.SetTrigger("cannonShootTrigger");
            }
        }
    }
}
