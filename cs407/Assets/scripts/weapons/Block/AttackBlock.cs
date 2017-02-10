using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBlock : Attack
{
    //constants
    private const int MANA_COST = 10;   //the mana point cost of the block attack

    /**
     * Initialize the block attack.
     *
     * @param p     The player performing the block attack.
     */
    public AttackBlock(Player p) : base(p)
    {
        this.manaCost = MANA_COST;
    }   //end of AttackBlock constructor

    /**
     * The actual code for the block attack.
     */
    protected override void attack()
    {
    }   //end of attack method
}   //end of AttackBlock class
