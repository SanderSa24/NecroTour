using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionManagementScript
{
    public static int currentMissionIndex;

    public static void MissionEnd(string result, bool backToMenu = false)
    {
        if (result == "win")
        {
            GameVariables.currentDay += 1;
            MissionWon();         
            GameVariables.areasAvailable[currentMissionIndex] = false;
            SceneManager.LoadScene("Overworld");
        }
        else if (result == "lose")
        {
            var spawnedMissions = 0;
            for (int i = 0; i < GameVariables.areasLength; i++)
            {
                if (GameVariables.areasAvailable[i])
                {
                    spawnedMissions++;
                }
            }

            if(spawnedMissions < GameVariables.areasLength)
            {
                GameVariables.currentDay += 1;
                MissionLost();
                if (!backToMenu)
                {
                    SceneManager.LoadScene("Overworld");  
                }
                else
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
            else
            {
                SceneManager.LoadScene("Game Over");
            }   
        }
    }
    static void  MissionWon()
    {
        for (int i = 0; i < GameVariables.difficultyLevels.Length; i++)
        {
            if (currentMissionIndex == i)
            {
                GameVariables.difficultyLevels[i] = 0;
                GameVariables.typeMission[i] = "Rescue";
            }
        }
    }
    static void MissionLost()
    {
        for (int i = 0; i < GameVariables.difficultyLevels.Length; i++)
        {
            if (currentMissionIndex == i)
            {
                GameVariables.difficultyLevels[i]++;
                if (GameVariables.difficultyLevels[i] <= AreaBehaviour.minimumSpreadingLevel)
                {
                    GameVariables.typeMission[i] = "Kill Count";
                }
                else
                {
                    if (GameVariables.typeMission[i] == "Defend")
                    {
                        GameVariables.typeMission[i] = "Kill Count";
                    }
                    else
                    {
                        GameVariables.typeMission[i] = "Defend";
                    }
                }
            }
        }
    }
    public static void MissionRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void CurrentMissionIndex(int index)
    {
        currentMissionIndex = index;
    }
}
