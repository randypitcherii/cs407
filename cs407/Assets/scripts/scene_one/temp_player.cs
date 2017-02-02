using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_player : MonoBehaviour, PlayerInterface
{
    public float speed;
	// Use this for initialization
	public void Start () {
		
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
