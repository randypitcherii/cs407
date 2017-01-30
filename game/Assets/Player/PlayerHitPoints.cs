﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints
{
    //constants
    private const int MAX_HIT_POINTS = 100;     //the maximum number of hit points

    //fields
    private int currentHitPoints = 0;           //the current number of hit points

    /**
     * Initializes the player's hit points.
     */
    public PlayerHitPoints()
    {
        //check for valid maximum hit points
        if (MAX_HIT_POINTS <= 0)    //the maximum hit points are invalid
        {
            Debug.LogError("MAX_HIT_POINTS=" + MAX_HIT_POINTS);
            return;
        }   //end if

        //initialize the player's hit points
        this.currentHitPoints = MAX_HIT_POINTS;
    }   //end of PlayerHitPoints constructor

    /**
     * Returns the player's current hit points.
     *
     * @return  Returns the player's current hit points.
     */
    public int getHitPoints()
    {
        return this.currentHitPoints;
    }   //end of getHitPoints method

    /**
     * Sets the player's current hit points to the given new hit points.
     *
     * @param newHitPoints  The new hit points.
     */
    public void setHitPoints(int newHitPoints)
    {
        //check for valid new hit points
        if (newHitPoints < 0 || newHitPoints > MAX_HIT_POINTS)  //the new hit points are invalid
        {
            Debug.LogError("newHitPoints=" + newHitPoints);
            return;
        }   //end if

        //set hit points
        this.currentHitPoints = newHitPoints;
    }   //end of setHitPoints method
}   //end of PlayerHitPoints class