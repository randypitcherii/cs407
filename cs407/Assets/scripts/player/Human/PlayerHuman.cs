using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    //fields
    private List<KeyCode> leftKeys = new List<KeyCode>() {KeyCode.LeftArrow, KeyCode.A};    //the list of left keys
    private List<KeyCode> rightKeys = new List<KeyCode>() {KeyCode.RightArrow, KeyCode.D};  //the list of right keys
    private List<KeyCode> jumpKeys = new List<KeyCode>() {KeyCode.UpArrow, KeyCode.W};      //the list of jump keys
    private List<KeyCode> meleeKeys = new List<KeyCode>() {KeyCode.Q};                               //the list of melee attack keys
    private List<KeyCode> rangedKeys = new List<KeyCode>() {KeyCode.E};                 //the list of ranged attack keys
    private List<KeyCode> blockKeys = new List<KeyCode>() {KeyCode.LeftShift,KeyCode.RightShift};                               //the list of block attack keys

    /**
     * Handles the player's movement.
     */
    public override void LateUpdate()
    {
        //check if a key was pressed
        if (leftKeyPressed())   //a left key was pressed
        {
            moveLeft();
        }
        else if (rightKeyPressed()) //a right key was pressed
        {
            moveRight();
        }
        else    //no key was pressed
        {
            standStill();
        }   //end if
        if (jumpKeyPressed())  //a jump key was pressed
        {
            jump();
        }
        else if (meleeKeyPressed()) //a melee attack key was pressed
        {
            useMeleeAttack();
        }
        else if (rangedKeyPressed())    //a ranged attack key was pressed
        {
            useRangedAttack();
        }
        else if (blockKeyPressed()) //a block attack key was pressed
        {
            useBlockAttack();
        }
        if (meleeKeyUp())
        {
            endMeleeAttack();
        }
        if (blockedKeyUp())
        {
            endBlockAttack();
        }
        
    }   //end of LateUpdate method
    
    /**
     * Returns whether or not a key from the list came up.
     *
     * @param keys  A list of keys.
     * @return      Returns whether or not a key from the list came up.
     */
    private bool keyUp(List<KeyCode> keys)
    {
        //loop through the list of keys to check if any came up
        foreach (KeyCode key in keys)
        {
            //check if a key from the list was pressed
            if (Input.GetKeyUp(key))  //a key from the list came up
            {
                //a key from the list came up
                return true;
            }   //end if
        }   //end for
        
        //no keys from the list came up
        return false;
    }   //end of keyPressed method

    /**
     * Returns whether or not a blocked key was lifted.
     *
     * @return  Returns whether or not a blocked key was lifted.
     */
    private bool blockedKeyUp()
    {
        return keyUp(this.blockKeys);
    }   //end of leftKeyPressed method
    /**
     * Returns whether or not a melee key was lifted.
     *
     * @return  Returns whether or not a melee key was lifted.
     */
    private bool meleeKeyUp()
    {
        return keyUp(this.meleeKeys);
    }   //end of meleeKeyUp method
    /**
     * Returns whether or not a key from the list was .
     *
     * @param keys  A list of keys.
     * @return      Returns whether or not a key from the list was pressed.
     */
    private bool keyPressed(List<KeyCode> keys)
    {
        //loop through the list of keys to check if any were pressed
        foreach (KeyCode key in keys)
        {
            //check if a key from the list was pressed
            if (Input.GetKey(key))  //a key from the list was pressed
            {
                //a key from the list was pressed
                return true;
            }   //end if
        }   //end for

        //no keys from the list were pressed
        return false;
    }   //end of keyPressed method
    /**
     * Returns whether or not a left key was pressed.
     *
     * @return  Returns whether or not a left key was pressed.
     */
    private bool leftKeyPressed()
    {
        return keyPressed(this.leftKeys);
    }   //end of leftKeyPressed method

    /**
     * Returns whether or not a right key was pressed.
     *
     * @return  Returns whether or not a right key was pressed.
     */
    private bool rightKeyPressed()
    {
        return keyPressed(this.rightKeys);
    }   //end of rightKeyPressed method

    /**
     * Returns whether or not a jump key was pressed.
     *
     * @return  Returns whether or not a jump key was pressed.
     */
    private bool jumpKeyPressed()
    {
        return keyPressed(this.jumpKeys);
    }   //end of jumpKeyPressed method

    /**
     * Returns whether or not a melee attack key was pressed.
     *
     * @return  Returns whether or not a melee attack key was pressed.
     */
    private bool meleeKeyPressed()
    {
        return keyPressed(this.meleeKeys);
    }   //end of meleeKeyPressed method

    /**
     * Returns whether or not a ranged attack key was pressed.
     *
     * @return  Returns whether or not a ranged attack key was pressed.
     */
    private bool rangedKeyPressed()
    {
        return keyPressed(this.rangedKeys);
    }   //end of rangedKeyPressed method

    /**
     * Returns whether or not a block attack key was pressed.
     *
     * @return  Returns whether or not a block attack key was pressed.
     */
    private bool blockKeyPressed()
    {
        return keyPressed(this.blockKeys);
    }   //end of blockKeyPressed method
}   //end of PlayerHuman class
