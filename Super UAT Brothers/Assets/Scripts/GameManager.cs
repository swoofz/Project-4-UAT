﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;             // Create Singleton

    public int playerLives;


    [HideInInspector] public List<PickUp> coins;
    [HideInInspector] public List<PickUp> keys;
    [HideInInspector] public int startLives;
    [HideInInspector] public string playerState;
    [HideInInspector] public GameObject checkPoint;
    [HideInInspector] public bool gameIsRunning, gameOver;
    [HideInInspector] public bool playerDied;
    [HideInInspector] public bool win, lose;
    [HideInInspector] public int coinCount, keyCount;

    private GameObject player;
    private Vector3 startLocation;

    void Awake() {
        if (instance != null) {     // If there is an Game Manager instance
            Destroy(gameObject);    // Destory new one
        } else {                            // Otherwise
            instance = this;                // Set instance to this Game Manager
            DontDestroyOnLoad(gameObject);  // Don't destory this when going to new scenes
        }
    }

    // Use this for initialization
    void Start () {
        startLives = playerLives;
    }
	
	// Update is called once per frame
	void Update () {
        gameIsRunning = CheckScene();

        if (gameIsRunning && !gameOver) {    // if the game is running

            if (player == null) {
                FindPlayer();
            }

            if (playerDied) {
                if (playerLives > 0) {
                    playerLives -= 1;
                    RespawnAtCheckPoint();
                } else {
                    gameOver = true;
                }

                playerDied = false;
            }




            if (Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene("Level_02");
            }

            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("Level_01");
            }
        }

        if (gameOver) {
            lose = true;
            gameOver = false;
        }
    }

    bool CheckScene() {
        for (int i = 0; i < SceneManager.sceneCount; i++) {
            if (SceneManager.GetActiveScene().name == "Start") {
                return false;
            }
        }

        return true;
    }

    void RespawnAtCheckPoint() {
        if (checkPoint != null) {
            player.transform.position = checkPoint.transform.position + Vector3.up;
        } else {
            player.transform.position = startLocation;
        }
    }


    void FindPlayer() {
        if (FindObjectOfType<PlayerController>() != null) {
            player = FindObjectOfType<PlayerController>().gameObject;
            startLocation = player.transform.position;
        }
    }
}
