using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStates : MonoBehaviour
{
    // De text die geactiveerd wordt in de tutorial
    public GameObject[] defendCanvas, killCountCanvas,rescueCanvas;
    // Aantal zombies die de player moet verslaan in de huidige state
    public int zombies;
    //De huidige target index van de survivor
    public int maxWaypoint;
    GameObject speech;
    GameObject survivor;
    public static float rangeMultiplier=1;
    float timer;
    float amountOfTime;
    // De huidige state
    public static string stateName;
    //De waypoint limit die op de survivor wordt gezet zodat hij niet verder loopt. Aantal zombies die de player moet verslaan
    public static int waypointMax = 0, nZombies;
    // Veranderd de waypointMax zodat de survivor niet te ver loopt.
    public  int conditionZombies1, conditionZombies2;
    //Om te  zie welke state we zitten
    public string state;
    // Use this for initialization
    void Awake()
    {
        survivor = GameObject.FindGameObjectWithTag("Survivor");
        speech = GameObject.FindGameObjectWithTag("speech");
        stateName = "Start";
        State();
        amountOfTime = 10;
    }
    private void Start()
    {
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        State();
        maxWaypoint = waypointMax;
        speech.transform.position = survivor.transform.position;

        
        
        //Bepaalt wat de waypointMax is aan de hand of alle zombies in de zone dood zijn
        if (nZombies <= 0)
        {
            waypointMax = conditionZombies1;
        }
        else
        {
            waypointMax = conditionZombies2;
        }
        zombies = nZombies;
        state = stateName;
    }
    //Bepaalt welke waarde de conditionZombie1 en 2 hebben aan de hand van de state 
    void State() {
        switch (stateName)
        {
            case "Start":
                {                   
                    conditionZombies1 = 2;
                    conditionZombies2 = 1;
                    rangeMultiplier = 0.5f;
                    HideText();
                    break;
                }
            case "LearnBreakableBox":
                {
                    rangeMultiplier = 1f;
                    HideText();
                    conditionZombies1 = 3;
                    conditionZombies2 = 3;
                    break;
                }
            case "LearnDoor":
                {
                    rangeMultiplier =1f;
                    conditionZombies1 = 4;
                    conditionZombies2 = 4;
                    HideText();
                    break;
                }
            case "Kill Zombies":
                {
                    rangeMultiplier = 2f;
                    conditionZombies1 = 9;
                    conditionZombies2 = 5;
                    HideText();
                    break;
                }
            case "Rescue":
                {
                    rangeMultiplier = 3;
                    conditionZombies1 = 13;
                    conditionZombies2 = 10;
                    HideText();
                    foreach (GameObject text in rescueCanvas)
                    {
                        //Debug.Log("Rescue");
                        text.SetActive(true);
                    }
                    break;
                }
            case "BigZombie":
                {
                    rangeMultiplier = 3;
                    conditionZombies1 = 17;
                    conditionZombies2 = 16;
                    HideText();
                    break;
                }
            case "Kill Count":
                {
                    rangeMultiplier = 3;
                    conditionZombies1 = 21;
                    conditionZombies2 = 18;
                    HideText();
                    foreach (GameObject text in killCountCanvas)
                    {
                       // Debug.Log("Kill");
                        text.SetActive(true);
                    }
                    break;
                }
            case "FastZombie":
                {
                    rangeMultiplier = 1f;
                    conditionZombies1 = 26;
                    conditionZombies2 = 22;
                    HideText();
                    break;
                }
            case "Defend":
                {
                    rangeMultiplier = 1f;
                    conditionZombies1 = 26;
                    conditionZombies2 = 26;
                    HideText();
                    break;
                }
            case "WatchOut":
                {
                    rangeMultiplier = 1f;
                    conditionZombies1 = waypointMax;
                    conditionZombies2 = waypointMax;
                    HideText();
                    break;
                }

            default:
                break;
        }
    }
  
    // Verbergt alle canvas texten
    void HideText()
    {
        if (Zone.stateActivated)
        {
            timer = 0;
           //  Debug.Log("False");
            foreach (GameObject text in defendCanvas)
            {
                text.SetActive(false);
            }
            foreach (GameObject text in killCountCanvas)
            {
                text.SetActive(false);
            }
            foreach (GameObject text in rescueCanvas)
            {
                text.SetActive(false);
            }
            Zone.stateActivated = false;
        }
    }
    
}
