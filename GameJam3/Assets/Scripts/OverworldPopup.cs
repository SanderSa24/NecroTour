using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//smerige hardcode voor de descriptions van de levels.

public class OverworldPopup : MonoBehaviour {


	
	private Rect windowRect = new Rect (200, 20, 500, 500);
	private Rect windowRectLetsGo = new Rect (200, 20, 750, 750);

	public Texture farmTexture;
	public Texture suburbTexture;
	public Texture cityTexture;
	public Texture pistolTexture;
	public Texture shotgunTexture;
	public Texture machinegunTexture;

	//color textures
	public Texture greyTexture;
	public Texture greenTexture;
	public Texture brownTexture;
	public Texture redTexture;


	Button button;
	public  bool boolPopup;


	string farmDescription = "Farmlands outside of the greater city area. Big open area with lots of grass and a big farmhouse. ";
	string suburbDescription = "Suburbs just outside of the city center. Detached houses and big lawns. Semi-Open area. Beware of middle-class.";
	string cityDescription = "Downtown New york Vibes. Lots of streets with small houses close to eachother. ";

	string defendMissionDescription = "Defend Mission. Defend the survivors for a set time. If it's overwhelming go back to the bus.";
	string rescueMissionDescription = "Rescue the civilians and bring them to your bus. If it's overwhelming go back to the bus. ";
	string killcountMissionDescription = "Clean up the area by killing as much zombies as possible. If it's overwhelming go back to the bus.";

	string defaultDescription = "To your right you see the World map. Zombies are slowly taking over the city, try to defend it for as many days as possible.  Red means zombies are currently invading the area. If you finished a mission you come back to this area and a day will have passed.\n \n Click on the red area to see more information about the mission.";
	//variabelen die meegegeven worden vanuit de areabehaviour class
	public static string levelType;
	public static string missionType;
	public static int difficultyLevel;
	public bool startMission;
	bool letsGo;
	//variables voor de windowheight etc.

	//unhardcode this shit



