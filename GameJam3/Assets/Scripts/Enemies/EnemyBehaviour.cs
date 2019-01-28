using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;
    public GameObject Blood;
    public bool tutorialZombie = false;
    //pickup variables
    public GameObject healthPickUp;
    public GameObject pistolAmmoPickUp;
    public GameObject shotgunAmmoPickUp;
    public GameObject machinegunAmmoPickUp;


    GameObject player, civilian;
    Vector2 direction, civilianDirection;
    float distance, distanceCivilian;
    public int health = 2;

    //public float minChaseDistance;
    //public float speed;
    CivilianMovement civilianMovement;
    Quaternion rot;
    GameObject[] bullets;
    GameObject[] civilians;
    public static float ranget, chaseRange;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        distanceCivilian = 1000000;
        ranget = 100;

    }
    private void Start()
    {
        //gameObject.SetActive(false);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, ranget);
        //Gizmos.color = Color.blue;
        //Gizmos.DrawSphere(transform.position, chaseRange);
    }



    private void FixedUpdate()
    {
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        civilians = GameObject.FindGameObjectsWithTag("civilian");

        if (health <= 0)
        {
            //random pickup drops
            RandomPickUp();
            if (tutorialZombie) TutorialStates.nZombies--;


            Instantiate(Blood, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("ZombieDead");

            if (EnemiesKilled.KillMode && FindObjectOfType<EnemiesKilled>() != null)
            {
                FindObjectOfType<EnemiesKilled>().EnemyKilled();
            }
        }
    }


	//method die zorgt voor een random drop van pickups. 
    void RandomPickUp()
    {

        int random = Random.Range(0, 100);


        //smerige code voor de pick up drops.


        if (random <= 10)
        {
            Instantiate(healthPickUp, transform.position, transform.rotation);
        }
        else if (random <= 15)
        {
            Instantiate(shotgunAmmoPickUp, transform.position, transform.rotation);
        }
        else if (random <= 20)
        {
            Instantiate(machinegunAmmoPickUp, transform.position, transform.rotation);
        }
        else if (random <= 30)
        {
            Instantiate(pistolAmmoPickUp, transform.position, transform.rotation);
        }



        /*
            switch (randomNumber) {
                case randomNumber < 10:
                    Instantiate (healthPickUp, transform.position, transform.rotation);
                    break;

                case randomNumber < 20:
                    Instantiate (shotgunAmmoPickUp, transform.position, transform.rotation);
                    break;
                case randomNumber <30:
                    Instantiate (machinegunAmmoPickUp, transform.position, transform.rotation);
                    break;
                case randomNumber <40:
                    Instantiate (pistolAmmoPickUp, transform.position, transform.rotation);
                    break;

                default:
                    break;
            }*/

    }

    void OnCollisionEnter2D(Collision2D otherObj)
    {


    }
}
