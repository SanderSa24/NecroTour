using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
    Text gameOverText;
    string daysText;
	// Use this for initialization
	void Awake () {
        if(GameVariables.currentDay == 1)
        {
            daysText = " day";
        }
        else
        {
            daysText = " days";
        }
        gameOverText = gameObject.GetComponent<Text>();
        gameOverText.text = "Game over!\n" + "You have survived for " + GameVariables.currentDay + daysText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
