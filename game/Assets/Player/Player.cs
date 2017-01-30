using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //fields
    private GameObject gameObj = null;          //the player's game object
    private PlayerMovement movement = null;     //the player's movement controls
    private PlayerHitPoints hitPoints = null;   //the player's hit points
    private PlayerManaPoints manaPoints = null; //the player's mana points

    /**
     * Initializes the player.
     *
     * @parama obj  The player's game object.
     */
    public Player(GameObject obj)
    {
        //check if the game object is valid
        if (obj == null)    //the game object is invalid
        {
            Debug.LogError("obj=null");
            return;
        }   //end if

        //check if the movement is valid
        if (obj.GetComponent<PlayerMovement>() == null) //the movement is invalid
        {
            Debug.LogError("PlayerMovement=null");
            return;
        }   //end if

        //initialize the player
        this.gameObj = obj;
        this.movement = obj.GetComponent<PlayerMovement>();
        this.hitPoints = new PlayerHitPoints();
        this.manaPoints = new PlayerManaPoints();
    }   //end of Start method

    /**
     * Returns a reference to the player's game object.
     *
     * @return  Returns a reference to the player's game object.
     */
    public GameObject getGameObject()
    {
        return this.gameObj;
    }   //end of getGameObject method

    /**
     * Returns a reference to the player's movement controls.
     *
     * @return  Returns a reference to the player's movement controls.
     */
    public PlayerMovement getMovementObject()
    {
        return this.movement;
    }   //end of getMovementObject method

    /**
     * Returns a reference to the player's hit points.
     *
     * @return  Returns a reference to the player's hit ponts.
     */
    public PlayerHitPoints getHitPointsObject()
    {
        return this.hitPoints;
    }   //end of getHitPointsObject method

    /**
     * Returns a reference to the player's mana points.
     *
     * @return  Returns a reference to the player's mana ponts.
     */
    public PlayerManaPoints getManaPointsObject()
    {
        return this.manaPoints;
    }   //end of getManaPointsObject method
}   //end of Player class