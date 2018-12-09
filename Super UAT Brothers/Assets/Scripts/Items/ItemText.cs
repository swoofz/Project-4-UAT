using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemText : MonoBehaviour {

    public Text coinText, keyText;  // Create variables to get text element
	
	// Update is called once per frame
	void Update () {
        // Change text values depending on the game
        coinText.text = "Coins: " + GameManager.instance.coinCount + "/" + GameManager.instance.coins.Count;
        keyText.text = "Keys: " + GameManager.instance.keyCount + "/" + GameManager.instance.keys.Count;
    }
}
