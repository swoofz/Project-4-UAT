using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

    void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }

    // Menu Actions
    public void PlayGame() {
        GameManager.instance.gameIsRunning = true;
        LoadLevel("Level_01");
    }

    public void GoToStart() {
        LoadLevel("Start");
    }

    public void PauseGame(GameObject pauseMenu) {
        if (pauseMenu.activeSelf) {
            pauseMenu.SetActive(false);
            GameManager.instance.gameIsRunning = false;
            Time.timeScale = 1;
        } else {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            GameManager.instance.gameIsRunning = true;
        }
    }

    public void QuitGame() {
        Application.Quit(); // Close the application
    }

}
