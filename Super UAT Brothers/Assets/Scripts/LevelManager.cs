using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    //private int lives;

    void Awake() {
        if (instance != null) {     // If there is an Level Manager instance
            Destroy(gameObject);    // Destory new one
        } else {                            // Otherwise
            instance = this;                // Set instance to this Game Manager
            DontDestroyOnLoad(gameObject);  // Don't destory this when going to new scenes
        }
    }

    // Use this for initialization
    void Start() {
        
    }


    public void LoadLevel(string level) {
        GameManager.instance.coinCount = 0;
        GameManager.instance.keyCount = 0;
        SceneManager.LoadScene(level);
        CheckLevel(level);
    }

    public void QuitGame() {
        Application.Quit();
    }

    void CheckLevel(string level) {
        if (level == "Level_01") {
            ResetGame();
        }
    }

    void ResetGame() {
        GameManager.instance.playerLives = GameManager.instance.startLives;
    }
}
