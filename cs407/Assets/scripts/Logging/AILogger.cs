using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILogger
{
    //constants
    private const string DIRECTORY = "Logs";        //the location of the directory
    private const string FILE_EXTENSION = "mlf";    //the file extension

    //private fields
    private System.IO.FileStream file;  //the log file
    private bool closed;                //whether or not the file has been closed

    /**
     * Initializes the AI logger.
     */
    public AILogger()
    {
        //create a new file name
        string fileName = "" + System.DateTime.UtcNow.Subtract(System.DateTime.MinValue.AddYears(1969)).TotalMilliseconds.ToString().Split('.')[0]; //the name of the log

        //check if the file name already exists
        if (System.IO.File.Exists(fileName)) //the file already exists
        {
            //error file already exists
            Debug.LogError("File already exists:  " + fileName);
            return;
        }   //end if

        //create the new file
        this.file = System.IO.File.OpenWrite(DIRECTORY + "/" + fileName + "." + FILE_EXTENSION);

        //initialize the closed flag
        this.closed = false;
    }   //end of AILogger constructor

    /**
     * Writes an action to the log file.
     *
     * @param line  An action.
     */
    public void write(int action)
    {
        //check if the log has been closed
        if (this.closed)    //the log has been closed
        {
            return;
        }   //end if

        //convert the action to a byte array
        byte[] bytes = {System.Convert.ToByte(action)}; //a byte array representation of the action

        //write to the log
        this.file.Write(bytes, 0, sizeof(int));
    }   //end of write method

    /**
     * Closes the log file.
     */
    public void close()
    {
        //check if the log has been closed
        if (this.closed)    //the log has been closed
        {
            return;
        }   //end if

        //set the flag to closed
        this.closed = true;

        //close the file
        this.file.Close();
    }   //end of close method

    /**
     * Returns the text in the given log file.
     *
     * @param fileName  The name of the log file.
     * @return          Returns the text of the log file.
     */
    public static string read(string fileName)
    {
        //convert the file name to a path
        string path = DIRECTORY + "/" + fileName + "." + FILE_EXTENSION;    //the path of the file

        //check if the file exists
        if (!System.IO.File.Exists(path))   //the file does not exist
        {
            Debug.Log("File does not exist:  " + path);
            return null;
        }   //end if

        //return the contents of the log
        return System.IO.File.ReadAllText(path);
    }   //end of read method
}   //end of AILogger class
