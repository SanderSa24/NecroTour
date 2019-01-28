using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

    public static float playerHealth;

    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.

    bool damaged;                                               // True when the player gets damaged.

    Text healthText;

    // Use this for initialization
    void Start()
    {

        //healthText = GetComponent<Text> ();
        FullHealth();
        playerHealth = GameVariables.playerMaxHealth;


    }

    void Update()
    {
        //healthText.text = "" + playerHealth;

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    void FixedUpdate()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0f;
            SceneManager.LoadScene("Game Over");
        }
        else if (playerHealth > GameVariables.playerMaxHealth)
        {
            playerHealth = GameVariables.playerMaxHealth;
        }
    }

    public static void ResetVariables()
    {
        GameVariables.currentDay = 0;
        GameVariables.difficultyLevel = 1;
        GameVariables.currentSpawnOneMission = 95;
        GameVariables.currentSpawnTwoMissions = 5;
        GameVariables.currentSpawnThreeMissions = 0;
        GameVariables.startedGame = false;
        for (int i = 0; i < GameVariables.areasLength; i++)
        {
            GameVariables.difficultyLevels[i] = 0;
            GameVariables.areasAvailable[i] = false;
            GameVariables.areasFallen[i] = false;
        }
    }

    public void HurtPlayer(float damageToGive)
    {

        damaged = true;

        playerHealth -= damageToGive;

        healthSlider.value = playerHealth;



    }



    public void FullHealth()
    {
        playerHealth = GameVariables.playerMaxHealth;


        if (EnemiesKilled.KillMode)
        {
            FindObjectOfType<EnemiesKilled>().ResetCounter();
        }
    }
}
