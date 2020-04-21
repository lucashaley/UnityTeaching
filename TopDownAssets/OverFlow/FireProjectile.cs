using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [Header("SETTINGS")]
    public float timeBetweenBullets = 0.15f;
    public float timeBetweenLandMines = 0.5f;
    public float effectsDisplayTime = 0.06f;
    public float lineRange = 100f;
    public bool playerHasBullets = true;
    public bool playerHasMines = true;
    public bool playerHasTimeBombs = true;

    [Header("PUBLIC REFERENCES")]
    public Transform bulletOrigin;      // Where to instantiate bullet
    public Transform mineOrigin;        // Where to place the mine
    public GameObject bullet;           // Prefab 
    public GameObject mine;             // Prefab
    public AudioClip gunSound;
    public AudioClip landMineSound;
    public AudioClip outOfAmmoSound;       
    public GameObject impactEffect;
   

    // PRIVATE VARIABLES
    float timer;
    float effectsTimer;
    AudioSource audioSource;
    LineRenderer lineRenderer;      // Reference to the line renderer
    Ray shootRay = new Ray();       // A ray from the projectile origin forwards (Z)
    RaycastHit hitResult;           // A raycast hit that returns information about what it hit
    int shootableMask;              // Layer No. so that the line only hits shootable things


    private void Start()
    {
        // Give audioSource a value
        audioSource = bulletOrigin.GetComponent<AudioSource>();

        //Give lineRenderer a value 
        lineRenderer = bulletOrigin.GetComponent<LineRenderer>();

        // Give shootableMask a value (returns the number of our 'Shootable' layer)
        shootableMask = LayerMask.GetMask("Shootable");
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // counts up 
        effectsTimer -= Time.deltaTime;     // counts down

        // If Fire1 input is received ..
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            // Set 'gunSound' as the current audio clip
            audioSource.clip = gunSound;

            // .. call the 'fire' method (below)
            FireBullet();

            // reset bullet timer
            timer = 0;

            // start the effects timer
            effectsTimer = effectsDisplayTime;
        }

        if (Input.GetButton("Fire2") && timer >= timeBetweenLandMines)
        {
            if (playerHasMines == true)
            {
                // Set 'landMineSound' as the current audio clip
                audioSource.clip = landMineSound;

                // Run the 'PlaceMine' method below
                PlaceMine();

                // reset bullet timer
                timer = 0;
            }

            else
            {
                // Set 'outOfAmmoSound' as the current audio clip
                audioSource.clip = outOfAmmoSound;

                // Play the outOfAmmoSound
                audioSource.Play();
            }
        }

        // Effects timer
        if (effectsTimer <= 0)
        {
            // Disable light
            DisableEffects();
        }

    }

    void FireBullet()
    {
        // Testing that the fire method is being called
        // Debug.Log("Firing bullet");

        // Instantiate the bullet at the point of origin
        Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

        // Stop the particle system (if it's already playing)
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
            // Set the end position of the line to be the point where the raycast hit
            lineRenderer.SetPosition(1, hitResult.point);

            // Instantiate the bullet impact effect at the point of impact
            // NOTE: impact effect contains audio source
            Instantiate(impactEffect, hitResult.point, Quaternion.identity);
        }

        else // If we don't hit anything
        {
            // Draw a 100-unit line (lineRange) in the forward direction
            lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
        }

        // Play the BANG sound
        audioSource.Play();
    }

    void PlaceMine()
    {
        // Player the deploy landmine sound
        audioSource.Play();

        // Instantiate the bomb prefab at the location of 'placeBombHere' (empty)
        Instantiate(mine, mineOrigin.position, mineOrigin.rotation);

        gameObject.GetComponent<Inventory>().useMine();
    }

    public void PlayerHasMinesTrue()
    {
        playerHasMines = true;
    }

    public void PlayerHasMinesFalse()
    {
        playerHasMines = false;
    }

    void DisableEffects()
    {
        // Turn off the light
        bulletOrigin.GetComponent<Light>().enabled = false;

        // Turn off the line renderer
        lineRenderer.enabled = false;
    }
}
