using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool lvlInProgress;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTime; // will change every level
    public Transform[] spawnLocations;
    List<GameObject> registeredEnemies = new List<GameObject>();

    int enemyAmount = 5; //initial amount of enemies will change as levels go higher

    private void Start()
    {
       InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
       
    }


    private void Update()
    {
        if(registeredEnemies.Count == enemyAmount)
        {
            lvlInProgress = false;
            CancelInvoke();
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
}

