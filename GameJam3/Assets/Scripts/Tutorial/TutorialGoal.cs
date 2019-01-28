using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGoal : MonoBehaviour {
    GameObject player;
    // Een array wat bepaalt wanneer iets wordt gezegd en wat wordt er gezegd
    public Sprite[] dialog;
    SpriteRenderer spriteRenderer;
    public string state;
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Bepaalt wat de dialog index is aan de hand van de index van de dichtsbijzijnde waypoint
        spriteRenderer.sprite = dialog[Array.IndexOf(TutorialWaypoints.pathfindingWaypoints, GetClosestWaypoint(TutorialWaypoints.pathfindingWaypoints))];
     
       
	}
  
    // pakt de dichtsbijzijnde Tutorialwaypoint naar de player 
    Transform GetClosestWaypoint(Transform[] waypoints)
    {
        Transform bestTarget = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < (TutorialWaypoints.pathfindingWaypoints.Length); i++)
        {
            float dToTarget = Vector3.Distance(waypoints[i].transform.position, player.transform.position);
            if (dToTarget < closestDistance)
            {
                closestDistance = dToTarget;
                bestTarget = waypoints[i];
            }
        }

        return bestTarget;
    }
}
