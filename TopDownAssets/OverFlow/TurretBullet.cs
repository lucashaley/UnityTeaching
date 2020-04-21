using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [Header("BULLET SETTINGS")]
    public float damage = 50;
    public float speed = 30;
    public float bulletLifetime = 2;

    void Start()
    {
        // Gives the bullet forward force when it's instantiated
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);

        // Destroy the bullet after an amount of time
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Turret bullet alive");

         // Destroy the bullet
         Destroy(gameObject);
    }


}
