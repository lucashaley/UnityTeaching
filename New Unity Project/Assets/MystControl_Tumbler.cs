// Version 0.3

/*

This script turns a gameobject into a tumbler for a combo.
Attach this to a gameObject in your scene.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [AddComponentMenu("Myst/Tumbler Control")]
  public class MystControl_Tumbler : MystControl
  {
    public int states;
    public int currentState = 0;

    [Header("How should it move when changing state?")]
    public Vector3 translateBy;
    public Vector3 rotateBy;
    public Vector3 translateTo;
    private Vector3 translateFrom;
    private Quaternion rotateTo;
    private Quaternion rotateFrom;

    // this a bullshit value because Quaternions are really hard to understand
    private Quaternion badQuaternion = new Quaternion(0,0,0,-1);

    [Header("This curve describes the pace which it will move")]
    public AnimationCurve moveCurve;
    private float animationTime;

    // Start is called before the first frame update
    // We're not doing anything special at Start
    // So we can comment this out
    // void Start()
    // {
    //   doInitialization();
    // }

    // Update is called once per frame
    void Update()
    {
      if (isActivating)
      {
        // WHY DO WE HAVE TO DO THIS?
        if (transform.rotation == badQuaternion)
        {
          transform.rotation = Quaternion.identity;
        }
        // UGH

        // if we haven't reached the destination…
        if ((translateTo != transform.position) || (rotateTo != transform.rotation))
        {
          //  …then keep going
          animationTime += Time.deltaTime;
          transform.position = Vector3.Lerp(transform.position, translateTo, moveCurve.Evaluate(animationTime));
          transform.rotation = Quaternion.Lerp(transform.rotation, rotateTo, moveCurve.Evaluate(animationTime));
        } else {
          // oh but we have reached the destination!
          isActivating = false;
        }
      }
    }

    protected override void doInitialization ()
    {
      base.doInitialization();

      translateFrom = transform.position;
      rotateFrom = transform.rotation;
    }

    public override void Action ()
    {
      if (!isActivating)
      {
        // this is a really useful pattern to cycle through numbers
        currentState = (currentState + 1) % states;

        translateTo = translateFrom + (translateBy * currentState);
        // rotateTo = rotateFrom * Quaternion.Euler(rotateBy * currentState);
        rotateTo = Quaternion.Euler(rotateFrom * (rotateBy * currentState));

        // reset animation timer
        animationTime = 0f;
        isActivating = true;

        foreach (MystController controller in controllers)
        {
          controller.DoControl(this);
        }
      }
    }

    public override void Reset ()
    {
      transform.position = translateFrom;
      transform.rotation = rotateFrom;
      base.Reset();
    }
  }
}
