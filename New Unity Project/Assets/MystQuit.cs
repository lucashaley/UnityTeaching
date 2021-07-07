// Version 0.3

/*

This script quits the game.
Add this script to a gameObject, or use the prefab supplied.

*/

﻿
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myst
{
    public class MystQuit : MonoBehaviour
    {
        [Header("Exit Game Key Bind")]
        // type the name of the key you want to have quit the game
        public string QuitKeyBind = "q";

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(QuitKeyBind))
            {
                //this will close the game
                Debug.Log("Quitting…");
                Application.Quit();
            }
        }

        // make sure you have gizmos turned on in the inspector to see the red sphere
        // you will find it at the top right of the view port
        void OnDrawGizmos()
        {
            // Draw a red sphere at the transform's position
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5);
        }
    }
}
