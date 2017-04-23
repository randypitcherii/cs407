using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    /**
     * Handles the player's movement.
     */
    public override void LateUpdate()
    {
        //check if an ai fighterBrain has been assigned to this human player
        if (fighterBrain != null)
        {
            //this human player has been assigned an AI brain. It will take over
            //control of this player. This is used for AI training.
            makeAIMovement();
            return;
        }

        //to get here, the human player has not been assigned an AI brain. Continue
        //listening for human input.

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
        if (!blockKeyPressed())
        {
            endBlockAttack();
        }
        
    }   //end of LateUpdate method

    /**
     * Handles the player's movement when an AI brain has been assigned.
     */
    public void makeAIMovement()
    {
        //create AI output (actions) and input (game state matrix)
        int[] aiInput = ls.buildArray();
        int[] actions = fighterBrain.GetMoves(aiInput);

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
    }   //end of makeAIMovement method

    /**
     * Returns whether or not a blocked key was lifted.
     *
     * @return  Returns whether or not a blocked key was lifted.
     */
    private bool blockedKeyUp()
    {
        return Input.GetKeyUp(Controls.getBlockKey());
    }   //end of leftKeyPressed method
    /**
     * Returns whether or not a melee key was lifted.
     *
     * @return  Returns whether or not a melee key was lifted.
     */
    private bool meleeKeyUp()
    {
        return Input.GetKeyUp(Controls.getMeleeKey());
    }   //end of meleeKeyUp method

    /**
     * Returns whether or not a left key was pressed.
     *
     * @return  Returns whether or not a left key was pressed.
     */
    private bool leftKeyPressed()
    {
        return Input.GetKey(Controls.getLeftKey());
    }   //end of leftKeyPressed method

    /**
     * Returns whether or not a right key was pressed.
     *
     * @return  Returns whether or not a right key was pressed.
     */
    private bool rightKeyPressed()
    {
        return Input.GetKey(Controls.getRightKey());
    }   //end of rightKeyPressed method

    /**
     * Returns whether or not a jump key was pressed.
     *
     * @return  Returns whether or not a jump key was pressed.
     */
    private bool jumpKeyPressed()
    {
        return Input.GetKey(Controls.getJumpKey());
    }   //end of jumpKeyPressed method

    /**
     * Returns whether or not a melee attack key was pressed.
     *
     * @return  Returns whether or not a melee attack key was pressed.
     */
    private bool meleeKeyPressed()
    {
        return Input.GetKey(Controls.getMeleeKey());
    }   //end of meleeKeyPressed method

    /**
     * Returns whether or not a ranged attack key was pressed.
     *
     * @return  Returns whether or not a ranged attack key was pressed.
     */
    private bool rangedKeyPressed()
    {
        return Input.GetKey(Controls.getRangedKey());
    }   //end of rangedKeyPressed method

    /**
     * Returns whether or not a block attack key was pressed.
     *
     * @return  Returns whether or not a block attack key was pressed.
     */
    private bool blockKeyPressed()
    {
        return Input.GetKey(Controls.getBlockKey());
    }   //end of blockKeyPressed method
}   //end of PlayerHuman class
