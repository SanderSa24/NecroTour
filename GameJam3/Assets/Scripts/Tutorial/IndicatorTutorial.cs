using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorTutorial : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public Transform waypoint;
    public GameObject tutorialIndicator;
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
    }

    // Update is called once per frame
    void Update()
    {
        waypoint = FindObjectOfType<SurvivorPathfinding>().target;
        if(busIndicatorInstance!=null)
        Destroy(busIndicatorInstance);
        //Indicator is made at the position of the player
        busIndicatorInstance = Instantiate(tutorialIndicator) as GameObject;
            busIndicatorInstance.transform.parent = transform;
            busIndicatorInstance.transform.position = transform.position;

            //The rotation is calculated so it rotates towards the bus
            Vector3 dir = player.transform.position - waypoint.position;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, dir);
            busIndicatorInstance.transform.rotation = rotation;
        float distance = Vector3.Distance(player.transform.position, waypoint.position);
        if (distance < range) busIndicatorInstance.SetActive(false);
        else
        {
            //Changes the opacity according to the distance
            busIndicatorInstance.SetActive(true);
            float opacity = ((range - distance) / range)*-1;
            // Debug.Log(opacity);
            opacity = Mathf.Lerp(0, maxOpacity, opacity);
            //Debug.Log("real" +opacity);

            busIndicatorInstance.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, opacity);
        }
    }
}
