using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller {
	
	// Update is called once per frame
	void Update () {
        pawn.SideMovement(speed);   // move enemy left or right
        pawn.FlipSprite(speed);     // change sprite look direction
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "EnemyWalls") { // if collide with an enemy wall
            speed *= -1;                                // go the other direction
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject target = collision.gameObject;       // create a variable to get our target that we collide with
        if (target.tag == "Player") {                   // if our target is a player
            GameManager.instance.playerDied = true;     // set player diead in game manager
        }
    }
}
