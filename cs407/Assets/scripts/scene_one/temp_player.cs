using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp_player : MonoBehaviour, PlayerInterface
{
    public Canvas healthPoints;
    public float speed;
	// Use this for initialization
	public void Start () {
        healthPoints = GameObject.FindObjectOfType<Canvas>();
        healthPoints.enabled = true;
    }

    public float getSpeed()
    {
        return speed;
    }
    public void Update()
    {

    }
	// Update is called once per frame
	public void LateUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed*Time.deltaTime, 0, 0);
        }
    }
}
