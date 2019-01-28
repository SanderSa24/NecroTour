using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeopleSavedManager : MonoBehaviour
{

    public static float peopleSaved = 0;
    public int peopleToSave;
    int maxPeopleSaved;

    Text peopleSavedText;

    // Use this for initialization
    void Awake()
    {
        peopleSavedText = GetComponent<Text>();
        maxPeopleSaved = GameObject.FindGameObjectsWithTag("RescuePlace").Length;

        if (peopleToSave > maxPeopleSaved)
        {
            peopleToSave = maxPeopleSaved;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (peopleSaved >= peopleToSave)
        {
            //peopleSaved = 0;
            //Timer.timeRunOut = false;
            FindObjectOfType<BusRescue>().MissionStatus("win");      
        }
        else
        {
            FindObjectOfType<BusRescue>().MissionStatus("lose");
        }

        peopleSavedText.text = "" + peopleSaved + " / " + peopleToSave;
    }



}
