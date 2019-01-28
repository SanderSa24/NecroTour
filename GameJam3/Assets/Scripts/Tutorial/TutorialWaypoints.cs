using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWaypoints : MonoBehaviour
{

    public static Transform[] pathfindingWaypoints;
   
    public static int waypoints;
    // Use this for initialization
    void Awake()
    {
        
        waypoints = transform.childCount;
        pathfindingWaypoints = new Transform[waypoints];
        // waypoints for the survivor to follow
        for (int i = 0; i < pathfindingWaypoints.Length; i++)
        {
            
                pathfindingWaypoints[i] = transform.GetChild(i);

            
            

        }

    }

}