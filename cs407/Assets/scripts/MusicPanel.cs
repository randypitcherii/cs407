using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPanel : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
        //set the volume slider value
        GameObject.Find("SF Slider").GetComponent<Slider>().value = Volume.read();
    }   //end of Start method

    /**
     * Updates the value of the volume slider.
     */
    public void volumeSliderUpdate()
    {
        float value = GameObject.Find("SF Slider").GetComponent<Slider>().value;    //the volume value

        //update the volume
        Volume.write(value);
        GameObject.Find("StartMenu").GetComponent<AudioSource>().volume = value;
    }   //end of volumeSliderUpdate method
}   //end of MusicPanel class
