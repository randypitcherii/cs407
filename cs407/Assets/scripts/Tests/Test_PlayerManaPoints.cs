using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerManaPoints : MonoBehaviour
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
        test8();
    }   //end of Start method

    /**
     * Test if the mana points are initialized to the correct value.
     */
    private void test1()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 100;                        //the expected amount of mana points

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test1 failed");
        }   //end if
    }   //end of test1 method

    /**
     * Test if the mana points can be changed to a valid value.
     */
    private void test2()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 80;                         //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(expectedManaPoints);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test2 failed");
        }   //end if
    }   //end of test2 method

    /**
     * Test if the mana points properly handle negative numbers.
     */
    private void test3()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 0;                          //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(-1);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test3 failed");
        }   //end if
    }   //end of test3 method

    /**
     * Test if the mana points properly handle being set to zero.
     */
    private void test4()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 0;                          //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(expectedManaPoints);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test4 failed");
        }   //end if
    }   //end of test4 method

    /**
     * Test if the mana points properly handle being set to one.
     */
    private void test5()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 1;                          //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(expectedManaPoints);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test5 failed");
        }   //end if
    }   //end of test5 method

    /**
     * Test if the mana points properly handle being set to MAX - 1.
     */
    private void test6()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 99;                         //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(expectedManaPoints);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test6 failed");
        }   //end if
    }   //end of test6 method

    /**
     * Test if the mana points properly handle being set to MAX.
     */
    private void test7()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 100;                        //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(expectedManaPoints);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test7 failed");
        }   //end if
    }   //end of test7 method

    /**
     * Test if the mana points properly handle being set to MAX + 1.
     */
    private void test8()
    {
        PlayerManaPoints manaPoints = new PlayerManaPoints();  //the player's mana points
        int expectedManaPoints = 100;                        //the expected amount of mana points

        //set the mana points
        manaPoints.setManaPoints(101);

        //check if the mana points were as expected
        if (manaPoints.getManaPoints() != expectedManaPoints)  //the mana points were not as expected
        {
            Debug.Log("Test_PlayerManaPoints:  test8 failed");
        }   //end if
    }   //end of test8 method
}   //end of Test_PlayerManaPoints class
