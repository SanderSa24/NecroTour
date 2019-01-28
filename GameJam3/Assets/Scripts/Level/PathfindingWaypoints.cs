using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingWaypoints : MonoBehaviour
{

    public static Transform[] pathfindingWaypoints;
    public static Transform[] zombiePathfindingWaypoints;
    GameObject player;
    GameObject[] survivors;
    GameObject[] defendpoints;
    GameObject[] rescuePoints;
    public static int points, waypoints;
    // Use this for initialization
    void Awake()
    {
        rescuePoints = GameObject.FindGameObjectsWithTag("RescuePlace");
        defendpoints = GameObject.FindGameObjectsWithTag("DefendPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        survivors = GameObject.FindGameObjectsWithTag("Survivor");
        points = defendpoints.Length + rescuePoints.Length + survivors.Length;
        waypoints = transform.childCount;
        pathfindingWaypoints = new Transform[waypoints + 1 + points];
        // waypoints to go when collision with wall
        for (int i = 0; i < pathfindingWaypoints.Length; i++)
        {
            if (i < (transform.childCount))
            {
                pathfindingWaypoints[i] = transform.GetChild(i);

            }
            else if (i == (pathfindingWaypoints.Length - 1))
            {
                pathfindingWaypoints[i] = player.transform;
            }

        }

    }

}