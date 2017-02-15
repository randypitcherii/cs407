using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_player : MonoBehaviour, PlayerInterface
{
    private bool isFlipped;
    public float speed;
    private Animator anim;
    private bool needFlip;
    public Rigidbody2D rb;
    private bool jumping;
	// Use this for initialization
	public void Start () {
        isFlipped = false;
        anim = GetComponent<Animator>();
    }

    public float getSpeed()
    {
        return speed;
    }
    public void Update()
    {
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
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("State", 1);
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
    }
}