	void OnGUI () {
		

	
		//if (boolPopup == true) {
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "Mission Description"); 
		//} 

	}

	void DoMyWindow (int windowID) {
		// farm
		/* H A R D C O D E
		* A
		 * R
		* D
		 * C
		* O
		 * D
		* E
				 */

		// maak switch met 3 cases voor level description

		//maak switch met 3 cases voor mission description. 
		switch (levelType) {
			case "Farm"://farm
				//farmDescription = GUI.TextArea (new Rect (50, 50, 400, 75), farmDescription, 200);
				GUI.Label (new Rect (50, 50, 400, 75), farmDescription);
				GUI.DrawTexture (new Rect (50, 210, 200, 200), farmTexture, ScaleMode.StretchToFill);

				break;
			case "Suburbs": 
				//suburbDescription = GUI.TextArea (new Rect (50, 50, 400, 75), suburbDescription, 200);
				GUI.Label (new Rect (50, 50, 400, 75), suburbDescription);
				GUI.DrawTexture (new Rect (50, 210, 200, 200), suburbTexture, ScaleMode.StretchToFill);
				//Debug.Log (suburbTexture);


				break; 
			case "City":
				//cityDescription = GUI.TextArea (new Rect (50, 50, 400, 75), cityDescription, 200);
				GUI.Label (new Rect (50, 50, 400, 75), cityDescription);
				GUI.DrawTexture (new Rect (50, 210, 200, 200), cityTexture, ScaleMode.StretchToFill);
				break;
			default:
				GUI.Label (new Rect (50, 50, 400, 150), defaultDescription);
				//draw 3 textures for each color here.
				GUI.DrawTexture (new Rect (50, 210, 50, 50), greenTexture, ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect (50, 260, 50, 50), brownTexture, ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect (50, 310, 50, 50), greyTexture, ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect (50, 360, 50, 50), redTexture, ScaleMode.StretchToFill);

				GUI.Label (new Rect (100, 210, 100, 50), "Green is farmlands");
				GUI.Label (new Rect (100, 260, 100, 50), "Brown is suburbs");
				GUI.Label (new Rect (100, 310, 100, 50), "Grey is for City");
				GUI.Label (new Rect (100, 360, 100, 50), "Red means a mission has spawned");


				break;
		}

		switch (missionType) {
			case "Defend":
				//defendMissionDescription = GUI.TextArea (new Rect (50, 125, 400, 75), defendMissionDescription, 200);
				GUI.Label (new Rect (50, 125, 400, 75), defendMissionDescription);
				break;
			case "Kill Count":
				//killcountMissionDescription = GUI.TextArea (new Rect (50, 125, 400, 75), killcountMissionDescription, 200);
				GUI.Label (new Rect (50, 125, 400, 75), killcountMissionDescription);
				break;
			case "Rescue":
				//rescueMissionDescription = GUI.TextArea (new Rect (50, 125, 400, 75), rescueMissionDescription, 200);
				GUI.Label (new Rect (50, 125, 400, 75), rescueMissionDescription);
				break;
			default:
				//GUI.Label (new Rect (50, 125, 400, 75), defaultDescription);
				break;

		}
		//teken de plattegrond


		//pistol 
		GUI.DrawTexture (new Rect (275, 210, 50, 50), pistolTexture, ScaleMode.ScaleToFit);


		//GUI.TextField (new Rect (325, 210, 50, 50), PlayerAmmoManager.currentPistolAmmo.ToString () + " / " + PlayerAmmoManager.pistolClip.ToString ());
		GUI.Label (new Rect (330, 210, 50, 50), PlayerAmmoManager.currentPistolAmmo.ToString () + " / " + PlayerAmmoManager.pistolClip.ToString ());

		// shotgun
		GUI.DrawTexture (new Rect (275, 260, 50, 50), shotgunTexture, ScaleMode.ScaleToFit);
		//GUI.TextField (new Rect (325, 260, 50, 50), PlayerAmmoManager.currentShotgunAmmo.ToString () + " / " + PlayerAmmoManager.shotgunClip.ToString ());
		GUI.Label (new Rect (330, 260, 50, 50), PlayerAmmoManager.currentShotgunAmmo.ToString () + " / " + PlayerAmmoManager.shotgunClip.ToString ());

		//Machinegun
		GUI.DrawTexture (new Rect (275, 310, 50, 50), machinegunTexture, ScaleMode.ScaleToFit);
		//GUI.TextField (new Rect (325, 310, 50, 50), PlayerAmmoManager.currentMachinegunAmmo.ToString () + " / " + PlayerAmmoManager.machinegunClip.ToString ());

		GUI.Label (new Rect (330, 310, 50, 50), PlayerAmmoManager.currentMachinegunAmmo.ToString () + " / " + PlayerAmmoManager.machinegunClip.ToString ());


		//difficulty
		//GUI.TextField (new Rect (325, 360, 150, 25), "Difficulty Level " + difficultyLevel.ToString());


		//GUI.Button  (new Rect (330, 420, 150, 25), "Start Mission");
			
		//doet alleen iets als er op een area geklikt is oftewel niet voor de default box.
		if (boolPopup == true) {
			if (GUI.Button (new Rect (330, 420, 150, 25), "Start Mission")) {

				print ("thankyou");
				AreaBehaviour.IncreaseDifficulty ();
				startMission = true;
			}
			//laat de difficulty level zien van het level
			GUI.Label (new Rect (330, 360, 150, 25), "Difficulty Level " + difficultyLevel.ToString ());
		}
	

		// deze moet blijven anders verdwijnt de hele GUI op magische wijze
		if (GUILayout.Button (" ")) {
	
		}

		
		
	}

	void Awake () {
		button = GetComponent<Button> ();
	

	}

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (letsGo) {
		
		}
	}
}
