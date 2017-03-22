using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAnalyzer
{
    //constants
    private const int NUM_ACTIONS = 7;  //the number of actions that can be performed

    /**
     * Analyzes a log file.
     *
     * @param fileName  The name of a log file.
     */
    public static void analyze(string fileName)
    {
        Debug.Log("START ANALYSIS OF " + fileName);

        //analyze the log for each action
        for (int actionIndex = 0; actionIndex < NUM_ACTIONS; actionIndex += 1)
        {
            //analyze the log for an action
            LogAnalyzer.analyze(fileName, actionIndex);
        }   //end for

        Debug.Log("END ANALYSIS OF " + fileName);
    }   //end of analyze method

    /**
     * Analyzes a log file to see if it contains a certain action.
     *
     * @param fileName  The name of a log file.
     * @param action    The action to check for.
     */
    public static void analyze(string fileName, int action)
    {
        //read from the log file
        string text = AILogger.read(fileName);  //the contents of the log file
        
        //check if the log contains the action
        if (text.Contains("" + action)) //the log contains the action
        {
            Debug.Log(fileName + " performs " + action);
        }
        else    //the log does not contain the action
        {
            Debug.LogError(fileName + " does NOT perform " + action);
        }   //end if
    }   //end of analyze method

    /**
     * Analyzes a list of log files.
     *
     * @param fileNames A list of names of log files.
     */
    public static void analyzeAll(string[] fileNames)
    {
        //analyze each file
        foreach (string fileName in fileNames)
        {
            //analyze a file
            LogAnalyzer.analyze(fileName);
        }   //end for
    }   //end of analyzeAll method
}   //end of LogAnalyzer class