using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierControl : MonoBehaviour
{
    [Header("SOLDIER SETTINGS")]
    public float thrust = 200f;
    public float dampening = 0.5f;

    [Header("DEBUG")]
    public bool playerIsWithinRange;

    // Update is called once per frame
    void Update()
    {
        if (playerIsWithinRange == true)
        {
            //  Create a Transform variable called 'targetLocation'
            //  Keep it updated with the location of the Player
            Transform targetLocation = GameObject.FindWithTag("Player").transform;

            //  Create a NavMeshAgent variable called 'navAgent'
            //  Point it to this soldier's NavMeshAgent component
            UnityEngine.AI.NavMeshAgent navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

            // Set the destination for the navAgent
            navAgent.SetDestination(targetLocation.position);

            // This makes the turret look at the player's X and Z but ignores the Y
            Vector3 playerPosition = new Vector3(targetLocation.position.x, transform.position.y, targetLocation.position.z);

            Vector3 aim = playerPosition - transform.position;

            //  Create a variable for soldier rotation
            Quaternion rotate = Quaternion.LookRotation(aim);

            // Lerp the soldier's rotation and include dampening to ease motion
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * dampening);
        }
    }

    public void playerInRangeTrue()
    {
        playerIsWithinRange = true;
    }

    public void playerInRangeFalse()
    {
        playerIsWithinRange = false;
    }
}
