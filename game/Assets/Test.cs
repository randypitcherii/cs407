using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Circle").GetComponentInChildren<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.setHitPoints(player.getHitPoints() + 10);
            Debug.Log("HP=" + player.getHitPoints());
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            player.setHitPoints(player.getHitPoints() - 10);
            Debug.Log("HP=" + player.getHitPoints());
        }
	}
}