using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // PUBLIC VARIABLES
    public bool isTurretAmmo;                           //  Sets the kind of bullet that's being fired
    public bool isSoldierAmmo;                          //  Sets the kind of bullet that's being fired

    [Header("TURRET AMMO")]
    public int turretDamage = 80;                       //  Sets the amount of damage a turret does
    public float turretBulletSpeed = 20f;               //  Sets the speed of a turret shell
    public float turretBulletLifetime = 1f;             //  Sets the lenth of a turret bullet's life
	
    [Header("SOLDIER AMMO")]
    public int soldierDamage = 20;                      //  Sets the amount of damage a soldier does
    public float soldierBulletSpeed = 50f;              //  Sets the speed of a soldier bullet
    public float soldierBulletLifetime = 1f;            //  Sets the lenth of a soldier bullet's life

    // PRIVATE VARIABLES
    float speed;                                        //  A private float to determine the bullet's speed
    int damage;                                         //  A variable to load with various damage values
    float bulletLifetime;                               //  A variable to determine various bullet lifespans


    void Awake()
    {
        // If this is a turret bullet ..
        if (isTurretAmmo == true)
        {
            // .. use these settings
            speed = turretBulletSpeed;
            damage = turretDamage;
            bulletLifetime = turretBulletLifetime; 
        }

        // If this is a soldier bullet ..
        if (isSoldierAmmo == true)
        {
            // .. use these settings
            speed = soldierBulletSpeed;
            damage = soldierDamage;
            bulletLifetime = soldierBulletLifetime;
        }

    }

    void Start()
    {
        // Give the bullet force / impulse
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);

        // When to remove the bullet from the game
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision other)
    {
        // Create a variable of type 'PlayerHealth' and store the PlayerHealth script in it
        PlayerHealth playerHealthScript = other.gameObject.GetComponentInParent<PlayerHealth>();

        // If the thing that this bullet hits has a PlayerHealth script..
        // (avoids errors when hitting non-player objects, like walls)
        if (playerHealthScript)                                     
        {
            // Run the PlayerHealth script's 'TakeDamage' method.
            playerHealthScript.TakeDamage(damage);                
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
