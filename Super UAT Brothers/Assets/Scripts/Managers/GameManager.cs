using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;             // Create Singleton

    public int playerLives;     // Create a variable to set the players lives


    [HideInInspector] public List<PickUp> coins;                // Create a list of coin items
    [HideInInspector] public List<PickUp> keys;                 // Create a list of key items
    [HideInInspector] public int startLives;                    // Create a variable for player start lives
    [HideInInspector] public string playerState;                // Create a variable to check player's state
    [HideInInspector] public GameObject checkPoint;             // Create a variable to store our last checkpoint object
    [HideInInspector] public bool gameIsRunning;                // Create a variable to see if the game is running
    [HideInInspector] public bool playerDied;                   // Create a variable to see if player died
    [HideInInspector] public bool goThroughDoor, lastLevel;     // Create variables to get scene changes
    [HideInInspector] public bool win, lose;                    // Create variables to check win conditions
    [HideInInspector] public int coinCount, keyCount;           // Create variables to key track of items collected

    private GameObject player;      // Create a variable to get our player object
    private Vector3 startLocation;  // Create a variable to get our player start location
    private SoundManger sm;         // Create a variable to get our sound manager
    private AudioSource AS;         // Create a variable to get our audio source

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
        startLives = playerLives;           // set our start lives
        sm = GetComponent<SoundManger>();   // get our sound manager componenet
        AS = GetComponent<AudioSource>();   // get our auido source component
    }
	
	// Update is called once per frame
	void Update () {
        gameIsRunning = CheckScene();   // see if game is running

        if (gameIsRunning) {    // if the game is running

            if (player == null) {   // if player is null
                FindPlayer();       // find the player object
            }

            if (playerDied) {                               // if player died
                if (playerLives > 0) {                      // if player has lives
                    playerLives -= 1;                       // take away a life
                    RespawnAtCheckPoint();                  // respawn player
                    PlaySoundEffect(sm.playerHit, 0.1f);    // play hit sound
                } else {                                    // otherwise
                    PlaySoundEffect(sm.playerDeath, 1f);    // play death sound
                    lose = true;                            // lose game
                }

                playerDied = false; // reset value 
            }

            if (goThroughDoor) {                            // if player goes through door
                if (!lastLevel) {                           // if not the last level
                    ResetCounts();                          // reset the key and coin count
                    SceneManager.LoadScene("Level_02");     // go to next level
                } else {                                    // otherwise
                    win = true;                             // you won the game
                }

                goThroughDoor = false;      // reset value
            }
        }
    }

    bool CheckScene() {
        for (int i = 0; i < SceneManager.sceneCount; i++) {         // go through all scenes
            if (SceneManager.GetActiveScene().name == "Start") {    // if the scene is the start scene
                return false;                                       // return false
            }
        }
                        // Otherwise
        return true;    // return true
    }

    void RespawnAtCheckPoint() {
        if (checkPoint != null) {                                                       // if there is a checkpoint
            player.transform.position = checkPoint.transform.position + Vector3.up;     // respawn player at the checkpoint
        } else {                                                                        // Otherwise
            player.transform.position = startLocation;                                  // respawn player at the start location
        }
    }


    void FindPlayer() {
        if (FindObjectOfType<PlayerController>() != null) {             // if can find a playercontroller component
            player = FindObjectOfType<PlayerController>().gameObject;   // set player object
            startLocation = player.transform.position;                  // set start location of that player
        }
    }

    void ResetCounts() {
        // Reset Values
        coinCount = 0;
        keyCount = 0;
        coins = new List<PickUp>();
        keys = new List<PickUp>();
    }

    void PlaySoundEffect(AudioClip clip, float volume) {
        // Player sound Effects
        AS.clip = clip;
        AS.volume = volume;
        AS.Play();
    }
}
