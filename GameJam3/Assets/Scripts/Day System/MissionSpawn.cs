using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSpawn : MonoBehaviour {

	public int unsafeAreaSpawnChance;
	public static int amountOfMissions = 1;
	//This determines the amount of missions that should spawn
	int spawnedMissions = 0;
	public static GameObject[] areas;
	AreaBehaviour[] areaBehaviour;

	// Use this for initialization
	void Awake () {
		if (Time.timeScale < 1) {
			Time.timeScale = 1;
		}

		areas = GameObject.FindGameObjectsWithTag ("Area");
		areaBehaviour = new AreaBehaviour[areas.Length];
        
		for (int i = 0; i < areas.Length; i++) {
			areaBehaviour [i] = areas [i].GetComponent<AreaBehaviour> ();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (spawnedMissions < amountOfMissions) {
			SpawnRandomMissions ();
		}
	}

	public void SpawnRandomMissions () {
		//Random number between 1 and 100 to determine where a mission spawns (safe or unsafe area)
		var diceRoll = Random.Range (1, 101);

		if (diceRoll <= unsafeAreaSpawnChance) {
			var randomUnsafeArea = Random.Range (0, areas.Length);

			if (!GameVariables.areasAvailable [randomUnsafeArea] && areaBehaviour [randomUnsafeArea].isUnsafe) {
				//spawn mission in a random "unsafe area" (the chance that this occurs equals the value of the "unsafeAreaSpawnChance" variable)
				GameVariables.areasAvailable [randomUnsafeArea] = true;
				spawnedMissions += 1;
			}
		} else if (diceRoll > unsafeAreaSpawnChance) {
			var randomSafeArea = Random.Range (0, areas.Length);

			if (!GameVariables.areasAvailable [randomSafeArea] && !areaBehaviour [randomSafeArea].isUnsafe) {
				//spawn mission in a random "safe area" (the chance that this occurs equals 100 minus the value of the "unsafeAreaSpawnChance" variable)
				GameVariables.areasAvailable [randomSafeArea] = true;
				spawnedMissions += 1;

			}
		}
	}
}
