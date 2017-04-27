using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class run_main_scene : MonoBehaviour {
    public bool createGame; //do I need to create a new game?
    // Use this for initialization
    void Start()
    {
        //init the class that deals with passing info along
        //number.obj = new Object[number.max];
        number.locked = false;
        number.rms =  this;
        number.isTraining = true;
        createGame = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (createGame)
        {
            createGame = false;
            Application.LoadLevelAdditive("scene_one");
            number.count++;
        }        
	}
    public void getGameInfo(GameInfo gi, int number)
    {

    }
}
public class number
{
    public static int count;    /*What scene number this is being created. 
                                  This allows create scene know where to place it the Parent Scene as well as be able to access it  */
    public static bool isTraining;  //Lets the system know if this is training or not and what it should do about that
    public static run_main_scene rms; //rms to pass to new scene so it is able to access it
    //TODO have a way to set it before returning
    public static Master_Game_Object mgo;   //this is the class that is the parent of everything in the scene
    public static bool locked;              //Locks creating a new scene while this is being used, imporant as it stops it from passing the wrong values to the wrong scene.
    public static AIEvaluator aiEval; // AIEvaluator class of game being created

    //Creates a game and then returns its mgo 
    public static Master_Game_Object createGame()
    {

        //checks to make sure no one else is using this
        waitForLock();
        Debug.Log("Exit Lock" + locked);
        //it is locked and unlocked in 
        rms.createGame = true; //sets a flag to let the parent scene know it needs to create a new scene
        //Save the Master Game Object before we undo the lock
        waitForGameToBeCreated();
        Master_Game_Object mgo1 = mgo;
        //set it back to null so it can wait for creating a new game with the lock work correctly
        
        number.locked = false;
        mgo = null;
        return mgo1;
    }

    public static IEnumerator waitForLock()
    {
        while (locked)
        {
            yield return null;
        }
        //Trying to see if this locks it or what happens
        locked = true;

    }
    //method waits for new scene to create a new gameObject and set mgo so we know that is done making the new gameObject
    public static IEnumerator waitForGameToBeCreated()
    {
        Debug.Log("Hello world");
        while (mgo == null)
        {
            yield return null;
        }
    }
}

