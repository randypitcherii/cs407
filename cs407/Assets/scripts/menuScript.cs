using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Button gamePlay;
    

	// Use this for initialization
	void Start () {
        gamePlay = gamePlay.GetComponent<Button>();
        Sound.playSound(gameObject, "Battle Theme 1_demo");
	}
	
    public void StartLevel()
    {
        Application.LoadLevel("StageSelectScene");
    }

    public void SelectCharacter()
    {
        Application.LoadLevel("CharacterSelect");
    }
}
