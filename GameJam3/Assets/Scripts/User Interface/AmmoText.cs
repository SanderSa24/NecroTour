using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {
	Text ammoText;
    public static int textLength;
	// Use this for initialization
	void Start () {
		ammoText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Gun.gunType == Gun.GunType.Pistol) {
			ammoText.text = "Pistol Ammo: ";
		} else if (Gun.gunType == Gun.GunType.Shotgun) {
			ammoText.text = "ShotGun Ammo: ";
		} else if (Gun.gunType == Gun.GunType.Machinegun) {
			ammoText.text = "MachineGun Ammo: ";
		}
        textLength = ammoText.text.Length;
	}
}
