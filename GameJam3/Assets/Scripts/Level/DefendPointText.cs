using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendPointText : MonoBehaviour {
    public static int defendPointsAlive = 0;
    GameObject[] defendPoint;
    public static int defendpointHealth;
    Text healthText;
    // Use this for initialization
    void Awake()
    {
        defendPoint = GameObject.FindGameObjectsWithTag("DefendPoint");
        defendPointsAlive = defendPoint.Length;
        healthText = GetComponent<Text>();
        Debug.Log("defendpoint "+defendPointsAlive);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (defendPointsAlive <= 0)
        {
            FindObjectOfType<WinLoseScreen>().ShowCanvas("lose");
        }
        healthText.text = "" + defendpointHealth;
       
    }
    
}
