using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp_player : MonoBehaviour, PlayerInterface
{
	
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
    private Canvas healthPoints;
    /*this gets around unity stupidy, it will be set to true 
    when ever the fight animation is running and allow the value
    resestCleared to true which will allow when setProj to true create one new Gameobject instead of thousands*/
	public int totalHealth = 100;
	public int currentHealth;
	//public GameObject player;
	//public GameObject ai;
	public GameObject pauseMenu;
	public Slider healthSlider;
	public bool reset;
    public bool resetCleared;
    private bool canMove; //new
    // Use this for initialization
	public void Start () {
        isFlipped = false;
        anim = GetComponent<Animator>();
        anim.SetInteger("Dir", 1);
		InvokeRepeating ("HealthDecrease", 1, 1);
        resetCleared = false;
        setProjectile = false;
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
            anim.SetBool("Jump", false);
            jumping = false;
        }
        else if (col.gameObject.tag == "Proj")
        {
            //TODO how to hurt health and add flash
            Destroy(col.gameObject);

        }
        else if (col.gameObject.tag == "hitBox")
        {
            //TODO how to hurt health and add flash
            Debug.Log("Get hit");
        }
    }
	void HealthDecrease(){
		currentHealth -= 5;
		transform.localScale = new Vector3 ((currentHealth / totalHealth), 1, 1);
		healthSlider.value = health;
		if (health <= 0) {
			//gameOver.SetActive(true);
			//temp_player.GetComponent<Animator>().SetTrigger("isDead");
			pauseMenu.SetActive (true);
		}
	}
    // Update is called once per frame
    public void LateUpdate () {
        anim.SetBool("Meele", false);
        anim.SetBool("Block", false);
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
        //They are standing still
        else
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //TODO have it exit state when hits ground
            if (!jumping)
            {
                jumping = true;
                anim.SetBool("Jump",true);
                rb.velocity = new Vector2(0, 5);
            }

        }
        if (Input.GetKey(KeyCode.Space))
        {
            dirProjectile = anim.GetInteger("Dir");
            anim.SetInteger("State",6);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("Meele", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Block", true);
        }
    }
}