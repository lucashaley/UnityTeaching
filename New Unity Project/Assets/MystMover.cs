// Version 0.3

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  public class MystMover : MonoBehaviour
  {
    // Public variables
    // [Header("How can the player interact?")]
    // public bool isToggle;

    [Header("Where should it go?")]
    public Vector3 translateTo;
    public Vector3 rotateTo;

    [Header("Are the above values relative to the starting position?")]
    public bool isRelative;

    [Header("This curve describes the pace which it will move")]
    public AnimationCurve moveCurve;

    private Vector3 translateFrom;
    private Vector3 rotateFrom;
    private Vector3 translateToAbs;
    private Vector3 rotateToAbs;
    private float animationTime;

    [HideInInspector]
    public bool isMoving;
    private bool isAtDestination;

    // Start is called before the first frame update
    void Start()
    {
      doInitialization();
    }

    // Update is called once per frame
    void Update()
    {
      if (isMoving)
      {
        if (isAtDestination)
        {
          // we're ready to go back to the starting position
          if ((translateFrom != transform.position) || (rotateFrom != transform.rotation.eulerAngles))
          {
            animationTime += Time.deltaTime;
            transform.position = Vector3.Lerp(translateToAbs, translateFrom, moveCurve.Evaluate(animationTime));
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateToAbs), Quaternion.Euler(rotateFrom), moveCurve.Evaluate(animationTime));
          } else {
            isMoving = false;
            isAtDestination = false;
            animationTime = 0f;
          }
        } else {
          // we're ready to go forward
          if ((translateToAbs != transform.position) || (rotateToAbs != transform.rotation.eulerAngles))
          {
            animationTime += Time.deltaTime;
            transform.position = Vector3.Lerp(translateFrom, translateToAbs, moveCurve.Evaluate(animationTime));
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(rotateFrom), Quaternion.Euler(rotateToAbs), moveCurve.Evaluate(animationTime));
          } else {
            isMoving = false;
            isAtDestination = true;
            animationTime = 0f;
          }
        }
      }
    }

    protected void doInitialization ()
    {
      translateFrom = transform.position;
      rotateFrom = transform.rotation.eulerAngles;

      translateToAbs = translateTo;
      rotateToAbs = rotateTo;

      if (isRelative)
      {
        translateToAbs += transform.position;
        rotateToAbs += transform.rotation.eulerAngles;
      }
    }

    public void Move ()
    {
      if (!isMoving)
      {
        isMoving = true;
      }
    }
  }
}
