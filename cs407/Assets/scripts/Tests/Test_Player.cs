using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    /**
     * Runs the test cases.
     */
    void Start()
    {
        test1();
        test2();
        test3();
        test4();
        test5();
        test6();
        test7();
	}   //end of Start method

    /**
     * Test if the game object is set properly.
     */
    private void test1()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object

        //check if the game object is the same as the original
        if (player.getGameObject() != obj)  //the game object is not the same as the original
        {
            Debug.Log("Test_Player:  test1 failed");
        }   //end if
    }   //end of test1 method

    /**
     * Test if the player movement object is set properly.
     */
    private void test2()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object

        //check if the player movement object is the same as the original
        if (player.getMovementObject() != obj.GetComponent<PlayerMovementHuman>())  //the player movement object is not the same as the original
        {
            Debug.Log("Test_Player:  test2 failed");
        }   //end if
    }   //end of test2 method

    /**
     * Test if the player hit points object was added properly.
     */
    private void test3()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object

        //check if the player hit points object was set
        if (player.getHitPointsObject() == null)    //the player hit points object was not set
        {
            Debug.Log("Test_Player:  test3 failed");
        }   //end if
    }   //end of test3 method

    /**
     * Test if the player mana points object was added properly.
     */
    private void test4()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object

        //check if the player hit points object was set
        if (player.getManaPointsObject() == null)   //the player mana points object was not set
        {
            Debug.Log("Test_Player:  test4 failed");
        }   //end if
    }   //end of test4 method

    /**
     * Test if the melee attack was added properly.
     */
    private void test5()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object
        int expectedManaPoints = 100;               //the expected amount of mana points

        //perform the melee attack
        player.attack<AttackMelee>();

        //check if the mana points were changed properly indicating that the attack was added properly
        if (player.getManaPointsObject().getManaPoints() != expectedManaPoints) //the mana points were not changed properly
        {
            Debug.Log("Test_Player:  test5 failed");
        }   //end if
    }   //end of test5 method

    /**
     * Test if the ranged attack was added properly.
     */
    private void test6()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object
        int expectedManaPoints = 95;                //the expected amount of mana points

        //perform the melee attack
        player.attack<AttackRanged>();

        //check if the mana points were changed properly indicating that the attack was added properly
        if (player.getManaPointsObject().getManaPoints() != expectedManaPoints) //the mana points were not changed properly
        {
            Debug.Log("Test_Player:  test6 failed");
        }   //end if
    }   //end of test6 method

    /**
     * Test if the block attack was added properly.
     */
    private void test7()
    {
        GameObject obj = new GameObject();          //a game object
        obj.AddComponent<PlayerMovementHuman>();    //a player movement object
        Player player = new Player(obj);            //the player object
        int expectedManaPoints = 90;                //the expected amount of mana points

        //perform the melee attack
        player.attack<AttackBlock>();

        //check if the mana points were changed properly indicating that the attack was added properly
        if (player.getManaPointsObject().getManaPoints() != expectedManaPoints) //the mana points were not changed properly
        {
            Debug.Log("Test_Player:  test7 failed");
        }   //end if
    }   //end of test7 method
}   //end of Test_Player class
