using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoCam : MonoBehaviour
{
    [Header("CAMERA SETTINGS")]
    public float dampening = 5f;
    public float YDistance = 10;
    public float ZDistance = -16;

    [Header("PUBLIC REFERENCES")]
    public Transform playerPosition;
    // public Transform spawnPoint01;

    [Header("DEBUG")]
    public bool gameIsActive = false;
    float timeBeforeGameBegins = 6.0f;

    // PRIVATE VARIABLES
    Vector3 cameraOffset;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial offset
        // initialOffset = playerPosition.position + new Vector3(0,10,-16.6f);

        cameraOffset = new Vector3(0, YDistance, ZDistance);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;            // counts up

        if (timer >= timeBeforeGameBegins)
        {
            gameIsActive = true;
        }
    }
    
    // This is called once per physics frame
    void FixedUpdate()
    {
        if (gameIsActive == true)
        {
            // Create a position for the camera to aim at, based on the offset from the target.
            Vector3 targetCamPos = playerPosition.position + cameraOffset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, dampening * Time.deltaTime);
        }
    }

    public void beginGame()
    {
        gameIsActive = true;
    }
}
