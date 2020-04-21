using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // public variables
    public float thrust = 300f;
    public bool cats = true;

    // private variables
    Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // This is called once per physics frame
    void FixedUpdate()
    {
        // This declares a private variable of type 'float' names it 'vertical' and gets the vertical input axis values
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Adds force, based on axis input and multiplies it by 'thrust'
        rbody.AddForce(new Vector3(horizontal, 0, vertical) * thrust);

        // Make the player face the mouse pointer
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;

        // If the raycast hits Layer 8 (MouseTracker)..
        if (Physics.Raycast (mouseRay, out mouseHit, Mathf.Infinity, 1 << 8))
        {
            // Make the player look at the mouse's x and z but keep the player's own Y position
            transform.LookAt(new Vector3(mouseHit.point.x, transform.position.y, mouseHit.point.z));
        }
    }
}
