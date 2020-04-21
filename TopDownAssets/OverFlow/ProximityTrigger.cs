using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    [Header("PUBLIC REFERENCES")]
    public GameObject mine;          // This is the parenting object

    private void OnTriggerStay(Collider other)
    {
        // If the player triggers the bomb
        if (other.gameObject.tag == "Player")
        {   
            // Run the Explode method in the ProximityMine script
            mine.GetComponent<ProximityMine>().Explode();
        }
    }

}
