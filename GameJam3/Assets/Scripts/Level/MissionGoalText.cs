using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionGoalText : MonoBehaviour {
    Text missionGoal;
    float timer, amountOfTime;
    // Use this for initialization
    private void Awake()
    {
        missionGoal = gameObject.GetComponent<Text>();
        amountOfTime = 5;
    }

    void Start () {
        switch (OverworldPopup.missionType)
        {
            case "Defend":
                missionGoal.text = "Defend the civilians";
                break;
            case "Kill Count":
                missionGoal.text = "Kill the zombies in the area";
                break;
            case "Rescue":
                missionGoal.text = "Rescue the civilians and escort them to the bus";
                break;
            default:
                missionGoal.text = "";
                break;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer < amountOfTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
