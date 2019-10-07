using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;

    float currentHealth;
    playerController controlMovement;

    // HUD variables
    public Slider healthSlider;
    public Image damageScreen;

    bool damaged;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f); // half alpha
    float smoothColor = 5f;

    // Audio variables
    public AudioClip playerHurt;
   // AudioSource playerAS;

    public AudioClip playerDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();

        // HUD initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        damaged = false;

        // Audio initialization
      //  playerAS = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColor;
            damaged = false;
        }
        else // this is done every frame and can slow down the game?
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime); // Color.clear is short for 0f,0f,0f,0f
        }
    }

    public void addDamage(float damage)
    {
        if(damage <= 0)   // For objects that might hit player but not cause damage
        {
            return;
        }
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        damaged = true;

        // set clip to playerHurt and play it
        //  playerAS.clip = playerHurt;
        //  playerAS.Play(); 

        // or use the following line instead of the above twp
        //    playerAS.PlayOneShot(playerHurt);
        AudioSource.PlayClipAtPoint(playerHurt, transform.position);

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth)
            currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }

    // public so events other than enemy hit, e.g. falling off a cliff can kill player as well
    public void makeDead()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
