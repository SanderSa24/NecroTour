using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWaypoints : MonoBehaviour
{
    public static Transform[] waypoints;
    

    // Use this for initialization
    void Awake()
    {
        // waypoints to go when idle
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }      
    }
}