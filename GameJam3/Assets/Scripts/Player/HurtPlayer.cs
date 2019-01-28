using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	Vector3 attackDir;

	public float knockbackForce;
	public float damageToGive;
	float time, nHitTime;
	public float hitTime = 0;

	// vars for new Method:
	bool attackedPlayer;
	bool playerInRange;
	public float playerCheckRadius;
	public Transform playerCheck;
	public LayerMask whatIsPlayer;
	private EnemyPathfinding enemyPathFinding;

	GameObject player;

	// Use this for initialization
	void Start () {
		nHitTime = hitTime;
		enemyPathFinding = FindObjectOfType<EnemyPathfinding> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		playerInRange = Physics2D.OverlapCircle (playerCheck.position, playerCheckRadius, whatIsPlayer);

        
		if (playerInRange) {
			time = Time.deltaTime;
			hitTime -= time;
		}

		if (playerInRange && attackedPlayer) {
			enemyPathFinding.canMove = false;
			enemyPathFinding.rotationSpeed = 0;
			if (hitTime <= 0) {
				//PlayerHealthManager.HurtPlayer(damageToGive);
				player.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
				hitTime = nHitTime;
				FindObjectOfType<AudioManager> ().Play ("ZombieAttack");


			}
		}

		if (!playerInRange && attackedPlayer) {
			time = Time.deltaTime;
			hitTime -= time;

			if (hitTime <= 0) {
				attackedPlayer = false;
				enemyPathFinding.canMove = true;
				enemyPathFinding.rotationSpeed = 360;
			}
		}
	}

	void OnCollisionStay2D (Collision2D other) {
		attackDir = other.gameObject.transform.position - gameObject.transform.position;


		//knockback && hurtplayer
		if (other.gameObject.CompareTag ("Player")) {
			if (attackedPlayer == false) {
				other.gameObject.GetComponent<Rigidbody2D> ().AddForce (attackDir.normalized * knockbackForce);
				player.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
				FindObjectOfType<AudioManager> ().Play ("PlayerHurt");
				//PlayerHealthManager.HurtPlayer(damageToGive);
				attackedPlayer = true;
			}
		}

	}

	// POSSIBLE APPROACH:
	// Use physics2D.overlapsCircle (bool playerInRange) for rangecheck
	// check if attackedPlayer == true
	// if attackedPlayer && playerInRange are true, do damage, start timer, if timer = 0, do damage again, if playerInRange = false, set attackedPlayer to false
    
	/*
    void OnCollisionStay2D(Collision2D other)
    {
        time = Time.deltaTime;
        hitTime -= time;
        attackDir = other.gameObject.transform.position - gameObject.transform.position;

        if (other.gameObject.CompareTag("Player") && hitTime <= 0)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(attackDir.normalized * knockbackForce);

            hitTime = nHitTime;
            PlayerHealthManager.HurtPlayer(damageToGive);
        }
    }*/
    
}
