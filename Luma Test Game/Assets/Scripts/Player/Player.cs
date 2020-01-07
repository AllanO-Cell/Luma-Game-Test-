using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStats playerStats;
    public int currentHealth;
    private int storedHealth;
    HUDSystem m_hudSystem;

    public GameObject ScoreUI;


    /// <summary>
    /// setting the players current health to the starting health of the player
    /// We cache the Scripts needed here 
    /// </summary>
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        currentHealth = playerStats.playerStartingHealth;
        m_hudSystem = FindObjectOfType<HUDSystem>();
        storedHealth = currentHealth;

    }



    /// <summary>
    /// Damage to be taken when attacked by the enemy
    /// </summary>
    /// <param name="dmgAmount"></param> amount of damage to be taken and removed from the health - parsed by the enimes DoDamage function
    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        m_hudSystem.UpdateHud();
        if (currentHealth <= 0)
            Death();
    }

    /// <summary>
    /// refreshes the health points when called at the end of the wave/Level
    /// </summary>
    public void RefreshHealth()
    {
        currentHealth = storedHealth;
        m_hudSystem.UpdateHud();
    }


    /// <summary>
    /// We update our struct with our score we got before we died
    /// We find the death screen and we activate it and we set our player to false
    /// </summary>
    private void Death()
    {
        ScoreUI.SetActive(true);

        GameManager mngr = FindObjectOfType<GameManager>();
        Scoreboard score = FindObjectOfType<Scoreboard>();
        score.m_playerScore = mngr.playerScore;

        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }




}
