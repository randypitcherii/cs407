using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetter : MonoBehaviour
{
	/**
     * Sets the stage sprite.
     */
	void Start()
    {
        //set the stage sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = Stage.getStage();
	}   //end of Start method
}   //end of StageSetter class
