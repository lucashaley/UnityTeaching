## Week 08: Complete Code

## PlayerBullet.cs
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class PlayerBullet : MonoBehaviour
	{
		[Header(“BULLET SETTINGS”)]
		public float speed = 10;
		public float bulletLifetime = 1f;

		void Start()
		{
			//	Gives the bullet forward force when instantiated
			gameObject.GetComponent<Rigidbody>().AddRelativeForce (Vector3.forward * speed, ForceMode.Impulse);

			// Destroy the bullet after an amount of time
			Destroy (gameObject, bulletLifetime);
		}

		void OnCollisionEnter(Collision other)
		{
			// Destroy the bullet
			Destroy(gameObject);
		}
	}
}
```

## FireProjectile.cs
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
	public class FireProjectile : MonoBehaviour
	{
		[Header(“PUBLIC REFERENCES”)]
		public Transform bulletOrigin;
		public GameObject bullet;
		public float timeBetweenBullets = 0.15f;

		// PRIVATE VARIABLES:
		float timer;

		// Update is called once per frame
		void Update()
		{
			// Tie ‘timer’ to the game clock
			timer += Time.deltaTime;

			//	If Fire1 input is received ..
			if (Input.GetButton(“Fire1”) && timer >= timeBetweenBullets)
			{
				// Call the ‘fire’ method
				FireBullet();

				// reset timer for next bullet
				timer = 0;
			}
		}

		void FireBullet()
		{
			// Testing that the fire method is being called
			// Debug.Log(“Firing bullet”);

			// Instantiate the bullet at the point of origin
			Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);

			// Stop the particle system (if it’s already playing)
			bulletOrigin.GetComponent<ParticleSystem>().Stop();

			// Play the particle system
			bulletOrigin.GetComponent<ParticleSystem>().Play();
		}
	}
}
```
