using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRanged : Attack
{
    //constants
    private const int MANA_COST = 5;    //the mana point cost of the ranged attack

    /**
     * Initialize the ranged attack.
     *
     * @param p     The player performing the ranged attack.
     */
    public AttackRanged(Player p) : base(p)
    {
        this.manaCost = MANA_COST;
    }   //end of AttackRanged constructor

    /**
     * The actual code for the ranged attack.
     */
    protected override void attack()
    {
    }   //end of attack method
}   //end of AttackRanged class
