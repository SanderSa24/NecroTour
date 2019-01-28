using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    bool paused; 
    public bool missionHasEnded;
    public GameObject canvas, pauseMenu, controlsMenu, exitMenu, returnText, quitText;
    public string menuToShow, buttonClicked;

    // Use this for initialization
    void Start () {
        menuToShow = "Pause";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            menuToShow = "Pause";
            paused = !paused;
        }

        if (!missionHasEnded)
        {
            if (paused)
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.SetActive(false);
                Time.timeScale = 1;
            }
        }

        switch (menuToShow)
        {
            case "Pause":
                pauseMenu.SetActive(true);
                controlsMenu.SetActive(false);
                exitMenu.SetActive(false);
                break;
            case "Controls":
                pauseMenu.SetActive(false);
                controlsMenu.SetActive(true);
                exitMenu.SetActive(false);
                break;
            case "Exit":
                pauseMenu.SetActive(false);
                controlsMenu.SetActive(false);
                exitMenu.SetActive(true);
                switch (buttonClicked)
                {
                    case "Return":
                        returnText.SetActive(true);
                        quitText.SetActive(false);
                        break;
                    case "Quit":
                        returnText.SetActive(false);
                        quitText.SetActive(true);
                        break;
                }
                break;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Controls()
    {
        menuToShow = "Controls";
    }

    public void Back()
    {
        menuToShow = "Pause";
    }

    public void ReturnToMenu()
    {
        buttonClicked = "Return";
        menuToShow = "Exit";
    }

    public void QuitGame()
    {
        buttonClicked = "Quit";
        menuToShow = "Exit";
    }

    public void YesButton()
    {
        switch (buttonClicked)
        {
            case "Return":
                PeopleSavedManager.peopleSaved = 0;
                if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
                {
                    FindObjectOfType<EnemiesKilled>().ResetCounter();
                }
                DefendPoint.health = 200;
                MissionManagementScript.MissionEnd("lose", true);
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }

    public void NoButton()
    {
        menuToShow = "Pause";
    }
}
