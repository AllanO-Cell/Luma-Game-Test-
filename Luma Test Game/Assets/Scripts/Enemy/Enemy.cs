using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;
    public EnemyStatsSO enemyStats;
    public int enemyCurrentHealth;
    public int damage;
    

    //gather stats from the scriptable object
    private void OnEnable()
    {
        enemyCurrentHealth = enemyStats.enemyStartingHealth;
        damage = enemyStats.enemyAttackDamage;
    }




    void DoDamage()
    {
        // do damage to the player
        // temp for damage dealing
        var playerHealth = GetComponent<Player>();
        if (playerHealth != null)
            playerHealth.TakeDamage(damage);
    }




    /// <summary>
    /// <see cref="TakeDamage(int)"/> this is to calculate how much of the damage is being done to the enemies health
    /// Calls the death function once the health is at or lower than 0
    /// </summary>
    /// <param name="damageAmount"></param> Amount to damage the enemy(Based off the player stats) - the int value is determined in the "FireGun" function
    public void TakeDamage(int damageAmount)
    {
        
        enemyCurrentHealth -= damageAmount;
        if (enemyCurrentHealth <= 0)
            Death();
    }


    /// <summary>
    ///Enemy death, This destorys the current instance of the game object and removes it from the list
    /// </summary>
    public void Death()
    {  
        var gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.registeredEnemies.Remove(gameObject);
            Destroy(gameObject);
        }

        gameManager.playerScore++;
    }
}
