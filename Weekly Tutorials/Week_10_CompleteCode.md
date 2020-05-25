# Week 10: Top-Down Shooter: Completed Fireprojectile script

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManPac
{
  public class FireProjectile : MonoBehaviour
  {
    [Header(“PUBLIC REFERENCES”)]
    public Transform bulletOrigin;            // Where to instantiate bullet
    public Transform mineOrigin;              // Where to place the mine
    public GameObject bullet;                 // Prefab
    public GameObject mine;                   // Prefab
    public AudioClip gunSound;
    public AudioClip landMineSound;
    public GameObject impactEffect;           // What to instantiate where bullet hits shootable object

    [Header(“SETTINGS”)]
    public float timeBetweenBullets = 0.15f;
    public float timeBetweenLandMines = 0.5f;
    public float effectsDisplayTime = 0.06f;
    public float lineRange = 100f;            // Length of line drawn

    // PRIVATE VARIABLES:
    float timer;
    float effectsTimer;
    AudioSource audioSource;
    LineRenderer lineRenderer;               // Reference to the line renderer
    Ray shootRay = new Ray();                // A ray cast from projectile origin forwards (Z)
    RaycastHit hitResult;                    // The object hit by raycast
    int shootableMask;                       // Layer No. of shootable mask

    void Start ()
    {
      // Give ‘audioSource’ a value
      audioSource = bulletOrigin.GetComponent<AudioSource>();

      // Give ‘lineRenderer’ a value
      lineRenderer = bulletOrigin.GetComponent<LineRenderer>();

      // Give ‘shootableMask’ a value
      // Returns the number of our ‘Shootable’ layer)
      shootableMask = LayerMask.GetMask(“Shootable”);
    }

    // Update is called once per frame
    void Update()
    {
      // Tie ‘timer’ to the game clock
      timer += Time.deltaTime;

      //If Fire1 input is received ..
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

      //If Fire2 input is received ..
      if (Input.GetButton(“Fire2”) && timer >= timeBetweenLandMines)
      {
        // Set ‘landMineSound’ as the current audio clip
        audioSource.clip = landMineSound;

        // Call the ‘PlaceMine’ method (below)
        PlaceMine();

        // Reset the timer for next mine
        timer = 0; }
      }
    }

    void FireBullet()
    {
      // Instantiate the bullet at the point of origin
      Instantiate(bullet, bulletOrigin.position,
      bulletOrigin.rotation);

      // Stop the particle system (if it’s already playing)
      bulletOrigin.GetComponent<ParticleSystem>().Stop();

      // Play the particle system
      bulletOrigin.GetComponent<ParticleSystem>().Play();

      // Turn on the light
      bulletOrigin.GetComponent<Light>().enabled = true;

      // Turn on the line renderer
      lineRenderer.enabled = true;

      // Set the point at which to begin drawing the line
      lineRenderer.SetPosition(0, bulletOrigin.position);

      // Set the point at which to begin the raycast
      shootRay.origin = bulletOrigin.position;

      // Set the direction for the raycast
      shootRay.direction = bulletOrigin.forward;

      // If the raycast hits something
      if (Physics.Raycast(shootRay, out hitResult, lineRange, shootableMask))
      {
        // set end position of line to be the point where the raycast hit
        lineRenderer.SetPosition(1, hitResult.point);

        // Instantiate the bullet impact effect at the point of impact
        Instantiate(impactEffect, hitResult.point, Quaternion.identity);

      }

      else // If we don’t hit anything
      {
        // Draw a 100-unit line (lineRange) in the forward direction
        lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction
        * lineRange);
      }

      // Play the BANG
      soundaudioSource.Play();
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

      // Turn off the line renderer
      lineRenderer.enabled = false;
    }
  }
}
```
