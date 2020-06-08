using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WilsonCharlotte
{
    public class TurretFire : MonoBehaviour
    {
        [Header("TURRET SETTINGS")]
        public float timeBetweenBullets = 0.5f;
        public float effectsDisplayTime = 0.06f;
        public float lineRange = 100f;

        [Header("PUBLIC REFERENCES")]
        public Transform bulletOrigin;      // Where to instantiate bullet
        public GameObject turretBullet;     // Prefab
        public AudioClip gunSound;          // The cannon sound
        public GameObject impactEffect;     // The effect to spawn when the line hits something

        [Header("OTHER VARIABLES")]
        public bool playerIsWithinRange;    // If player is close enough to shoot at

        // PRIVATE VARIABLES
        float timer;
        float effectsTimer;
        AudioSource audioSource;
        LineRenderer lineRenderer;      // Reference to the line renderer
        Ray shootRay = new Ray();       // A ray from the projectile origin forwards (Z)
        RaycastHit hitResult;           // A raycast hit that returns information about what it hit
        int shootableMask;              // Layer No. so that the line only hits shootable things
        int playerMask;                 // Layer No. so that the line also hits the player

        private void Awake()
        {
            // Give audioSource a value
            audioSource = bulletOrigin.GetComponent<AudioSource>();

            //Give lineRenderer a value 
            lineRenderer = bulletOrigin.GetComponent<LineRenderer>();

            // Give shootableMask a value (returns the number of our 'Shootable' layer)
            shootableMask = LayerMask.GetMask("Shootable");

            // Give playerMask a value (returns the number of our 'Player' layer)
            playerMask = LayerMask.GetMask("Player");
        }


        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;            // counts up 
            effectsTimer -= Time.deltaTime;     // counts down

            // If the player is within range
            if (playerIsWithinRange == true && timer >= timeBetweenBullets)
            {
                // Set 'gunSound' as the current audio clip
                audioSource.clip = gunSound;

                // .. call the 'fire' method (below)
                FireBullet();

                // reset the bullet timer
                timer = 0;

                // start the effects timer
                effectsTimer = effectsDisplayTime;
            }

            // Effects timer
            if (effectsTimer <= 0)
            {
                // Disable light
                DisableEffects();
            }

            //if the player is dead, consider it to be 'out of range'
            if (GameObject.FindWithTag("Player").GetComponent<PlayerDeath>().playerIsDead == true)
            {
                playerIsWithinRange = false;
            }
        }

        public void playerInRangeTrue()
        {
            playerIsWithinRange = true;
        }

        public void playerInRangeFalse()
        {
            playerIsWithinRange = false;
        }

        void FireBullet()
        {
            // Instantiate the bullet at the point of origin
            Instantiate(turretBullet, bulletOrigin.position, bulletOrigin.rotation);

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
            else
            {
                // If the raycast hits the player
                if (Physics.Raycast(shootRay, out hitResult, lineRange, playerMask))
                {
                    // Set the end position of the line to be the point where the raycast hit
                    lineRenderer.SetPosition(1, hitResult.point);

                    // Instantiate the bullet impact effect at the point of impact
                    // NOTE: impact effect contains audio source
                    Instantiate(impactEffect, hitResult.point, Quaternion.identity);
                }
                else // If turret doesn't hit anything
                {
                    // Draw a 100-unit line (lineRange) in the forward direction
                    lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * lineRange);
                }
            }

            // Play the BANG sound
            audioSource.Play();
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
