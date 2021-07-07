// Version 0.3

/*

This script turns a gameobject into something the player can pick up.
Attach this to a gameObject in your scene.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [RequireComponent(typeof(Collider))]
  [RequireComponent(typeof(Rigidbody))]
  public class MystControl_Grab : MystControl
  {
    public Transform playerCamera;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
      Camera cameraRaw = (Camera)FindObjectOfType(typeof(Camera));
      playerCamera = cameraRaw.gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (isActivating)
      {
        // transform.position = playerCamera.position + cameraOffset;
        // transform.rotation = playerCamera.localRotation;
      }
    }

    public override void Action ()
    {
      // attach the gameObject to the player
      MystClick clicker = (MystClick)FindObjectOfType(typeof(MystClick));
      if (clicker)
      {
        if (isActivating)
        {
          transform.parent = null;
          GetComponent<Rigidbody>().isKinematic = false;
          isActivating = false;
        } else {
          GetComponent<Rigidbody>().isKinematic = true;
          cameraOffset = playerCamera.position - transform.position;
          // transform.SetParent(clicker.transform);
          transform.SetParent(playerCamera);
          isActivating = true;
        }
      }
    }
  }
}
