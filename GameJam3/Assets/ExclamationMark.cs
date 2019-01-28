using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExclamationMark : MonoBehaviour {

	Image image;


	public Sprite exclamationMarkSprite;
	bool rotationBool;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<AreaBehaviour> ().isAvailable) {
			image.sprite = exclamationMarkSprite;
		} else if (rotationBool != true) {
			transform.Rotate(new Vector3(0,90,0));
			rotationBool = true;

		}
	}
}



	// Use this for initialization

