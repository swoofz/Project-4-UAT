using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool isPaused;
    public GameObject pause;

    void Update() {
        if (isPaused) {
            PauseGame();
        } else {
            UnPauseGame();
        }
    }

    public void PauseGame() {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame() {
        pause.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

}
