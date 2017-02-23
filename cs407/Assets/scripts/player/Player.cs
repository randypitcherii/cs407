using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Use this abstract to modularize human and AI players.
 */
public abstract class Player : MonoBehaviour
{
    //constants
    private const int MAX_HIT_POINTS = 100;     //the maximum amount of hit points
    private const int MAX_MANA_POINTS = 100;    //the maximum amount of mana points

    //private fields
    private Animator anim;      //handles the animations
    private bool jumping;       //whether or not the player is jumping
    private int dirProjectile;  //direction of the projectile
    private bool isFlipped;     //whether or not the player is flipped
    private Color hitColor;     //the color to change to when hit
    private Color normalColor;  //the normal color of the player

    //protected fields
    protected int hitPoints;  //the player's current hit points
    protected int manaPoints; //the player's current mana points

    //public fields
    public float speed;             //the player's current speed
    public Rigidbody2D rb;          //TODO:  ADD COMMENT
    public bool reset;              //TODO:  ADD COMMENT
    public bool resetCleared;       //TODO:  ADD COMMENT
    public bool setProjectile;      //TODO:  ADD COMMENT
    public Canvas healthPoints;     //TODO:  ADD COMMENT
    public GameObject projectile;   //TODO:  ADD COMMENT
    private bool canMove;            //can the user move right now or not
    public bool setCanMove;         //this will be a public method that when changed can set this to true which will turn on cannot move;
    //abstract methods
    public abstract void LateUpdate();

    /**
     * Initializes the player.
     */
    public void Start()
    {
        //initialize hit points
        this.hitPoints = MAX_HIT_POINTS;

        //initialize mana points
        this.manaPoints = MAX_MANA_POINTS;

        //initialize jumping flag
        this.jumping = false;

        //initialize reset cleared flag
        this.resetCleared = false;

        //initialize set projectile flag
        this.setProjectile = false;

        //initialize flipped flag
        this.isFlipped = false;

        //initialize the animator
        anim = GetComponent<Animator>();
        anim.SetInteger("Dir", 1);

        //initialize the health points
        healthPoints = GameObject.FindObjectOfType<Canvas>();
        healthPoints.enabled = true;

        //initialize the color
        this.hitColor = Color.red;
        this.normalColor = GetComponent<SpriteRenderer>().color;

        //allow the player to move
        canMove = true;
        setCanMove = false;
    }   //end of Start method

