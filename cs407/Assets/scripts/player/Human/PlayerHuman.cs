using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHuman : Player
{
    //override parent color
    private Color hiddenNormalColor = new Color(1, 1, 1, 1);    //hidden normal color of playerHuman
    protected override Color normalColor                        //normal color of playerHuman
    {
        get
        {
            return this.hiddenNormalColor;
        }

        set
        {
            ;
        }
    }

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
        if (!blockKeyPressed())
        {
            endBlockAttack();
        }
        
    }   //end of LateUpdate method

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
