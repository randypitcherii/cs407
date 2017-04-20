using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_main_scene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //init the class that deals with passing info along
        number.max = 5;
        number.count = 0;
        number.obj = new Object[number.max];
        Application.LoadLevelAdditive("scene_one");
        number.count++;
        number.rms =  this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void getGameInfo(GameInfo gi, int number)
    {

    }
}
public class number
{
    public static int count;
    public static int max = -1;
    public static Object[] obj; //what ever object you want to pass along
    public static run_main_scene rms;
}

