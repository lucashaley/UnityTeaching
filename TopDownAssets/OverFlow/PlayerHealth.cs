using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // PUBLIC VARIABLES

    [Header("UI")]
    public int health = 1000;               // The player's starting health
    public Slider healthSlider;             // Reference to the UI health bar
    public int power = 1000;                // The player's starting power
    public Slider powerSlider;              // Reference to the UI power bar
    public float powerEfficiency = 10.0f;   // How slowly the droid loses power (higher number is slower)

    [Header("EFFECTS")]
    public Image damageImage;               // A reference to the UI damageImage
    public float flashSpeed = 5f;           // How fast to flash the DamageImage
    public Color flashColour;
    public GameObject smokeEffect;          // Reference to the smoke effect
    public int criticalDamageLevel = 200;   // Health level where the player starts/stops smoking

    [Header("DEBUG")]
    public bool damageCritical;             // For debug purposes
    public bool isDead;

    // PRIVATE VARIABLES
    float timer;
    float powerUsage;
    int startingHealth;
    PlayerControl playerController;
    FireProjectile fireProjectile;
    bool damaged;
    


	void Awake()
    {
        // Set up initial values
        playerController = GetComponent<PlayerControl>();
        fireProjectile = GetComponent<FireProjectile>();
        startingHealth = health;                                // This records the initial health value to use when player is destroyed
        healthSlider.value = health;
        powerUsage = (powerEfficiency / 10);
    }

    void Start()
    {
        // This makes sure that the smoke effect won't play on start
        smokeEffect.GetComponent<ParticleSystem>().Stop();

        // Player does not start with critical damage
        damageCritical = false;

        Debug.Log("PowerUsage = " + powerUsage);
    }

       
    void Update()
    {
        timer += Time.deltaTime;            // counts up from zero
        

        if (timer >= powerUsage)
        {
            power--;
            powerSlider.value = power;
            timer = 0;
        }

        // If 'damaged == true (ie. the player is taking damage)
        if (damaged)
        {
            // .. flash the damage colour
            damageImage.color = flashColour;
        }
       
        else
        {
	        // ..fade the colour back to nothing 
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset 'currently being damaged' state
        damaged = false;
    }



    // HEALTH:

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        healthSlider.value = health;

        // Debug.Log ("Health received from pickup:" + healthValue);

        if (health >= criticalDamageLevel)
        {
            // Debug
            damageCritical = false;

            // Disable the smoke effect
            smokeEffect.GetComponent<ParticleSystem>().Stop();
        }
    }

    public void AddPower(int powerValue)
    {

    }

    // Used after the PlayerDeath script has run
    public void resetHealth()
    {
        health = startingHealth;
        healthSlider.value = health;
        damageCritical = false;
        isDead = false;     
    }


		// TAKING DAMAGE:

		public void TakeDamage(int damage)
		{
			damaged = true;

			// Reduce health value
			health -= damage;

			healthSlider.value = health;

			// Play the player hit sound effect
			// playerAudio.Play();


			if (health <= criticalDamageLevel)
			{
                damageCritical = true;

                // Begin the smoke effect
                smokeEffect.GetComponent<ParticleSystem>().Play();
			}


			// If the player has lost all it's health and the death flag hasn't been set yet...
			if (health <= 0 && isDead == false)
			{
                // Send out a general message: 'If you've got a HandleDeath method
                // and you're attached to this gameObject, run it!'
                // PlayerDeath has it and will run it.
                gameObject.SendMessage("HandleDeath");

                // Run the below Death method. 
                Death();
			}
		}



        //  This is called by the DeathScript of the exploding object
        //  public void TakeExplosionDamage(int explosionDamage)
        //    {
        //        health -= explosionDamage;
        //        Debug.Log("Damage caused by explosion");
        //    }



        // DEATH

        void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

        // Turn off any remaining shooting effects.
        // FireProjectile.DisableEffects();

        // Turn off smoke effect
        smokeEffect.GetComponent<ParticleSystem>().Stop();

        // Turn off the movement and shooting scripts.
        playerController.enabled = false;
            fireProjectile.enabled = false;
        }


}

