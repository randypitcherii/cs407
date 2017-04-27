using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CharacterSettings {

    //file location
    private const string DIRECTORY = "Settings";
    private const string FILE = "aiCharacter";

    //file writer
    private static StreamWriter settingsWriter;

    //file reader
    private static StreamReader settingsReader;

    //color of the character
    private static Color SelectedColor = new Color(1, 1, 1, 1);

    /** Write the character settings to a file
     * 
     */
    public static void WriteSettings()
    {
        //prepare to write the settings
        settingsWriter = new StreamWriter(File.OpenWrite(DIRECTORY + '/' + FILE));

        //write the settings in order
        WriteColor();

        //close the file
        settingsWriter.Close();
    }

    /** Read the character settings from a file
     * 
     */
    public static void LoadSettings()
    {
        //in case the file is missing
        if (!File.Exists(DIRECTORY + '/' + FILE))
        {
            WriteSettings();
            return;
        }

        //prepare to write the settings
        settingsReader = new StreamReader(File.OpenRead(DIRECTORY + '/' + FILE));

        //write the settings in order
        ReadColor();

        //close the file
        settingsReader.Close();
    }

    /** Set the selected color
     * 
     */
    public static void SetColor(Color c)
    {
        SelectedColor = c;
    }

    /** Get the selected color
     * 
     */
    public static Color GetColor()
    {
        return SelectedColor;
    }

    /** Write the character color settings to file
     * 
     */
    private static void WriteColor()
    {
        //write the color to the file
        settingsWriter.WriteLine("" + SelectedColor[0] + " " + SelectedColor[1] + " " + SelectedColor[2] + " " + SelectedColor[3] + " ");
    }

    /** Load color from a file
     * 
     */
    private static void ReadColor()
    {
        //read in the color
        string color = settingsReader.ReadLine();

        float[] elements = new float[4];    //elements of the color
        string colorElement;                //current color element
        int index;                          //index of the parsing space

        //get each color element
        for(int i = 0; i < 4; i++)
        {
            //find parsing space
            index = color.IndexOf(" ");

            //get element string
            colorElement = color.Substring(0, index);

            //parse element string
            elements[i] = float.Parse(colorElement);

            //remove current element from color
            color = color.Substring(index + 1);
        }

        //store color
        SelectedColor = new Color(elements[0], elements[1], elements[2], elements[3]);
    }
}
