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
    }   //end of Start method

    /**
     * TODO:  ADD COMMENT
     */
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
            Debug.Log("Hit floor");
            if (jumping)
            {
                int state = anim.GetInteger("State");
                if (state == 5)
                {
                    anim.SetInteger("State", 0);
                }
                else
                {
                    anim.SetInteger("State", 4);
                }
                jumping = false;
            }
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
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        anim.SetInteger("State", 2);
        anim.SetInteger("Dir", 2);
    }   //end of moveLeft method

    /**
     * Makes the player move to the right.
     */
    protected void moveRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        anim.SetInteger("State", 1);
        anim.SetInteger("Dir", 1);
    }   //end of moveRight method

    /**
     * Makes the player jump.
     */
    protected void jump()
    {
        //TODO have it exit state when hits ground
        if (!jumping)
        {
            jumping = true;
            anim.SetInteger("State", 3);
            rb.velocity = new Vector2(0, 5);
        }
    }   //end of jump method

    /**
     * Makes the player perform a melee attack.
     */
    protected void useMeleeAttack()
    {

    }   //end of useMeleeAttack method

    /**
     * Makes the player perform a ranged attack.
     */
    protected void useRangedAttack()
    {
        dirProjectile = anim.GetInteger("Dir");
        anim.SetInteger("State", 6);
    }   //end of useRangedAttack method

    /**
     * Makes the player perform a block attack.
     */
    protected void useBlockAttack()
    {

    }   //end of useBlockAttack method

    /**
     * Makes the player stand still.
     */
    protected void standStill()
    {
        if (jumping)
        {
            anim.SetInteger("State", 5);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
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
}   //end of Player abstract