using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controls
{
    //constants
    private static KeyCode DEFAULT_LEFT = KeyCode.A;            //the default left key
    private static KeyCode DEFAULT_RIGHT = KeyCode.D;           //the default right key
    private static KeyCode DEFAULT_JUMP = KeyCode.W;            //the default jump key
    private static KeyCode DEFAULT_MELEE = KeyCode.Q;           //the default melee attack key
    private static KeyCode DEFAULT_RANGED = KeyCode.E;          //the default ranged attack key
    private static KeyCode DEFAULT_BLOCK = KeyCode.LeftShift;   //the default block key
    private static string FILE_NAME = "controls";               //the controls file name

    //private fields
    private static KeyCode left;            //the left key
    private static KeyCode right;           //the right key
    private static KeyCode jump;            //the jump key
    private static KeyCode melee;           //the melee attack key
    private static KeyCode ranged;          //the ranged attack key
    private static KeyCode block;           //the block key
    private static bool isLoaded = false;   //whether or not the controls have been loaded in

    /**
     * Loads in the control configuration.
     */
    private static void load()
    {
        //TODO:  Load in the configuration

        //set the loaded flag
        isLoaded = true;
    }   //end of load method

    /**
     * Saves the control configuration to a file.
     */
    private static void save()
    {
        //TODO:  Save the configuration
    }   //end of save method

    /**
     * Returns the left key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getLeftKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return left;
    }   //end of getLeftKey method

    /**
     * Returns the right key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getRightKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return right;
    }   //end of getRightKey method

    /**
     * Returns the jump key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getJumpKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return jump;
    }   //end of getJumpKey method

    /**
     * Returns the melee attack key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getMeleeKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return melee;
    }   //end of getMeleeKey method

    /**
     * Returns the ranged attack key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getRangedKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return ranged;
    }   //end of getRangedKey method

    /**
     * Returns the block key.
     * Loads in the control configuration if necessary.
     */
    public static KeyCode getBlockKey()
    {
        //check if the controls have been loaded in
        if (!isLoaded)  //the controls have not been loaded in
        {
            //load in the controls
            load();
        }   //end if

        //return the key
        return block;
    }   //end of getBlockKey method

    /**
     * Sets the left key to the given key.
     *
     * @param key   The given key.
     */
    public static void setLeftKey(KeyCode key)
    {
        //set the key
        left = key;

        //save the change
        save();
    }   //end of setLeftKey method

    /**
     * Sets the right key to the given key.
     *
     * @param key   The given key.
     */
    public static void setRightKey(KeyCode key)
    {
        //set the key
        right = key;

        //save the change
        save();
    }   //end of setRightKey method

    /**
     * Sets the jump key to the given key.
     *
     * @param key   The given key.
     */
    public static void setJumpKey(KeyCode key)
    {
        //set the key
        jump = key;

        //save the change
        save();
    }   //end of setJumpKey method

    /**
     * Sets the melee attack key to the given key.
     *
     * @param key   The given key.
     */
    public static void setMeleeKey(KeyCode key)
    {
        //set the key
        melee = key;

        //save the change
        save();
    }   //end of setMeleeKey method

    /**
     * Sets the ranged attack key to the given key.
     *
     * @param key   The given key.
     */
    public static void setRangedKey(KeyCode key)
    {
        //set the key
        ranged = key;

        //save the change
        save();
    }   //end of setRangedKey method

    /**
     * Sets the block key to the given key.
     *
     * @param key   The given key.
     */
    public static void setBlockKey(KeyCode key)
    {
        //set the key
        block = key;

        //save the change
        save();
    }   //end of setBlockKey method
}   //end of Controls class
