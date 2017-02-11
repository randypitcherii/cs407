using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Use this abstract class to modularize the different attacks.
 */
public abstract class Attack
{
    //fields
    protected Player player = null; //the player performing the attack
    protected int manaCost = 0;     //the mana point cost of the attack

    /**
     * Initializes the attack.
     *
     * @param p The player performing the attack.
     */
    public Attack(Player p)
    {
        //intialize the attack
        this.player = p;
    }   //end of Attack constructor

    /**
     * Performs the attack.
     */
    public void use()
    {
        attack();
        reduceManaPoints();
    }   //end of use method

    /**
     * The actual code for the attack.
     */
    protected abstract void attack();

    /**
     * Reduces the mana points of the player after using an attack.
     */
    private void reduceManaPoints()
    {
        PlayerManaPoints manaPoints = this.player.getManaPointsObject();
        manaPoints.setManaPoints(manaPoints.getManaPoints() - this.manaCost);
    }   //end of reduceManaPoints method
}   //end of Attack interface
