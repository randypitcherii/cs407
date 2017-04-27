using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
public class Master_Game_Object : MonoBehaviour {
    run_main_scene rms;
    //TODO create a way to set this information
    AIEvaluator aiEval;
    Object obj;
    int i;
    public GameInfo gi;
	// Use this for initialization
	void Start () {
        

        
        if (number.isTraining == false)
        {
            //not running multiple scripts
        }
        //else creating multiple scenes so need to set this up
        else
        {
            gi = new GameInfo();
            //TODO need away to set aiEval to be able to get it;
            number.mgo = this;
            aiEval = number.aiEval;
            Debug.LogError(aiEval);
            aiEval.setGameInfo(gi);
            this.transform.position = new Vector3(0,number.count*25,0);
            rms = number.rms;
            i = number.count;
        }
        
    }
    //Called from AIEvalutor and needs to return both player1 and player2
    //returns array with array[0] being player1 and array[1] being player2
    //makes an assumation that there are only 2 players
	public Player[] getPlayers()
    {
        //get all gameObjects under are GameObject
        GameObject[] go = GetComponentsInChildren<GameObject>();
        Player[] ret = new Player[2];
        Debug.LogError(go);
        int count = 0; //keeps track of how many are found
        foreach(GameObject g in go)
        {
            if(g.tag == "AI")
            {
                ret[count++] = g.GetComponent<Player>();
                if(count == 2)
                {
                    break;
                }
            }
        }
        //checks to make sure two items were added
        if (ret[1] == null)
        {
            return null;
        }
        return ret;
    }
	// Update is called once per frame
	void Update () {
        if (rms != null)
        {
            rms.getGameInfo(new GameInfo(), i);
        }

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
