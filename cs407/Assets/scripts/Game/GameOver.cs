using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver
{
    /**
     * Static method used to end the game.
     */
    public static void endGame()
    {
        Application.Quit();
        Time.timeScale = 0;
    }   //end of endGame method
}   //end of GameOver class
