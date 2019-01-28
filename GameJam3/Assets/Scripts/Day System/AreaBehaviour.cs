using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaBehaviour : MonoBehaviour {
	public bool isUnsafe;
	public bool isAvailable;
	Button button;
	public string typeArea;
	public static string sceneToLoad;
	Color initialNormalColor, initialHighlightedColor, initialPressedColor;
	ColorBlock cb;
	GameObject areaManager;
	SpawnedMissionColors spawnedMissionColors;
	ArrayList borderingAreasList = new ArrayList ();
	ArrayList borderingAreaIndexes = new ArrayList ();
	int amountOfIndexes, amountOfActivatedAreas;
	public static int minimumSpreadingLevel, minimumFallenLevel;
	public int ownIndex, difficulty;


	// Use this for initialization
	void Awake () {
		areaManager = GameObject.Find ("AreaManager");
		spawnedMissionColors = areaManager.GetComponent<SpawnedMissionColors> ();
		button = GetComponent<Button> ();
		cb = button.colors;

		//Colors are set to initial values on start
		initialNormalColor = cb.normalColor;
		initialHighlightedColor = cb.highlightedColor;
		initialPressedColor = cb.pressedColor;

		//This replaces the Onclick() event in the editor, so that levels can only be loaded if a mission has spawned on the area that is being clicked on
		button.onClick.AddListener (() => {
			//LoadLevel();
				// spawn a window met informatie over het level.
				if (isAvailable) {
					GetMissionVariables ();
				FindObjectOfType<OverworldPopup>().boolPopup = true;
					
				}
			}
		);//END OF BUTTON ON CLICK
		minimumSpreadingLevel = 7; //Minimum difficulty level at which zombies start spreading to bordering areas
		minimumFallenLevel = 8; //Minimum difficulty level at which an area becomes "fallen"
	}


	void Start () {
		ownIndex = System.Array.IndexOf (MissionSpawn.areas, gameObject); //Get own index in the array containing all areas

		SetFallenAreas (); /*Areas are set to fallen when their difficulty is higher than minimumFallenLevel
                            This method is not called in the Awake() method, because it is dependant on data in other scripts*/
		GameVariables.typeArea [ownIndex] = typeArea;
	}

	// Update is called once per frame
	void FixedUpdate () {
		button.colors = cb;
		difficulty = GameVariables.difficultyLevels [ownIndex]; //Own difficulty is set to difficulty level in the array containing all difficulty levels using its own index  

		ChangeColor (); //Colors are changed depending on whether the mission is available or not

		SetMissionAvailibility (); //Spawns missions that are available

		//Get all indexes of bordering areas in the array containing all areas (MissionSpawn.areas)
		for (int i = 0; i < borderingAreasList.Count; i++) {
			if (amountOfIndexes < borderingAreasList.Count) {
				borderingAreaIndexes.Insert (i, System.Array.IndexOf (MissionSpawn.areas, borderingAreasList [i]));
				amountOfIndexes++;
			}
		}

		//If own difficulty is higher or equal to minimumSpreadingLevel and zombies haven't spread to other areas yet, a new bordering area will be infected
		if (GameVariables.difficultyLevels [ownIndex] >= minimumSpreadingLevel && amountOfActivatedAreas < 1) {
			ActivateBorderArea (); //Infect/spawn a new area
		}

		SetFallenAreas (); //This method is called again in the FixedUpdate() method, to ensure that newly infected areas are set to fallen when the difficulty value is high enough


		bool startMission = FindObjectOfType<OverworldPopup> ().startMission;
		if (startMission) {
			startMission = false;
			LoadLevel ();

			// loading screen. 
			//	OverworldPopup.startMission = false;
		}
	}

	void Update(){
		
	}

	public static void IncreaseDifficulty() {
		for (int i = 0; i < GameVariables.difficultyLevels.Length; i++) {
			if (i != MissionManagementScript.currentMissionIndex && GameVariables.areasAvailable [i]) {
				GameVariables.difficultyLevels [i]++; //Increase difficulty by 1 if this area is not selected by the player and this area contains an available mission
				if (GameVariables.difficultyLevels [i] <= 2) {
					GameVariables.typeMission [i] = "Rescue"; //Mission type is rescue when the difficulty is lower or equal to the value in this if-statement
					//Debug.Log(i + "rescue");
				} else {
					GameVariables.typeMission [i] = "Kill Count"; //When the difficulty is higher, the mission type becomes kill count
					//Debug.Log(i + "kill");
				}
			}
		}
		GameVariables.difficultyLevel = GameVariables.difficultyLevels [MissionManagementScript.currentMissionIndex]; //Get own difficulty by using own index in the array containing all difficulty levels

	}

    
	public void LoadLevel () {
		//This code is executed when an area is available/a mission has spawned
		if (isAvailable) {
			//Passes current mission to the Mission Management script. The called method requires one argument: the index of the array that the area is in
			//MissionManagementScript.CurrentMissionIndex (System.Array.IndexOf (MissionSpawn.areas, gameObject));
			//For the unsafe areas, the length of the safe areas array is added up to its own index, so that only this value is needed in the MissionManagement script


			changeLoadScene ();
            //SceneManager.LoadScene (sceneToLoad);
            SceneManager.LoadScene("Loading Screen");
		}
	}
    

	//Set scene to load using own index of the area to determine mission type
	void changeLoadScene () {
		Debug.Log ("mission index :" + MissionManagementScript.currentMissionIndex);
		Debug.Log ("mission type: " + GameVariables.typeMission [MissionManagementScript.currentMissionIndex]);
		Debug.Log ("Area: " + typeArea);
       
		//sceneToLoad = GameVariables.typeMission [MissionManagementScript.currentMissionIndex] + " " + typeArea + " New";   
		sceneToLoad = OverworldPopup.missionType + " " + OverworldPopup.levelType;
	}

	void ChangeColor () {
		if (isAvailable) { //Colors for areas where missions have spawned
			cb.normalColor = spawnedMissionColors.spawnedNormalColor;
			cb.highlightedColor = spawnedMissionColors.spawnedHighlightedColor;
			cb.pressedColor = spawnedMissionColors.spawnedPressedColor;


		} else { //Colors for areas where no missions have spawned
		//	cb.normalColor = initialNormalColor;
		//	cb.highlightedColor = initialHighlightedColor;
			//cb.pressedColor = initialPressedColor;
		}
	}

	void GetMissionVariables () {
		
		MissionManagementScript.CurrentMissionIndex (System.Array.IndexOf (MissionSpawn.areas, gameObject));
		OverworldPopup.levelType = typeArea;
		OverworldPopup.missionType = GameVariables.typeMission [ownIndex];
		OverworldPopup.difficultyLevel = GameVariables.difficultyLevels [ownIndex];

	} 

	//This method sets the "isAvailable" boolean dependant on an array of booleans found in the "GameVariables" script
	void SetMissionAvailibility () {
		isAvailable = GameVariables.areasAvailable [System.Array.IndexOf (MissionSpawn.areas, gameObject)];
	}



	//Adds all bordering areas to borderingAreasList
	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.CompareTag ("Area")) {
			borderingAreasList.Add (collision.gameObject);
		}
	}

	//Activate a random bordering area
	void ActivateBorderArea () {
		if (borderingAreasList.Count > 0) {
			var randomBorderingArea = Random.Range (0, borderingAreasList.Count);

			var chosenAreaIndex = (int)borderingAreaIndexes [randomBorderingArea];

			if (!GameVariables.areasAvailable [chosenAreaIndex] && GameVariables.areasAvailable [ownIndex]) {
				GameVariables.areasAvailable [chosenAreaIndex] = true;
				GameVariables.difficultyLevels [chosenAreaIndex] = GameVariables.difficultyLevels [ownIndex] - 2;
				amountOfActivatedAreas++;
			}       
		}    
	}

	//Determine if an area is fallen or unsafe
	void SetFallenAreas () {
		if (GameVariables.difficultyLevels [ownIndex] >= minimumFallenLevel) {
			GameVariables.areasFallen [ownIndex] = true;
		}

		if (GameVariables.areasFallen [ownIndex]) {
			isUnsafe = true;
		}
	}
}

