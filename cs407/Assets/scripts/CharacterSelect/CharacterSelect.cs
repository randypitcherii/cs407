using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {
    
    //color of the character
    public Color SelectedColor;

    /** Write the character settings to a file
     * 
     */
    public void WriteSettings()
    {
        //load the settings
        CharacterSettings.SetColor(this.SelectedColor);

        //write the settings
        CharacterSettings.WriteSettings();

        //load the main menu
        LoadMenu();
    }

    /** Load the main menu
     * 
     */
    public void LoadMenu()
    {
        //go back to the main menu
        Application.LoadLevel("MainMenu");
    }
}
