// Version 0.3

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  public class MystInventory_Item : MonoBehaviour
  {
    // Public variables
    public bool isCollidable = true;
    public bool isClickable;
    public MystInventory inventory;
    public MystInventory_Pickup pickup;

    // Start is called before the first frame update
    void Start()
    {
      doInitialization();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void doInitialization ()
    {
      // dynamically find the player's inventory
      inventory = GameObject.FindWithTag("Inventory").GetComponent<MystInventory>();
    }

    void OnCollisionEnter (Collision collision)
    {
        if (isCollidable)
        {
            Collect();
        }
    }

    void Click ()
    {
      if (isClickable)
      {
        Collect();
      }
    }

    void Collect ()
    {
        // add to inventory
        inventory.AddItem(gameObject.name);

        // instantiate a pickup
        if (pickup)
        {
          Instantiate(pickup, transform.position, Quaternion.identity);
        }

        // destroy
        Destroy(gameObject);
    }
  }
}
