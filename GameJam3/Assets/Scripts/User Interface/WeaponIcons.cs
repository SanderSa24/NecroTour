using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcons : MonoBehaviour {

	// Use this for initialization
	Image image;

	public Sprite pistolSprite;
	public Sprite machinegunSprite;
	public Sprite shotgunSprite;

	void Start () {
		image = GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {

		if (Gun.gunType == Gun.GunType.Pistol) {
			image.sprite = pistolSprite;
		} else if (Gun.gunType == Gun.GunType.Shotgun) {
			image.sprite = shotgunSprite;
		} else if (Gun.gunType == Gun.GunType.Machinegun) {
			image.sprite = machinegunSprite;
		}
	}
}
