using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour {
    Button button;
    public bool isUnavailable;
	// Use this for initialization
	void Awake () {
        button = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        button.onClick.AddListener(() => { PlaySound(); });

        switch (name)
        {
            case "ContinueButton":
                if (!GameVariables.startedGame)
                {
                    isUnavailable = true;
                }
                break;
        }
    }

    void PlaySound()
    {
        if (isUnavailable)
        {
            FindObjectOfType<AudioManager>().Play("ButtonUnavailable");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("ButtonSelect");
        }
    }
}
