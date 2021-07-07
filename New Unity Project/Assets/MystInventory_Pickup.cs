// Version 0.3

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst {
  [RequireComponent(typeof(AudioSource))]
  public class MystInventory_Pickup : MonoBehaviour
  {
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
      gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
      Destroy(gameObject, sound.length);
    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}
