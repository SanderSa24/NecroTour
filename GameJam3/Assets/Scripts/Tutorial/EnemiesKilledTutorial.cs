using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemiesKilledTutorial : MonoBehaviour {
   
    int zombiesKilled = 0;
   Text zombiesKilledText;
   // Use this for initialization
	void Awake ()
    {
        zombiesKilledText = GetComponent<Text>();       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks hoe veel zombies er in de zone zijn
        zombiesKilled = TutorialStates.nZombies;
        zombiesKilledText.text = "" + zombiesKilled;        
    }
}
