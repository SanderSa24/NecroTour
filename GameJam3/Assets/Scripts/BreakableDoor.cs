using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BreakableDoor : MonoBehaviour {


	public int doorHealth;
    public int maxDoorHealth;    
    public int repairAmount;
    public int healthTreshold1;
    public int healthTreshold2;
    public int healthTreshold3;
    public float repairTime, nRepairTime;

    public int damageAmount;
    public float damageTime, nDamageTime;

    int repairWFS = 2;


    //sprite variables 
    public Sprite spriteDoor;
	public Sprite spriteDoorHalfBroken;
	public Sprite spriteDoorBroken;

    public GameObject childBoxCollider;
    private bool colliderActive;
    private bool doorOpen;
    public Vector3 newRotation;
    public Vector3 oldRotation;

	private SpriteRenderer spriteRenderer;

	
    /*
	void RepairDoor(){
	// change the sprite of the door and repair it. 
		doorHealth +=1;
		if (spriteRenderer.sprite == spriteDoorBroken) {
			spriteRenderer.sprite = spriteDoorHalfBroken;
		} else if (spriteRenderer.sprite == spriteDoorHalfBroken) {
			spriteRenderer.sprite = spriteDoor;
		} else if (spriteRenderer.sprite == spriteDoor) {
			spriteRenderer.sprite = spriteDoorBroken;
		}
        
	}
    */
    

	// Use this for initialization
	void Start () {
        repairTime = nRepairTime;
        damageTime = nDamageTime;
        spriteRenderer = GetComponent<SpriteRenderer> ();

		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = spriteDoorBroken;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        
        if (colliderActive)
        {
            childBoxCollider.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (!colliderActive)
        {
            childBoxCollider.GetComponent<BoxCollider2D>().enabled = false;
        }

        
        if (doorHealth > maxDoorHealth)
        {
            doorHealth = maxDoorHealth;
        }
        else if (doorHealth <= 0)
        {
            doorHealth = 0;
            colliderActive = false;
        }
        else if (doorHealth >= healthTreshold1 && !doorOpen)
        {
            colliderActive = true;
        }


        if (doorOpen)
        {
            if (doorHealth > healthTreshold1)
            {
                gameObject.transform.eulerAngles = newRotation;
                colliderActive = false;

            }
        }
        else if (!doorOpen)
        {
            if (doorHealth > healthTreshold1)
            {
                gameObject.transform.eulerAngles = oldRotation;
                colliderActive = true;


            }
        }
        
        

        //DoorHealth 
        if (doorHealth <= healthTreshold1)
        {
            spriteRenderer.sprite = spriteDoorBroken;
        }
        else if (doorHealth <= healthTreshold2)
        {
            spriteRenderer.sprite = spriteDoorHalfBroken;
        }
        else if (doorHealth <= healthTreshold3)
        {
            spriteRenderer.sprite = spriteDoor;
        }

	}

    void OnTriggerStay2D(Collider2D colider)
    {

        if (colider.gameObject.tag == "Player")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                repairTime -= Time.deltaTime;
                Repair();
                // RepairDoor();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                // open door
                if (!doorOpen)
                {
                    doorOpen = true;
					FindObjectOfType<AudioManager>().Play("OpenDoor");
                }
                else
                {
                    doorOpen = false;
					FindObjectOfType<AudioManager>().Play("CloseDoor");
                }
            }
        }
        if (colider.gameObject.tag == "Survivor")
        {

                // open door
                if (!doorOpen)
                {
                    doorOpen = true;
                }
               
            
        }
        if (colider.gameObject.tag == "Enemy")
        {
            damageTime -= Time.deltaTime;

            if (damageTime <= 0)
            {
                doorHealth -= damageAmount;
                damageTime = nDamageTime;
            }
            //DamageDoor();
        }
    }

    void Repair()
    {
        if (repairTime <= 0)
        {
            doorHealth += repairAmount;
            repairTime = nRepairTime;
        }
        //StartCoroutine("RepairCo");
    }

    void DamageDoor()
    {
        doorHealth -= 1;
        if (spriteRenderer.sprite == spriteDoor)
        {
            spriteRenderer.sprite = spriteDoorHalfBroken;
        }
        else if (spriteRenderer.sprite == spriteDoorHalfBroken)
        {
            spriteRenderer.sprite = spriteDoorBroken;
        }
    }

    public IEnumerator RepairCo()
    {
        // Play animation?
        yield return new WaitForSeconds(repairWFS);
    }

}
