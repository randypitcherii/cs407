﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//TODO still need to set everything 
public class Location_Script : MonoBehaviour {
    //public objects
    public GameObject edgeColider;  //the edge of unity
    public GameObject[] playersGameObjects;
    //private Object
    private PlayerInfo player1;        //Player Information of Player1
    private PlayerInfo player2;        //Player Information of Player2
    private float width;              //will tell how wide the course is
    private PlayerInfo[] pi;           //Information of all the #
    private int numberPlayers;   //gets count from number of player game objects given
                                 /*this what we will build all the input into, each box will be the .25 space of the game course. 
                                     The bottom row will always be ground and will not change, as the row will always be the player stats
                                     Each row will be 4 * width of the area  determined by start of it
                                     use the formula j+(i*width*4) to find each row where. 
                                     Also the bottom of the array is located at -.25 so that way the top of the floor is at 0
                                     the center of x is at 4 width /2 = width*2
                                 */
    private int[] arena;
    //classes use to store basic info edit to make more sense
    public void printArena()
    {
        for (int i = (arena.Length / (4 * (int)width))-1; i >=0 ; i--)
        {
            StringBuilder sb = new StringBuilder();
            //this will go through each row in the arena
            for (int j = 0; j < 4 * width; j++)
            {
                sb.Append(arena[j + (i * ((int)width) * 4)]);
            }
            Debug.Log(sb.ToString());
        }
    }
    public class PlayerInfo
    {
        public GameObject player;
        public Player pScript;         //Player Script of Player
        public int Health;            //health of player
        public int Mana;              //Mana of player1
        public float x;                //location of Player1 x postion
        public float y;                //location of Player1 y postion
        public int costManaBlock;    //cost of Blocking per unit time for Player1; TODO find out the time
        public bool Blocking;      //is Player Blocking right now
        public bool Jumping;       //is player1 Jumping
        public MeeleDetails md;       //details about meele attack
        public Meele meele;             //if not null will contain information about meele attack
        public ProjectileDetails pd;  //details about projectile attack
        public float playerWidth;         //the width of the collider of the item
        private GameObject right1;      //right box to attack with
        private GameObject left1;       //left box to attack with
        public bool isAttacking()
        {
            return right1.activeSelf || left1.activeSelf;
        }
        public PlayerInfo(GameObject player)
        {
            meele = null;
            this.player = player;
            this.playerWidth = player.GetComponent<BoxCollider2D>().size.y;
            this.pScript = player.GetComponent<Player>();
            pd = new ProjectileDetails(pScript.projSpeed, pScript.setRangedAttack, pScript.setMeleeAttack);
            costManaBlock = pScript.manaBlock;
            right1 = player.transform.FindChild("RightHitBox").gameObject;
            BoxCollider2D bcRight1 = right1.GetComponent<BoxCollider2D>();
            left1 = player.transform.FindChild("LeftHitBox").gameObject;
            BoxCollider2D bcLeft1 = left1.GetComponent<BoxCollider2D>();
            md = new MeeleDetails(pScript.manaMelee, pScript.setMeleeAttack, bcLeft1.offset.x, bcLeft1.size.x, bcRight1.offset.x, bcRight1.size.x, bcLeft1.offset.y, bcLeft1.size.y, bcRight1.offset.y, bcRight1.size.y);
            Update();
        }
        public void Update()
        {

            Health = pScript.getHitPoints();
            Mana = pScript.getManaPoints();
            x = player.transform.position.x;
            y = player.transform.position.y;
            Blocking = pScript.isBlocking;
            Jumping = pScript.jumping;
            if (meele != null)
            {
                if (!isAttacking())
                {
                    meele = null;
                }
            }
            else
            {
                if (isAttacking())
                {
                    if (right1.activeSelf)
                    {
                        meele = new Meele(md, 0, this);
                    }
                    else
                    {
                        meele = new Meele(md, 1, this);
                    }
                }
            }
        }
    }
    public class ProjectileDetails
    {
        private int speed;              //right now only in the x direction
        private int manaCost;           //cost of firing a mana 
        private int healthCost;         //cost to other players health
        public ProjectileDetails(int speed, int healthCost, int manaCost)
        {
            this.speed = speed;
            this.healthCost = healthCost;
            this.manaCost = manaCost;
        }

