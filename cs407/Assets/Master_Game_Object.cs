using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Game_Object : MonoBehaviour {
    run_main_scene rms;
    Object obj;
    int i;
	// Use this for initialization
	void Start () {
        //need away
        if (number.max == -1)
        {
            //not running multiple scripts
        }
        else
        {
            this.transform.position = new Vector3(0,number.count*25 - (25 * number.max/2),0);
            rms = number.rms;
            obj = number.obj[number.count];
            i = number.count;
            if (number.count != number.max)
            {
                Application.LoadLevelAdditive("scene_one");
                number.count++;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        rms.getGameInfo(new GameInfo(), i);

    }
}
//way of passing the game info back to player 
public class GameInfo {
    public bool isOver { get; set; }
    public Player winner { get; set; }
    public double timeLeft { get; set; }

    public GameInfo()
    {
        this.isOver = false;
        this.winner = null;
        this.timeLeft = 300.0;
    }
}