    /**
     * TODO:  ADD COMMENT
     */
    public void Update()
    {
        //if they are not allowed to move do not allow them
        if (setCanMove == false)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
        if (reset)
        {
            resetCleared = true;
        }
        if (!reset && resetCleared)
        {
            resetCleared = false;
            setProjectile = false;
            GameObject created = (GameObject)Instantiate(projectile, transform);
            //created.SetActive(true);
            //created.transform.SetParent(transform,true);
            //point projectile left
            if (dirProjectile == 2)
            {
                //This line makes no sense to me, why do I have to add parent postion when it should already know them
                created.transform.position = new Vector2((float)-4.405 + transform.position.x, (float)-.31 + transform.position.y);
                Rigidbody2D rb = created.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-10, 0);

            }
            //point projectile right
            else
            {
                created.transform.position = new Vector2((float)3.798 + transform.position.x, (float)-.308 + transform.position.y);
                Rigidbody2D rb = created.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(10, 0);
            }
        }
    }   //end of Update method

    /**
     * TODO:  ADD COMMENT
     */
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
    }   //end of OnTriggerEnter2D method

    /**
     * Returns the player's current hit points.
     *
     * @return  Returns the player's current hit points.
     */
    public int getHitPoints()
    {
        return this.hitPoints;
    }   //end of getHitPoints method

    /**
     * Sets the player's current hit points to the given new hit points.
     *
     * @param newHitPoints  The new hit points.
     */
    public void setHitPoints(int newHitPoints)
    {
        //check for valid new hit points
        if (newHitPoints <= 0)   //the new hit points are invalid
        {
            //set hit points to zero
            this.hitPoints = 0;

            //end the game
            GameOver.endGame();
        }
        else if (newHitPoints > MAX_HIT_POINTS) //the new hit points are invalid
        {
            //set the hit points to the valid maximum
            this.hitPoints = MAX_HIT_POINTS;
        }
        else    //the new hit points are valid
        {
            //set hit points
            this.hitPoints = newHitPoints;
        }   //end if
    }   //end of setHitPoints method

    /**
     * Returns the player's current mana points.
     *
     * @return  Returns the player's current mana points.
     */
    public int getManaPoints()
    {
        return this.hitPoints;
    }   //end of getManaPoints method

    /**
     * Sets the player's current mana points to the given new mana points.
     *
     * @param newHitPoints  The new mana points.
     */
    public void setManaPoints(int newManaPoints)
    {
        //check for valid new mana points
        if (newManaPoints < 0)  //the new mana points are invalid
        {
            //set mana points to zero
            this.manaPoints = 0;
        }
        else if (newManaPoints > MAX_MANA_POINTS)   //the new mana points are invalid
        {
            //set mana points to the valid maximum
            this.manaPoints = MAX_MANA_POINTS;
        }
        else    //the new mana points are valid
        {
            //set mana points
            this.manaPoints = newManaPoints;
        }   //end if
    }   //end of setHitPoints method

    /**
     * Makes the player move to the left.
     */
    protected void moveLeft()
    {
        if (canMove)
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            anim.SetInteger("Dir", 2);
        }
        anim.SetInteger("State", 2);
    }   //end of moveLeft method

    /**
     * Makes the player move to the right.
     */
    protected void moveRight()
    {
        if (canMove)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("Dir", 1);
        }
        anim.SetInteger("State", 1);
    }   //end of moveRight method

    /**
     * Makes the player jump.
     */
    protected void jump()
    {
        if (!jumping && canMove)
        {
            jumping = true;
            anim.SetBool("Jump", true);
            rb.velocity = new Vector2(0, 5);
        }
    }   //end of jump method

    /**
     * Makes the player perform a melee attack.
     */
    protected void useMeleeAttack()
    {
        if (canMove)
        {
            anim.SetBool("Meele", true);
        }
    }   //end of useMeleeAttack method
    protected void endMeleeAttack()
    {
        anim.SetBool("Meele", false);
    }
    /**
     * Makes the player perform a ranged attack.
     */
    protected void useRangedAttack()
    {
        //change to make it stay in one direction and can not change
        if (canMove)
        {
            dirProjectile = anim.GetInteger("Dir");
            anim.SetInteger("State", 6);
        }
    }   //end of useRangedAttack method

    /**
     * Makes the player perform a block attack.
     */
    protected void useBlockAttack()
    {
        if (canMove)
        {
            anim.SetBool("Block", true);
        }
    }   //end of useBlockAttack method

    protected void endBlockAttack()
    {
        anim.SetBool("Block", false);
    }   //end of endBlockAttack method
    /**
     * Makes the player stand still.
     */
    protected void standStill()
    {
        anim.SetInteger("State", 0);
    }   //end of standStill method

    /**
     * Returns the player's current speed.
     *
     * @returns Returns the player's current speed.
     */
    public float getSpeed()
    {
        return this.speed;
    }   //end of getSpeed method

    /**
     * Changes the color of the sprite when hit.
     */
    protected void changeToHitColor()
    {
        GetComponent<SpriteRenderer>().color = this.hitColor;
    }   //end of changeToHitColor method

    /**
     * Changes the color of the sprite back to normal.
     */
    protected void changeToNormalColor()
    {
        GetComponent<SpriteRenderer>().color = this.normalColor;
    }   //end of changedToNormalColor method
}   //end of Player abstract