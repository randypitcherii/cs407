using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Controls
{
    //constants
    private const KeyCode DEFAULT_LEFT = KeyCode.A;             //the default left key
    private const KeyCode DEFAULT_RIGHT = KeyCode.D;            //the default right key
    private const KeyCode DEFAULT_JUMP = KeyCode.W;             //the default jump key
    private const KeyCode DEFAULT_MELEE = KeyCode.Q;            //the default melee attack key
    private const KeyCode DEFAULT_RANGED = KeyCode.E;           //the default ranged attack key
    private const KeyCode DEFAULT_BLOCK = KeyCode.LeftShift;    //the default block key
    private const string FILE_NAME = "controls";                //the controls file path
    private const string DIRECTORY = "Settings";                //the directory
    private const int LEFT_INDEX = 0;                           //the index of the left key
    private const int RIGHT_INDEX = 1;                          //the index of the right key
    private const int JUMP_INDEX = 2;                           //the index of the jump key
    private const int MELEE_INDEX = 3;                          //the index of the melee attack key
    private const int RANGED_INDEX = 4;                         //the index of the ranged attack key
    private const int BLOCK_INDEX = 5;                          //the index of the block key
    private const int NUM_CONTROLS = 6;                         //the number of controls

    //private fields
    private static KeyCode left = DEFAULT_LEFT;     //the left key
    private static KeyCode right = DEFAULT_RIGHT;   //the right key
    private static KeyCode jump = DEFAULT_JUMP;     //the jump key
    private static KeyCode melee = DEFAULT_MELEE;   //the melee attack key
    private static KeyCode ranged = DEFAULT_RANGED; //the ranged attack key
    private static KeyCode block = DEFAULT_BLOCK;   //the block key
    private static bool isLoaded = false;           //whether or not the controls have been loaded in

    /**
     * Loads in the control configuration.
     */
    private static void load()
    {
        //check if the configuration file exists
        if (File.Exists(DIRECTORY + "/" + FILE_NAME))   //the configuration file exists
        {
            string[] contents = File.ReadAllLines(DIRECTORY + "/" + FILE_NAME);    //the contents of the configuration file

            //set the left key
            left = (KeyCode)KeyCode.Parse(left.GetType(), contents[LEFT_INDEX]);

            //set the right key
            right = (KeyCode)KeyCode.Parse(right.GetType(), contents[RIGHT_INDEX]);

            //set the jump key
            jump = (KeyCode)KeyCode.Parse(jump.GetType(), contents[JUMP_INDEX]);

            //set the melee attack key
            melee = (KeyCode)KeyCode.Parse(melee.GetType(), contents[MELEE_INDEX]);

            //set the ranged attack key
            ranged = (KeyCode)KeyCode.Parse(ranged.GetType(), contents[RANGED_INDEX]);

            //set the block key
            block = (KeyCode)KeyCode.Parse(block.GetType(), contents[BLOCK_INDEX]);
        }
        else    //the configuration file does not exist
        {
            //set the left key
            left = DEFAULT_LEFT;

            //set the right key
            right = DEFAULT_RIGHT;

            //set the jump key
            jump = DEFAULT_JUMP;

            //set the melee attack key
            melee = DEFAULT_MELEE;

            //set the ranged attack key
            ranged = DEFAULT_RANGED;

            //set the block key
            block = DEFAULT_BLOCK;

            //save the control configuration
            save();
        }   //end if

        //set the loaded flag
        isLoaded = true;
    }   //end of load method

    /**
     * Saves the control configuration to a file.
     */
    private static void save()
    {
        //check if the Settings directory exists
        if (!Directory.Exists(DIRECTORY))    //the directory does not exist
        {
            //create the directory
            Directory.CreateDirectory(DIRECTORY);
        }   //end if

        StreamWriter writer = new StreamWriter(File.OpenWrite(DIRECTORY + "/" + FILE_NAME));    //the writer
        string[] controls = new string[NUM_CONTROLS];                                           //the list of controls

        //add the controls to the string
        controls[LEFT_INDEX] = left.ToString();
        controls[RIGHT_INDEX] = right.ToString();
        controls[JUMP_INDEX] = jump.ToString();
        controls[MELEE_INDEX] = melee.ToString();
        controls[RANGED_INDEX] = ranged.ToString();
        controls[BLOCK_INDEX] = block.ToString();

        //write to the configuration file
        for (int controlIndex = 0; controlIndex < controls.Length; controlIndex += 1)
        {
            //write a control to the file
            writer.WriteLine(controls[controlIndex]);
        }   //end for

        //close the writer
        writer.Close();
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
