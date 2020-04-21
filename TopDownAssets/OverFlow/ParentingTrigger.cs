using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);

            // Correcting player scale (working around a weird bug that squishes the player) 
            //other.transform.localScale += new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}