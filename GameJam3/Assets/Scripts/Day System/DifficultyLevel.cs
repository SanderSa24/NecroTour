using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour {
	float chanceMoreMission;
	float spawnOneMission, spawnTwoMissions, spawnThreeMissions;
	AreaBehaviour[] areaBehaviour;
	// Use this for initialization
	private void Awake () {
		changeMissionSpawn ();
		/* Debug.Log("% chance for more missions: " + chanceMoreMission);
         Debug.Log("% for 1 mission: " + spawnOneMission);
         Debug.Log("% for 2 mission: " + spawnTwoMissions);
         Debug.Log("% for 3 mission: " + spawnThreeMissions);
         Debug.Log("Day: " + GameVariables.currentDay);*/
	}

	private void Start () {
		areaBehaviour = new AreaBehaviour[MissionSpawn.areas.Length];

		for (int i = 0; i < MissionSpawn.areas.Length; i++) {
			areaBehaviour [i] = MissionSpawn.areas [i].GetComponent<AreaBehaviour> ();
		}

		MissionDifficulty ();
	}

	// Update is called once per frame

	void FixedUpdate () {


	}

	void MissionDifficulty () {
		for (int i = 0; i < GameVariables.difficultyLevels.Length; i++) {
			if (GameVariables.difficultyLevels [i] == 0) {
				GameVariables.typeMission [i] = "Rescue";
				if (areaBehaviour [i].isUnsafe) {
					GameVariables.difficultyLevels [i] = 2 + GameVariables.currentDay / 7;
				} else {
					GameVariables.difficultyLevels [i] = 1;
				}
			}
//			Debug.Log ("Level: " + i + "  difficulty " + GameVariables.difficultyLevels [i] + " mission type: " + GameVariables.typeMission[i]);
          
        }
	}

	void changeMissionSpawn () {
		chanceMoreMission = Random.Range (1, 101);
		spawnOneMission = Mathf.Max (GameVariables.currentSpawnOneMission, 25);
		spawnTwoMissions = Mathf.Min (GameVariables.currentSpawnTwoMissions, 50);
		spawnThreeMissions = Mathf.Min (GameVariables.currentSpawnThreeMissions, 25);

		if (chanceMoreMission <= spawnOneMission) {
			MissionSpawn.amountOfMissions = 1;
		} else if (chanceMoreMission <= (spawnOneMission + spawnTwoMissions)) {
			MissionSpawn.amountOfMissions = 2;
		} else {
			MissionSpawn.amountOfMissions = 3;
		}

		if ((Mathf.Max (GameVariables.currentDay, 1)) % 7 == 0) {
			GameVariables.currentSpawnOneMission -= 10;
			GameVariables.currentSpawnTwoMissions += 9;
			GameVariables.currentSpawnThreeMissions += 1;
		}

	}
   
}
