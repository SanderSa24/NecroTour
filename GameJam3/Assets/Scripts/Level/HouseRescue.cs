using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRescue : MonoBehaviour {
    GameObject player, cloneGrandma, houseInstance;
    public Transform positionGrandma, positionHouse;
    public GameObject civilian, House;
    SpriteRenderer spriterenderer;
    public Sprite[] civilianSprites;
    // Use this for initialization

    void Awake ()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        spriterenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
     
    }
    void ChangeSprite() {
        for (int i = 0; i < civilianSprites.Length; i++) {
            
            if (spriterenderer.sprite.name == "RescuePoint" + civilianSprites[i].name) {
                cloneGrandma.GetComponent<SpriteRenderer>().sprite = civilianSprites[i];
                Debug.Log(spriterenderer.sprite.name);
                Debug.Log("RescuePoint" + civilianSprites[i].name);
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 3;
                break;
            }
        }
       
    }
    void ChangeCivilianVariables()
    {
        switch (spriterenderer.sprite.name)
        {
            case "RescuePointhitman1":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 15f;
                break;
            case "RescuePointmanBlue":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 15f;
                break;
            case "RescuePointmanBrown":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 15f;
                break;
            case "RescuePointmanOld":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 1f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 9f;
                break;
            case "RescuePointmanRed":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 15f;
                break;
            case "RescuePointsoldier1":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2.5f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 21f;
                break;
            case "RescuePointsoldier2":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2.5f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 21f;
                break;
            case "RescuePointsurvivor1":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health =15f;
                break;
            case "RescuePointwomanGreen":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 2f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 15f;
                break;
            case "RescuePointwomanOld":
                cloneGrandma.GetComponent<CivilianPathfinding>().speed = 1f;
                cloneGrandma.GetComponent<CivilianMovement>().health = 9f;
                break;
            default:
                break;

        }
    } 
    void OnCollisionStay2D(Collision2D otherObj)
    {
        if (otherObj.gameObject == player)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("create");
                cloneGrandma = Instantiate(civilian, positionGrandma);
                ChangeSprite();
                ChangeCivilianVariables();
                Debug.Log("changed");    
                if (cloneGrandma != null)
                {
                    cloneGrandma.SetActive(true);
                }
                GameObject parent = this.transform.parent.gameObject;
                parent.transform.GetChild(2).gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
