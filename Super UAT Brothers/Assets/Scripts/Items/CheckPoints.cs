using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

    private Collider2D boxCollider;     // Create a variable to store our collider
    private Animator anim;              // Create a variable to store our animator to set animation

    // Use this for initialization
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();    // get our boxcollider
        anim = GetComponent<Animator>();                // get our animator
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject target = collision.gameObject;                       // create a variable to get our target that we collide with
        if (target.transform.parent != null) {                          // if our target has a parent object
            target = collision.gameObject.transform.parent.gameObject;  // set our target to the parent object
        }

        if (target.tag == "Player") {       // if our target is a player
            boxCollider.enabled = false;    // diable our collider
            anim.Play("Wave");              // play the wave animation      
        }
    }
}
