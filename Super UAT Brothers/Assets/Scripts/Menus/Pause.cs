using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool isPaused;    // Create a variable to check if game is paused
    public GameObject pause;        // Create a variable to store our pause menu

    void Update() {
        if (isPaused) {     // if game is paused
            PauseGame();    // pause game
        } else {            // otherwise
            UnPauseGame();  // unpause game
        }
    }

    public void PauseGame() {
        pause.SetActive(true);  // active pause menu
        Time.timeScale = 0;     // stop motion
    }

    public void UnPauseGame() {
        pause.SetActive(false); // deactive pause menu
        Time.timeScale = 1;     // set motion back to normal
        isPaused = false;       // reset pause value
    }

}
