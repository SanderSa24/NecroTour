using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuePointManager : MonoBehaviour {
    HouseRescue[] rescuePoints;
    public int livingCivilans, amountOfRescuePoints, peopleToSave;
    
	// Use this for initialization
	void Awake () {
        rescuePoints = FindObjectsOfType<HouseRescue>();
        amountOfRescuePoints = rescuePoints.Length;
        livingCivilans = amountOfRescuePoints;
        peopleToSave = FindObjectOfType<PeopleSavedManager>().peopleToSave;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (livingCivilans < peopleToSave)
        {
            FindObjectOfType<WinLoseScreen>().ShowCanvas("lose");
        }
	}
}
