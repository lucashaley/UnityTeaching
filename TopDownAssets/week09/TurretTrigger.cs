using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    [Header("PUBLIC REFERENCE")]
    public GameObject thisTurret;       // Connect the parenting turret object in the editor

    private void OnTriggerStay(Collider other)
    {
        // If the object with the 'Player' tag is inside the trigger zone..
        if (other.CompareTag("Player"))
        {
            // .. tell the TurretFire script that the player is within range.
            thisTurret.GetComponent<TurretFire>().playerInRangeTrue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the object with the 'Player' tag leaves the trigger zone..
        if (other.CompareTag("Player"))
        {
            // .. tell the TurretFire script that the player is out of range.
            thisTurret.GetComponent<TurretFire>().playerInRangeFalse();
        }
    }
}
