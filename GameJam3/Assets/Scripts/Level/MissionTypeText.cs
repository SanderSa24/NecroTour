using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTypeText : MonoBehaviour {
    Text typeOfMissionText;
	// Use this for initialization
	void Awake () {
        typeOfMissionText = gameObject.GetComponent<Text>();
	}

    void Start()
    {
        if(OverworldPopup.missionType != null)
        typeOfMissionText.text = OverworldPopup.missionType;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
