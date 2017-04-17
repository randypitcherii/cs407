using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Button gamePlay;
	public GameObject musicPanel, mainMenuPanel;
	AudioSource source;
	//AudioSource volumeSet;
	public Slider volumeSlider;
	public AudioClip sound;
	public bool muteToggle;

	// Use this for initialization
	void Start () {
		//mainMenuPanel.SetActive (true);
		musicPanel.SetActive (false);
        gamePlay = gamePlay.GetComponent<Button>();
		source.PlayOneShot (sound);	
		muteToggle = false;
	}
	
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

	public void MusicSetting() 
	{
		musicPanel.SetActive(true);
		mainMenuPanel.SetActive(false);

		if (muteToggle == false) {
			AudioListener.volume = 1;
		}
		if (muteToggle == true) {
			AudioListener.volume = 0;
		}
	}
	public void VolumeControl() {
		AudioListener.volume = volumeSlider.value ;
	}
}
