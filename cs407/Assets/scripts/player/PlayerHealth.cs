using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int health = 100;
	public GameObject player;
	public GameObject ai;
	public GameObject pauseMenu;
	public Slider healthPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("ReduceHealth", 1, 1);
	}
	
	// Update is called once per frame
	public void HealthDecrease(){
		health -= 20;
		healthPoints.value = health;
		if (health <= 0) {
			//gameOver.SetActive(true);
			//temp_player.GetComponent<Animator>().SetTrigger("isDead");
			pauseMenu.SetActive (true);
	
		}
	}
}
