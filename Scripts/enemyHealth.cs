using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    float currentHealth;

    // HUD variables
    public Slider enemySlider;

    // drops variables
    public bool drops;
    public GameObject theDrop;

    // Audio
    public AudioClip deathKnell;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public function enabling other objects to affect the health of the current object
    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemySlider.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            makeDead();
        }
    }
    public void makeDead()
    {
        Destroy(gameObject.transform.parent.gameObject);
        // position and rotation will be saved so the code below will work
        AudioSource.PlayClipAtPoint(deathKnell, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops)
            Instantiate(theDrop, transform.position, transform.rotation);
    }
}
