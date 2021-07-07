// Version 0.3

/*

This script turns a gameobject into a zone.
Attach this to a gameObject in your scene, and make sure the
collider is set to "isTrigger"

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [RequireComponent(typeof(Collider))]
  [AddComponentMenu("Myst/Zone Control")]
  public class MystControl_Zone : MonoBehaviour
  {
    [HideInInspector]
    public List<MystController> controllers;

    public GameObject zoneKey;
    public bool isActivated;

    public void OnTriggerEnter(Collider c)
    {
      if (c.gameObject == zoneKey)
      {
        isActivated = true;
      }
    }

    public void OnTriggerExit(Collider c)
    {
      if (c.gameObject == zoneKey)
      {
        isActivated = false;
      }
    }

    public void Action ()
    {
      if (isActivated)
      {
        foreach (MystController controller in controllers)
        {
          // controller.DoControl(this); // we can no longer pass the control
        }
      }
    }
  }
}
