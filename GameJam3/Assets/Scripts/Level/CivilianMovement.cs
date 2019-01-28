using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianMovement : MonoBehaviour {
	GameObject enemy, safePlace;
	Rigidbody2D rb;
	public GameObject player;
	Vector2 direction, safePlaceRange;
	float distance, distanceSafePlace;
	public float maxChaseDistance, range;
	public float speed = 20, health = 1;
	public static float ranget;
	GameObject[] enemies;
	// Use this for initialization
	void Awake () {
        
		gameObject.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");
		safePlace = GameObject.FindGameObjectWithTag ("SafePlace");
		rb = GetComponent<Rigidbody2D> ();
		AddToArray ();
	}

	private void Start () {
         
	}

	void OnDrawGizmosSelected () {
       
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere (transform.position, ranget);
	}
	// Update is called once per frame
	void FixedUpdate () {
        

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
       
     
		if (health <= 0 && FindObjectOfType<RescuePointManager> () != null) {
			Destroy (gameObject);
			FindObjectOfType<RescuePointManager> ().livingCivilans--;
			FindObjectOfType<AudioManager>().Play("CivilianDeath");

		}
	}

	void AddToArray () {
		for (int i = 0; i < PathfindingWaypoints.pathfindingWaypoints.Length; i++) {
			if (PathfindingWaypoints.pathfindingWaypoints [i] == null) {
				PathfindingWaypoints.pathfindingWaypoints [i] = gameObject.transform;
				break;
			}
         

		}
	}

	void OnCollisionEnter2D (Collision2D otherObj) {
		foreach (GameObject enemy in enemies) {
			if (otherObj.gameObject == enemy) {

				health--;
			}
		}      
	}
}
