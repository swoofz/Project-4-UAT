using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour {

    private Text lives;

	// Use this for initialization
	void Start () {
        lives = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "Lives: " + GameManager.instance.playerLives;
	}
}
