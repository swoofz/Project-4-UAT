using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScreen : MonoBehaviour {

    public GameObject winScreen, loseScreen;    // Create variables to get our screens
    private bool setActive;                     // Create a variable change active state
	
	// Update is called once per frame
	void Update () {
        if (setActive) {                    // if active
            winScreen.SetActive(false);     // deactivate win screen
        }

        if (GameManager.instance.win) {         // if won game
            winScreen.SetActive(true);          // activate win screen
            GameManager.instance.win = false;   // reset win value
            setActive = true;                   // set active
        }

        if (GameManager.instance.lose) {        // if lost the game
            loseScreen.SetActive(true);         // activate the lose screen
            GameManager.instance.lose = false;  // reset lose value
        }
	}

    // onclick action
    public void DeactiveScreen() {
        winScreen.SetActive(false); // deactivate win screen
    }
}
