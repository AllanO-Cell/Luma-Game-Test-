using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyStatsSO
{

    PlayerStats playerStats;

    public int enemyCurrentHealth;
    

    //gather stats from the scriptable object
    private void OnEnable()
    {
        enemyCurrentHealth = enemyStartingHealth;

        //if (!playerStats) playerStats = FindObjectOfType<PlayerStats>();
            
    }




    void DoDamage()
    {
        // do damage to the player
        // temp for damage dealing
        throw new NotImplementedException();
    }




    /// <summary>
    /// <see cref="TakeDamage(int)"/> this is to calculate how much of the damage is being done to the enemies health
    /// Calls the death function once the health is at or lower than 0
    /// </summary>
    /// <param name="damageAmount"></param> Amount to damage the enemy(Based off the player stats) - the int value is determined in the "FireGun" function
    public void TakeDamage(int damageAmount)
    {
        //damageAmount = playerStats.playerAttackDamage;
        enemyCurrentHealth -= playerStats.playerAttackDamage;
        if (enemyCurrentHealth <= 0)
            Death();
    }

    private void Death()
    {
        throw new NotImplementedException();
    }
}
