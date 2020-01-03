using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    PlayerStats playerStats;
    public int currentHealth;
    HUDSystem m_hudSystem;

    // setting the players current health to the starting health of the player
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        currentHealth = playerStats.playerStartingHealth;
        m_hudSystem = FindObjectOfType<HUDSystem>();
    }



    /// <summary>
    /// Damage to be taken when attacked by the enemy
    /// </summary>
    /// <param name="dmgAmount"></param> amount of damage to be taken and removed from the health - parsed by the enimes DoDamage function
    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        var healthUpdate = m_hudSystem;
        healthUpdate.UpdateHud();
        if (currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        throw new NotImplementedException();
    }
}
