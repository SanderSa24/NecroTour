using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMissionText : MonoBehaviour {
    Text winText;
    string objectiveCompletedText;
	// Use this for initialization
	void Awake () {
        winText = gameObject.GetComponent<Text>();
	}

    private void Start()
    {
        switch (GameVariables.typeMission[MissionManagementScript.currentMissionIndex])
        {
            case "Defend":
                objectiveCompletedText = "You have defended the civilians!";
                break;
            case "Kill Count":
                objectiveCompletedText = "You have killed the zombies!";
                break;
            case "Rescue":
                objectiveCompletedText = "You have rescued the civilians!";
                break;
        }

        winText.text = "Mission Completed!\n" + objectiveCompletedText;
    }

    // Update is called once per frame
    void Update () {

        
	}
}
