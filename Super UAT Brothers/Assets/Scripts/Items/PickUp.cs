using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public ItemText text;       // Create a variable for pick text
    private AudioSource AS;     // Create a variable for our audioSource

    // Use this for initialization
    void Start() {
        if (gameObject.tag == "Coin") {             // if this object is a coin
            GameManager.instance.coins.Add(this);   // add to the coin list in the game manager
        }
        if (gameObject.tag == "Key") {              // if this object is a key
            GameManager.instance.keys.Add(this);    // add to the key list in the game manager
        }

        AS = GetComponent<AudioSource>();   // set our audioSource into a variable
    }

    void PickUpItem(string item) {
        if (item == "Coin") {                       // if item is a coin
            GameManager.instance.coinCount += 1;    // add a coin to how many coins we have
        }
        if (item == "Key") {                        // if item is a key
            GameManager.instance.keyCount += 1;     // add a key to how many keys we have
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.transform.parent != null) {                             // if collide with an object that has a parent object
            if (collision.gameObject.transform.parent.gameObject.tag == "Player") {     // if that parent object is a player
                PickUpItem(gameObject.tag);                                             // pick up our item
                AudioSource.PlayClipAtPoint(AS.clip, gameObject.transform.position);    // play our pick sound
                Destroy(gameObject);                                                    // destory object
            }
        }
    }
}
