using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pawn.SideMovement(speed);
        pawn.FlipSprite(speed);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "EnemyWalls") {
            speed *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject target = collision.gameObject;
        if (target.tag == "Player") {
            GameManager.instance.playerDied = true;
        }
    }
}
