// Version 0.3

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  public class MystInventory_Require : MonoBehaviour
  {
    public MystInventory_Item required;
    public int amount = 1;

    // what to tell the user when they fail the check
    public string failText;
    public AudioClip failAudio;

    private MystInventory inventory;

    private string requireString;

    // Start is called before the first frame update
    void Start()
    {
      doInitialization();
    }

    protected void doInitialization ()
    {
      // find the inventory object dynamically
      inventory = GameObject.FindWithTag("Inventory").GetComponent<MystInventory>();

      // we have to use the string, as the object might be destroyed during gameplay
      requireString = required.name;
    }

    public bool Check()
    {
      // ask the inventory
      return inventory.CheckFor(requireString, amount);
    }
  }
}
