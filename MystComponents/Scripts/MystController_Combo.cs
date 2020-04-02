// Version 0.3

/*

This script turns a gameobject into a controller for combos.
Attach this to a gameObject in your scene, and add your tumbler controls
to the Controls array.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Linq allows for using All with arrays
using System.Linq;

namespace Myst {
  [AddComponentMenu("Myst/Combination Controller")]
  public class MystController_Combo : MystController
  {
    [Header("The combination. Note this is in the same sequence as the controls above.")]
    public int[] combination;

    [Header("Do they have it right?")]
    public bool isCorrect;

    [Header("Should the player have to use another control to confirm combination?")]
    public bool requireConfirmation;
    [Header("If so, what is that control?")]
    public GameObject confirmationButton;

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    protected override void doInitialization ()
    {
      base.doInitialization();

      if (requireConfirmation)
      {
        confirmationButton.GetComponent<MystControl>().controllers.Add(this);
      }
    }

    public override bool DoControl (MystControl control)
    {
      // This is the easier-to-read version for beginners
      // if (control.gameObject == confirmationButton || !requireConfirmation)
      // {
      //   isCorrect = true;
      // } else {
      //   isCorrect = false;
      // }

      // this is the slick version
      isCorrect = control.gameObject == confirmationButton || !requireConfirmation;

      if (isCorrect)
      {
        for (int i = 0; i < controls.Length; i++)
        {
          MystControl_Tumbler c = controls[i] as MystControl_Tumbler;
          isCorrect &= (c.currentState == combination[i]);
        }
      }

      if (isCorrect)
      {
        DoComplete();
      }

      return isCorrect;
    }

    // This method gets called in editor
    public override void OnDrawGizmosSelected() {
      // draw base lines
      base.OnDrawGizmosSelected();

      if (requireConfirmation)
      {
        // Link controls
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, confirmationButton.transform.position);
      }
    }
  }
}
