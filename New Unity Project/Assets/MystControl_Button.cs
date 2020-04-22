// Version 0.3

/*

This script turns a gameobject into a button.
Attach this to a gameObject in your scene.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Button Control")]
  public class MystControl_Button : MystControl
  {

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    // Update is called once per frame
    // void Update()
    // {
    //
    // }
    new public bool isCollidable = false;
    new public bool isClickable = false;

    public override void Action ()
    {
      isActivating = true;
      StartCoroutine(FlashColor());

      foreach (MystController controller in controllers)
      {
        if (controller.DoControl(this))
        {
          Debug.Log("Returned Value");
        }
      }
    }

    private IEnumerator FlashColor()
    {
      gameObject.GetComponent<Renderer>().sharedMaterial.color = switchColor;
      yield return new WaitForSeconds(0.5f);
      gameObject.GetComponent<Renderer>().sharedMaterial.color = startColor;
      isActivating = false;
    }
  }
}
