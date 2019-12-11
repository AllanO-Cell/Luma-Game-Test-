using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy_Stats enemyStats;
    public PlayerStats playerStats;

    int currentHealth; // the current health of the enemy



    private void OnEnable()
    {
        // gather all stats from the scriptable object
        currentHealth = enemyStats.startingHealth;
    }


    /// <summary>
    /// <see cref="TakeDamage(int)"/> this is to calulate how much damage is being done to the enemy(stats to increase with pick ups)
    /// Calls the death function which pretty much does exactly what is says (kills the player) this will remove the AI from the game and calculate score
    /// <see cref="playerStats"/> this is getting the amount of damage the player will do to the enemy
    /// </summary>
    /// 

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= playerStats.playerDamage;
        if (currentHealth <= 0)
            Death();
    }



    private void Death()
    {
        //to do when the player would need to die
    }
}
