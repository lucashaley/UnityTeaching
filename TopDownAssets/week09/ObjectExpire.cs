using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExpire : MonoBehaviour
{

    public float secondsBeforeRemoval = 5;

    void Start()
    {
        // Removes this object from the game 
        Destroy(gameObject, secondsBeforeRemoval);
    }
}
