using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMissionText : MonoBehaviour {
    Text loseText;
    string objectiveFailedText;
    // Use this for initialization
    void Awake()
    {
        loseText = gameObject.GetComponent<Text>();
    }

    private void Start()
    {
        switch (GameVariables.typeMission[MissionManagementScript.currentMissionIndex])
        {
            case "Defend":
                objectiveFailedText = "You have failed to defend the civilians!";
                break;
            case "Kill Count":
                objectiveFailedText = "You have failed to kill the zombies!";
                break;
            case "Rescue":
                objectiveFailedText = "You have failed to rescue the civilians!";
                break;
        }

        loseText.text = "Mission Failed!\n" + objectiveFailedText;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
