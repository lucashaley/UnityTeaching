using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    [Header("SETTINGS")]
    public float dampening = 5.0f;


    void Update()
    {
        // Declare a Transform variable and keep it updated with player's position
        Transform targetLocation = GameObject.FindWithTag("Player").transform;

        // This makes the turret look at the player's X and Z but ignores the Y
        Vector3 playerPosition = new Vector3(targetLocation.position.x, transform.position.y, targetLocation.position.z);

        Vector3 aim = playerPosition - transform.position;

        Quaternion rotate = Quaternion.LookRotation(aim);

        // This performs the lerp
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * dampening);
    }
}
