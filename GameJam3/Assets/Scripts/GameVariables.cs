using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables {


	// Player variables
	public static int playerMaxHealth = 100;


	public static int peopleSaved;
	public static int areasLength = 9;

	//ammo variables
	// max ammo is het maximaal aantal ammo wat de speler op zich kan dragen.
	//magazinesize is de grote van de magazine van het wapen.
	// starting ammo is met hoeveel ammo de game gestart word.

	//pistol ammo
	public static int maxPistolAmmo = 60;
    public static int pistolStartingAmmo = 36;
    public static int pistolMagazineSize = 12;

	//machinegun ammo variables
	public static int maxMachinegunAmmo = 420;
	public static int machinegunMagazineSize = 30;

	//shotgun ammo variables
	public static int maxShotgunAmmo = 24;
	public static int shotgunMagazineSize = 2;


    public static int currentDay = 0;
    
	public static int difficultyLevel = 1;
	public static int[] difficultyLevels = new int[areasLength];
	public static string[] typeMission = new string[areasLength];
	public static string[] typeArea = new string[areasLength];
	public static bool[] areasAvailable = new bool[areasLength];
	public static bool[] areasFallen = new bool[areasLength];

    //public static int difficultyLevel = 1;
    public static float currentSpawnOneMission = 95;
    public static float currentSpawnTwoMissions = 5;
    public static float currentSpawnThreeMissions = 0;

    public static bool realisticMode;
    public static int hardModeMultiplier = 1;

    public static bool startedGame;
    public static bool playTutorial = true;
}
