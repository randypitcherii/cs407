using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    //constants
    private const double ACTION_THRESHOLD = 0.5;    //the threshold to determine whether or not an action should be performed

    //private fields
    private AILogger log = null;                    //logs the AI's actions

    /**
     * Handles the player's movement.
     */
    public override void LateUpdate()
    {
        /*
        ISignalArray actions = new AIFighter(BRAIN).GetMoves(Location_Script.buildArray()); //the actions the AI should perform
        //perfrom the actions that pass the specified threshold
        for (int actionIndex = 0; actionIndex < actions.Length; actionIndex += 1)
        {
            //check if the actiono should be performed
            if (actions[actionIndex] >= ACTION_THRESHOLD)   //the action should be performed
            {
                //perform the action
                performAction(actionIndex);
            }   //end if
        }   //end for
        */
    }   //end of LateUpdate method

    /**
     * Performs the given action.
     *
     * @action  The action to perform.
     */
    public void performAction(int action)
    {
        /*
        //check what the AI should do
        switch (action)
        {
            case DO_NOTHING:    //the AI should do nothing
                break;
            case MOVE_LEFT: //the AI should move left
                moveLeft();
                break;
            case MOVE_RIGHT:    //the AI should move right
                moveRight();
                break;
            case JUMP:  //the AI should jump
                jump();
                break;
            case MELEE_ATTACK:  //the AI should perform a melee attack
                useMeleeAttack();
                break;
            case RANGED_ATTACK: //the AI should perform a ranged attack
                useRangedAttack();
                break;
            case BLOCK_ATTACK:  //the AI should perform a block attack
                useBlockAttack();
                break;
            default:    //error
                Debug.LogError("action=" + action);
        }   //end switch
        //check if a log was created
        if (this.log == null)   //a log was not created
        {
            this.log = new AILogger();
        }   //end if
        //write the action to the log
        this.log.write(action);
        */
    }   //end of performAction method

    /**
     * Closes the AI's logger.
     */
    public void closeLog()
    {
        //check if a log was created
        if (this.log == null)   //a log was not created
        {
            return;
        }   //end if

        //close the log
        this.log.close();
        this.log = null;
    }   //end of closeLog method
}   //end of PlayerAI class