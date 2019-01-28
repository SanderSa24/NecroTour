using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefendPoint : MonoBehaviour {
    public static int health;
    public int defendpointHealth=1;
    public float hitTime = 1f;
    float time,nHitTime;
    int maxDefendpointHealth;
    bool wonMission;
    
     // Use this for initialization
    void Awake () {

        DefendPointText.defendpointHealth = defendpointHealth;
        nHitTime = hitTime;
        maxDefendpointHealth = defendpointHealth;
        health = defendpointHealth;
        FindObjectOfType<BusRescue>().MissionStatus("lose");
        
    }
    private void Start()
    {
        AddToArray();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.G))
        {
            defendpointHealth--;
        }
        DefendPointText.defendpointHealth = defendpointHealth;
        
        if (Timer.timeRunOut)
        {
            wonMission = true;
            Timer.timeRunOut = false;
        }
        
        if (wonMission)
        {
            FindObjectOfType<BusRescue>().MissionStatus("win");
        }

        if (defendpointHealth <= 0)
        {
            DefendPointText.defendPointsAlive--;
            Destroy(gameObject);
            Debug.Log("defendpoint " + DefendPointText.defendPointsAlive);

        }
    }
    void AddToArray()
    {
        for (int i = 0; i < PathfindingWaypoints.pathfindingWaypoints.Length; i++)
        {
            if (PathfindingWaypoints.pathfindingWaypoints[i] == null)
            {
                PathfindingWaypoints.pathfindingWaypoints[i] = gameObject.transform;
                break;
            }


        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        time = Time.deltaTime;
        hitTime -= time;
        if (other.gameObject.CompareTag("Enemy") && hitTime<=0)
        {
            hitTime = nHitTime;
            defendpointHealth--;
        }
    }
}
