using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivHealth : MonoBehaviour {
    float health, maxhealth;
    GameObject Healthbar;

	// Use this for initialization
	void Start () {
        health = GetComponentInParent<CivilianMovement>().health;
        maxhealth = health;

        Healthbar = transform.Find("health").gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        Transform ParentT = GetComponentInParent<Transform>();
        transform.eulerAngles = new Vector3(-ParentT.rotation.x, -ParentT.rotation.y, -ParentT.rotation.z);
        


        health = GetComponentInParent<CivilianMovement>().health;
        float healthScale = 100 / maxhealth * health / 100;
        Healthbar.transform.localScale = new Vector3(healthScale, 1, 1);
	}
}
