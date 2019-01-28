using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonText : MonoBehaviour {
    Text startButtonText;
	// Use this for initialization
	void Awake () {
        startButtonText = gameObject.GetComponent<Text>();
	}

    private void Start()
    {
        if (!GameVariables.startedGame)
        {
            startButtonText.text = "Start Game";
        }
        else
        {
            startButtonText.text = "Continue";
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}
