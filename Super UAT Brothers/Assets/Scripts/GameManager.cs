using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;             // Create Singleton

    [HideInInspector]
    public string playerState;

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
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
