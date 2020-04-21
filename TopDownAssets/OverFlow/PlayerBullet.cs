using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("BULLET SETTINGS")]
    public int bulletDamage = 50;
    public float speed = 10;
    public float bulletLifetime = 1;

    void Start()
    {
        // Gives the bullet forward force when it's instantiated
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);

        // Destroy the bullet after an amount of time
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision other)
    {
        // Create a variable of type 'EnemyHealth' and store the EnemyHealth script in it
        EnemyHealth enemyHealthScript = other.gameObject.GetComponentInParent<EnemyHealth>();

        // If the thing that this bullet hits has a PlayerHealth script..
        // (avoids errors when hitting non-player objects, like walls)
        if (enemyHealthScript)
        {
            // Run the PlayerHealth script's 'TakeDamage' method.
            // and deliver the value of 'bulletDamage'
            enemyHealthScript.TakeDamage(bulletDamage);
        }

        // Destroy the bullet
        Destroy(gameObject);    
    }


}
