using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject lvlCanvas;
    public EnemyStatsSO[] statUpdate;

    public bool lvlInProgress;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTime; // will change every level
    public Transform[] spawnLocations;
    public List<GameObject> registeredEnemies = new List<GameObject>();

    int enemyAmount = 5; //initial amount of enemies will change as levels go higher

    public int playerScore;


    /// <summary>
    /// repeat invokes the spawn function based on the time
    /// </summary>
    private void Start()
    {
       InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
       
    }



    private void Update()
    {
        if(registeredEnemies.Count == enemyAmount)
        {
            CancelInvoke();
        }

        if(registeredEnemies.Count == 0)
        {
            lvlInProgress = false;
            RoundOver();
        }
    }


    /// <summary>
    /// Spawn function. Time will be set and increased after every level completion. Amount of enemies to spawn will be determined by the "enemyAmount" value which will update after every level
    /// checking to see if the level has ended if it hasnt carry on spawning if it has stop the repeating invoke
    /// </summary>
    void SpawnEnemies()
    {
        if (lvlInProgress = false)
        {
            CancelInvoke();
            return;
        }


        lvlInProgress = true;
        int spawnPointIndex = Random.Range(0, spawnLocations.Length);
        GameObject newGo = Instantiate(enemies[Random.RandomRange(0, enemies.Count)], spawnLocations[spawnPointIndex].position, spawnLocations[spawnPointIndex].rotation); 
        registeredEnemies.Add(newGo);

    }

    // prepares the next round of enimies with upgrades to their stats
    void RoundOver()
    {

        lvlCanvas.SetActive(true);
        while(lvlInProgress = false)
        {
            
            foreach (EnemyStatsSO stat in statUpdate)
            {
                stat.enemyStartingHealth += 10;
                stat.enemyAttackSpeed += 10;
                stat.enemyAttackDamage += 10;
                stat.enemyMoveSpeed += 10;

            }
            // adding a random amount of enemies after the first level based on the current amount 
            int additionalEnemies = Random.Range(enemyAmount, enemyAmount += 3);
            enemyAmount =+ additionalEnemies;
            break;
        }
    }

    void StartNextRound()
    {
        // start the next round pretty much need to repeatinvoke the
    }

}

