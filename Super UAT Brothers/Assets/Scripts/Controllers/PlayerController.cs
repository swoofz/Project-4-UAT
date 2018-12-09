using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    private float moveX;            // Create a variable to get direction of motion
    private int jumpMax;            // Create a variable to get max number of jumps player has
    private States playerState;     // Create a variable to get the player state
    private string currentState;    // Create a variable to get the current player state

	// Use this for initialization
	void Start () {
        jumpMax = jumpCount;    // Set max jumps to how many jumps we have
        jumpCount = 0;          // Set intial jumpCount to 0 until reset
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxis("Horizontal") * speed;    // get direction to move
        SetState();                                     // set players state


        if (pawn.IsGrounded() && !Input.GetKeyDown(KeyCode.Space)) {    // if player is grounded and not pressing space
            jumpCount = jumpMax;                                        // reset jump count
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0) { // if pressing space and the jump count is less then 0
            pawn.Jump(jumpForce);                               // jump
            jumpCount -= 1;                                     // take away a jump
        }

        if (!pawn.IsGrounded()) {   // if player is not on the ground
            pawn.JumpThru();        // player can jump through a platform can allows that
        }

        currentState = pawn.ChangeState(playerState);   // get player state
        pawn.ChangeAnimation(currentState);             // change player animation
        
        pawn.SideMovement(moveX);   // move player




        // Pause Game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause.isPaused = !Pause.isPaused;
        }
	}

    void SetState() {
        if (moveX == 0) {               // if not moving
            playerState = States.Idle;  // set player state to idle
        } else {                        // Otherwise
            playerState = States.Walk;  // set player state to walk
        }

        if (!pawn.IsGrounded()) {       // if player is not on the ground
            playerState = States.Jump;  // set player state to jump
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "CheckPoints") {                // if collide with a checkpoint
            GameManager.instance.checkPoint = collision.gameObject;     // set our checkpoint in the game manager
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "JumpThru") {   // if leave a collider with a jumpthru object
            collision.isTrigger = false;                // set it trigger to false
        }
    }
}
