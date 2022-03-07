// Version 0.3

/*

This script turns a gameobject into an on-off button.
Attach this to a gameObject in your scene.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Toggle Control")]
  public class MystControl_Toggle : MystControl
  {
    public bool isToggled;

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }


    public override void Action ()
    {
      foreach (MystController controller in controllers)
      {
        if (!controller.CheckMovers())
        {
          isToggled = !isToggled;
          // this is a special case, because if the control has multiple controls
          // then we can't sync them all
          if (controller.DoControl(this))
          {
            Debug.Log("Returned Value");
          }
        } else {
          Debug.Log("STILL MOVING");
        }
      }

      // This is the easier-to-read version for beginners
      // if (isToggled)
      // {
      //   gameObject.GetComponent<Renderer>().sharedMaterial.color = switchColor;
      // } else {
      //   gameObject.GetComponent<Renderer>().sharedMaterial.color = startColor;
      // }

      // this is the slick version
      gameObject.GetComponent<Renderer>().sharedMaterial.color = (isToggled) ? switchColor : startColor;
    }
  }
}
