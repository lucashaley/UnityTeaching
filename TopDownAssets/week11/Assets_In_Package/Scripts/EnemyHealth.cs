using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public bool isTurret;
    public bool isSoldier;

    [Header("TURRET SETTINGS")]
    public int turretHealth = 1000;
    public int turretCriticalDamageLevel = 150;     // Health level where the enemy starts/stops smoking
    public int turretPointsValue = 800;

    [Header("SOLDIER SETTINGS")]
    public int soldierHealth = 100;
    public int soldierCriticalDamageLevel = 50;     // Health level where the enemy starts/stops smoking
    public int soldierPointsValue = 200;

    [Header("PUBLIC REFERENCES")]
    public GameObject smokeEffect;

    [Header("DEBUG")]
    public int unitHealth;                          // For debug purposes
    public int unitCriticalDamageLevel;             // For debug purposes
    public bool damageCritical = false;             // For debug purposes


    // private variables


    void Start()
    {
        // This makes sure that the smoke effect won't play on start
        smokeEffect.GetComponent<ParticleSystem>().Stop();
        smokeEffect.GetComponent<ParticleSystem>().gameObject.SetActive(false);

        // If this enemy unit is a turret
        if (isTurret == true)
        {
            // Then use these settings
            unitHealth = turretHealth;
            unitCriticalDamageLevel = turretCriticalDamageLevel;
        }

        // If this enemy unit is a soldier
        if (isSoldier == true)
        {
            // Then use these settings
            unitHealth = soldierHealth;
            unitCriticalDamageLevel = soldierCriticalDamageLevel;
        }
    }


    public void TakeDamage(int damage)
    {
        // Decrement health value by the value of 'damage' (supplied by the PlayerBullet script)
        unitHealth -= damage;

        if (unitHealth <= unitCriticalDamageLevel)
        {
            // DEBUG - set the damage critical flag
            damageCritical = true;

            // Plays the smoke effect when the enemy is low on health
            smokeEffect.GetComponent<ParticleSystem>().gameObject.SetActive(true);
            smokeEffect.GetComponent<ParticleSystem>().Play();
        }

        if (unitHealth <= 0)
        {
            // Run the EnemyDeath script's HandleDeath method
            GetComponent<EnemyDeath>().HandleDeath();
        }
    }
}