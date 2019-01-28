using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool inZone = false;
    public bool checkedZombies = false;
    public static bool stateActivated = false, changeRange = true;
    public string stateName;
    public int numberOfZombies = 0;
    GameObject player;
    GameObject[] enemies;
    // Use this for initialization
    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfZombies = 0;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TutorialStates.stateName == stateName && checkedZombies == true) {
            TutorialStates.nZombies = numberOfZombies;
            checkedZombies = false;
            
        }
    }
   
    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //Actions based on what the other objects are
        if (otherObj.gameObject.tag == "Enemy")
        {
            otherObj.GetComponent<EnemyBehaviour>().tutorialZombie = true;
            //Debug.Log("enter " + stateName);
            checkedZombies = true;
            numberOfZombies++;
        }
        //Actions based on what the other objects are
        if (otherObj.gameObject.tag == "Player")
        {
            inZone = true;
            stateActivated = true;
            changeRange = true;
            if (stateName !=null)
            TutorialStates.stateName = stateName;
        }
        
    }
   
    private void OnTriggerStay2D(Collider2D otherObj)
    {
        //Actions based on what the other objects are
        if (otherObj.gameObject.tag == "Enemy")
        {

            if (inZone)
            {               
                otherObj.gameObject.GetComponent<EnemyPathfinding>().rotationIn2D = true;
                otherObj.gameObject.GetComponent<EnemyPathfinding>().target = player.transform;
            }
            else
            {
                otherObj.gameObject.GetComponent<EnemyPathfinding>().rotationIn2D = false;
            }            
        }
             
    }
}