using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour {

    private Text lives; // Create a variable for our lives text

	// Use this for initialization
	void Start () {
        lives = GetComponent<Text>();   // set our text component into a variable
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "Lives: " + GameManager.instance.playerLives; // update how many lives we have
	}
}
