using System.Collections.Generic;
using UnityEngine;


//deze class word vastgeplakt aan een pick up object. 
//door de string public te maken kan dit script hergebruikt worden.
// ook voor dingen zoals keys.
public class PickUp : MonoBehaviour {

	// Use this for initialization

	public string variable;
	public int pickUpBonus;


	void OnTriggerEnter2D (Collider2D colider){
		if (colider.gameObject.tag == "Player"){
			FindObjectOfType<AudioManager>().Play("PickUp");
			switch(variable){
				case "health":
					PlayerHealthManager.playerHealth += pickUpBonus;
					Destroy (gameObject);
					break; 
				case "pistolAmmo":
					PlayerAmmoManager.currentPistolAmmo += pickUpBonus;
					Destroy (gameObject);
					break;
				case "shotgunAmmo":
					PlayerAmmoManager.currentShotgunAmmo += pickUpBonus;
					Destroy (gameObject);
					break;
				case "machinegunAmmo":
					PlayerAmmoManager.currentMachinegunAmmo += pickUpBonus;
					Destroy (gameObject);
					break; 
			}

		/*	if (variable == "health"
				|| variable ==  "Health"
				|| variable =="playerHealth" 
				|| variable == "PlayerHealth") {
				PlayerHealthManager.playerHealth += pickUpBonus;
				Destroy (gameObject);
			}else if (variable == "pistolammo" 
				) {
				GameVariables.maxAmmo += pickUpBonus;
				Destroy (gameObject);
			} */
		}
	}
}