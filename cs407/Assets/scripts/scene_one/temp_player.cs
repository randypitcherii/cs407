using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp_player : MonoBehaviour, PlayerInterface
{
<<<<<<< HEAD
    private bool isFlipped;
    public float speed;
    private Animator anim;
    private bool needFlip;
    public Rigidbody2D rb;
    private bool jumping;
    //set the direction of the projectile being shot
    private int dirProjectile;
    public bool setProjectile;
    public GameObject projectile;
    /*this gets around unity stupidy, it will be set to true 
    when ever the fight animation is running and allow the value
    resestCleared to true which will allow when setProj to true create one new Gameobject instead of thousands*/
    public bool reset;
    public bool resetCleared;
    public Canvas healthPoints;
    // Use this for initialization
	public void Start () {
        isFlipped = false;
        anim = GetComponent<Animator>();
        anim.SetInteger("Dir", 1);
        resetCleared = false;
        setProjectile = false;
	healthPoints = GameObject.FindObjectOfType<Canvas>();
	healthPoints.enabled = true;
    }

    public float getSpeed()
    {
        return speed;
    }
    public void Update()
    {
        if (reset)
        {
            resetCleared = true;
        }
        if (!reset && resetCleared)
        {
            resetCleared = false;
            setProjectile = false;
            GameObject created = (GameObject) Instantiate(projectile, transform);
            //created.SetActive(true);
            //created.transform.SetParent(transform,true);
            //point projectile left
            if (dirProjectile == 2)
            {
                //This line makes no sense to me, why do I have to add parent postion when it should already know them
                created.transform.position = new Vector2((float)-4.405+transform.position.x, (float)-.31+transform.position.y);
                Rigidbody2D rb = created.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-10,0);

            }
            //point projectile right
            else
            {
                created.transform.position = new Vector2((float)3.798 + transform.position.x, (float)-.308 + transform.position.y);
                Rigidbody2D rb = created.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(10, 0);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "floor")
        {
            Debug.Log("Hit floor");
            if (jumping) {
                int state = anim.GetInteger("State");
                if (state == 5)
                {
                    anim.SetInteger("State", 0);
                }
                else
                {
                    anim.SetInteger("State",4);
                }
                jumping = false;
            }
        }
    }
    // Update is called once per frame
    public void LateUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            anim.SetInteger("State", 2);
            anim.SetInteger("Dir", 2);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("State", 1);
            anim.SetInteger("Dir", 1);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //TODO have it exit state when hits ground
            if (!jumping) {
                jumping = true;
                anim.SetInteger("State", 3);
                rb.velocity = new Vector2(0, 5);
            }

        }
        //They are standing still
        else
        {
            
            if (jumping)
            {
                    anim.SetInteger("State", 5);
            }
            else
            {
                anim.SetInteger("State", 0);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            dirProjectile = anim.GetInteger("Dir");
            anim.SetInteger("State",6);
        }
    }
}
