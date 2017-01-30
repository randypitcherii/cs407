using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //constants
    private const int MAX_HIT_POINTS = 100;     //the maximum number of hit points
    private const int MAX_MANA_POINTS = 100;    //the maximum number of mana points

    //fields
    private int currentHitPoints = 0;           //the current number of hit points
    private int currentManaPoints = 0;          //the current number of mana points

    /**
     * Initializes the player object.
     */
    public void Start()
    {
        //check for valid maximum hit points
        if (MAX_HIT_POINTS <= 0)    //the maximum hit points are invalid
        {
            Debug.LogError("MAX_HIT_POINTS=" + MAX_HIT_POINTS);
            return;
        }   //end if

        //check for valid maximum mana points
        if (MAX_MANA_POINTS <= 0)   //the maximum mana points are invalid
        {
            Debug.LogError("MAX_MANA_POINTS=" + MAX_MANA_POINTS);
            return;
        }   //end if

        //initialize the player object
        this.currentHitPoints = MAX_HIT_POINTS;
        this.currentManaPoints = MAX_MANA_POINTS;
    }   //end of Start method

    /**
     * Update is called once per frame
     */
    public void Update()
    {

    }   //end of Update method

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
}   //end of Player class