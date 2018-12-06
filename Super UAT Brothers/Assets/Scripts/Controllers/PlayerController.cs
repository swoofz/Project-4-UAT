using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

    private float moveX;
    private int jumpMax;

	// Use this for initialization
	void Start () {
        jumpMax = jumpCount;
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxis("Horizontal") * speed;
        isGrounded = pawn.IsGrounded();
        Debug.Log(isGrounded);

        if (isGrounded && !Input.GetKeyDown(KeyCode.Space)) {
            jumpCount = jumpMax;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0) {
            pawn.Jump(jumpForce);
            jumpCount -= 1;
        }
        
        pawn.SideMovement(moveX);
	}
}
