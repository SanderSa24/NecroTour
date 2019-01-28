using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorMovement : MonoBehaviour {
    GameObject enemy, safePlace;
    Rigidbody2D rb;
    public GameObject player;
    Vector2 direction, safePlaceRange;
    float distance, distanceSafePlace;
    public float maxChaseDistance,range;
    public float speed = 20, health = 1;
   public static float ranget,rangeP;
    GameObject[] enemies;
    // Use this for initialization
    void Awake()
    {
        
        //gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        safePlace = GameObject.FindGameObjectWithTag("SafePlace");
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
      AddToArray();   
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, rangeP);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, ranget);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
       
     
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void AddToArray() {
        for (int i = 0; i < PathfindingWaypoints.pathfindingWaypoints.Length; i++)
        {
            if (PathfindingWaypoints.pathfindingWaypoints[i] == null)
            {
                PathfindingWaypoints.pathfindingWaypoints[i] = gameObject.transform;
                break;
            }
         

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box") {
            collision.gameObject.GetComponent<BreakableBox>().boxHealth -= 1;
            //collision.gameObject.GetComponent<BreakableBox>().boxHealth -= collision.gameObject.GetComponent<BreakableBox>().damageAmountMelee;

        }
    }
    void OnCollisionEnter2D(Collision2D otherObj)
    {
        foreach(GameObject enemy in enemies) {
            if (otherObj.gameObject == enemy)
            {

                health--;
            }
        }      
    }
}
