using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{

    bool meleeAttack;
    Vector3 attackDir;
    public int meleeDamage;
    public float knockbackForce;
    public float damageTime, nDamageTime;
    // Use this for initialization
    void Start()
    {
        damageTime = nDamageTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            meleeAttack = true;
        }

    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            damageTime -= Time.deltaTime;
            attackDir = other.gameObject.transform.position - gameObject.transform.position;
            if (meleeAttack && damageTime <= 0)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(attackDir.normalized * knockbackForce, ForceMode2D.Force);
                other.gameObject.GetComponent<EnemyBehaviour>().health -= meleeDamage;

                FindObjectOfType<AudioManager>().Play("PlayerMelee");
                damageTime = nDamageTime;
            }

            meleeAttack = false;
        }
        if (other.gameObject.CompareTag("Box"))
        {
            damageTime -= Time.deltaTime;
            attackDir = other.gameObject.transform.position - gameObject.transform.position;
            if (meleeAttack && damageTime <= 0)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(attackDir.normalized * knockbackForce, ForceMode2D.Force);
                other.gameObject.GetComponent<BreakableBox>().boxHealth -= other.gameObject.GetComponent<BreakableBox>().damageAmountMelee;
                meleeAttack = false;

                FindObjectOfType<AudioManager>().Play("PlayerMelee");
                damageTime = nDamageTime;
            }

        }


    }

}
