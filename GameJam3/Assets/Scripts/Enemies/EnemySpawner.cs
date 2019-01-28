using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
   
    GameObject[] spawnpoint;
    public GameObject enemy;
    GameObject cloneOfEnemy;
    GameObject[] enemies;
    int spawnTimer, timeLimit = 90,spawn, multiplier=1;
    public int spawnInterval, divisor, zombieCap = 5 ;
    public bool killmode, zombielimit;
    public int zombiecounter,tl;
	// Use this for initialization
	void Awake () {
        spawnTimer = 0;
        spawnpoint = GameObject.FindGameObjectsWithTag("Spawnpoint");
        timeLimit /= (GameVariables.difficultyLevel * GameVariables.hardModeMultiplier);
	}

    // Update is called once per frame
    void FixedUpdate() {
        tl = timeLimit;
        if (Timer.timeRunOut)
            multiplier = 2;
        zombieCap = 7* GameVariables.difficultyLevel * multiplier * GameVariables.hardModeMultiplier;
        killmode = EnemiesKilled.KillMode;
        zombielimit = EnemiesKilled.zombieLimit;
        zombiecounter = EnemiesKilled.zombieCounter;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawnTimer++;
        
        if (spawnTimer % (60 * timeLimit)==0 && spawnInterval>1) {
            
            spawnInterval /= divisor;
        }
        if(spawnTimer % (60 * spawnInterval) == 0)
        {

            spawn = (int)Random.Range(0, spawnpoint.Length);
            if (!EnemiesKilled.zombieLimit && (zombieCap >= enemies.Length + 1))
            {
                cloneOfEnemy = Instantiate(enemy, spawnpoint[spawn].transform.position, enemy.transform.rotation);
                if (EnemiesKilled.KillMode)
                {
                    EnemiesKilled.zombieCounter++;
                }
            }    
        }
        if (cloneOfEnemy != null)
        {
            cloneOfEnemy.SetActive(true);
        }
        
    }
}
