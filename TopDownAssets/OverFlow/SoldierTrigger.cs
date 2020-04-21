using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierTrigger : MonoBehaviour
{
    [Header("PUBLIC REFERENCE")]
    public GameObject thisSoldier;       // Connect the parenting turret object in the editor

    private void OnTriggerStay(Collider other)
    {
        // If the object with the 'Player' tag is inside the trigger zone..
        if (other.CompareTag("Player"))
        {
            // .. tell the SoldierControl script that the player is within range.
            thisSoldier.GetComponent<SoldierControl>().playerInRangeTrue();

            // .. tell the SoldierFire script that the player is within range.
            thisSoldier.GetComponent<SoldierFire>().playerInRangeTrue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the object with the 'Player' tag leaves the trigger zone..
        if (other.CompareTag("Player"))
        {
            // .. tell the SoldierControl script that the player is out of range.
            thisSoldier.GetComponent<SoldierControl>().playerInRangeFalse();

            // .. tell the SoldierFire script that the player is out of range.
            thisSoldier.GetComponent<SoldierFire>().playerInRangeFalse();
        }
    }
}
