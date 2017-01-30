using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : Attack
{
    //constants
    private const int MANA_COST = 0;    //the mana point cost of the melee attack

    /**
     * Initialize the melee attack.
     *
     * @param p     The player performing the melee attack.
     */
    public AttackMelee(Player p) : base(p)
    {
        this.manaCost = MANA_COST;
    }   //end of AttackMelee constructor

    /**
     * The actual code for the melee attack.
     */
    protected override void attack()
    {
    }   //end of attack method
}   //end of AttackMelee class
