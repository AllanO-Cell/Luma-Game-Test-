using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Image healthBar;

    public EnemyStatsSO enemyStats;
    public int enemyCurrentHealth;
    bool isRanged;
    Transform target;
    NavMeshAgent agent;

    // Array of items to be dropped
    [Header("Dropable items")]
    public GameObject[] itemDrop;
    float dropRate = 0.25f;
    public Transform dropSpawnLocation;

    [Header("Attacking Parameters")]
    public GameObject EnemyBullets;
    public Transform bulletSpawn;
    public float bulletSpeed;
    float shootRateTimeStamp;

    
    /// <summary>
    /// gather stats from the scriptable object
    /// Using the Unity Navmesh component, from when the enemy spawns the enemy will run towards the player
    /// </summary>
    private void OnEnable()
    {
        enemyCurrentHealth = enemyStats.enemyStartingHealth;
        isRanged = enemyStats.isRanged;

        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = enemyStats.enemyMoveSpeed;

       
    }


    /// <summary>
    /// Sets the navmesh agent to follow after the player
    /// Checks if the enemy is range. If the enemy is ranged is moving the enemy will start shooting
    /// </summary>
    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        else return;

        if(isRanged == true)
        {
                if(Time.time > shootRateTimeStamp)
                {
                    GameObject bullet = Instantiate(EnemyBullets, bulletSpawn.position, bulletSpawn.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
                    shootRateTimeStamp = Time.time + enemyStats.enemyAttackSpeed;
                }

        }
    }
    



    /// <summary>
    /// <see cref="TakeDamage(int)"/> this is to calculate how much of the damage is being done to the enemies health
    /// Calls the death function once the health is at or lower than 0
    /// Updates the enemy health bar
    /// </summary>
    /// <param name="damageAmount"></param> Amount to damage the enemy(Based off the player stats) - the int value is determined in the "FireGun" function
    public void TakeDamage(int damageAmount)
    {

        enemyCurrentHealth -= damageAmount;
        healthBar.fillAmount = Map(enemyCurrentHealth, 0, 100, 0, 1);
        if (enemyCurrentHealth <= 0)
            Death();
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }



    /// <summary>
    ///Enemy death, This destorys the current instance of the game object and removes it from the list
    ///the death also adds to the player score and adds to the experience system using the amount of xp the enemies give from the scritable object
    /// </summary>
    public void Death()
    {
        var gameManager = FindObjectOfType<GameManager>();
        var playerStats = FindObjectOfType<PlayerStats>();
        playerStats.AddExperience(enemyStats.DeathXp);
        DropItem();
        if (gameManager != null)
        {
            gameManager.registeredEnemies.Remove(gameObject);
            Destroy(gameObject);
        }

    }


    /// <summary>
    ///  Needs testing
    /// </summary>
    void DropItem()
    {
        if (Random.Range(0f, 1f) <= dropRate)
        {
            int indexToDrop = Random.Range(0, itemDrop.Length);
            Instantiate(itemDrop[indexToDrop], dropSpawnLocation.transform.position, dropSpawnLocation.transform.rotation);
        }
    }
}
