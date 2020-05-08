using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                           // This line is necessary when referencing UI objects

public class PlayerHealth : MonoBehaviour
{
    // PUBLIC VARIABLES
    [Header("UI")]
    public int health = 1000;                   // The player's starting health
    public Slider healthSlider;                 // Reference to the UI health bar
    public int power = 1000;                    // 1. The player's starting power - uncomment this for droid power system
    //  public Slider powerSlider;              // 2. Reference to the UI power bar - uncomment this for droid power system
    //  public float powerEfficiency = 10.0f;   // 3. How slowly the droid loses power (higher number is slower)
                                                // Uncomment powerEfficiency variable for droid power system

    [Header("EFFECTS")]
    public Image damageImage;                   // A reference to the UI damageImage
    public float flashSpeed = 5f;               // How fast to flash the DamageImage
    public Color flashColour;                   // The colour to flash when taking damage
    public GameObject smokeEffect;              // Reference to the smoke effect
    public int criticalDamageLevel = 200;       // Health level where the player starts/stops smoking

    [Header("DEBUG")]
    public bool damageCritical;                 // For debug purposes
    public bool isDead;                         // For debug purposes

    // PRIVATE VARIABLES
    float timer;                                // A variable for the timer to use (for the flashing damage image)
    // float powerUsage;                        // 4. Uncomment this for droid power system              
    int startingHealth;
    int startingPower;
    PlayerControl playerController;
    FireProjectile fireProjectile;
    bool damaged;
    


	void Awake()
    {
        // Set up initial values
        playerController = GetComponent<PlayerControl>();
        fireProjectile = GetComponent<FireProjectile>();
        startingHealth = health;                                // This records the initial health value to use when player respawns
        // startingPower = power;                               // 5. This records the initial power value to use when player respawns
        healthSlider.value = health;
        // powerUsage = (powerEfficiency / 10);                 // 6. Uncomment this for droid power system
    }

    void Start()
    {
        // This makes sure that the smoke effect won't play on start
        smokeEffect.GetComponent<ParticleSystem>().Stop();

        // Player does not start with critical damage
        damageCritical = false;

        // Testing
        // Debug.Log("PowerUsage = " + powerUsage);             // 7. Uncomment this to test droid power system
    }

       
    void Update()
    {
        timer += Time.deltaTime;            // counts up from zero
        
        /* 8. Delete this whole line if implementing droid power system
        if (timer >= powerUsage)
        {
            power--;
            powerSlider.value = power;
            timer = 0;
        }
        9. Delete this whole line if implementing droid power system  */
        


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


    // You can use this method for power pickups (eg. batteries)
    public void AddPower(int powerValue)
    {

    }


    // Used after the PlayerDeath script has run
    public void resetHealth()
    {
        health = startingHealth;
        healthSlider.value = health;
        // power = startingPower;               10. Uncomment this line if adding droid power system
        // powerSlider.value = power;           11. Uncomment this line if adding droid power system
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

		    // If player health is below critical damage value..
			if (health <= criticalDamageLevel)
			{
                // Set damageCritical to TRUE
                damageCritical = true;

                // Begin the smoke effect
                smokeEffect.GetComponent<ParticleSystem>().Play();
			}


			// If the player has lost all it's health and the death flag hasn't been set yet...
			if (health <= 0 && isDead == false)
			{
            //GetComponent<PlayerDeath>().HandleDeath();

                // Send out a general message: 'If you've got a HandleDeath method
                // and you're attached to this gameObject (ie. Player01), run it!'
                gameObject.SendMessage("HandleDeath");

                // Run the below Death method. 
                Death();
			}
		}


        //  You can use this method if you want the player to take explosion damage:  
        //  This can be called by the DeathScript of the exploding object or enemy.
        //  public void TakeExplosionDamage(int explosionDamage)
        //    {
        //        health -= explosionDamage;
        //        Debug.Log("Damage caused by explosion");
        //    }


        // DEATH

        void Death()
        {

        Debug.Log("Is Dead");
            // Set the death flag so this function only gets called once.
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

