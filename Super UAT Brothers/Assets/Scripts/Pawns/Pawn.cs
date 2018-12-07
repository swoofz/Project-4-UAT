using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

    public virtual void FlipSprite(float direction) {
        // Get the SpriteRenderer component and store it in a variable
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (direction > 0) {        // Going right
            sr.flipX = false;       // Set to original direction on x-axis
        } else if (direction < 0) { // Going left
            sr.flipX = true;        // Flip sprite on x-axis
        }
    }

    public virtual void SideMovement(float direction) {
        Transform tf = transform;           // Create a variable for our transfrom
            
        if (transform.parent != null) { // If our transfrom has a parent transfrom
            tf = transform.parent;      // Set our transfrom variable to our parent
        }

        FlipSprite(direction);                                      // Flip our sprites x-axis basic on the direction we are going
        tf.position += Vector3.right * direction * Time.deltaTime;  // Move right or left
    }

    public virtual void Jump(float jumpForce) {
        Transform tf = transform;   // Create a variable to store our transform
        if (tf.parent != null) {    // if our transform has a parent
            tf = tf.parent;         // Set our transform to the parent transform
        }

        Rigidbody2D rb = tf.GetComponent<Rigidbody2D>();    // Create a variable to store our transform
        rb.AddForce(Vector2.up * jumpForce * 100);          // Add upward force to ourselves
    }

    public virtual bool IsGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f); // See if anything is below us

        if (hit.collider != null) {             // if we hit anything
            string name = hit.collider.name;    // create a variable for what we hit to make it easy to use
            if (name == "Floor") {              // if we hit the floor
                return true;                    // return true
            }
        }
                        // Otherwise
        return false;   // return false
    }

    public virtual string ChangeState(Controller.States state) {
        return state.ToString();
    }

    public virtual void ChangeAnimation(string state) {
        Animator anim = GetComponent<Animator>();
        anim.Play(state);
    }
}
