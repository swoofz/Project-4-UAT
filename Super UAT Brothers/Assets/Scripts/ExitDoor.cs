using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    public bool lastLevel;
    public SpriteRenderer doorTop, doorBottom;
    public Sprite closeDoorTop, closeDoorBottom;

    private int keysCollected, keyToGet;
    private bool doorOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keysCollected = GameManager.instance.keyCount;
        keyToGet = GameManager.instance.keys.Count;
        if (doorOpen) {
            GameManager.instance.goThroughDoor = true;
        }
	}

    void ChangeDoor() {
        doorTop.sprite = closeDoorTop;
        doorBottom.sprite = closeDoorBottom;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.transform.parent != null) {
            GameObject target = collision.gameObject.transform.parent.gameObject;

            if (target.tag == "Player") {
                if (keysCollected == keyToGet) {
                    ChangeDoor();
                    GameManager.instance.lastLevel = lastLevel;
                    doorOpen = true;
                }
            }
        }
    }
}
