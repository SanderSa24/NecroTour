using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour {
    Button button;
    ColorBlock initialColorBlock, selectedColorBlock, unavailableColorBlock, cb;
    MainMenuButtons mainMenuButtons;
    GameObject canvasController;
	// Use this for initialization
	void Awake () {
        button = GetComponent<Button>();
        initialColorBlock = button.colors;
        canvasController = GameObject.Find("CanvasController");
        mainMenuButtons = canvasController.GetComponent<MainMenuButtons>();


        selectedColorBlock.normalColor = mainMenuButtons.selectedNormalColor;
        selectedColorBlock.highlightedColor = mainMenuButtons.selectedHighlighedColor;
        selectedColorBlock.pressedColor = mainMenuButtons.selectedPressedColor;
        selectedColorBlock.colorMultiplier = 1;

        unavailableColorBlock.normalColor = mainMenuButtons.unavailableColor;
        unavailableColorBlock.highlightedColor = mainMenuButtons.unavailableColor;
        unavailableColorBlock.pressedColor = mainMenuButtons.unavailableColor;
        unavailableColorBlock.colorMultiplier = 1;
    }

    // Update is called once per frame
    void FixedUpdate () {
        button.colors = cb;
        switch (name)
        {
            case "NormalButton":
                if(GameVariables.hardModeMultiplier <= 1)
                {
                    cb = selectedColorBlock;
                }
                else if(GameVariables.hardModeMultiplier > 1)
                {
                    cb = initialColorBlock;
                }
                break;
            case "HardButton":
                if (GameVariables.hardModeMultiplier <= 1)
                {
                    cb = initialColorBlock;
                }
                else if (GameVariables.hardModeMultiplier > 1)
                {
                    cb = selectedColorBlock;
                }
                break;
            case "StandardModeButton":
                if (GameVariables.realisticMode)
                {
                    cb = initialColorBlock;
                }
                else
                {
                    cb = selectedColorBlock;
                }
                break;
            case "RealisticModeButton":
                if (GameVariables.realisticMode)
                {
                    cb = selectedColorBlock;
                }
                else
                {
                    cb = initialColorBlock;
                }
                break;
            case "YesButton":
                if (GameVariables.playTutorial)
                {
                    cb = selectedColorBlock;
                }
                else
                {
                    cb = initialColorBlock;
                }
                break;
            case "NoButton":
                if (GameVariables.playTutorial)
                {
                    cb = initialColorBlock;
                }
                else
                {
                    cb = selectedColorBlock;
                }
                break;
            case "ContinueButton":
                if (FindObjectOfType<PlaySoundOnClick>().isUnavailable)
                {
                    cb = unavailableColorBlock;
                }
                else
                {
                    cb = initialColorBlock;
                }
                break;
        }
    }
}
