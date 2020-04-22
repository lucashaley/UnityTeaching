// Version 0.3

/*

This script turns a gameobject into a controller for combos.
Attach this to a gameObject in your scene, and add your tumbler controls
to the Controls array.

This currently does nothing.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Debug Controller")]
  public class MystController_Debug : MystController
  {

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    // if you want to do something different with initialization,
    // make sure to mark this as an override
    protected override void doInitialization ()
    {
      base.doInitialization();
    }

    public override bool DoControl (MystControl control)
    {
      return true;
    }
  }
}
