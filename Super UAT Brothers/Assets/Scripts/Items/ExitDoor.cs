using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public bool lastLevel;                          // Create a variable to set the last level
    public SpriteRenderer doorTop, doorBottom;      // Create variables to get the spriteRenderer from
    public Sprite closeDoorTop, closeDoorBottom;    // Create variables to add new sprites

    private int keysCollected, keyToGet;    // Create variables to get the amount of keys have and to get
    private bool doorOpen;                  // create a variable to open the door

	
	// Update is called once per frame
	void Update () {
        keysCollected = GameManager.instance.keyCount;  // set our key collected variable to the amount of key the player collected
        keyToGet = GameManager.instance.keys.Count;     // set our key to get variable to how many keys are in the scene

        if (doorOpen) {                                 // if the door is open
            GameManager.instance.goThroughDoor = true;  // go through the door to the next level
        }
	}

    void ChangeDoor() {
        // Create a new sprite
        doorTop.sprite = closeDoorTop;
        doorBottom.sprite = closeDoorBottom;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.transform.parent != null) {                        // if the thing that collide with have a parent object
            GameObject target = collision.gameObject.transform.parent.gameObject;   // set the parent object into a variable for easy access

            if (target.tag == "Player") {           // if our target is a player

                if (keysCollected == keyToGet) {                    // if our player has all the keys
                    ChangeDoor();                                   // change the door sprite
                    GameManager.instance.lastLevel = lastLevel;     // set if this door is the last level in the game manager
                    doorOpen = true;                                // open door
                }
            }
        }
    }
}