        //gets speed proj goes at
        public int getSpeed()
        {
            return speed;
        }
        //get how much mana the player looses
        public int getManaCost()
        {
            return manaCost;
        }
        //returns how much the attack affects the other Player
        public int gethealthCost()
        {
            return healthCost;
        }
    }
    //Stores each Projectile here
    public class Projectile
    {
        private float locationX;          //the location it was fired from in the X direction
        private float locationY;          //the location it was fired from in the y direction
        private int direction;          //postive 1 for right and -1 for left
        private GameObject projectile;  //the projectile itself
        private ProjectileDetails pd;   //stores the Projectile details in this form.

        public Projectile(int direction, GameObject projectile, ProjectileDetails pd)
        {
            this.direction = direction;
            this.projectile = projectile;
            this.pd = pd;
            locationX = projectile.transform.position.x;
            locationY = projectile.transform.position.y;
        }

        //gets speed proj goes at
        public int getSpeed()
        {
            return pd.getSpeed();
        }
        //get how much mana the player looses
        public int getManaCost()
        {
            return pd.getManaCost();
        }
        //returns how much the attack affects the other Player
        public int gethealthCost()
        {
            return pd.gethealthCost();
        }
        public GameObject getProjectile()
        {
            return projectile;
        }
        public float getLocationX()
        {
            return locationX;
        }
        public void setLocationX(float locationX)
        {
            this.locationX = locationX;
        }
        public float getLocationY()
        {
            return locationY;
        }
        public int getDirection()
        {
            return direction;
        }
    }
    //Stores the basic info of a Meele for each player
    //TODO something to redo boxes like maybe find width effected
    public class MeeleDetails
    {
        public int manaCost;            //cost of firing a mana 
        public int healthCost;          //cost to other players health
        public float offsetXLeft;       //offset of the box comapared to the center of the Players Location
        public float sizeXLeft;         //size of box in the X plane
        public float offsetXRight;      //offset of the box comapared to the center of the Players Location
        public float sizeXRight;        //size of box in the X plane
        public float offsetYLeft;       //offset of the box comapared to the center of the Players Location
        public float sizeYLeft;         //size of box in the Y plane
        public float offsetYRight;      //offset of the box comapared to the center of the Players Location
        public float sizeYRight;        //size of box in the Y plane
        public MeeleDetails(int manaCost, int healthCost, float offsetXLeft, float sizeXLeft, float offsetXRight, float sizeXRight, float offsetYLeft, float sizeYLeft, float offsetYRight, float sizeYRight)
        {
            this.manaCost = manaCost;
            this.healthCost = healthCost;
            this.offsetXLeft = offsetXLeft;
            this.sizeXLeft = sizeXLeft;
            this.offsetXRight = offsetXRight;
            this.sizeXRight = sizeXRight;
            this.offsetYLeft = offsetYLeft;
            this.sizeYLeft = sizeYLeft;
            this.offsetYRight = offsetYRight;
            this.sizeYRight = sizeYRight;
        }
    }
    //Stores each Meele attack here
    public class Meele
    {
        private MeeleDetails mD;    //the Details of the meele attack for a specifc player is stored here  
        private float minX;           //minX affected by attack
        private float maxX;           //maxX affeected by attack
        private float minY;           //minY affected by attack
        private float maxY;           //maxY affected by attack
        //int side attacked from 0 for right, 1 for left
        //int player 1 for player 1 2 for player 2
        //TODO have not tested this method
        public Meele(MeeleDetails mD, int side, PlayerInfo pi)
        {
            this.mD = mD;
            if (side == 0)
            {
                minX = pi.x + mD.offsetXRight - (mD.sizeXRight / 2);
                maxX = pi.x + mD.offsetXRight + (mD.sizeXRight / 2);
                minY = pi.y + mD.offsetYRight - (mD.sizeYRight / 2);
                maxY = pi.y + mD.offsetYRight + (mD.sizeYRight / 2);
            }
            else
            {
                minX = pi.x + mD.offsetXLeft - (mD.sizeXLeft / 2);
                maxX = pi.x + mD.offsetXLeft + (mD.sizeXLeft / 2);
                minY = pi.y + mD.offsetYLeft - (mD.sizeYLeft / 2);
                maxY = pi.y + mD.offsetYLeft + (mD.sizeYLeft / 2);
            }
        }
        public int getManaCost()
        {
            return mD.manaCost;
        }
        public int getHealthCost()
        {
            return mD.healthCost;
        }
        public float getMinX()
        {
            return minX;
        }
        public float getMaxX()
        {
            return maxX;
        }
        public float getMinY()
        {
            return minY;
        }
        public float getMaxY()
        {
            return maxY;
        }
    }

