using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
    //time until scene ends
    public float time;
    //Text that will show on the timer
    public Text timer;
    //The main player that the camera is to watch
    public GameObject player;
    //The AI player 
    public GameObject player2;
    //offset is need to fix camera view
    private Vector3 offset;
    //change that the player has made while moving
    private float totalPlayerChange;
    //distance for player to move so that way camera will move
    public float moveCamDist;
    //speed the camera will move at
    private float speedCamera;
    //store players previous location
    private Vector3 playerPrevLoc;
    //how far left the camera can move
    public float leftCameraBond;
    //how far right the camera can go
    public float rightCameraBond;
    //script of player to allow us to get certain fetarues
    private Player script;
    private Player script2;
    //old Time to allow us to know when x seconds has passed to help fill mana
    private float oldTime;
    //after how many seconds add more mana to the player
    public float secAddMana;
    //how much mana to refil by
    public int addMana;
    //set the timescale for the game 
    public int timeScale;
    public GameObject endGame;
    // Use this for initialization
    void Start () {
        offset = transform.position;
        totalPlayerChange = 0;
        playerPrevLoc = player.transform.position;
        script = player.GetComponent<Player>();
        script2 = player2.GetComponent<Player>();
        Time.timeScale = timeScale;
        if(script == null)
        {
            Debug.Log("Script is null");
        }
        else
        {
            speedCamera = (float)(script.getSpeed() * 1.0);
        }
        speedCamera = (float)(script.getSpeed()*1.0);
        secAddMana = 1.0f;
        addMana = 1;
        oldTime = time;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            timer.text = "0.00";
            end(true);
        }
        else
        {
            int minsLeft = ((int)time) / 60;
            int secLeft = ((int)time) % 60;

            if (time > 30)
            {
                timer.text = minsLeft + ":" + String.Format("{0:00}", secLeft);
            }
            else
            {
                timer.text = minsLeft + ":" + String.Format("{0:0.00}", time % 60);
            }
        }
        if (time-oldTime < -1*secAddMana)
        {
            oldTime = time;
            script.setManaPoints(script.getManaPoints() + addMana);
            script2.setManaPoints(script2.getManaPoints()+addMana);
        }
	}
    //function that helps deal with ending the game and the game menu
    public void end( bool isTie)
    {
        int p1Health = player.GetComponent<Player>().getHitPoints();
        int p2Health = player2.GetComponent<Player>().getHitPoints();
        //get the time that is left
        int minsLeft = ((int)time) / 60;
        int secLeft = ((int)time) % 60;
        string timeLeft;
        //make time in the same format as before
        if (time > 30)
        {
            timeLeft = minsLeft + ":" + String.Format("{0:00}", secLeft);
        }
        else
        {
            timeLeft = String.Format("{0:0.00}", time % 60);
        }
        //set the menu to be active
        endGame.SetActive(true);
        //if it is a tie let them know
        if (isTie)
        {
            endGame.transform.FindChild("Panel").FindChild("Stats").GetComponent<Text>().text = "The Clock expired no winner\n The com had " + p1Health + " health left\n" + "You had " + p2Health + " health left";
        }
        else
        {
            //player 1 is consider to be the actual player while player2 is the com
            if (p2Health <= 0)
            {
                endGame.transform.FindChild("Panel").FindChild("Stats").GetComponent<Text>().text = "You have won\n" + "With " + timeLeft + " Time left\n" + "and you had " + p1Health + " health left";
            }
            else
            {
                endGame.transform.FindChild("Panel").FindChild("Stats").GetComponent<Text>().text = "You have lost\n" + "With " + timeLeft + " Time left\n" + "and the com had " + p2Health + " health left";
            }
        }
        //freeze the game and make no more updates
        Time.timeScale = 0;
    }   //end of endGame method
    void LateUpdate()
    {
        /*totalPlayerChange = (transform.position - playerPrevLoc + offset).x; 
        if (moveCamDist < Math.Abs(totalPlayerChange))
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z),speedCamera*Time.deltaTime);
        }
        if(transform.position.x < leftCameraBond)
        {
            transform.position = new Vector3(leftCameraBond,transform.position.y,transform.position.z);
        }
        else if(transform.position.x > rightCameraBond)
        {
            transform.position = new Vector3(rightCameraBond, transform.position.y, transform.position.z);
        }
        playerPrevLoc = player.transform.position;*/
    }
}
