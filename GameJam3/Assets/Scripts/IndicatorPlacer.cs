using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorPlacer : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public GameObject bus;
    public GameObject busIndicator;
    public GameObject missionIndicator;
    [Header("Other variables")]
    public float range;
    public float maxOpacity;
    private List<GameObject> indicators = new List<GameObject>();
    private List<GameObject> objectives = new List<GameObject>();
    private GameObject busIndicatorInstance, missionIndicatorInstance;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bus = GameObject.FindGameObjectWithTag("Bus");
    }

    // Update is called once per frame
    void Update()
    {
        //When tab is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Indicator is made at the position of the player
            busIndicatorInstance = Instantiate(busIndicator) as GameObject;
            busIndicatorInstance.transform.parent = transform;
            busIndicatorInstance.transform.position = transform.position;

            //Searches active objectives and adds them to the list
            foreach (GameObject objective in GameObject.FindGameObjectsWithTag("Objective"))
                if (objective.activeInHierarchy == true)
                {
                    objectives.Add(objective);
                }

            int indicatorIndex = 0;

            //Mission indicator is made at the position of the player for every objective
            foreach (GameObject objective in objectives)
            {
                missionIndicatorInstance = Instantiate(missionIndicator);
                missionIndicatorInstance.GetComponent<targetObjective>().target = objective;
                missionIndicatorInstance.transform.parent = transform;
                missionIndicatorInstance.transform.position = transform.position;
                missionIndicatorInstance.name = "missionIndicator" + indicatorIndex++;
                indicators.Add(missionIndicatorInstance);
            }
        }

        //When tab is hold
        if (Input.GetKey(KeyCode.Tab)) {

            //The rotation is calculated so it rotates towards the bus
            Vector3 dir = player.transform.position - bus.transform.position;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, dir);
            busIndicatorInstance.transform.rotation = rotation;

            //Gets the position of the targets and calculates the direction to rotate to. Also checks if objective is in range
            foreach (GameObject indicator in indicators)
            {
                Vector3 indicatorDir = player.transform.position - indicator.GetComponent<targetObjective>().target.transform.position;
                Quaternion indicatoRotation = Quaternion.FromToRotation(Vector3.up, indicatorDir);
                indicator.transform.rotation = indicatoRotation;
                float distance = Vector3.Distance(player.transform.position, indicator.GetComponent<targetObjective>().target.transform.position);
                if (distance > range) indicator.SetActive(false);
                else
                {
                    //Changes the opacity according to the distance
                    indicator.SetActive(true);
                    float opacity = (range - distance)/range;
                   // Debug.Log(opacity);
                    opacity = Mathf.Lerp(0,maxOpacity, opacity);
                    //Debug.Log("real" +opacity);

                    indicator.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f,opacity);
                }
            }
        }

        //When tab is released
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Destroy(busIndicatorInstance);
            foreach(GameObject indicator in indicators)
            {
                //Debug.Log("Destroy");
                Destroy(indicator);
            }
            objectives.Clear();
            indicators.Clear();
        }


    }
}
