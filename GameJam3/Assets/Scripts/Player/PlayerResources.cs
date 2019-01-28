using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResources : MonoBehaviour {
	public float playerHealth;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Death ();
	}

	void Death () {
		if (playerHealth <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	private void OnCollisionStay2D (Collision2D collision) {
		if (collision.gameObject.CompareTag ("Enemy")) {
			playerHealth--;
		}
	}
}
