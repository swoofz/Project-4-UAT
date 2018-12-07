using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;             // Create Singleton

    [HideInInspector]
    public string playerState;
    [HideInInspector]
    public GameObject checkPoint;


    private GameObject player;
    private Vector3 startLocation;

    void Awake() {
        if (instance != null) {     // If the is an Game Manager instance
            Destroy(gameObject);    // Destory new one
        } else {                            // Otherwise
            instance = this;                // Set instance to this Game Manager
            DontDestroyOnLoad(gameObject);  // Don't destory this when going to new scenes
        }
    }

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>().gameObject;
        startLocation = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            RespawnAtCheckPoint();
        }
	}


    void RespawnAtCheckPoint() {
        if (checkPoint != null) {
            player.transform.position = checkPoint.transform.position + Vector3.up;
        } else {
            player.transform.position = startLocation;
        }
    }
}
