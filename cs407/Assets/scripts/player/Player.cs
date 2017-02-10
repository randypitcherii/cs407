using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //fields
    private GameObject gameObj = null;                  //the player's game object
    private PlayerMovement movement = null;             //the player's movement controls
    private PlayerHitPoints hitPoints = null;           //the player's hit points
    private PlayerManaPoints manaPoints = null;         //the player's mana points
    private List<Attack> attacks = new List<Attack>();  //the player's attacks

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
        addAttacks();
    }   //end of Player constructor

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

    /**
     * Adds attacks to the player.
     */
    private void addAttacks()
    {
        attacks.Add(new AttackMelee(this));
        attacks.Add(new AttackRanged(this));
        attacks.Add(new AttackBlock(this));
    }   //end of addAttacks method

    /**
     * Performs the given attack.
     *
     * @generic type    The attack type.
     */
    public void attack<type>()
    {
        //loop through all of the attacks to find the correct attack
        foreach (var attack in this.attacks)
        {
            //check if the attack was found
            if (typeof(type) == attack.GetType())   //the attack was found
            {
                //perform the attack
                attack.use();

                return;
            }   //end if
        }   //end for

        //the attack was not found
        Debug.LogError("Invalid type");
    }   //end of attack method
}   //end of Player class