using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stage
{
    //enum
    public enum Number {One, Two, Three, Four}; //used to select a stage

    //constants
    private static readonly string[] STAGE_FILE_NAMES = {"hill", "Stage2", "Stage3", "Stage4"};  //the file names of the stages

    //private fields
    private static Number stage = Number.One;    //the selected stage

    /**
     * Sets the stage to the given input.
     *
     * @param selection The given input.
     */
    public static void setStage(Number selection)
    {
        //set the stage
        stage = selection;
    }   //end of setStage method

    /**
     * Returns the stage as a sprite.
     *
     * @return  Returns the stage as a sprite.
     */
    public static UnityEngine.Sprite getStage()
    {
        //return the stage as sprite
        return Resources.Load<UnityEngine.Sprite>("Stages/" + STAGE_FILE_NAMES[(int)stage]);
    }   //end of getStage method
}   //end of Stage class