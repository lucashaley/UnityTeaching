// Version 0.3

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  public class MystInventory : MonoBehaviour
  {
    // Public variables
    // public Dictionary<string, int> items;
    public MystInventoryDictionary items;

    // // Start is called before the first frame update
    // void Start()
    // {
    //   doInitialization();
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //
    // }
    //
    // protected void doInitialization ()
    // {
    //
    // }

    public void AddItem (string item)
    {
      if (items.ContainsKey(item))
      {
        int currentCount;
        items.TryGetValue(item, out currentCount);
        items[item] = currentCount + 1;
      } else {
        items.Add(item, 1);
      }
    }

    public bool CheckFor(string item, int amount)
    {
      if (items.ContainsKey(item))
      {
        if (items[item] >= amount)
        {
          return true;
        }
      }
      return false;
    }
  }
}
