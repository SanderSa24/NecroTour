using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour {
    public GameObject winCanvas, loseCanvas, deathCanvas, busCanvas;
    GameObject[] childCanvasses;
	// Use this for initialization
	void Start () {
        childCanvasses = new GameObject[transform.childCount];
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < transform.childCount; i++)
        {
            childCanvasses[i] = transform.GetChild(i).gameObject;

            if (childCanvasses[i].activeSelf && childCanvasses[i].name != "BusCanvas")
            {
                Time.timeScale = 0;
            }
        }
	}

    public void ShowCanvas(string result)
    {
        switch (result)
        {
            case "win":
                FindObjectOfType<PauseGame>().missionHasEnded = true;
                winCanvas.SetActive(true);
                break;
            case "lose":
                FindObjectOfType<PauseGame>().missionHasEnded = true;
                loseCanvas.SetActive(true);
                break;
            case "death":
                FindObjectOfType<PauseGame>().missionHasEnded = true;
                deathCanvas.SetActive(true);
                break;
            case "bus":
                busCanvas.SetActive(true);
                break;
        }
    }

    public void MissionWin()
    {
        PeopleSavedManager.peopleSaved = 0;
        if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
        {
            FindObjectOfType<EnemiesKilled>().ResetCounter();
        }
        DefendPoint.health = 200;
        MissionManagementScript.MissionEnd("win");
    }

    public void MissionLose()
    {
        PeopleSavedManager.peopleSaved = 0;
        if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
        {
            FindObjectOfType<EnemiesKilled>().ResetCounter();
        }
        DefendPoint.health = 200;
        MissionManagementScript.MissionEnd("lose");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Cancel()
    {
        busCanvas.SetActive(false);
    }
}
