using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {
    string healthText;
    float health;
    GameObject player;
    //PlayerResources resourceScript;
    GUIStyle textStyle;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        //resourceScript = player.GetComponent<PlayerResources>();
        textStyle = new GUIStyle();
        textStyle.fontSize = 24;
        textStyle.normal.textColor = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate () {
        health = GameVariables.playerMaxHealth;
        healthText = "Health: " + health;
    }

    private void OnGUI()
    {
        //GUI.Box(new Rect(0, 0, 200, 20), healthText, textStyle);
    }
}
