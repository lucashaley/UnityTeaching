// Version 0.3

/*

This script turns a gameobject into a controller for on-off switches.
Attach this to a gameObject in your scene, and add your toggle controls
to the Controls array.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Toggle Controller")]
  public class MystController_Toggle : MystController
  {
    public bool isToggled;

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    public override bool DoControl (MystControl control)
    {
      isToggled = !isToggled;
      DoComplete();
      return isToggled;
    }
  }
}
