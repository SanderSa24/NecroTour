using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour {
   
    int maxZombiesKilled = 30 * GameVariables.difficultyLevel * GameVariables.hardModeMultiplier;
    int zombiesKilled = 0;
    public static bool KillMode = false, zombieLimit = false;   
    Text zombiesKilledText;
    public static int zombieCounter = 0;
    bool wonMission;
	// Use this for initialization
	void Awake ()
    {
        ResetCounter();

        zombiesKilledText = GetComponent<Text>();
        KillMode = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        zombiesKilledText.text = "" + zombiesKilled;
        if (zombiesKilled<=0) {
            wonMission = true;
            //FindObjectOfType<PlayerHealthManager>().FullHealth();
            //ResetCounter();
            //KillMode = false;
        }

        if (wonMission)
        {
            FindObjectOfType<BusRescue>().MissionStatus("win");
        }
        else
        {
            FindObjectOfType<BusRescue>().MissionStatus("lose");
        }

        if (zombieCounter >= maxZombiesKilled) {
            zombieLimit = true;
        }
    }
   public void ResetCounter() {
        
        zombiesKilled = maxZombiesKilled;
        zombieCounter = 0;
        zombieLimit = false;
        
       
    }
    public void EnemyKilled(){
        zombiesKilled--;
        }

}
