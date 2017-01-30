using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Player player;

	// Use this for initialization
	void Start () {
        player = new Player(GameObject.Find("Circle"));
        Attack a = new AttackMelee(player);
        a.use();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.getHitPointsObject().setHitPoints(player.getHitPointsObject().getHitPoints() + 10);
            Debug.Log("HP=" + player.getHitPointsObject().getHitPoints());
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            player.getHitPointsObject().setHitPoints(player.getHitPointsObject().getHitPoints() - 10);
            Debug.Log("HP=" + player.getHitPointsObject().getHitPoints());
        }
	}
}