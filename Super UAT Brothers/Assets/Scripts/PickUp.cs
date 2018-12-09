using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public ItemText text;

    // Use this for initialization
    void Start() {
        if (gameObject.tag == "Coin") {
            GameManager.instance.coins.Add(this);
        }
        if (gameObject.tag == "Key") {
            GameManager.instance.keys.Add(this);
        }
    }

    void PickUpItem(string item) {
        if (item == "Coin") {
            GameManager.instance.coinCount += 1;
        }
        if (item == "Key") {
            GameManager.instance.keyCount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.transform.parent != null) {
            if (collision.gameObject.transform.parent.gameObject.tag == "Player") {
                PickUpItem(gameObject.tag);
                Destroy(gameObject);
            }
        }
    }
}
