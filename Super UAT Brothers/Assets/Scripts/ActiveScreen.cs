using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScreen : MonoBehaviour {

    public GameObject winScreen, loseScreen;
    private bool setActive;
	
	// Update is called once per frame
	void Update () {
        if (setActive) {
            winScreen.SetActive(false);
        }

        if (GameManager.instance.win) {
            winScreen.SetActive(true);
            GameManager.instance.win = false;
            setActive = true;
        }

        if (GameManager.instance.lose) {
            loseScreen.SetActive(true);
            GameManager.instance.lose = false;
        }
	}

    // onclick action
    public void DeactiveScreen() {
        winScreen.SetActive(false);
    }
}
