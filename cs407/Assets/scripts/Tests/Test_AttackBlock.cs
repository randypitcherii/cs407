using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_AttackBlock : MonoBehaviour
{
	/**
     * Runs the test cases.
     */
	void Start()
    {
        test1();
	}   //end of Start method

    /**
     * Test if a block attack reduces the player's mana points.
     */
    private void test1()
    {
        GameObject obj = new GameObject();              //a game object
        obj.AddComponent<PlayerMovementHuman>();        //a player movement object
        Player player = new Player(obj);                //a player object
        AttackBlock attack = new AttackBlock(player);   //the block attack
        int expectedManaPoints = 90;                    //the expected amount of mana points

        //perform the attack
        attack.use();

        //check if the mana points are reduced as expected
        if (player.getManaPointsObject().getManaPoints() != expectedManaPoints) //the mana points are not reduced as expected
        {
            Debug.Log("Test_AttackBlock:  test1 failed");
        }   //end if
    }   //end of test1 method
}   //end of Test_AttackBlock class
