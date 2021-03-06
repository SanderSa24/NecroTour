using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BreakableBox : MonoBehaviour
{

    public GameObject pickUp;
    public int boxHealth;
    public int maxBoxHealth;

    public int healthTreshold1;
    public int healthTreshold2;

    public int damageAmountEnemy, damageAmountBullet, damageAmountMelee;
    public float damageTime, nDamageTime;
   
    //pickup variables
    public GameObject healthPickUp;
    public GameObject pistolAmmoPickUp;
    public GameObject shotgunAmmoPickUp;
    public GameObject machinegunAmmoPickUp;

    //sprite variables 
    public Sprite spriteBox;
    public Sprite spriteBoxHalfBroken;
    public Sprite spriteBoxAlmostBroken;
    public Sprite spriteBoxBroken;
    bool collide = true;
    Collider2D c;
    public SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {

        boxHealth = maxBoxHealth;
        damageTime = nDamageTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
        c = GetComponent<Collider2D>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = spriteBoxBroken;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (boxHealth > maxBoxHealth)
        {
            boxHealth = maxBoxHealth;
        }

        else if (boxHealth <= 0)
        {
            boxHealth = 0;

        }

        //boxHealth 
        if (boxHealth > healthTreshold1)
        {
            spriteRenderer.sprite = spriteBox;
        }
        else if (boxHealth > healthTreshold2)
        {
            spriteRenderer.sprite = spriteBoxHalfBroken;
        }
        else if (boxHealth > 0)
        {
            spriteRenderer.sprite = spriteBoxAlmostBroken;
        }
        else if (boxHealth <= 0)
        {
            spriteRenderer.sprite = spriteBoxBroken;
            if (collide)
            {
                c.enabled = !c.enabled;
                collide = false;
                RandomPickUp();
                if (pickUp !=null)
                Instantiate(pickUp, transform.position, transform.rotation);
            }
        }



    }
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

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            damageTime -= Time.deltaTime;
            if (damageTime <= 0)
            {
                boxHealth -= damageAmountEnemy;
                damageTime = nDamageTime;
            }

        }
    }
}
