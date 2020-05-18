# Week 09: Top-Down Shooter: Completed Fireprojectile script
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManPac
{
  public class FireProjectile : MonoBehaviour
  {
    [Header(“PUBLIC REFERENCES”)]
    public Transform bulletOrigin;	// Where to instantiate bullet
    public Transform mineOrigin;	  // Where to place the mine
    public GameObject bullet;		 // Prefab		
    public GameObject mine;		   // Prefab
    public AudioClip gunSound;
    public AudioClip landMineSound;

    [Header(“SETTINGS”)]
    public float timeBetweenBullets = 0.15f;
    public float timeBetweenLandMines = 0.5f;
    public float effectsDisplayTime = 0.06f;

    // PRIVATE VARIABLES:
    float timer;
    float effectsTimer;
    AudioSource audioSource

    void Start ()
    {
      // Give ‘audioSource’ a value
      audioSource = bulletOrigin.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      // Tie ‘timer’ to the game clock
      timer += Time.deltaTime;

      //	If Fire1 input is received ..
      if (Input.GetButton(“Fire1”) && timer >= timeBetweenBullets)
      {
        // Set ‘gunSound’ as the current audio clip
        audioSource.clip = gunSound;

        // Call the ‘fire’ method
        FireBullet();

        // Reset timer for next bullet
        timer = 0;

        // Start the effects timer
        effectsTimer = effectsDisplayTime;
      }

      //	If Fire2 input is received ..
      if (Input.GetButton(“Fire2”) && timer >= timeBetweenLandMines)
      {
        // Set ‘landMineSound’ as the current audio clip
        audioSource.clip = landMineSound;

        // Call the ‘PlaceMine’ method (below)
        PlaceMine();

        // Reset the timer for next mine
        timer = 0;
      }
    }

    void FireBullet()
    {
      // Instantiate the bullet at the point of origin
      Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

      // Stop the particle system (if it’s already playing)
      bulletOrigin.GetComponent<ParticleSystem>().Stop();

      // Play the particle system
      bulletOrigin.GetComponent<ParticleSystem>().Play();

      // Turn on the light
      bulletOrigin.GetComponent<Light>().enabled = true;

      // Play the BANG sound
      audioSource.Play();
    }

    void PlaceMine()
    {
      // Play the landmine deploy sound
      audioSource.Play();

      // Instantiate the mine prefab at the referenced location
      Instantiate(mine, mineOrigin.position, mineOrigin.rotation);  
    }


    void DisableEffects()
    {
      // Turn off the light
      bulletOrigin.GetComponent<Light>().enabled = false;
    }
  }
}
```
