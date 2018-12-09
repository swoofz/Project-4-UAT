using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Pawn {

    public override void SideMovement(float direction) {
        Transform tf = transform;           // Create a variable for our transfrom

        if (transform.parent != null) { // If our transfrom has a parent transfrom
            tf = transform.parent;      // Set our transfrom variable to our parent
        }

        FlipSprite(direction);                                     // Flip our sprites x-axis basic on the direction we are going
        tf.position += Vector3.left * direction * Time.deltaTime;  // Move right or left
    }

}
