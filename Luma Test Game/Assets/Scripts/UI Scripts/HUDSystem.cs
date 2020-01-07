using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Since this is a simple UI system it will not be necesaary complicate it and rather just update the values displayed as they show from the player stats
/// </summary>
public class HUDSystem : MonoBehaviour
{
    public Image currentHealth;
    public Image levelUpBar;
    public Text currentLevel;
    public Text gameTimerText;
    public float gameTimer;

    PlayerStats stats;
    Player player;
    GameManager manager;

    /// <summary>
    /// caching the stats on awake
    /// </summary>
    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<Player>();
        manager = FindObjectOfType<GameManager>();
        levelUpBar.fillAmount = 0;
    }

    /// <summary>
    /// Our time counter which is also used for the players score
    /// we change the formatting to be more readable here to update the UI text and we set the playerscore to the time elapsed
    /// </summary>
    private void Update()
    {
        gameTimer += Time.deltaTime;
        int sec = (int)(gameTimer % 60);
        int min = (int)(gameTimer / 60) %60 ;
        int hours = (int)(gameTimer /3600) % 24;

        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, min, sec);
        gameTimerText.text = timerString;
        manager.playerScore = (int)gameTimer;

    }


    /// <summary>
    /// Updates the HUD (Health, Level and experience) these are all based and updated when there has been changes to any of the players variables
    /// </summary>
    public void UpdateHud()
    {
        levelUpBar.fillAmount = Map(stats.experience, 0, 100, 0, 1);
        currentLevel.text = stats.level.ToString();
        currentHealth.fillAmount = Map(player.currentHealth, 0, 100, 0, 1); 
    }

    public float Map(float value, float inMin, float inMax, float outMin, float outmax)
    {
        return (value - inMin) * (outmax - outMin) / (inMax - inMin) + outMin;
    }
}
