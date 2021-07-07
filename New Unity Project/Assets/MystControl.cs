// Version 0.3

/*

This script is the base class for controls.
Do not use this directly.

*/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Linq allows for using All with arrays
using System.Linq;

namespace Myst {
  [RequireComponent(typeof(AudioSource))]
  public abstract class MystControl : MonoBehaviour
  {
    // Public variables
    // [Header("List of controllers")]
    [HideInInspector]
    public List<MystController> controllers;

    [HideInInspector]
    public MystInventory_Require[] requireList;

    [Header("How can the player interact?")]
    public bool isCollidable = true;
    public bool isClickable;

    [Header("What color does it switch to when interacted?")]
    public Color switchColor;

    [Header("Audio")]
    public AudioClip successSound;
    public AudioClip failureSound;

    [HideInInspector]
    public Color startColor;

    public bool isActivating;

    // Start is called before the first frame update
    void Start()
    {
      doInitialization();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void doInitialization ()
    {
      startColor = gameObject.GetComponent<Renderer>().material.color;
      requireList = gameObject.GetComponents<MystInventory_Require>();
    }

    void OnCollisionEnter (Collision c) {
      if (isCollidable)
      {
        CheckRequires();
      }
    }

    public void Click ()
    {
      if (isClickable)
      {
        if (CheckRequires())
        {
          if (successSound != null) gameObject.GetComponent<AudioSource>().PlayOneShot(successSound);
          Action();
        } else {
          if (failureSound != null) gameObject.GetComponent<AudioSource>().PlayOneShot(failureSound);
          Debug.Log("Require has failed: " + gameObject.name);
        }
      }
    }

    protected bool CheckRequires ()
    {
      return requireList.All(r => r.Check());
    }

    public abstract void Action ();

    public virtual void Reset ()
    {
      gameObject.GetComponent<Renderer>().sharedMaterial.color = startColor;
    }
  }
}