    //methods to get different objects
    //TODO put checks to make sure number is valid

    //Returns the width of the course that this script is on
    public float getCourseWidth()
    {
        return width;
    }
    //Returns Player X current Health
    public int getpXHeath(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return -1;
        }
        return pi[x].Health;
    }
    //Returns Player x current Mana
    public int getpXMana(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return -1;
        }
        return pi[x].Mana;
    }
    //Returns Player X current y postion
    public float getpXY(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return -1;
        }
        return pi[x].y;
    }
    //Returns Player X current X postion
    public float getpXX(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return -1;
        }
        return pi[x].x;
    }
    //returns the cost to mana for blocking for Player X
    public int getCostManaBlockPX(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return -1;
        }
        return pi[x].costManaBlock;
    }
    //is player X jumping right now
    public bool isPXJumping(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return false;
        }
        return pi[x].Jumping;
    }
    //is Player x Blocking
    public bool isPXBlocking(int x)
    {
        //check to make sure x is valid
        if (x < 0 || x > numberPlayers)
        {
            return false;
        }
        return pi[x].Blocking;
    }
    //TODO set up way to call update and call other things for each one
    // Use this for initialization
    void Start() {
        numberPlayers = playersGameObjects.Length;
        pi = new PlayerInfo[numberPlayers];
        int i = 0;
        foreach (GameObject p in playersGameObjects)
        {
            pi[i++] = new PlayerInfo(p);
        }
        //sets up to find width of course assuming it has a boundry
        EdgeCollider2D c1 = edgeColider.GetComponents<EdgeCollider2D>()[0];
        EdgeCollider2D c2 = edgeColider.GetComponents<EdgeCollider2D>()[1];
        width = System.Math.Abs(c1.bounds.center.x - c2.bounds.center.x);
    }

    // Update is called once per frame
    void Update() {
        foreach (PlayerInfo p in pi)
        {
            p.Update();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            buildArray();
            printArena();
        }
    }
    public int[] buildArray()
    {

        arena = new int[(int)(4 * width * 10 * 4)];
        //this will go through the base row
        for (int j = 0; j < 4 * width; j++)
        {
            //put in array the ground
            arena[j] = 1;
        }
        //int to allow me to know which player we are on for storing its info in the top of the array
        //int a = 0;
        foreach (PlayerInfo p in pi)
        {
            // x and y are centers
            float normalizeX = p.x * 4 + width * 2;     //the normalation of the x to use in arena corninates
            int x = (int)normalizeX / 1;
            float normalizeY = (p.y * 4);         //normalation of the y add 1 to it because 0 is the ground
            int y = (int)normalizeY;
            //TODO maybe convert this to deal with variables and not hardcoded units
            //since it is 2 wide and 5 high we can hardcode it add these
            //deals with adding all the width to the user goes from one to the left to one to the right 
            for (int k = -1 * 4; k < 1 * 4; k++)
            {
                //to go from bottom of the user to top
                for (int l = -10; l < 10; l++)
                {
                    if ((k + x) + ((int)(l + y - 1) * ((int)width) * 4) >= arena.Length)
                    {
                        continue;
                    }
                    //come up with a way to tell what player this is, player playing or not
                    arena[(k + x) + ((l + y + 2) * ((int)width) * 4)] = 5;
                }
            }
            if (p.isAttacking())
            {
                Debug.Log("Attacked");
                // converted min and max squares to mark as attacked
                int minX = (int) (p.meele.getMinX()*4 + width * 2);
                int maxX = (int) ((p.meele.getMaxX()*4) + width *2);
                int minY = (int)(p.meele.getMinY()*4) +1;
                int maxY = (int)(p.meele.getMaxY()*4)+1;
                
                for (int i = minX; i < maxX; i++)
                {
                    for (int j = minY+1;j < maxY; j++)
                    {
                        arena[i + (j * ((int)width) * 4)] = 6;
                    }
                }
            }
            /*//a times 4 is becuase we have 4 items putting in front of it
            //this should be finding the last row
            int start =  (arena.Length - (int)(width*4)-1) + a*4;
            arena[start] = p.Blocking ? 1 : 0;
            arena[start + 1] = p.Jumping ? 1 : 0;
            arena[start + 2] = p.Health;
            arena[start + 3] = p.Mana;*/
        }
        return arena;
    } 
}