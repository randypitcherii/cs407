using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Button gamePlay;
	public AudioSource source;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
        gamePlay = gamePlay.GetComponent<Button>();
		source.PlayOneShot (sound);	
	}
	
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
}
