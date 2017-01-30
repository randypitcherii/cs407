using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaPoints
{
    //constants
    private const int MAX_MANA_POINTS = 100;    //the maximum number of mana points

    //fields
    private int currentManaPoints = 0;          //the current number of mana points

    /**
     * Initializes the player's mana points.
     */
    public PlayerManaPoints()
    {
        //check for valid maximum mana points
        if (MAX_MANA_POINTS <= 0)   //the maximum mana points are invalid
        {
            Debug.LogError("MAX_MANA_POINTS=" + MAX_MANA_POINTS);
            return;
        }   //end if

        //initialize the player's mana points
        this.currentManaPoints = MAX_MANA_POINTS;
    }   //end of PlayerManaPoints constructor

    /**
     * Returns the player's current mana points.
     *
     * @return  Returns the player's current mana points.
     */
    public int getManaPoints()
    {
        return this.currentManaPoints;
    }   //end of getManaPoints method

    /**
     * Sets the player's current mana points to the given new mana points.
     *
     * @param newHitPoints  The new mana points.
     */
    public void setManaPoints(int newManaPoints)
    {
        //check for valid new mana points
        if (newManaPoints < 0 || newManaPoints > MAX_MANA_POINTS)  //the new mana points are invalid
        {
            Debug.LogError("newManaPoints=" + newManaPoints);
            return;
        }   //end if

        //set mana points
        this.currentManaPoints = newManaPoints;
    }   //end of setHitPoints method
}   //end of PlayerManaPoints class
