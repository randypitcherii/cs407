using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : MonoBehaviour
{
    /**
     * Handles the Stage1Button's click event.
     */
    public void stage1ButtonClick()
    {
        //set the stage
        Stage.setStage(Stage.Number.One);

        //start the game
        startGame();
    }   //end of stage1ButtonClick method

    /**
     * Handles the Stage2Button's click event.
     */
    public void stage2ButtonClick()
    {
        //set the stage
        Stage.setStage(Stage.Number.Two);

        //start the game
        startGame();
    }   //end of stage2ButtonClick method

    /**
     * Handles the Stage3Button's click event.
     */
    public void stage3ButtonClick()
    {
        //set the stage
        Stage.setStage(Stage.Number.Three);

        //start the game
        startGame();
    }   //end of stage3ButtonClick method

    /**
     * Handles the Stage4Button's click event.
     */
    public void stage4ButtonClick()
    {
        //set the stage
        Stage.setStage(Stage.Number.Four);

        //start the game
        startGame();
    }   //end of stage4ButtonClick method

    /**
     * Starts the game.
     */
    public void startGame()
    {
        //start the game
        Application.LoadLevel("scene_one");
    }   //end of startGame method

    /**
     * Handles the BackButton's click event.
     */
    public void backButtonClick()
    {
        //go back to the main menu
        Application.LoadLevel("MainMenu");
    }   //end of backButtonClick method
}   //end of StageSelectScene class
