using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerHitPoints : MonoBehaviour
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
     * Test if the hit points are initialized to the correct value.
     */
    private void test1()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 100;                        //the expected amount of hit points

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test1 failed");
        }   //end if
    }   //end of test1 method

    /**
     * Test if the hit points can be changed to a valid value.
     */
    private void test2()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 80;                         //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(expectedHitPoints);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test2 failed");
        }   //end if
    }   //end of test2 method

    /**
     * Test if the hit points properly handle negative numbers.
     */
    private void test3()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 0;                          //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(-1);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test3 failed");
        }   //end if
    }   //end of test3 method

    /**
     * Test if the hit points properly handle being set to zero.
     */
    private void test4()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 0;                          //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(expectedHitPoints);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test4 failed");
        }   //end if
    }   //end of test4 method

    /**
     * Test if the hit points properly handle being set to one.
     */
    private void test5()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 1;                          //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(expectedHitPoints);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test5 failed");
        }   //end if
    }   //end of test5 method

    /**
     * Test if the hit points properly handle being set to MAX - 1.
     */
    private void test6()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 99;                         //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(expectedHitPoints);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test6 failed");
        }   //end if
    }   //end of test6 method

    /**
     * Test if the hit points properly handle being set to MAX.
     */
    private void test7()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 100;                        //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(expectedHitPoints);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test7 failed");
        }   //end if
    }   //end of test7 method

    /**
     * Test if the hit points properly handle being set to MAX + 1.
     */
    private void test8()
    {
        PlayerHitPoints hitPoints = new PlayerHitPoints();  //the player's hit points
        int expectedHitPoints = 100;                        //the expected amount of hit points

        //set the hit points
        hitPoints.setHitPoints(101);

        //check if the hit points were as expected
        if (hitPoints.getHitPoints() != expectedHitPoints)  //the hit points were not as expected
        {
            Debug.Log("Test_PlayerHitPoints:  test8 failed");
        }   //end if
    }   //end of test8 method
}   //end of Test_PlayerHitPoints class
