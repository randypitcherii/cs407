﻿using System.Collections;
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
	// Use this for initialization
	void Start () {
        offset = transform.position;
        totalPlayerChange = 0;
        playerPrevLoc = player.transform.position;
        PlayerInterface script = player.GetComponent<PlayerInterface>();
        speedCamera = (float)(script.getSpeed()*1.0);

    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if(time < 0)
        {
            Debug.Log("time up");
            timer.text = "0.00";
            Menu.DisplayWinner();
            Menu.returnToMenu();
        }
        else
        {
            int minsLeft = ((int) time) / 60;
            int secLeft = ((int)time) % 60;

            if (time > 30)
            {
                timer.text = minsLeft + ":" + secLeft;
            }
            else
            {
                timer.text = minsLeft + ":" + String.Format("{0:0.00}", time % 60);
            }
            
        }
	}
    void LateUpdate()
    {
        totalPlayerChange = (transform.position - playerPrevLoc + offset).x; 
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
        playerPrevLoc = player.transform.position;
    }
}
