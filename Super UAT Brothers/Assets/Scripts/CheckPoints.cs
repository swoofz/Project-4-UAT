using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

    private Collider2D boxCollider;

    // Use this for initialization
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject target = collision.gameObject;
        if (collision.gameObject.transform.parent != null) {
            target = collision.gameObject.transform.parent.gameObject;
        }

        if (target.tag == "Player") {
            boxCollider.enabled = false;
            // TODO:: Set Animation
        }
    }
}
