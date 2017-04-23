using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class run_main_scene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //init the class that deals with passing info along
        number.obj = new Object[number.max];
        number.locked = false;
        number.rms =  this;
        number.max = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //if this is locked we need to create a new scene to take its place so load a new scene and pass the 
        
	}
    public void createGame()
    {
        Application.LoadLevelAdditive("scene_one");
        number.count++;
    }
    public void getGameInfo(GameInfo gi, int number)
    {

    }
}
public class number
{
    public static int count;    //covert
    public static int max = -1; //max number will not need
    public static Object[] obj; //what ever object you want to pass along
    public static run_main_scene rms; //rms to pass to new run
    public static Master_Game_Object mgo;   //this is the class that is the parent of everything in the scene
    public static bool locked; //is something using this class, so does it need to be locked
    public static AIEvaluator aiEval; // AIEvaluator of item
    public static Master_Game_Object createGame()
    {
        //checks to make sure no one else is using this, will unlock in MasterGameObject when it is returned
        while (locked) { }
        //locks it so nothing else can access it
        locked = true;
        rms.createGame();
        return mgo;
    }
}

