using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityMine : MonoBehaviour
{
    [Header("MINE SETTINGS")]
    public float armingDelay = 1.3f;  // seconds before bomb is armed
    public float mineDamage = 50;
    public bool mineIsArmed = false;

    [Header("PUBLIC REFERENCES")]
    public GameObject mineLight;
    public GameObject explosionEffect;          // Effects prefab
    public Material lightArmedMaterial;
    public Material lightDisarmedMaterial;
    public Material pickUpMaterial;             

    // PRIVATE VARIABLES
    float timer = 0f;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mineLight.GetComponent<Renderer>().material = pickUpMaterial;
    }


    void Update()
    {
        timer += Time.deltaTime;            // counts up 

        // Arm the bomb after a small delay
        if (timer >= armingDelay)
        {
            mineLight.GetComponent<Renderer>().material = lightArmedMaterial;
            mineIsArmed = true;
        }

    }


    public void Explode()
    {
        if (mineIsArmed == true)
        {
            // Testing
            // Debug.Log("BANG!!!");

            // Spawn the explosion effect
            Instantiate(explosionEffect, transform.position, transform.rotation);

            // Destroy the bomb
            Destroy(gameObject);
        }
    }
}


