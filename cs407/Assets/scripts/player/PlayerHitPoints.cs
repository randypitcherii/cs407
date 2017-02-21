using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitPoints : MonoBehaviour
{
    public GameObject temp_player;
    //constants
    private const int MAX_HIT_POINTS = 100;     //the maximum number of hit points
    public Slider healthSlider;
    //fields
    private int currentHitPoints = 0;           //the current number of hit points

    /**
     * Initializes the player's hit points.
     */
    public PlayerHitPoints()
    {
        //temp_player.SetActive(true);
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
        if (newHitPoints <= 0)   //the new hit points are invalid
        {
            //set hit points to zero
            this.currentHitPoints = 0;

            //end the game
            GameOver.endGame();
        }
        else if (newHitPoints > MAX_HIT_POINTS) //the new hit points are invalid
        {
            //set the hit points to the valid maximum
            this.currentHitPoints = MAX_HIT_POINTS;
        }
        else    //the new hit points are valid
        {
            //set hit points
            this.currentHitPoints = newHitPoints;
            healthSlider.value = this.currentHitPoints;
        }   //end if
    }   //end of setHitPoints method
}   //end of PlayerHitPoints class
