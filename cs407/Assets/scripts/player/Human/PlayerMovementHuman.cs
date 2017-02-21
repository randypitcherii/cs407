using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHuman : PlayerMovement
{
    //fields
    private List<KeyCode> leftKeys;     //the list of left keys
    private List<KeyCode> rightKeys;    //the list of right keys
    private List<KeyCode> jumpKeys;     //the list of jump keys
    private List<KeyCode> meleeKeys;    //the list of melee attack keys
    private List<KeyCode> rangedKeys;   //the list of ranged attack keys
    private List<KeyCode> blockKeys;    //the list of block attack keys

    /**
     * PlayerMovementHuman constructor initializes fields.
     */
    public PlayerMovementHuman()
    {
        //initialize left keys
        this.leftKeys = new List<KeyCode>();
        this.leftKeys.Add(KeyCode.LeftArrow);
        this.leftKeys.Add(KeyCode.A);

        //initialize right keys
        this.rightKeys = new List<KeyCode>();
        this.rightKeys.Add(KeyCode.RightArrow);
        this.rightKeys.Add(KeyCode.D);

        //initialize jump keys
        this.jumpKeys = new List<KeyCode>();
        this.jumpKeys.Add(KeyCode.UpArrow);
        this.jumpKeys.Add(KeyCode.W);

        //initialize melee attack keys
        this.meleeKeys = new List<KeyCode>();

        //initialize ranged attack keys
        this.rangedKeys = new List<KeyCode>();
        this.rangedKeys.Add(KeyCode.Space);

        //initialize block attack keys
        this.blockKeys = new List<KeyCode>();
    }   //end of PlayerMovementHuman constructor

    /**
     * Returns whether or not a key from the list was pressed.
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

    /**
     * Handles player movement.
     */
    public override void LateUpdate()
    {
        //check if a key was pressed
        if (leftKeyPressed())   //a left key was pressed
        {

        }
        else if (rightKeyPressed()) //a right key was pressed
        {

        }
        else if (jumpKeyPressed())  //a jump key was pressed
        {

        }
        else if (meleeKeyPressed()) //a melee attack key was pressed
        {

        }
        else if (rangedKeyPressed())    //a ranged attack key was pressed
        {

        }
        else if (blockKeyPressed()) //a block attack key was pressed
        {

        }
        else    //no key was pressed
        {

        }   //end if
    }   //end of LateUpdate method
}   //end of PlayerMovementHuman class
