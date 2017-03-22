using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour {
    // Use this for initialization
    public int attackStrength = 0;
    public Location_Script ls;
    public GameObject camera;
    //allows the attack Streght to be set on fire
    public void setAttackStrenght(int x)
    {
        this.attackStrength = x;
        ls = camera.GetComponent<Location_Script>();
    }
    public int getAttackStrenght()
    {
        return attackStrength;
    }
    void Start () {
        ls.addRanged(this.gameObject);
	}
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Out of Bonds Collider")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update() {

	}
    void LateUpdate() {
        transform.parent = null;
    }
}
