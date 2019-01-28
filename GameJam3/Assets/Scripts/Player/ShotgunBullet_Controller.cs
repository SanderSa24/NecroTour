using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet_Controller : MonoBehaviour {

    public int shotgunDamage;

    //awake starts as soon as object comes to life. 
    void Awake() {
    }

    // Update is called once per frame
    void FixedUpdate() {
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //Actions based on what the other objects are
        switch (otherObj.gameObject.tag)
        {
            case "Enemy":
                {
                    otherObj.gameObject.GetComponent<EnemyBehaviour>().health -= shotgunDamage;
                    break;
                }
            case "civilian":
                {
                    otherObj.gameObject.GetComponent<CivilianMovement>().health -= shotgunDamage;
                    break;
                }
            case "Survivor":
                {
                    otherObj.gameObject.GetComponent<SurvivorMovement>().health -= shotgunDamage;
                    break;
                }
            case "Box":
                {
                    otherObj.gameObject.GetComponent<BreakableBox>().boxHealth -= otherObj.gameObject.GetComponent<BreakableBox>().damageAmountBullet;
                    break;
                }
            default:
                break;
        }
    }
}

