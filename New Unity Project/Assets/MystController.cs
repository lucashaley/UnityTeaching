// Version 0.3

/*

This script is the base class for controllers.
Do not use this directly.
*/

﻿
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Myst {
  public abstract class MystController : MonoBehaviour
  {
    [Header("Which objects does this control?")]
    public MystControl[] controls;

    [Header("Which objects need to know when complete?")]
    public MystMover[] completeTargets;

    // Start is called before the first frame update
    void Start()
    {
      doInitialization();
    }

    // virtual methods are real (non-abstract) methods
    // that get overridden by any inherited method
    protected virtual void doInitialization ()
    {
      // register this component in each sequence object
      foreach (MystControl control in controls)
      {
        control.controllers.Add(this);
      }
    }

    // Mark any methods you will want to override with _abstract_
    public abstract bool DoControl (MystControl control);

    public virtual void DoComplete ()
    {
      foreach (MystMover mover in completeTargets)
      {
        mover.Move();
      }
    }

    // virtual methods are real (non-abstract) methods
    // that get overridden by any inherited method
    public virtual void ResetControls ()
    {
      foreach (MystControl control in controls)
      {
        control.Reset();
      }
    }

    public bool CheckMovers ()
    {
      return completeTargets.All(t => t.isMoving);
    }

    // This method gets called in editor
    public virtual void OnDrawGizmosSelected() {
      // Link controls
      Gizmos.color = Color.yellow;
      foreach (MystControl control in controls)
      {
        Gizmos.DrawLine(transform.position, control.transform.position);
      }

      // link movers
      Gizmos.color = Color.green;
      foreach (MystMover mover in completeTargets)
      {
        Gizmos.DrawLine(transform.position, mover.transform.position);
      }
    }
  }
}
