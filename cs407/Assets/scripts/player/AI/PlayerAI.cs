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

        System.Random r = new System.Random();

        //create random actions
        int[] actions = {
            r.Next(0,2), //left key pressed             0
            r.Next(0,2), //right key pressed            1
            r.Next(0,2), //jump key pressed             2
            r.Next(0,2), //melee attack key pressed     3
            r.Next(0,2), //ranged attack key pressed    4
            r.Next(0,2)  //block key pressed            5
        };

        Debug.Log("\n\n");
        Debug.Log(actions[0]);

        //check if a key was pressed
        if (actions[0] == 1)   //a left key was pressed
        {
            moveLeft();
        }
        else if (actions[1] == 1) //a right key was pressed
        {
            moveRight();
        }
        else    //no key was pressed
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
        if (actions[5] == 0)
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
}   //end of PlayerAI class
