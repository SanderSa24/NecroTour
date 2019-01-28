using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusRescue : MonoBehaviour {

    GameObject player;
    public Transform positionGrandma, positionHouse;
    GameObject[] civilians;
    public string missionStatus;
    Scene currentScene;
    string currentSceneName;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
    }    
    // Update is called once per frame
    void FixedUpdate()
    {
        civilians = GameObject.FindGameObjectsWithTag("civilian");
    }
    void OnCollisionEnter2D(Collision2D otherObj)
    {

        foreach (GameObject civilian in civilians)
        {
            if (otherObj.gameObject == civilian)
            {
                //otherObj.gameObject.SetActive(false);
                Destroy(civilian);
                PeopleSavedManager.peopleSaved++;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            if (Input.GetKey(KeyCode.F))
            {
                /*
                PeopleSavedManager.peopleSaved = 0;
                if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
                {
                    FindObjectOfType<EnemiesKilled>().ResetCounter();
                }
                DefendPoint.health = 200;
                */
                if (currentSceneName != "Tutorial")
                {
                    if (missionStatus == "win")
                    {
                        FindObjectOfType<WinLoseScreen>().ShowCanvas("win");
                    }
                    else if (missionStatus == "lose")
                    {
                        FindObjectOfType<WinLoseScreen>().ShowCanvas("bus");
                    }
                }
                else
                {
                    PeopleSavedManager.peopleSaved = 0;
                    if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
                    {
                        FindObjectOfType<EnemiesKilled>().ResetCounter();
                    }
                    DefendPoint.health = 200;
                    MissionManagementScript.MissionEnd("lose");
                }
            }
        }
    }

    public void MissionStatus(string status)
    {
        missionStatus = status;
    }
}
