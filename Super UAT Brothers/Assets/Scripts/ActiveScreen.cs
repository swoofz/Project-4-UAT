using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScreen : MonoBehaviour {

    public GameObject winScreen, loseScreen;
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.win) {
            winScreen.SetActive(true);
            GameManager.instance.win = false;
        }

        if (GameManager.instance.lose) {
            loseScreen.SetActive(true);
            GameManager.instance.lose = false;
        }
	}
}
