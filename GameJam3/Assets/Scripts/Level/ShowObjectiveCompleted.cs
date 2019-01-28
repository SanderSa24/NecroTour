using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectiveCompleted : MonoBehaviour {
    float timer, amountOfTime;
    GameObject objectiveCompletedText;
    // Use this for initialization
    void Awake () {
        amountOfTime = 5;
        objectiveCompletedText = GameObject.Find("ObjectiveCompletedText");
        objectiveCompletedText.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (FindObjectOfType<BusRescue>().missionStatus == "win")
        {
            if (timer < amountOfTime)
            {
                objectiveCompletedText.SetActive(true);
                timer += Time.deltaTime;
            }
            else
            {
                objectiveCompletedText.SetActive(false);
            }
        } 
    }
}
