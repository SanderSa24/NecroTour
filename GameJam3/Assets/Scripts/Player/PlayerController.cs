using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//De player controller is de class waarin verschillende controls voor de player in verwerkt worden
// zoals de movement en interactions (bijvoorbeeld schieten van verschillende wapens)
public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 movement;
	public float speed;
    
	// Use this for initialization

	//shooting variables
	public Transform rocketLocation;
	public GameObject bullet;
	public float fireRate = 0.5f;
	public float nextFire = 0;
	Quaternion rot;
	Animator anim;

	//melee variables
	bool meleeAttack;
	public int meleeDamage;
	public float knockbackForce;
	public float meleeDelay;
	float meleeTime;

	bool melee_isAxisInUse = false;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		meleeTime = meleeDelay;
	}

	void Update () {
		
		//Interactions ();
	
	}

	void FixedUpdate () {
		Movement ();
		Interactions ();
	}

	void Movement () {
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z + 90);
		// transform.eulerAngles = new Vector3(0, 0, 90);
		rb.angularVelocity = 0;

		// float input = Input.GetAxis("Vertical");
		// rb.AddForce(gameObject.transform.up * speed * input);

		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		movement = new Vector2 (moveX, moveY);
		movement.Normalize ();
		rb.velocity = movement * speed;
	}

	void Interactions () {
		//fire buttons
		// shooting, all different weapons. 
		// left mouse button
		if (Input.GetAxis ("Fire1") > 0) {


			if (PlayerAmmoManager.pistolClip > 0) {
				//FirePistol ();
			}
		}


		// Melee attack right button
		if (Input.GetButtonDown ("Fire2")) {
			//if (Input.GetAxisRaw ("Fire2") > 0 ) {
			if (melee_isAxisInUse == false) {
				//anim.SetTrigger ("MeleeStart");
				//anim.SetTrigger ("MeleeEnd");
				melee_isAxisInUse = true;
				meleeAttack = true;// melee attack animation
			}
		}

		meleeTime -= Time.deltaTime;
		// end melee animation 
		if (meleeTime < 0) {
			//anim.SetTrigger ("MeleeEnd");
			melee_isAxisInUse = false;
			//Debug.Log ("Meleetime <0 ");
			//anim.SetTrigger ("MeleeEnd");
			meleeTime = meleeDelay;
		}
	}


	void FirePistol () {
	      
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			FindObjectOfType<AudioManager> ().Play ("Gunshot");
			Instantiate (bullet, rocketLocation.position, rot);
			PlayerAmmoManager.pistolClip -= 1;
		}           	
	}
	void FireMachineGun(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			FindObjectOfType<AudioManager> ().Play ("Gunshot");
			Instantiate (bullet, rocketLocation.position, rot);
			PlayerAmmoManager.machinegunClip -= 1;
		}
	
	}
	void FireShotgun () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			FindObjectOfType<AudioManager> ().Play ("Gunshot");
			Instantiate (bullet, rocketLocation.position, rot);
			PlayerAmmoManager.pistolClip -= 1;
		}  
	}


		
	// trigger for melee attack
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			if (meleeAttack) {
				//other.gameObject.GetComponent<EnemyBehaviour> ().health -= meleeDamage;
				meleeAttack = false;
			}
		}

	}
}
