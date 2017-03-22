using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour {
    // Use this for initialization
    public int attackStrength = 0;
    
    
    //allows the attack Streght to be set on fire
    public void setAttackStrenght(int x)
    {
        this.attackStrength = x;
        
    }
    public int getAttackStrenght()
    {
        return attackStrength;
    }
    void Start () {
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
