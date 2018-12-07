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
        moveX = Input.GetAxis("Horizontal") * speed;
        SetState();


        if (pawn.IsGrounded() && !Input.GetKeyDown(KeyCode.Space)) {
            jumpCount = jumpMax;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0) {
            pawn.Jump(jumpForce);
            jumpCount -= 1;
        }

        currentState = pawn.ChangeState(playerState);
        pawn.ChangeAnimation(currentState);
        
        pawn.SideMovement(moveX);
	}

    void SetState() {
        if (moveX == 0) {
            playerState = States.Idle;
        } else if (moveX > 0 || moveX < 0) {
            playerState = States.Walk;
        }

        if (!pawn.IsGrounded()) {
            playerState = States.Jump;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "CheckPoints") {
            GameManager.instance.checkPoint = collision.gameObject;
        }
    }
}
