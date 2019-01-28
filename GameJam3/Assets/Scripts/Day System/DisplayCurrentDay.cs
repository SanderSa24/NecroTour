using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentDay : MonoBehaviour {
    Text currentDayValue;
	// Use this for initialization
	void Start () {
        currentDayValue = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        currentDayValue.text = GameVariables.currentDay.ToString();
	}
}
