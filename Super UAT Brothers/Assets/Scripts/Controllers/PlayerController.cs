using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    private float moveX;
    private int jumpMax;
    private States playerState;
    private string currentState;

	// Use this for initialization
	void Start () {
        jumpMax = jumpCount;
        jumpCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        playerState = States.Idle;
        moveX = Input.GetAxis("Horizontal") * speed;
        isGrounded = pawn.IsGrounded();

        if (moveX > 0 || moveX < 0) {
            playerState = States.Walk;
        }


        if (isGrounded && !Input.GetKeyDown(KeyCode.Space)) {
            jumpCount = jumpMax;
        }

        if (!isGrounded) {
            playerState = States.Jump;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0) {
            pawn.Jump(jumpForce);
            jumpCount -= 1;
        }

        currentState = pawn.ChangeState(playerState);
        pawn.ChangeAnimation(currentState);
        
        pawn.SideMovement(moveX);
	}
}
