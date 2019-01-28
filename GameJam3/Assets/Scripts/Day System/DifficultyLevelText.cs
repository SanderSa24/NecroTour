using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyLevelText : MonoBehaviour {
	/// <summary>
	/// Script werkt niet zoals het hoort. Je krijgt de laaste waarde terug ipv die van de respectieve area.
	/// </summary>
	Text difficultyText;
	string typeMission;
	// Use this for initialization
	void Start () {
		difficultyText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        
		for (int i = 0; i < GameVariables.difficultyLevels.Length; i++) {
			if (MissionManagementScript.currentMissionIndex == i) {
				switch (GameVariables.typeMission [i]) {

					case "Rescue":
						typeMission = "R";
						break;
					case "Defend":
						typeMission = "D";
						break;
					case "Kill Count":
						typeMission = "K";
						break;
					default:
						break;
				}
				difficultyText.text = GameVariables.difficultyLevels [i] + " " + typeMission;
			}
		}
        
	}
}
