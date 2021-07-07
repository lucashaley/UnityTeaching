// Version 0.3

/*

This script allows the player to click things in your Myst game.
Attach this to the RigidBodyFPSController in your scene.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  public class MystClick : MonoBehaviour
  {
    // Public variables
    public float hitDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // check if mouse button is pressed
      if (Input.GetMouseButtonDown(0))
      {
        // create a ray from the center of the screen
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        // send the ray out, and see what it hits
        if (Physics.Raycast(ray, out hit, hitDistance, layerMask , QueryTriggerInteraction.Ignore))
        {
            // Do something with the object that was hit by the raycast.
            Transform objectHit = hit.transform;
            Debug.Log("Clicked on " + objectHit.name);

            // this is the clean, complex version
            if (objectHit.TryGetComponent(out MystControl clickedControl)) clickedControl.Click();

            // this is the brute-force version
            // just send a message to anything, and hope it receives
            // objectHit.SendMessage("Click", SendMessageOptions.DontRequireReceiver);

        }
      }
    }
  }
}
