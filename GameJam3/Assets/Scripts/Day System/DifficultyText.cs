using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyText : MonoBehaviour {

    Text difficultyText;
    // Use this for initialization
    void Start () {
        difficultyText = GetComponent<Text>();
       // Debug.Log("mission index :"+MissionManagementScript.currentMissionIndex);
    }
	
	// Update is called once per frame
	void Update () {
        difficultyText.text = "" + GameVariables.difficultyLevel;
    }
}
