using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunScript : MonoBehaviour {

    public static bool timeRunOut = false;
    public float maxTime=10;
    public float interval = 2;
    public float  t, m= 2;
    public static float timeLeft;
    float time;
    Text timeText;

    // Use this for initialization
    void Start()
    {
        timeText = GetComponent<Text>();
        timeLeft = maxTime* m;
        t = maxTime ;
    }

    void Update()
    {
      
    }

    void FixedUpdate()
    {
        if (timeLeft >= 0 && Timer.timeLeft<=0)
        {
        time = Time.deltaTime;
        timeLeft -= m *time;
        t = Mathf.Round(timeLeft);
       
            if (t % (interval) == 0)
            {

                timeText.color = Color.red;
                timeText.text = "Danger!";

            }
            else
            {
                timeText.text = " ";
            }

        }
        else
        {
            timeText.text = " ";
        }

    }


}
