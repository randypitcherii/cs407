using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sound_Bar : MonoBehaviour {
    public float soundLevel;
    private Slider s;
    public void onLoad()
    {
        //TODO make way to set soundLevel from file instead of this
        soundLevel = .30f;
        s = this.GetComponent<Slider>();
        s.value = soundLevel;
    }
    public void onDeLoad()
    {
        s = this.GetComponent<Slider>();
        soundLevel = s.value;
        Debug.Log(soundLevel);
        //TODO save value were ever
    }
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
