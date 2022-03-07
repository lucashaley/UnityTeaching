// Version 0.3

/*

This script turns a gameobject into a controller for a sequence of controls.
Attach this to a gameObject in your scene, and add your controls
to the Controls array.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Sequence Controller")]
  public class MystController_Sequencer : MystController
  {
    // Public variables
    [Header("Note: the controls variable is in ordered sequence")]
    [Header("This is the current completed control in order")]
    public int currentIndex = 0;

    [Header("Should the whole pattern reset if the player makes a mistake?")]
    public bool resetOnMistake;

    [Header("Should the controls show successful progress?")]
    public bool showProgress = true;

    [Header("Is the sequence complete?\nUsually you don't manually set this")]
    public bool isComplete;

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    // When you implement an abstract method, you must declare it as an _override_
    public override bool DoControl (MystControl control)
    {
        if (control == controls[currentIndex])
        {
            currentIndex++;

            if (currentIndex == controls.Length)
            {
                isComplete = true;
                DoComplete();
            }

            return showProgress;
        } else {
            if (resetOnMistake)
            {
                currentIndex = 0;
                ResetControls();
            }

            return false;
        }
    }

    public override void DoComplete ()
    {
      base.DoComplete();
      currentIndex = 0;
      ResetControls();
    }
  }
}
