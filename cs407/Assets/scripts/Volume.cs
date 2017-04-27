using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Volume
{
    //constants
    private const string FILE_NAME = "Volume";      //the file name
    private const string DIRECTORY = "Settings";    //the directory
    private const float DEFAULT_VOLUME = 1.0f;      //the default volume

    public static void write(float value)
    {
        StreamWriter writer = new StreamWriter(File.OpenWrite(DIRECTORY + "/" + FILE_NAME));    //the writer

        //write the volume to the file
        writer.WriteLine(value);

        //close the writer
        writer.Close();
    }   //end of write method

    public static float read()
    {
        //check if the file exists
        if (File.Exists(DIRECTORY + "/" + FILE_NAME))   //the file exists
        {
            return float.Parse(File.ReadAllLines(DIRECTORY + "/" + FILE_NAME)[0]);
        }
        else    //the file does not exist
        {
            //return the volume
            return DEFAULT_VOLUME;
        }   //end if
    }   //end of read method
}   //end of Volume class
