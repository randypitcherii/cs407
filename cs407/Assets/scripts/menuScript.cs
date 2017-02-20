using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Button gamePlay;
    

	// Use this for initialization
	void Start () {
        gamePlay = gamePlay.GetComponent<Button>();
        	
	}
	
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
}
