using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Use this abstract to modularize Human and AI movement.
 */
public abstract class PlayerMovement : MonoBehaviour
{
    public float speed; //the player's speed

    /**
     * Returns the player's current speed.
     */
    public float getSpeed()
    {
        return this.speed;
    }   //end of getSpeed method

    /**
     * Handles the player's movement.
     */
    public abstract void LateUpdate();
}   //end of PlayerMovement abstract
