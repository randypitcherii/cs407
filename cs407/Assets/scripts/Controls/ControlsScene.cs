using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScene : MonoBehaviour
{
    //constants
    private const int NUM_KEYS = 6; //the number of keys

    //enums
    private enum Button {LeftButton, RightButton, JumpButton, MeleeButton, RangedButton, BlockButton};  //the Button enum

    //private fields
    private bool isRecording;                   //whether or not input is being recorded
    private Button currentButton;               //the current button
    private UnityEngine.UI.Text currentText;    //the current text
    private KeyCode[] keys;                     //the list of keys

    /**
     * Initializes the fields.
     */
    public void Start()
    {
        //stop recording input
        this.isRecording = false;

        //initialize the keys
        this.keys = new KeyCode[NUM_KEYS];

        //set the move left key
        this.keys[(int)Button.LeftButton] = Controls.getLeftKey();
        GameObject.Find("LeftButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getLeftKey().ToString();

        //set the move right key
        this.keys[(int)Button.RightButton] = Controls.getRightKey();
        GameObject.Find("RightButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getRightKey().ToString();

        //set the jump key
        this.keys[(int)Button.JumpButton] = Controls.getJumpKey();
        GameObject.Find("JumpButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getJumpKey().ToString();

        //set the melee attack key
        this.keys[(int)Button.MeleeButton] = Controls.getMeleeKey();
        GameObject.Find("MeleeButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getMeleeKey().ToString();

        //set the ranged attack key
        this.keys[(int)Button.RangedButton] = Controls.getRangedKey();
        GameObject.Find("RangedButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getRangedKey().ToString();

        //set the block key
        this.keys[(int)Button.BlockButton] = Controls.getBlockKey();
        GameObject.Find("BlockButtonText").GetComponent<UnityEngine.UI.Text>().text = Controls.getBlockKey().ToString();
    }   //end of Start method

    /**
     * Handles the capturing of input.
     */
    public void OnGUI()
    {
        //check if a key was pressed and input is being recorded
        if (Event.current != null && Event.current.type == EventType.KeyDown && isRecording)    //a key was pressed and input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //set the new key
            this.keys[(int)currentButton] = Event.current.keyCode;

            //set the text to the new key
            this.currentText.text = Event.current.keyCode.ToString();
        }   //end if
    }   //end of OnGUI method

    /**
     * Handles the cancel button's click event.
     */
    public void cancelButtonClick()
    {
        //load the main menu
        Application.LoadLevel("MainMenu");
    }   //end of backButtonClick method

    /**
     * Handles the save button's click event.
     */
    public void saveButtonClick()
    {
        //save the keys
        Controls.setLeftKey(this.keys[(int)Button.LeftButton]);
        Controls.setRightKey(this.keys[(int)Button.RightButton]);
        Controls.setJumpKey(this.keys[(int)Button.JumpButton]);
        Controls.setMeleeKey(this.keys[(int)Button.MeleeButton]);
        Controls.setRangedKey(this.keys[(int)Button.RangedButton]);
        Controls.setBlockKey(this.keys[(int)Button.BlockButton]);

        //load the main menu
        Application.LoadLevel("MainMenu");
    }   //end of saveButtonClick

    /**
     * Handles the left button's click event.
     */
    public void leftButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.LeftButton;

        //set the current text
        this.currentText = GameObject.Find("LeftButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of leftButtonClick method

    /**
     * Handles the right button's click event.
     */
    public void rightButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.RightButton;

        //set the current text
        this.currentText = GameObject.Find("RightButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of rightButtonClick method

    /**
     * Handles the jump button's click event.
     */
    public void jumpButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.JumpButton;

        //set the current text
        this.currentText = GameObject.Find("JumpButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of jumpButtonClick method

    /**
     * Handles the melee button's click event.
     */
    public void meleeButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.MeleeButton;

        //set the current text
        this.currentText = GameObject.Find("MeleeButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of meleeButtonClick method

    /**
     * Handles the ranged button's click event.
     */
    public void rangedButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.RangedButton;

        //set the current text
        this.currentText = GameObject.Find("RangedButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of rangedButtonClick method

    /**
     * Handles the block button's click event.
     */
    public void blockButtonClick()
    {
        //check if input is being recorded
        if (isRecording)    //input is being recorded
        {
            //stop recording input
            this.isRecording = false;

            //reset the text of the previously clicked button
            this.currentText.text = this.keys[(int)this.currentButton].ToString();
        }   //end if

        //set current button
        this.currentButton = Button.BlockButton;

        //set the current text
        this.currentText = GameObject.Find("BlockButtonText").GetComponent<UnityEngine.UI.Text>();

        //set the text on the button
        this.currentText.text = "Press any key";

        //start recording input
        this.isRecording = true;
    }   //end of blockButtonClick method
}   //end of ControlsScene class