using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bow : MonoBehaviour {
    private Animator anim;
    public GameObject arrow;
    public float shootV2;
    public float arrowPullBackSpeed;
    public Boolean shot;
    private Rigidbody2D arrowRB;
    private int state;
    //if 2 means it is a power shot
    private int powerShot;
    public float timeResetArrow;
    private float timeToReset;
    //arrow offset when reloading from bow
    private Vector3 arrowOffset; 
    // Use this for initialization
    void Start ()
    {
        timeToReset = 0;
        shot = false;
        powerShot = 1;
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0);
        if(arrow == null)
        {
            Debug.LogError("arrow is null");
            Application.Quit();
        }
        arrowRB = arrow.GetComponent<Rigidbody2D>();
        if (arrowRB == null)
        {
            Debug.LogError("arrow rb is null");
            Application.Quit();
        }
        state = 0;
        arrowOffset = arrow.transform.position - transform.position;
    }
    //this method will find the player and mouse location and then will follow it up between 50 and -20 degrees.
    float followMouse()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 player = transform.position;
        float x = mouse.x - player.x  ;
        float y = mouse.y - player.y ;
        float angle = (float)((180 / Math.PI) * Math.Atan(y / x));
        //Debug.Log("x " + x + ",y " + y);
        //means we need to flip everything as mouse is behind arrow and this is how degrees work i guess
        if (x < 0)
        {
            angle *= -1;
        }
        if (angle > 50)
        {
            angle = 50;
        }
        if (angle < -20)
        {
            angle = -20;
        }
        //arrow.transform.eulerAngles = new Vector3(0, 0, angle);
        transform.eulerAngles = new Vector3(0, 0, angle);
        return angle;
    }
    //resets all vars so that way person can reshoot a arrow
    void reload()
    {
        //set the location of the bow to 0,0,0 so that way it will roate with it
        Vector3 temp = transform.eulerAngles;
        transform.eulerAngles = new Vector3(0,0,0);
        //arrow.transform.eulerAngles = new Vector3(0,0,0);
        
        //set back to free fire values
        arrowRB.gravityScale = 0;
        state = 0;
        powerShot = 1;
        shot = false;
        //set all the arrow states back to init states and resting states and the bow to state before transform 
        arrowRB.velocity = new Vector2(0, 0);
        arrow.transform.position = arrowOffset + this.transform.position;
        arrow.transform.parent = this.transform;
        arrow.transform.eulerAngles = this.transform.eulerAngles;
        transform.eulerAngles = temp;
    }
    // Update is called once per frame
    void Update()
    {
        //looks at when to reload arrows by time passing 
        if(timeToReset > 0)
        {
            timeToReset -= Time.deltaTime;
            Debug.Log("Time left =" + timeToReset);
            if(timeToReset <= 0)
            {
                timeToReset = 0;
                reload();
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("bow_load2"))
        {
            powerShot = 2;
        }
        if (state == 1)
        {
            state = 0;
        }
        if (Input.GetMouseButtonDown(0) && shot == false)
        {
            state = 1;
            anim.SetInteger("State", 1);
            
        }
        if (Input.GetMouseButtonUp(0) && shot == false)
        {
            timeToReset = timeResetArrow;
            Debug.Log("Time left =" + timeToReset);
            anim.SetInteger("State", 2);
        }
        //angle that bow is aimed at
        double angle = (Math.PI * followMouse() / 180);
        if (!shot)
        {
            if (state == 1 || (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) && (anim.GetCurrentAnimatorStateInfo(0).IsName("bow_load") || anim.GetCurrentAnimatorStateInfo(0).IsName("bow_load2")))
            {
                arrowRB.velocity = new Vector2((float)(arrowPullBackSpeed * Math.Cos(angle)), (float)(arrowPullBackSpeed * Math.Sin(angle)));
            }
            else if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) && (anim.GetCurrentAnimatorStateInfo(0).IsName("bow_load") || anim.GetCurrentAnimatorStateInfo(0).IsName("bow_load2")))
            {
                arrowRB.velocity = new Vector2(0, 0);
            }
        }
    }
    void LateUpdate()
    {
        if (shot)
        {
            Vector2 v = arrowRB.velocity;
            double a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.AngleAxis((float)a, Vector3.forward);
        }
        //angle that bow is aimed at
        double angle = (Math.PI * followMouse() / 180);
        if (Input.GetMouseButtonUp(0))
        {
            if (!shot)
            {
                transform.DetachChildren();
                shot = true;
                //sets speed by angle

                arrowRB.velocity = new Vector2((float)(powerShot * shootV2 * Math.Cos(angle)), (float)(powerShot * shootV2 * Math.Sin(angle)));
                arrowRB.gravityScale = 1;
            }
        }
        
    }
}
