using Assets.scripts.player.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private AILogger log = null;    //logs the AI's actions

    /**
     * Handles the player's movement.
     */
    public override void LateUpdate()
    {
        //create AI output (actions) and input (game state matrix)
        int[] actions;
        int[] aiInput = ls.buildArray();

        if (fighterBrain != null)
        {
            //AI brain found. Use it here.
            actions = fighterBrain.GetMoves(aiInput);
        }
        else
        {
            //no AI brain found. Use default model.
            actions = AIBrain.getMoves(ls.buildArray());
        }

        //check if a key was pressed
        if (actions[0] != 0)   //a left key was pressed
        {
            moveLeft();
        }
        else if (actions[1] != 0) //a right key was pressed
        {
            moveRight();
        }
        else if (actions[6] == 1)    //no key was pressed
        {
            standStill();
        }   //end if


        if (actions[2] == 1) //a jump key was pressed
        {
            jump();
        }
        else if (actions[3] == 1) //a melee attack key was pressed
        {
            useMeleeAttack();
        }
        else if (actions[4] == 1)    //a ranged attack key was pressed
        {
            useRangedAttack();
        }
        else if (actions[5] == 1) //a block attack key was pressed
        {
            useBlockAttack();
        }

        if (actions[3] == 0)
        {
            endMeleeAttack();
        }
        if (actions[5] != 1)
        {
            endBlockAttack();
        }
    }   //end of LateUpdate method

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
    public Master_Game_Object createScene()
    {
        return null;
    }
}   //end of PlayerAI class